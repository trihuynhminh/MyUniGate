using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniGate.Api.DTOs;
using UniGate.Core.Entities;
using UniGate.Infrastructure;
using UniGate.Shared.DTOs;

namespace UniGate.Api.Controllers
{
    [ApiController]
    [Route("api/admin/admissions")]
    public class AdmissionAdminController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AdmissionAdminController(AppDbContext db)
        {
            _db = db;
        }


        [HttpPost("upsert")]
        public async Task<IActionResult> Upsert([FromBody] AdmissionUpsertRequest req)
        {
            // Validate FK
            if (!await _db.Universities.AnyAsync(u => u.UniversityID == req.UniversityID))
                return BadRequest("UniversityID không tồn tại");

            if (!await _db.Majors.AnyAsync(m => m.MajorID == req.MajorID))
                return BadRequest("MajorID không tồn tại");

            var validGroupIds = await _db.SubjectGroups
                .Where(g => req.GroupIds.Contains(g.GroupID))
                .Select(g => g.GroupID)
                .ToListAsync();

            if (validGroupIds.Count != req.GroupIds.Count)
                return BadRequest("Có GroupID không tồn tại");

            // 1️⃣ Xóa admission cũ (theo major + trường + năm)
            var old = _db.Admissions.Where(a =>
                a.UniversityID == req.UniversityID &&
                a.MajorID == req.MajorID &&
                a.Year == req.Year);

            _db.Admissions.RemoveRange(old);

            // 2️⃣ Thêm lại theo từng GroupID
            foreach (var gid in req.GroupIds)
            {
                _db.Admissions.Add(new Admission
                {
                    UniversityID = req.UniversityID,
                    MajorID = req.MajorID,
                    GroupID = gid,          // ✅ FK chuẩn
                    Year = req.Year,
                    MinScore = req.MinScore
                });
            }

            await _db.SaveChangesAsync();
            return Ok("Lưu điểm chuẩn thành công");
        }

        [HttpGet("by-group")]
        public async Task<IActionResult> GetByGroup([FromQuery] int groupId, [FromQuery] short? year)
        {
            var q = _db.Admissions
                .Include(a => a.Major)
                .Include(a => a.University)
                .Include(a => a.SubjectGroup)
                .Where(a => a.GroupID == groupId);

            if (year.HasValue) q = q.Where(a => a.Year == year.Value);

            var data = await q
                .Select(a => new MajorByComboRowDto
                {
                    MajorId = a.MajorID,
                    MajorCode = a.Major.MajorCode,
                    MajorName = a.Major.MajorName,

                    UniversityId = a.UniversityID,
                    UniversityName = a.University.UniversityName,

                    GroupId = a.GroupID,
                    GroupName = a.SubjectGroup.GroupName, // tùy entity bạn đặt tên cột

                    MinScore = a.MinScore,
                    Year = a.Year
                })
                .OrderByDescending(x => x.Year)
                .ThenBy(x => x.UniversityName)
                .ThenBy(x => x.MajorName)
                .ToListAsync();

            return Ok(data);
        }


        [HttpGet("by-group-codes")]
        public async Task<IActionResult> GetByGroupCodes(
    [FromQuery] string codes,
    [FromQuery] short? year)
        {
            var arr = codes.Split(',');

            var q = _db.Admissions
                .Include(a => a.Major)
                .Include(a => a.University)
                .Include(a => a.SubjectGroup)
                .Where(a => arr.Contains(a.SubjectGroup.GroupName));

            if (year.HasValue)
                q = q.Where(a => a.Year == year.Value);

            var data = await q.Select(a => new MajorByComboRowDto
            {
                MajorId = a.MajorID,
                MajorCode = a.Major.MajorCode,
                MajorName = a.Major.MajorName,
                UniversityId = a.UniversityID,
                UniversityName = a.University.UniversityName,
                GroupName = a.SubjectGroup.GroupName,
                MinScore = a.MinScore,
                Year = a.Year
            }).ToListAsync();

            return Ok(data);
        }

    }
}
