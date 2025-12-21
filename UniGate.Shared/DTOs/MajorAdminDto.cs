

namespace UniGate.Shared.DTOs;

public class MajorAdminDto
{
    public int Id { get; set; }              // ❗ KHÔNG PHẢI MajorID
    public string? MajorCode { get; set; }
    public string? Name { get; set; }        // ❗ KHÔNG PHẢI MajorName
    public string? Description { get; set; }

    public int SchoolId { get; set; }
    public string? SchoolName { get; set; }

    public int Year { get; set; }
    public decimal CutoffScore { get; set; }

    public List<string> Combos { get; set; } = new();
}
