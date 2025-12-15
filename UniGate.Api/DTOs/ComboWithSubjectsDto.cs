namespace UniGate.Api.DTOs
{
    public class ComboWithSubjectsDto
    {
        public string Code { get; set; } = "";
        public List<string> Subjects { get; set; } = new();
    }
}
