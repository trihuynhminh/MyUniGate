namespace UniGate.Shared.DTOs
{
    public class MajorByComboRowDto
    {
        public int MajorId { get; set; }
        public string MajorCode { get; set; } = "";
        public string MajorName { get; set; } = "";

        public int UniversityId { get; set; }
        public string UniversityName { get; set; } = "";

        public int GroupId { get; set; }
        public string GroupName { get; set; } = "";   // ví dụ: A00

        public decimal MinScore { get; set; }
        public short Year { get; set; }
    }
}