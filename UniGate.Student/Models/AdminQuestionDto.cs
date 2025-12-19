using UniGate.Admin.Models;

namespace UniGate.Admin.Models
{
    public class AdminQuestionDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = "";
        public string Group { get; set; } = "";
        public bool IsActive { get; set; } = true;
    }
}
