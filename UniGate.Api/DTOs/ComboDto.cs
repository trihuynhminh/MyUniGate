namespace UniGate.Api.DTOs
{
    public class ComboDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public List<string> Subjects { get; set; } = new();
    }
}
