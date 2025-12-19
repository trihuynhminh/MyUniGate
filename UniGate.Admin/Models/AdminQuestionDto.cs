namespace UniGate.Admin.Models;

public class AdminQuestionDto
{
    public int Id { get; set; }
    public string Content { get; set; } = "";
    public string Code { get; set; } = "";
    public string Group { get; set; } = "";
    public string TestType { get; set; } = "Holland";
    public bool IsActive { get; set; } = true;
}
