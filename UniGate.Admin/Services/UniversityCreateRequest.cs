namespace UniGate.Admin.Services;

public class UniversityCreateRequest
{
    public string UniversityCode { get; set; } = "";
    public string UniversityName { get; set; } = "";
    public string? Province { get; set; }
    public string? Website { get; set; }
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
}
