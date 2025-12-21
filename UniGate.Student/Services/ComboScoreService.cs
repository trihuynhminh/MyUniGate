using System;
using System.Collections.Generic;
using System.Linq;
using static UniGate.Student.Forms.FormChonKhoi;
using UniGate.Shared.DTOs;

namespace UniGate.Student.Services
{
    public class ComboScoreService
    {
        private readonly UserScoreResponse _scores;
        private readonly string[] _allLang =
        {
            "tiếng anh","tiếng nhật","tiếng hàn",
            "tiếng pháp","tiếng đức","tiếng trung","tiếng nga"
        };

        public ComboScoreService(UserScoreResponse scores)
        {
            _scores = scores;
        }

        // ======================
        // PUBLIC API
        // ======================
        public List<ComboScoreResultDto> TinhDiemToHop(List<ComboInfoDto> combos)
        {
            bool daNhapThpt = DaNhapThpt();
            decimal diemUuTien = TinhDiemUuTien();

            var result = new List<ComboScoreResultDto>();

            foreach (var c in combos)
            {
                decimal tong = 0m;
                bool hopLe = true;
                string detail = "";

                foreach (var mon in c.Subjects)
                {
                    decimal? diem = daNhapThpt
                        ? GetThptScoreOnly(mon)
                        : GetHocBaScoreOnly(mon);

                    if (diem == null)
                    {
                        hopLe = false;       
                        break;
                    }

                    tong += diem.Value;
                    detail += $"{mon} + ";
                }

                if (!hopLe) continue;

                detail = detail.TrimEnd('+', ' ');

                // Tính ưu tiên áp dụng theo yêu cầu:
                decimal appliedPriority = diemUuTien;
                string note = string.Empty;

                if (diemUuTien > 0m)
                {
                    // Nếu tổng >= 22.5 (thang tổng tối đa 30), scale theo công thức
                    if (tong >= 22.5m)
                    {
                        appliedPriority = ((30m - tong) / 7.5m) * diemUuTien;
                        if (appliedPriority < 0m) appliedPriority = 0m;
                        note = $"Ưu tiên hiệu chỉnh: {appliedPriority:0.##} (gốc: {diemUuTien:0.##}) vì tổng >= 22.5";
                    }
                    else
                    {
                        note = $"Ưu tiên áp dụng: {diemUuTien:0.##}";
                    }
                }
                else
                {
                    note = "Không có ưu tiên.";
                }

                result.Add(new ComboScoreResultDto
                {
                    Code = c.Code,
                    Score = tong + appliedPriority,
                    Detail = detail,
                    Note = note
                });
            }

            return result;
        }

        // ======================
        // PRIVATE LOGIC
        // ======================
        private bool DaNhapThpt()
        {
            if (_scores.Thpt_Toan != null) return true;
            if (_scores.Thpt_Van != null) return true;

            if (!string.IsNullOrWhiteSpace(_scores.Thpt_TuChon1_Mon)
                && _scores.Thpt_TuChon1_Diem != null) return true;

            if (!string.IsNullOrWhiteSpace(_scores.Thpt_TuChon2_Mon)
                && _scores.Thpt_TuChon2_Diem != null) return true;

            return false;
        }

        private string Norm(string s)
            => (s ?? "").Trim().ToLowerInvariant();

        private decimal? TinhTb(decimal? a, decimal? b, decimal? c)
        {
            if (a == null || b == null || c == null) return null;
            return (a.Value + b.Value + c.Value) / 3m;
        }

        private decimal? GetThptScoreOnly(string monRaw)
        {
            var mon = Norm(monRaw);

            if (mon == "toán") return _scores.Thpt_Toan;
            if (mon == "ngữ văn" || mon == "văn") return _scores.Thpt_Van;

            if (Norm(_scores.Thpt_TuChon1_Mon) == mon)
                return _scores.Thpt_TuChon1_Diem;

            if (Norm(_scores.Thpt_TuChon2_Mon) == mon)
                return _scores.Thpt_TuChon2_Diem;

            return null;
        }

        private decimal? GetHocBaScoreOnly(string monRaw)
        {
            var mon = Norm(monRaw);

            if (_allLang.Contains(mon))
                return TinhTb(_scores.HB_NgoaiNgu_10, _scores.HB_NgoaiNgu_11, _scores.HB_NgoaiNgu_12);

            if (mon == "toán")
                return TinhTb(_scores.HB_Toan_10, _scores.HB_Toan_11, _scores.HB_Toan_12);

            if (mon == "ngữ văn" || mon == "văn")
                return TinhTb(_scores.HB_Van_10, _scores.HB_Van_11, _scores.HB_Van_12);

            if (mon.Contains("lý") || mon.Contains("vật"))
                return TinhTb(_scores.HB_Ly_10, _scores.HB_Ly_11, _scores.HB_Ly_12);

            if (mon.Contains("hóa"))
                return TinhTb(_scores.HB_Hoa_10, _scores.HB_Hoa_11, _scores.HB_Hoa_12);

            if (mon.Contains("sinh"))
                return TinhTb(_scores.HB_Sinh_10, _scores.HB_Sinh_11, _scores.HB_Sinh_12);

            if (mon.Contains("sử") || mon.Contains("lịch"))
                return TinhTb(_scores.HB_Su_10, _scores.HB_Su_11, _scores.HB_Su_12);

            if (mon.Contains("địa"))
                return TinhTb(_scores.HB_Dia_10, _scores.HB_Dia_11, _scores.HB_Dia_12);

            if (mon.Contains("gdk") || mon.Contains("ktpl"))
                return TinhTb(_scores.HB_GDKTPL_10, _scores.HB_GDKTPL_11, _scores.HB_GDKTPL_12);

            if (mon.Contains("tin"))
                return TinhTb(_scores.HB_Tin_10, _scores.HB_Tin_11, _scores.HB_Tin_12);

            if (mon.Contains("công") || mon.Contains("nghệ"))
                return TinhTb(_scores.HB_CongNghe_10, _scores.HB_CongNghe_11, _scores.HB_CongNghe_12);

            return null;
        }

        private decimal TinhDiemUuTien()
        {
            decimal cong = 0m;

            switch ((_scores.KhuVuc ?? "").Trim())
            {
                case "KV1": cong += 0.75m; break;
                case "KV2": cong += 0.25m; break;
                case "KV2-NT": cong += 0.5m; break;
            }

            switch ((_scores.DoiTuong ?? "").Trim())
            {
                case "ƯT1": cong += 2m; break;
                case "ƯT2": cong += 1m; break;
            }

            if (_scores.DiemCongThem != null)
                cong += _scores.DiemCongThem.Value;

            return cong;
        }
    }
}
