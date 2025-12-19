namespace UniGate.Shared.DTOs
{
    public class MajorUpsertDto
    {
        public int? Id { get; set; } // null = add, có = edit

        public string? MajorCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int UniversityID { get; set; }
        public short Year { get; set; }
        public decimal MinScore { get; set; }

        public List<int> GroupIds { get; set; } = new();
    }
}
