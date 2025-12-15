using System.ComponentModel.DataAnnotations;

namespace UniGate.Api.DTOs
{
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
