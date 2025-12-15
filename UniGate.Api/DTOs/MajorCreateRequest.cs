namespace UniGate.Api.DTOs
{
    public class MajorCreateRequest
    {
        public string? MajorCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<int> GroupIds { get; set; } = new();
        public short? ExamYear { get; set; }
    }
}
