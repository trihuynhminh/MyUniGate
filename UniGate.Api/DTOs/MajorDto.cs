
/*lấy ngành của trí*/
namespace UniGate.Api.DTOs;

public class MajorDto
{
    public string UniversityName { get; set; } = string.Empty;
    public string MajorName { get; set; } = string.Empty;
    public string MajorCode { get; set; } = string.Empty;
    public float StandardScore { get; set; }
    public float SafeMargin { get; set; }

    public bool IsPersonalityMatch { get; set; } // True nếu hợp tính cách
    public string MatchNote { get; set; } = string.Empty; // Ghi chú hiển thị
}