/*File 1: AuthEntities.cs (Nhóm Tài khoản)

(Chứa: Role, Region, User, PasswordResetToken)*/
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniGate.Core.Entities;

[Table("Roles")]
public class Role
{
    [Key] public int RoleID { get; set; }
    [Required, MaxLength(50)] public string RoleName { get; set; } = string.Empty;
}

[Table("Regions")]
public class Region
{
    [Key] public int RegionID { get; set; }
    [Required, MaxLength(50)] public string RegionName { get; set; } = string.Empty;
    [Column(TypeName = "decimal(5,2)")] public decimal BonusScore { get; set; }
}

[Table("Users")]
public class User
{
    [Key] public int UserID { get; set; }
    [MaxLength(100)] public string? FullName { get; set; }
    [Required, MaxLength(100)] public string Email { get; set; } = string.Empty;
    [Required, MaxLength(255)] public string PasswordHash { get; set; } = string.Empty;
    public int RoleID { get; set; }
    public int? RegionID { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [ForeignKey("RoleID")] public Role? Role { get; set; }
    [ForeignKey("RegionID")] public Region? Region { get; set; }

    // 1 User có 1 bảng điểm
    public UserScore? UserScore { get; set; }
}

[Table("PasswordResetTokens")]
public class PasswordResetToken
{
    [Key] public int TokenID { get; set; }
    public int UserID { get; set; }
    [Required, MaxLength(255)] public string TokenCode { get; set; } = string.Empty;
    public DateTime ExpiryDate { get; set; }
    public bool IsUsed { get; set; } // Map TINYINT(1)
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [ForeignKey("UserID")] public User? User { get; set; }
}