using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using UniGate.Core.Entities;
using UniGate.Infrastructure;
using UniGate.Api.DTOs;
using UniGate.Shared.DTOs;

namespace UniGate.Api.Controllers
{
    [ApiController]
    [Route("api/admin/majors")]
    public class MajorAdminController : ControllerBase
    {
        private readonly AppDbContext _db;

        public MajorAdminController(AppDbContext db)
        {
            _db = db;
        }

        // ===========================================
        // GET: api/admin/majors?schoolId=1
        // (schoolId = UniversityID trong DB mới)
        // Output giống cũ: Id, MajorCode, Name, SchoolId, SchoolName, Combos
        // ===========================================
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int schoolId)
        {
            var raw = await (
        from a in _db.Admissions
        join m in _db.Majors on a.MajorID equals m.MajorID
        join g in _db.SubjectGroups on a.GroupID equals g.GroupID
        join u in _db.Universities on a.UniversityID equals u.UniversityID
        where a.UniversityID == schoolId
        select new
        {
            a.Year,
            a.MinScore,
            MajorID = m.MajorID,
            m.MajorCode,
            MajorName = m.MajorName,
            m.Description,
            u.UniversityID,
            u.UniversityName,
            Combo = g.GroupName
        }
    ).ToListAsync(); // 🔥 CHỐT: ToListAsync ở đây

            // 2️⃣ XỬ LÝ GROUP + LOGIC Ở RAM
            var result = raw
                .GroupBy(x => new
                {
                    x.MajorID,
                    x.MajorCode,
                    x.MajorName,
                    x.Description,
                    x.UniversityID,
                    x.UniversityName
                })
                .Select(grp =>
                {
                    var latestYear = grp.Max(x => x.Year);

                    return new MajorAdminDto
                    {
                        Id = grp.Key.MajorID,
                        MajorCode = grp.Key.MajorCode,
                        Name = grp.Key.MajorName,
                        Description = grp.Key.Description,

                        SchoolId = grp.Key.UniversityID,
                        SchoolName = grp.Key.UniversityName,

                        Year = latestYear,
                        CutoffScore = grp
                            .Where(x => x.Year == latestYear)
                            .Max(x => x.MinScore),

                        Combos = grp
                            .Where(x => x.Year == latestYear)
                            .Select(x => x.Combo)
                            .Distinct()
                            .ToList()
                    };
                })
                 .OrderBy(x => x.Id)
                .ToList();

            return Ok(result);
        }

        // ===========================================
        // GET: api/admin/majors/{id}?schoolId=1
        // Output giống cũ
        // ===========================================
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id, [FromQuery] int? schoolId)
        {
            var m = await _db.Majors
                .AsNoTracking()
                .Include(x => x.MajorGroups)
                    .ThenInclude(mg => mg.SubjectGroup)
                .FirstOrDefaultAsync(x => x.MajorID == id);

            if (m == null) return NotFound("Không tìm thấy ngành.");

            var schoolName =
                (from a in _db.Admissions
                 join u in _db.Universities on a.UniversityID equals u.UniversityID
                 where a.MajorID == m.MajorID
                       && (!schoolId.HasValue || a.UniversityID == schoolId.Value)
                 select u.UniversityName)
                .FirstOrDefault();

            return Ok(new
            {
                Id = m.MajorID,
                MajorCode = m.MajorCode,
                Name = m.MajorName,
                SchoolId = schoolId,
                SchoolName = schoolName,
                Combos = m.MajorGroups
                    .Select(x => x.SubjectGroup.GroupName)
                    .Distinct()
                    .ToList()
            });
        }

        // ===========================================
        // POST: api/admin/majors
        // NOTE: DB mới không có SchoolId trong Majors
        // nên schoolId chỉ dùng để filter hiển thị, không lưu trực tiếp vào Major
        // ===========================================
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MajorUpsertDto req)
        {
            if (string.IsNullOrWhiteSpace(req.Name))
                return BadRequest("Tên ngành không được để trống");

            // ✅ CHECK TRÙNG MajorCode
            if (!string.IsNullOrWhiteSpace(req.MajorCode))
            {
                var exists = await _db.Majors
                    .AnyAsync(x => x.MajorCode == req.MajorCode);

                if (exists)
                    return BadRequest("Mã ngành đã tồn tại");
            }

            var major = new Major
            {
                MajorCode = req.MajorCode,
                MajorName = req.Name,
                Description = req.Description
            };

            _db.Majors.Add(major);
            await _db.SaveChangesAsync();

            return Ok(major.MajorID);
        }

        // ===========================================
        // PUT: api/admin/majors/{id}
        // ===========================================
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] MajorUpsertDto req)
        {
            if (id != req.Id) return BadRequest();

            var major = await _db.Majors
                .Include(x => x.MajorGroups)
                .FirstOrDefaultAsync(x => x.MajorID == id);

            if (major == null) return NotFound();

            major.MajorCode = req.MajorCode;
            major.MajorName = req.Name;
            major.Description = req.Description;

            _db.MajorGroups.RemoveRange(major.MajorGroups);

            var oldAdmissions = _db.Admissions
                .Where(a => a.MajorID == id && a.UniversityID == req.UniversityID && a.Year == req.Year);
            _db.Admissions.RemoveRange(oldAdmissions);

            foreach (var gid in req.GroupIds)
            {
                _db.MajorGroups.Add(new MajorGroup
                {
                    MajorID = id,
                    GroupID = gid,
                    ExamYear = req.Year
                });

                _db.Admissions.Add(new Admission
                {
                    UniversityID = req.UniversityID,
                    MajorID = id,
                    GroupID = gid,
                    Year = req.Year,
                    MinScore = req.MinScore
                });
            }

            await _db.SaveChangesAsync();
            return Ok();
        }

        // ===========================================
        // DELETE: api/admin/majors/{id}
        // ===========================================
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var admissions = _db.Admissions.Where(a => a.MajorID == id);
            _db.Admissions.RemoveRange(admissions);

            var groups = _db.MajorGroups.Where(g => g.MajorID == id);
            _db.MajorGroups.RemoveRange(groups);

            var major = await _db.Majors.FindAsync(id);
            if (major == null) return NotFound();

            _db.Majors.Remove(major);

            await _db.SaveChangesAsync();
            return Ok();
        }



    }


}
