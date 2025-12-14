/*(Nhóm Thống kê & Điểm User)

(Chứa: ScoreConversion, GroupScoreDistribution, UserScore, UserSelectedCombo)*/
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniGate.Core.Entities;

[Table("ScoreConversions")]
public class ScoreConversion
{
    [Key] public int ConversionID { get; set; }
    [Required, MaxLength(50)] public string CertificateName { get; set; } = string.Empty;
    [Column(TypeName = "decimal(5,2)")] public decimal OriginalScore { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal ConvertedScore { get; set; }
    public short? ExamYear { get; set; }
}

[Table("GroupScoreDistributions")]
public class GroupScoreDistribution
{
    [Key] public int DistDetailID { get; set; }
    public int GroupID { get; set; }
    public short ExamYear { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal TotalScoreLevel { get; set; }
    public int CountStudents { get; set; }
    [Column(TypeName = "decimal(5,4)")] public decimal ProbDistribution { get; set; }

    [ForeignKey("GroupID")] public SubjectGroup? SubjectGroup { get; set; }
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

// Bảng điểm "siêu to khổng lồ"
[Table("UserScores")]
public class UserScore
{
    [Key, ForeignKey("User")] public int UserID { get; set; }

    // HỌC BẠ
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Toan_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Toan_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Toan_12 { get; set; }
    // ... (Anh tự copy thêm các môn khác tương tự nếu muốn đủ bộ 100%, em viết mẫu đại diện)
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Van_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Van_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Van_12 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Anh_10 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Anh_11 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? HB_Anh_12 { get; set; }

    // THPT QG
    [Column(TypeName = "decimal(5,2)")] public decimal? Thpt_Toan { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? Thpt_Van { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? Thpt_Anh { get; set; }

    // Ưu Tiên
    [MaxLength(50)] public string KhuVuc { get; set; } = string.Empty;
    [MaxLength(50)] public string DoiTuong { get; set; } = string.Empty;
    [Column(TypeName = "decimal(5,2)")] public decimal? DiemCongThem { get; set; }

    public virtual User? User { get; set; }
}