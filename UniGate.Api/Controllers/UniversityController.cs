using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniGate.Core.Entities;

using UniGate.Infrastructure;


namespace UniGate.Api.Controllers
{
    [ApiController]
    [Route("api/universities")]
    public class UniversityController : ControllerBase
    {
        private readonly AppDbContext _db;
        public UniversityController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? keyword)
        {
            var query = _db.Universities.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim().ToLower();
                query = query.Where(u =>
                    (u.UniversityName ?? "").ToLower().Contains(keyword) ||
                    (u.UniversityCode ?? "").ToLower().Contains(keyword) ||
                    (u.Province ?? "").ToLower().Contains(keyword));
            }

            var result = await query
                .OrderBy(u => u.UniversityName)
                .Select(u => new UniversityDto
                {
                    UniversityID = u.UniversityID,
                    UniversityCode = u.UniversityCode,
                    UniversityName = u.UniversityName,
                    Province = u.Province,
                    Website = u.Website,
                    Description = u.Description,
                    LogoUrl = u.LogoUrl
                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var u = await _db.Universities.FindAsync(id);
            if (u == null) return NotFound("Không tìm thấy trường đại học.");

            return Ok(new UniversityDto
            {
                UniversityID = u.UniversityID,
                UniversityCode = u.UniversityCode,
                UniversityName = u.UniversityName,
                Province = u.Province,
                Website = u.Website,
                Description = u.Description,
                LogoUrl = u.LogoUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UniversityCreateRequest req)
        {
            var existed = await _db.Universities.AnyAsync(x => x.UniversityCode == req.UniversityCode);
            if (existed) return BadRequest("Mã trường đã tồn tại.");

            var uni = new University
            {
                UniversityCode = req.UniversityCode,
                UniversityName = req.UniversityName,
                Province = req.Province,
                Website = req.Website,
                Description = req.Description ?? "",
                LogoUrl = req.LogoUrl ?? ""
            };

            _db.Universities.Add(uni);
            await _db.SaveChangesAsync();
            return Ok("Thêm trường đại học thành công!");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UniversityUpdateRequest req)
        {
            if (id != req.UniversityID) return BadRequest("Id không khớp.");

            var u = await _db.Universities.FindAsync(id);
            if (u == null) return NotFound("Không tìm thấy trường đại học.");

            var existed = await _db.Universities.AnyAsync(x => x.UniversityID != id && x.UniversityCode == req.UniversityCode);
            if (existed) return BadRequest("Mã trường đã tồn tại.");

            u.UniversityCode = req.UniversityCode;
            u.UniversityName = req.UniversityName;
            u.Province = req.Province;
            u.Website = req.Website;
            u.Description = req.Description ?? "";
            u.LogoUrl = req.LogoUrl ?? "";

            await _db.SaveChangesAsync();
            return Ok("Cập nhật trường đại học thành công!");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var u = await _db.Universities.FindAsync(id);
            if (u == null) return NotFound("Không tìm thấy trường đại học.");

            _db.Universities.Remove(u);
            await _db.SaveChangesAsync();
            return Ok("Đã xóa trường đại học.");
        }
    }

    // =========================
    // DTOs (tạm để chung file)
    // =========================
    public class UniversityDto
    {
        public int UniversityID { get; set; }
        public string? UniversityCode { get; set; }
        public string? UniversityName { get; set; }
        public string? Province { get; set; }
        public string? Website { get; set; }
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
    }

    public class UniversityCreateRequest
    {
        public string UniversityCode { get; set; } = "";
        public string UniversityName { get; set; } = "";
        public string? Province { get; set; }
        public string? Website { get; set; }
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
    }

    public class UniversityUpdateRequest : UniversityCreateRequest
    {
        public int UniversityID { get; set; }
    }
}
