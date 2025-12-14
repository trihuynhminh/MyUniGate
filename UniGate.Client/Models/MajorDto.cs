namespace UniGate.Client.Models;

public class MajorDto
{
    public string UniversityName { get; set; } = string.Empty;
    public string MajorName { get; set; } = string.Empty;
    public string MajorCode { get; set; } = string.Empty;
    public double StandardScore { get; set; } // Bên Client dùng double cho tiện binding
    public double SafeMargin { get; set; }

    // --- THÊM 2 DÒNG NÀY ---
    public bool IsPersonalityMatch { get; set; }
    public string MatchNote { get; set; } = string.Empty;
}