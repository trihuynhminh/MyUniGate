/*trí dùng để lọc ngành*/
namespace UniGate.Api.DTOs;

public class FilterRequest
{
    public float Score { get; set; }       // Điểm thi (VD: 24.5)
    public string Group { get; set; } = ""; // Khối thi (VD: "A00")
    public string? PersonalityType { get; set; }
}