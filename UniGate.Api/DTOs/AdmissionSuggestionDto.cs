namespace UniGate.Api.Models.DTOs
{
    public class AdmissionSuggestionDto
    {
        // Thông tin Ngành và Trường
        public string UniversityName { get; set; }
        public string MajorName { get; set; }
        public string MajorCode { get; set; }

        // Thông tin Khối thi và Điểm chuẩn
        public string GroupName { get; set; }
        public decimal MinScore { get; set; } // Điểm chuẩn năm đó

        // Thông tin Người dùng và Kết quả
        public decimal UserCalculatedScore { get; set; } // Điểm của người dùng sau khi cộng ưu tiên
        public decimal ScoreDifference { get; set; } // Chênh lệch điểm (UserScore - MinScore)
        public bool IsPassed { get; set; } // True nếu UserCalculatedScore >= MinScore
    }
}
