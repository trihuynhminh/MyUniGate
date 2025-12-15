using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

//using UniGate.Application.DTOs.Score;
using UniGate.Core.Entities;

using UniGate.Infrastructure;


namespace UniGate.Api.Controllers
{
    [ApiController]
    [Route("api/user-scores")]
    public class UserScoresController : ControllerBase
    {
        private readonly AppDbContext _db;

        public UserScoresController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveScores([FromBody] UserScoreRequest req)
        {
            if (req == null)
                return BadRequest(new { Message = "Thiếu dữ liệu đầu vào!" });

            if (req.UserId <= 0)
                return BadRequest(new { Message = "Thiếu UserId hoặc UserId không hợp lệ!" });

            var userExists = await _db.Users.AnyAsync(u => u.UserID == req.UserId);
            if (!userExists)
                return NotFound(new { Message = $"Không tìm thấy người dùng ID = {req.UserId}" });

            // ======================
            // 🔍 KIỂM TRA ĐẦY ĐỦ ĐIỂM
            // ======================
            var missingFields = new List<string>();

            // Học bạ: tất cả Toán - Văn - Lý - Hóa - Sinh - Tin - Công Nghệ - GDCD - Sử - Địa
            string[] monHoc = { "Toan", "Van", "Ly", "Hoa", "Sinh", "Tin", "CongNghe", "GDKTPL", "Su", "Dia" };
            foreach (var mon in monHoc)
            {
                for (int lop = 10; lop <= 12; lop++)
                {
                    var prop = typeof(UserScoreRequest).GetProperty($"HB_{mon}_{lop}");
                    var val = prop?.GetValue(req) as float?;
                    if (val == null)
                        missingFields.Add($"HB_{mon}_{lop}");
                }
            }

            // Ngoại ngữ
            if (string.IsNullOrWhiteSpace(req.HB_NgoaiNgu_Mon))
                missingFields.Add("HB_NgoaiNgu_Mon");
            if (req.HB_NgoaiNgu_10 == null) missingFields.Add("HB_NgoaiNgu_10");
            if (req.HB_NgoaiNgu_11 == null) missingFields.Add("HB_NgoaiNgu_11");
            if (req.HB_NgoaiNgu_12 == null) missingFields.Add("HB_NgoaiNgu_12");

            // THPT
            if (req.Thpt_Toan == null) missingFields.Add("Thpt_Toan");
            if (req.Thpt_Van == null) missingFields.Add("Thpt_Van");
            if (string.IsNullOrWhiteSpace(req.Thpt_TuChon1_Mon) || req.Thpt_TuChon1_Diem == null)
                missingFields.Add("Thpt_TuChon1");
            if (string.IsNullOrWhiteSpace(req.Thpt_TuChon2_Mon) || req.Thpt_TuChon2_Diem == null)
                missingFields.Add("Thpt_TuChon2");

            // ĐGNL
            if (req.DGNL_Toan == null) missingFields.Add("DGNL_Toan");
            if (req.DGNL_TuDuy == null) missingFields.Add("DGNL_TuDuy");
            if (req.DGNL_NgonNgu == null) missingFields.Add("DGNL_NgonNgu");

            // Ưu tiên
            if (string.IsNullOrWhiteSpace(req.KhuVuc))
                missingFields.Add("KhuVuc");
            if (string.IsNullOrWhiteSpace(req.DoiTuong))
                missingFields.Add("DoiTuong");
            if (req.DiemCongThem == null)
                missingFields.Add("DiemCongThem");

            if (missingFields.Any())
                return BadRequest(new
                {
                    Message = "Thiếu các trường bắt buộc!",
                    MissingFields = missingFields
                });

            // ======================
            // 🔧 LƯU DỮ LIỆU
            // ======================
            var score = await _db.UserScores.FindAsync(req.UserId);
            bool isNew = false;
            if (score == null)
            {
                score = new UserScore { UserID = req.UserId };
                _db.UserScores.Add(score);
                isNew = true;
            }

            // Auto-map nhanh tất cả field có cùng tên
            var props = typeof(UserScoreRequest).GetProperties();
            foreach (var prop in props)
            {
                var val = prop.GetValue(req);
                var targetProp = typeof(UserScore).GetProperty(prop.Name);
                if (targetProp != null)
                    targetProp.SetValue(score, val);
            }

            await _db.SaveChangesAsync();

            return Ok(new
            {
                Message = isNew ? "Tạo bảng điểm mới thành công!" : "Cập nhật bảng điểm thành công!",
                UserID = req.UserId,
                UpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetScores(int userId)
        {
            var score = await _db.UserScores.FindAsync(userId);
            if (score == null)
                return NotFound(new { Message = "Người dùng chưa nhập điểm!" });

            return Ok(score);
        }

        // DTO đặt trong file này luôn (tạm thời)
        public class UserScoreRequest
        {
            [Required]
            public int UserId { get; set; }

            // ===== HỌC BẠ =====
            [Required] public decimal HB_Toan_10 { get; set; }
            [Required] public decimal HB_Toan_11 { get; set; }
            [Required] public decimal HB_Toan_12 { get; set; }

            [Required] public decimal HB_Van_10 { get; set; }
            [Required] public decimal HB_Van_11 { get; set; }
            [Required] public decimal HB_Van_12 { get; set; }

            [Required] public decimal HB_Su_10 { get; set; }
            [Required] public decimal HB_Su_11 { get; set; }
            [Required] public decimal HB_Su_12 { get; set; }

            [Required] public decimal HB_Dia_10 { get; set; }
            [Required] public decimal HB_Dia_11 { get; set; }
            [Required] public decimal HB_Dia_12 { get; set; }

            [Required] public decimal HB_GDKTPL_10 { get; set; }
            [Required] public decimal HB_GDKTPL_11 { get; set; }
            [Required] public decimal HB_GDKTPL_12 { get; set; }

            [Required] public decimal HB_Ly_10 { get; set; }
            [Required] public decimal HB_Ly_11 { get; set; }
            [Required] public decimal HB_Ly_12 { get; set; }

            [Required] public decimal HB_Hoa_10 { get; set; }
            [Required] public decimal HB_Hoa_11 { get; set; }
            [Required] public decimal HB_Hoa_12 { get; set; }

            [Required] public decimal HB_Sinh_10 { get; set; }
            [Required] public decimal HB_Sinh_11 { get; set; }
            [Required] public decimal HB_Sinh_12 { get; set; }

            [Required] public decimal HB_Tin_10 { get; set; }
            [Required] public decimal HB_Tin_11 { get; set; }
            [Required] public decimal HB_Tin_12 { get; set; }

            [Required] public decimal HB_CongNghe_10 { get; set; }
            [Required] public decimal HB_CongNghe_11 { get; set; }
            [Required] public decimal HB_CongNghe_12 { get; set; }

            // Ngoại ngữ
            [Required] public string HB_NgoaiNgu_Mon { get; set; } = "";
            [Required] public decimal HB_NgoaiNgu_10 { get; set; }
            [Required] public decimal HB_NgoaiNgu_11 { get; set; }
            [Required] public decimal HB_NgoaiNgu_12 { get; set; }

            // ===== THPT =====
            [Required] public decimal Thpt_Toan { get; set; }
            [Required] public decimal Thpt_Van { get; set; }

            [Required] public string Thpt_TuChon1_Mon { get; set; } = "";
            [Required] public decimal Thpt_TuChon1_Diem { get; set; }

            [Required] public string Thpt_TuChon2_Mon { get; set; } = "";
            [Required] public decimal Thpt_TuChon2_Diem { get; set; }

            // ===== ĐGNL =====
            [Required] public decimal DGNL_NgonNgu { get; set; }
            [Required] public decimal DGNL_Toan { get; set; }
            [Required] public decimal DGNL_TuDuy { get; set; }

            // ===== ƯU TIÊN =====
            [Required] public string KhuVuc { get; set; } = "";
            [Required] public string DoiTuong { get; set; } = "";
            [Required] public decimal DiemCongThem { get; set; }
        }

    }
}
