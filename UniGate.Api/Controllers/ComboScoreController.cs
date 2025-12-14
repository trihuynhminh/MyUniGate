using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using UniGate.Core.Entities;
using UniGate.Infrastructure;

namespace UniGate.Api.Controllers
{
    [ApiController]
    [Route("api/combo-scores")]
    public class ComboScoreController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ComboScoreController(AppDbContext db)
        {
            _db = db;
        }

        // ====================================
        // API: TÍNH ĐIỂM THEO TỔ HỢP MÔN
        // ====================================
        [HttpGet("{userId:int}")]
        public IActionResult GetComboScores(int userId)
        {
            var scores = _db.UserScores.FirstOrDefault(s => s.UserID == userId);
            if (scores == null)
                return NotFound("Chưa có điểm học bạ hoặc THPT!");

            var combos = _db.SubjectGroups.AsNoTracking().ToList();
            var result = new List<object>();

            foreach (var combo in combos)
            {
                // "Toán, Lý, Hóa" -> ["toán","lý","hóa"]
                var subjects = combo.Subjects
                    .Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim().ToLower())
                    .ToList();

                decimal? total = TinhCombo(scores, subjects);
                if (total != null)
                {
                    result.Add(new
                    {
                        Combo = combo.GroupName,
                        Score = total
                    });
                }
            }

            var sorted = result.OrderByDescending(x => ((dynamic)x).Score);
            return Ok(sorted);
        }

        // ====================================
        // TÍNH TỔNG ĐIỂM 1 TỔ HỢP
        // ====================================
        private decimal? TinhCombo(UserScore s, List<string> monList)
        {
            decimal sum = 0;
            int count = 0;

            foreach (var mon in monList)
            {
                decimal? diem = LayDiemMon(s, mon);
                if (diem == null)
                    return null; // thiếu môn -> bỏ qua combo này

                sum += diem.Value;
                count++;
            }

            return count == 0 ? null : sum;
        }

        // ====================================
        // LẤY ĐIỂM 1 MÔN
        // ====================================
        private decimal? LayDiemMon(UserScore s, string mon)
        {
            mon = mon.ToLower().Trim();
            bool coThpt = s.Thpt_Toan != null || s.Thpt_Van != null ||
                          s.Thpt_TuChon1_Diem != null || s.Thpt_TuChon2_Diem != null;

            if (coThpt)
            {
                switch (mon)
                {
                    case "toán": return s.Thpt_Toan;
                    case "văn": return s.Thpt_Van;
                    case "lý":
                    case "vật lí": return LayDiemTuChon(s, "Lý");
                    case "hóa":
                    case "hóa học": return LayDiemTuChon(s, "Hóa");
                    case "sinh": return LayDiemTuChon(s, "Sinh");
                    case "địa":
                    case "địa lí": return LayDiemTuChon(s, "Địa");
                    case "sử":
                    case "lịch sử": return LayDiemTuChon(s, "Sử");

                    // Ngoại ngữ
                    case "anh":
                    case "nhật":
                    case "hàn":
                    case "trung":
                    case "đức":
                    case "pháp":
                    case "nga":
                        return LayDiemTuChon(s, ChuanHoaNgoaiNgu(mon));

                    default:
                        return null;
                }
            }

            // Không có THPT → dùng học bạ (TB cộng)
            return mon switch
            {
                "toán" => TinhTB(s.HB_Toan_10, s.HB_Toan_11, s.HB_Toan_12),
                "văn" => TinhTB(s.HB_Van_10, s.HB_Van_11, s.HB_Van_12),
                "lý" or "vật lí" => TinhTB(s.HB_Ly_10, s.HB_Ly_11, s.HB_Ly_12),
                "hóa" or "hóa học" => TinhTB(s.HB_Hoa_10, s.HB_Hoa_11, s.HB_Hoa_12),
                "sinh" => TinhTB(s.HB_Sinh_10, s.HB_Sinh_11, s.HB_Sinh_12),
                "địa" or "địa lí" => TinhTB(s.HB_Dia_10, s.HB_Dia_11, s.HB_Dia_12),
                "sử" or "lịch sử" => TinhTB(s.HB_Su_10, s.HB_Su_11, s.HB_Su_12),
                "anh" or "nhật" or "hàn" or "trung" or "đức" or "pháp" or "nga"
                    => mon == s.HB_NgoaiNgu_Mon?.ToString() ? .ToLower()
                        ? TinhTB(s.HB_NgoaiNgu_10, s.HB_NgoaiNgu_11, s.HB_NgoaiNgu_12)
                        : null,
                _ => null
            };
        }

        // ====================================
        // LẤY ĐIỂM MÔN TỰ CHỌN
        // ====================================
        private decimal? LayDiemTuChon(UserScore s, string mon)
        {
            if (string.Equals(s.Thpt_TuChon1_Mon?.ToString(), mon, StringComparison.OrdinalIgnoreCase)
)
                return s.Thpt_TuChon1_Diem;
            if (string.Equals(s.Thpt_TuChon2_Mon?.ToString(), mon, StringComparison.OrdinalIgnoreCase))
                return s.Thpt_TuChon2_Diem;
            return null;
        }

        // ====================================
        // TÍNH TRUNG BÌNH HỌC BẠ
        // ====================================
        private decimal? TinhTB(decimal? x, decimal? y, decimal? z)
        {
            if (x == null || y == null || z == null) return null;
            return (x.Value + y.Value + z.Value) / 3m;
        }

        // ====================================
        // CHUẨN HOÁ NGOẠI NGỮ
        // ====================================
        private string ChuanHoaNgoaiNgu(string mon) => mon switch
        {
            "anh" => "Anh",
            "nhật" => "Nhật",
            "hàn" => "Hàn",
            "trung" => "Trung",
            "đức" => "Đức",
            "pháp" => "Pháp",
            "nga" => "Nga",
            _ => mon
        };
    }
}
