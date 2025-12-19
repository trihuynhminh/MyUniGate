namespace UniGate.Student.Models
{
    public class LoginResultDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = "";
        public string Role { get; set; } = "";
    }
}
