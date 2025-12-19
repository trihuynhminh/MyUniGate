using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UniGate.Api.DTOs;
using UniGate.Api.Services;

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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var score = await _db.UserScores.FindAsync(req.UserId);

            if (score == null)
            {
                score = new UserScore { UserID = req.UserId };
                _db.UserScores.Add(score);
            }

            foreach (var prop in typeof(UserScoreRequest).GetProperties())
            {
                var target = typeof(UserScore).GetProperty(prop.Name);
                if (target != null)
                    target.SetValue(score, prop.GetValue(req));
            }

            await _db.SaveChangesAsync();
            return Ok(new { Message = "Lưu điểm thành công" });
        }
        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetScores(int userId)
        {
            var score = await _db.UserScores.AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserID == userId);

            if (score == null)
                return NotFound(new { Message = "Người dùng chưa nhập điểm!" });

            var res = new UserScoreResponse
            {
                UserId = score.UserID,

                HB_Toan_10 = score.HB_Toan_10,
                HB_Toan_11 = score.HB_Toan_11,
                HB_Toan_12 = score.HB_Toan_12,

                HB_Van_10 = score.HB_Van_10,
                HB_Van_11 = score.HB_Van_11,
                HB_Van_12 = score.HB_Van_12,

                HB_Ly_10 = score.HB_Ly_10,
                HB_Ly_11 = score.HB_Ly_11,
                HB_Ly_12 = score.HB_Ly_12,

                HB_Hoa_10 = score.HB_Hoa_10,
                HB_Hoa_11 = score.HB_Hoa_11,
                HB_Hoa_12 = score.HB_Hoa_12,

                HB_Sinh_10 = score.HB_Sinh_10,
                HB_Sinh_11 = score.HB_Sinh_11,
                HB_Sinh_12 = score.HB_Sinh_12,

                HB_Su_10 = score.HB_Su_10,
                HB_Su_11 = score.HB_Su_11,
                HB_Su_12 = score.HB_Su_12,

                HB_Dia_10 = score.HB_Dia_10,
                HB_Dia_11 = score.HB_Dia_11,
                HB_Dia_12 = score.HB_Dia_12,

                HB_Tin_10 = score.HB_Tin_10,
                HB_Tin_11 = score.HB_Tin_11,
                HB_Tin_12 = score.HB_Tin_12,

                HB_CongNghe_10 = score.HB_CongNghe_10,
                HB_CongNghe_11 = score.HB_CongNghe_11,
                HB_CongNghe_12 = score.HB_CongNghe_12,

                HB_GDKTPL_10 = score.HB_GDKTPL_10,
                HB_GDKTPL_11 = score.HB_GDKTPL_11,
                HB_GDKTPL_12 = score.HB_GDKTPL_12,

                HB_NgoaiNgu_Mon = score.HB_NgoaiNgu_Mon,
                HB_NgoaiNgu_10 = score.HB_NgoaiNgu_10,
                HB_NgoaiNgu_11 = score.HB_NgoaiNgu_11,
                HB_NgoaiNgu_12 = score.HB_NgoaiNgu_12,

                Thpt_Toan = score.Thpt_Toan,
                Thpt_Van = score.Thpt_Van,
                Thpt_TuChon1_Mon = score.Thpt_TuChon1_Mon,
                Thpt_TuChon1_Diem = score.Thpt_TuChon1_Diem,
                Thpt_TuChon2_Mon = score.Thpt_TuChon2_Mon,
                Thpt_TuChon2_Diem = score.Thpt_TuChon2_Diem,

                DGNL_NgonNgu = score.DGNL_NgonNgu,
                DGNL_Toan = score.DGNL_Toan,
                DGNL_TuDuy = score.DGNL_TuDuy,

                KhuVuc = score.KhuVuc,
                DoiTuong = score.DoiTuong,
                DiemCongThem = score.DiemCongThem
            };

            return Ok(res);
        }



    }
}
