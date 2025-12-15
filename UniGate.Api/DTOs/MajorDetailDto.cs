namespace UniGate.Api.DTOs
{
    public class MajorDetailDto
    {
        public int Id { get; set; }
        public string? MajorCode { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public List<string> Combos { get; set; } = new();
    }
}
