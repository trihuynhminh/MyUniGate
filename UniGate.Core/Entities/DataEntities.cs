/*(Nhóm Thống kê & Điểm User)

(Chứa: ScoreConversion, GroupScoreDistribution, UserScore, UserSelectedCombo)*/
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniGate.Core.Entities;

[Table("GroupScoreDistributions")]
public class GroupScoreDistribution
{
    [Key] public int DistDetailID { get; set; }
    public int GroupID { get; set; }
    public short ExamYear { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal TotalScoreLevel { get; set; }
    public int CountStudents { get; set; }
    [Column(TypeName = "decimal(5,4)")] public decimal ProbDistribution { get; set; }

    // Navigation property với SubjectGroup
    [ForeignKey("GroupID")] public virtual SubjectGroup SubjectGroup { get; set; } = null!;
}

[Table("UserSelectedCombos")]
public class UserSelectedCombo
{
    // Bảng này dùng Composite Key, sẽ cấu hình bên DbContext
    public int UserID { get; set; }
    public int GroupID { get; set; }

    [ForeignKey("UserID")] public User? User { get; set; }
    [ForeignKey("GroupID")] public SubjectGroup? SubjectGroup { get; set; }
}

// Bảng điểm "siêu to khổng lồ"[Table("UserScores")]
public class UserScore
{
    // Khóa chính đồng thời là khóa ngoại trỏ về User (Quan hệ 1-1)
    [Key, ForeignKey("User")]
    public int UserID { get; set; }

    // --- HỌC BẠ (Phải khai báo đầy đủ như SQL) ---

    // Toán
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Toan_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Toan_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Toan_12 { get; set; }

    // Văn
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Van_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Van_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Van_12 { get; set; }

<<<<<<< HEAD
    // Sử
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Su_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Su_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Su_12 { get; set; }

    // Địa
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Dia_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Dia_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Dia_12 { get; set; }

    // GD KT & PL
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_GDKTPL_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_GDKTPL_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_GDKTPL_12 { get; set; }

    // Lý
=======
>>>>>>> api-ngành-theo-khối(client+admin)
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Ly_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Ly_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Ly_12 { get; set; }

<<<<<<< HEAD
    // Hóa
=======
>>>>>>> api-ngành-theo-khối(client+admin)
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Hoa_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Hoa_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Hoa_12 { get; set; }

<<<<<<< HEAD
    // Sinh
=======
>>>>>>> api-ngành-theo-khối(client+admin)
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Sinh_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Sinh_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Sinh_12 { get; set; }

<<<<<<< HEAD
    // Tin
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Tin_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Tin_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Tin_12 { get; set; }

    // Công nghệ
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_CongNghe_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_CongNghe_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_CongNghe_12 { get; set; }

    // --- NGOẠI NGỮ (Lưu ý tên cột trong SQL là Ngoại Ngữ chứ không phải Anh) ---
    [MaxLength(50)] public string HB_NgoaiNgu_Mon { get; set; } = string.Empty; // Ví dụ: "Tiếng Anh", "Tiếng Nhật"
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_NgoaiNgu_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_NgoaiNgu_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_NgoaiNgu_12 { get; set; }

    // --- ĐIỂM THI THPT QUỐC GIA ---
=======
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Dia_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Dia_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Dia_12 { get; set; }

    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Su_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Su_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Su_12 { get; set; }

    [Column(TypeName = "NVARCHAR(50)")] public decimal? HB_NgoaiNgu_Mon { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_NgoaiNgu_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_NgoaiNgu_11 { get; set; }

    [Column(TypeName = "decimal(5,2)")] public decimal? HB_NgoaiNgu_12 { get; set; }
    [Column(TypeName = "NVARCHAR(50)")] public decimal? Thpt_TuChon1_Mon { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? Thpt_TuChon1_Diem { get; set; }

    [Column(TypeName = "NVARCHAR(50)")] public decimal? Thpt_TuChon2_Mon { get; set; }

    [Column(TypeName = "decimal(5,2)")] public decimal? Thpt_TuChon2_Diem { get; set; }



    // THPT QG
>>>>>>> api-ngành-theo-khối(client+admin)
    [Column(TypeName = "decimal(5,2)")] public decimal? Thpt_Toan { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? Thpt_Van { get; set; }

    // Môn tự chọn (Lý/Hóa/Sử...)
    [MaxLength(50)] public string Thpt_TuChon1_Mon { get; set; } = string.Empty;
    [Column(TypeName = "decimal(5,2)")] public decimal? Thpt_TuChon1_Diem { get; set; }

    [MaxLength(50)] public string Thpt_TuChon2_Mon { get; set; } = string.Empty;
    [Column(TypeName = "decimal(5,2)")] public decimal? Thpt_TuChon2_Diem { get; set; }

    // --- ĐÁNH GIÁ NĂNG LỰC ---
    [Column(TypeName = "decimal(5,2)")] public decimal? DGNL_NgonNgu { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? DGNL_Toan { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? DGNL_TuDuy { get; set; }

    // --- ƯU TIÊN ---
    [MaxLength(50)] public string KhuVuc { get; set; } = string.Empty;
    [MaxLength(50)] public string DoiTuong { get; set; } = string.Empty;
    [Column(TypeName = "decimal(5,2)")] public decimal? DiemCongThem { get; set; }

    // Navigation Property
    public virtual User? User { get; set; }
}