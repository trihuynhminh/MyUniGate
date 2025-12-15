using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniGate.Infrastructure;
using UniGate.Core.Entities;
using UniGate.Api.DTOs;

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
        public async Task<IActionResult> GetAll([FromQuery] int? schoolId)
        {
            var query = _db.Majors
                .AsNoTracking()
                .Include(m => m.MajorGroups)
                    .ThenInclude(mg => mg.SubjectGroup)
                .AsQueryable();

            // Lọc theo "trường" (University) thông qua bảng Admissions
            if (schoolId.HasValue)
            {
                query = query.Where(m =>
                    _db.Admissions.Any(a => a.MajorID == m.MajorID && a.UniversityID == schoolId.Value));
            }

            var result = await query
                .Select(m => new
                {
                    Id = m.MajorID,
                    MajorCode = m.MajorCode,
                    Name = m.MajorName,

                    // giữ tên như cũ
                    SchoolId = schoolId,

                    // lấy tên trường qua Admissions -> Universities (nếu không truyền schoolId thì có thể null/đại diện)
                    SchoolName =
                        (from a in _db.Admissions
                         join u in _db.Universities on a.UniversityID equals u.UniversityID
                         where a.MajorID == m.MajorID
                               && (!schoolId.HasValue || a.UniversityID == schoolId.Value)
                         select u.UniversityName)
                        .FirstOrDefault(),

                    // Combos = danh sách mã tổ hợp (A00, D01...) từ SubjectGroups
                    Combos = m.MajorGroups
                        .Select(x => x.SubjectGroup.GroupName)
                        .Distinct()
                        .ToList()
                })
                .ToListAsync();

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
        public async Task<IActionResult> Create([FromBody] MajorCreateRequest req)
        {
            var major = new Major
            {
                MajorCode = req.MajorCode,
                MajorName = req.Name,
                Description = req.Description
            };

            _db.Majors.Add(major);
            await _db.SaveChangesAsync();

            // Lưu "combo" theo DB mới = insert MajorGroups
            foreach (var groupId in req.GroupIds.Distinct())
            {
                _db.MajorGroups.Add(new MajorGroup
                {
                    MajorID = major.MajorID,
                    GroupID = groupId,
                    ExamYear = req.ExamYear
                });
            }

            await _db.SaveChangesAsync();
            return Ok("Thêm ngành thành công!");
        }

        // ===========================================
        // PUT: api/admin/majors/{id}
        // ===========================================
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] MajorUpdateRequest req)
        {
            if (id != req.Id)
                return BadRequest("Id không khớp.");

            var m = await _db.Majors
                .Include(x => x.MajorGroups)
                .FirstOrDefaultAsync(x => x.MajorID == id);

            if (m == null) return NotFound("Không tìm thấy ngành.");

            m.MajorCode = req.MajorCode;
            m.MajorName = req.Name;
            m.Description = req.Description;

            // Xóa group cũ
            _db.MajorGroups.RemoveRange(m.MajorGroups);

            // Thêm group mới
            foreach (var groupId in req.GroupIds.Distinct())
            {
                _db.MajorGroups.Add(new MajorGroup
                {
                    MajorID = id,
                    GroupID = groupId,
                    ExamYear = req.ExamYear
                });
            }

            await _db.SaveChangesAsync();
            return Ok("Cập nhật ngành thành công!");
        }

        // ===========================================
        // DELETE: api/admin/majors/{id}
        // ===========================================
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var m = await _db.Majors.FindAsync(id);
            if (m == null) return NotFound("Không tìm thấy ngành.");

            // Xóa liên kết MajorGroups trước
            var links = _db.MajorGroups.Where(x => x.MajorID == id);
            _db.MajorGroups.RemoveRange(links);

            _db.Majors.Remove(m);
            await _db.SaveChangesAsync();

            return Ok("Đã xoá ngành.");
        }
    }

   
}
