namespace UniGate.Api.DTOs
{
    public class ComboDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = "";
        public List<string> Subjects { get; set; } = new();
    }
}
