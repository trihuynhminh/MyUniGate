namespace UniGate.Api.DTOs
{
    // DTO để nhập dữ liệu phổ điểm
    public class GroupScoreDistributionDTO
    {
        public decimal TotalScoreLevel { get; set; } // 1–30
        public int CountStudents { get; set; }
    }

}
