/*Đây là nơi mình "ra lệnh" cho code hiểu các ràng buộc SQL (như khóa ngoại, khóa chính đôi...).*/
using Microsoft.EntityFrameworkCore;
using UniGate.Core.Entities;

namespace UniGate.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Khai báo 18 bảng
    public DbSet<Role> Roles { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
    public DbSet<TestType> TestTypes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<UserAnswer> UserAnswers { get; set; }
    public DbSet<TestResult> TestResults { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Major> Majors { get; set; }
    public DbSet<SubjectGroup> SubjectGroups { get; set; }
    public DbSet<MajorGroup> MajorGroups { get; set; }
    public DbSet<Admission> Admissions { get; set; }
    public DbSet<CareerSuggestion> CareerSuggestions { get; set; }
    public DbSet<GroupScoreDistribution> GroupScoreDistributions { get; set; }
    public DbSet<UserScore> UserScores { get; set; }
    public DbSet<UserSelectedCombo> UserSelectedCombos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1. Cấu hình bảng UserSelectedCombos (Khóa chính kép)
        modelBuilder.Entity<UserSelectedCombo>()
            .HasKey(sc => new { sc.UserID, sc.GroupID });

        // 2. Cấu hình UserScore (Quan hệ 1-1 với User)
        modelBuilder.Entity<UserScore>()
            .HasOne(us => us.User)
            .WithOne(u => u.UserScore)
            .HasForeignKey<UserScore>(us => us.UserID)
            .OnDelete(DeleteBehavior.Cascade);

        // 3. Unique Constraints (Ràng buộc duy nhất)
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<TestType>().HasIndex(t => t.TestName).IsUnique();
        modelBuilder.Entity<SubjectGroup>().HasIndex(g => g.GroupName).IsUnique();
    }
}