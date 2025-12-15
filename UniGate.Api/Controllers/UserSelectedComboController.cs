using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniGate.Core.Entities;
using UniGate.Infrastructure;


namespace UniGate.Api.Controllers
{
    [ApiController]
    [Route("api/user-combos")]
    public class UserSelectedComboController : ControllerBase
    {
        private readonly AppDbContext _db;

        public UserSelectedComboController(AppDbContext db)
        {
            _db = db;
        }

        // ========================
        // === DTO nội bộ =========
        // ========================
        public class UserComboSelectRequest
        {
            public int UserId { get; set; }
            public List<string>? GroupNames { get; set; } // ví dụ: ["A00", "A01", "D01"]
        }

        // ========================
        // === POST: chọn combo ===
        // ========================
        [HttpPost("select")]
        public async Task<IActionResult> SelectCombos([FromBody] UserComboSelectRequest req)
        {
            if (req == null || req.GroupNames == null || req.GroupNames.Count == 0)
                return BadRequest("Vui lòng chọn ít nhất 1 tổ hợp.");

            if (req.GroupNames.Count > 3)
                return BadRequest("Bạn chỉ được chọn tối đa 3 tổ hợp.");

            // Kiểm tra user tồn tại
            var userExists = await _db.Users.AnyAsync(u => u.UserID == req.UserId);
            if (!userExists)
                return BadRequest("UserId không tồn tại!");

            // Xóa tổ hợp cũ
            var old = _db.UserSelectedCombos.Where(c => c.UserID== req.UserId);
            _db.UserSelectedCombos.RemoveRange(old);

            // Thêm tổ hợp mới
            int added = 0;
            foreach (var name in req.GroupNames)
            {
                var group = await _db.SubjectGroups.FirstOrDefaultAsync(g => g.GroupName == name);
                if (group == null) continue;

                _db.UserSelectedCombos.Add(new UserSelectedCombo
                {
                    UserID = req.UserId,
                    GroupID = group.GroupID
                });

                added++;
            }

            if (added == 0)
                return BadRequest("Không có tổ hợp hợp lệ nào được thêm!");

            await _db.SaveChangesAsync();
            return Ok($"Đã lưu {added} tổ hợp xét tuyển cho người dùng!");
        }

        // ========================
        // === GET: lấy combo đã chọn
        // ========================
        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetSelected(int userId)
        {
            var combos = await _db.UserSelectedCombos
                                  .Include(c => c.SubjectGroup)
                                  .Where(c => c.UserID== userId)
                                  .Select(c => c.SubjectGroup.GroupName)
                                  .ToListAsync();

            if (combos.Count == 0)
                return NotFound("Người dùng chưa chọn tổ hợp nào.");

            return Ok(combos);
        }
    }
}
