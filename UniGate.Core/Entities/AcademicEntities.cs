/*File 2: AcademicEntities.cs (Nhóm Trường - Ngành)

(Chứa: University, Major, SubjectGroup, MajorGroup, Admission)*/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniGate.Core.Entities;

[Table("Universities")]
public class University
{
    [Key] public int UniversityID { get; set; }
    [MaxLength(10)] public string? UniversityCode { get; set; }
    [Required, MaxLength(255)] public string UniversityName { get; set; } = string.Empty;
    [MaxLength(100)] public string? Province { get; set; }
    [MaxLength(255)] public string? Website { get; set; }
    [MaxLength(500)] public string? Description { get; set; }
    [MaxLength(255)] public string? LogoUrl { get; set; }
    
}

[Table("Majors")]
public class Major
{
    [Key] public int MajorID { get; set; }
    [MaxLength(10)] public string? MajorCode { get; set; }
    [Required, MaxLength(150)] public string MajorName { get; set; } = string.Empty;
    [MaxLength(500)] public string? Description { get; set; }
}

[Table("SubjectGroups")]
public class SubjectGroup
{
    [Key] public int GroupID { get; set; }
    [Required, MaxLength(10)] public string GroupName { get; set; } = string.Empty;
    [Required, MaxLength(100)] public string Subjects { get; set; } = string.Empty;
    
    public virtual ICollection<GroupScoreDistribution> GroupScoreDistributions { get; set; } = new List<GroupScoreDistribution>();
}

[Table("MajorGroups")]
public class MajorGroup
{
    [Key] public int MajorGroupID { get; set; }
    public int MajorID { get; set; }
    public int GroupID { get; set; }
    public short? ExamYear { get; set; }

    [ForeignKey("MajorID")] public Major? Major { get; set; }
    [ForeignKey("GroupID")] public SubjectGroup? SubjectGroup { get; set; }
}

[Table("Admissions")]
public class Admission
{
    [Key] public int AdmissionID { get; set; }
    public int UniversityID { get; set; }
    public int MajorID { get; set; }
    public int GroupID { get; set; }
    public short Year { get; set; }

    [Column(TypeName = "decimal(5,2)")] public decimal MinScore { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? MedianScore { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? Percentile25 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? Percentile75 { get; set; }
    [Column(TypeName = "decimal(5,2)")] public decimal? MaxScore { get; set; }

    [ForeignKey("UniversityID")] public University? University { get; set; }
    [ForeignKey("MajorID")] public Major? Major { get; set; }
    [ForeignKey("GroupID")] public SubjectGroup? SubjectGroup { get; set; }
}