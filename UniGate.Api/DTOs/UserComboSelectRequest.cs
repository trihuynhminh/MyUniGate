namespace UniGate.Api.DTOs
{
    public class UserComboSelectRequest
    {
        public int UserId { get; set; }
        public List<string>? GroupNames { get; set; } // ví dụ: ["A00", "A01", "D01"]
    }
}
