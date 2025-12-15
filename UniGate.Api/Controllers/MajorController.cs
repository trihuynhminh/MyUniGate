/*lọc ngành phù hợp tính cách và điểm thi và khối thi của trí*/
using Microsoft.AspNetCore.Mvc;
using UniGate.Api.DTOs;
using UniGate.Api.Services;
using UniGate.Core.Entities;
using UniGate.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace UniGate.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MajorController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly MajorService _majorService;

    public MajorController(AppDbContext db, MajorService majorService)
    {
        _db = db;
        _majorService = majorService;
    }

    [HttpPost("filter")]
    public async Task<IActionResult> FilterMajors([FromBody] FilterRequest request)
    {
        // Cập nhật dòng này: Truyền thêm request.PersonalityType
        var result = await _majorService.GetSuitableMajors(
            request.Score,
            request.Group,
            request.PersonalityType // <--- Thêm cái này
        );

        return Ok(result);
    }


    // ==============================
    // GET: api/majors/{id}
    // ==============================
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var m = _db.Majors
            .Include(x => x.MajorGroups)
            .ThenInclude(g => g.SubjectGroup)
            .Where(x => x.MajorID == id)
            .Select(x => new MajorDetailDto
            {
                Id = x.MajorID,
                MajorCode = x.MajorCode,
                Name = x.MajorName,
                Description = x.Description,
                Combos = x.MajorGroups.Select(g => g.SubjectGroup.GroupName).ToList()
            })
            .FirstOrDefault(x => x.Id == id);

        if (m == null)
            return NotFound("Ngành không tồn tại!");

        return Ok(m);
    }

    // ==============================
    // GET: api/majors?schoolId=1
    // ==============================
    [HttpGet]
    public IActionResult GetMajorsByUniversity([FromQuery] int schoolId)
    {
        var majors = (
            from a in _db.Admissions
            join m in _db.Majors on a.MajorID equals m.MajorID
            join g in _db.SubjectGroups on a.GroupID equals g.GroupID
            where a.UniversityID == schoolId
            group new { a, m, g } by new { m.MajorID, m.MajorCode, m.MajorName } into grp
            select new
            {
                Id = grp.Key.MajorID,
                MajorCode = grp.Key.MajorCode,
                Name = grp.Key.MajorName,

                // giống output cũ
                CutoffScore = grp.Max(x => x.a.MinScore),

                Combos = grp.Select(x => x.g.GroupName).Distinct().ToList()
            }
        ).ToList();

        return Ok(majors);
    }

    // ==============================
    // GET: api/majors/by-combos/{userId}
    // ==============================
    [HttpGet("by-combos/{userId:int}")]
    public IActionResult GetMajorsByUserCombos(int userId)
    {
        var selectedGroupIds = _db.UserSelectedCombos
            .Where(x => x.UserID == userId)
            .Select(x => x.GroupID)
            .ToList();

        if (!selectedGroupIds.Any())
            return Ok(new List<object>());

        var majors = (
            from a in _db.Admissions
            join m in _db.Majors on a.MajorID equals m.MajorID
            join u in _db.Universities on a.UniversityID equals u.UniversityID
            join g in _db.SubjectGroups on a.GroupID equals g.GroupID
            where selectedGroupIds.Contains(a.GroupID)
            group new { a, m, u, g } by new { m.MajorID, m.MajorName, u.UniversityName } into grp
            select new
            {
                MajorId = grp.Key.MajorID,
                Name = grp.Key.MajorName,
                SchoolName = grp.Key.UniversityName,
                ComboCodes = grp.Select(x => x.g.GroupName).Distinct().ToList(),
                LastYearScore = grp.Max(x => x.a.MinScore)
            }
        ).ToList();

        return Ok(majors);
    }


    // ==============================
    // POST: api/majors
    // ==============================
    [HttpPost]
    public IActionResult Create([FromBody] MajorCreateRequest req)
    {
        var major = new Major
        {
            MajorCode = req.MajorCode,
            MajorName = req.Name,
            Description = req.Description
        };

        _db.Majors.Add(major);
        _db.SaveChanges();

        // Thêm liên kết với các tổ hợp
        foreach (var groupId in req.GroupIds)
        {
            _db.MajorGroups.Add(new MajorGroup
            {
                MajorID = major.MajorID,
                GroupID = groupId,
                ExamYear = (short?)DateTime.Now.Year
            });
        }

        _db.SaveChanges();
        return Ok("Thêm ngành thành công!");
    }

    // ==============================
    // PUT: api/majors/{id}
    // ==============================
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] MajorUpdateRequest req)
    {
        var major = _db.Majors
            .Include(m => m.MajorGroups)
            .FirstOrDefault(m => m.MajorID == id);

        if (major == null)
            return NotFound("Không tìm thấy ngành!");

        major.MajorCode = req.MajorCode;
        major.MajorName = req.Name;
        major.Description = req.Description;

        // Xóa tổ hợp cũ và gắn lại mới
        _db.MajorGroups.RemoveRange(major.MajorGroups);
        foreach (var groupId in req.GroupIds)
        {
            _db.MajorGroups.Add(new MajorGroup
            {
                MajorID = id,
                GroupID = groupId,
                ExamYear = (short?)DateTime.Now.Year
            });
        }

        _db.SaveChanges();
        return Ok("Cập nhật ngành thành công!");
    }

    // ==============================
    // DELETE: api/majors/{id}
    // ==============================
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var major = _db.Majors.Find(id);
        if (major == null)
            return NotFound("Không tìm thấy ngành!");

        _db.Majors.Remove(major);
        _db.SaveChanges();

        return Ok("Đã xoá ngành.");
    }

}
