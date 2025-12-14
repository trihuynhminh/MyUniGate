/*File 3: TestEntities.cs (Nhóm Trắc nghiệm)

(Chứa: TestType, Question, UserAnswer, TestResult, CareerSuggestion)*/
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniGate.Core.Entities;

[Table("TestTypes")]
public class TestType
{
    [Key] public int TestTypeID { get; set; }
    [Required, MaxLength(50)] public string TestName { get; set; } = string.Empty;
    [MaxLength(255)] public string? Description { get; set; }
}

[Table("Questions")]
public class Question
{
    [Key] public int QuestionID { get; set; }
    public int TestTypeID { get; set; }
    [Required, MaxLength(500)] public string QuestionText { get; set; } = string.Empty;
    [MaxLength(200)] public string? OptionA { get; set; }
    [MaxLength(200)] public string? OptionB { get; set; }
    [MaxLength(200)] public string? OptionC { get; set; }
    [MaxLength(200)] public string? OptionD { get; set; }
    [MaxLength(10)] public string? CorrectOption { get; set; }

    [ForeignKey("TestTypeID")] public TestType? TestType { get; set; }
}

[Table("UserAnswers")]
public class UserAnswer
{
    [Key] public int AnswerID { get; set; }
    public int UserID { get; set; }
    public int QuestionID { get; set; }
    [Required, MaxLength(10)] public string SelectedOption { get; set; } = string.Empty;
    public DateTime AnswerDate { get; set; } = DateTime.Now;

    [ForeignKey("UserID")] public User? User { get; set; }
    [ForeignKey("QuestionID")] public Question? Question { get; set; }
}

[Table("TestResults")]
public class TestResult
{
    [Key] public int ResultID { get; set; }
    public int UserID { get; set; }
    public int TestTypeID { get; set; }
    [Required, MaxLength(10)] public string ResultCode { get; set; } = string.Empty;
    [MaxLength(500)] public string? ResultText { get; set; }
    public DateTime TestDate { get; set; } = DateTime.Now;

    [ForeignKey("UserID")] public User? User { get; set; }
    [ForeignKey("TestTypeID")] public TestType? TestType { get; set; }
}

[Table("CareerSuggestions")]
public class CareerSuggestion
{
    [Key] public int SuggestionID { get; set; }
    public int TestTypeID { get; set; }
    [Required, MaxLength(10)] public string ResultCode { get; set; } = string.Empty;
    public int MajorID { get; set; }
    [MaxLength(255)] public string? Note { get; set; }

    [ForeignKey("TestTypeID")] public TestType? TestType { get; set; }
    [ForeignKey("MajorID")] public Major? Major { get; set; }
}