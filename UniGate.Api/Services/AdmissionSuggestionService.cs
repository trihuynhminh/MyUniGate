using Microsoft.EntityFrameworkCore;
using System.Linq;
using UniGate.Api.Models.DTOs; // Giữ lại DTOs, loại bỏ DTOs nếu bạn không có thư mục đó
using UniGate.Infrastructure;
using UniGate.Core.Entities;

namespace UniGate.Api.Services
{
    public class AdmissionSuggestionService
    {
        private readonly AppDbContext _context; // <--- KHAI BÁO BIẾN '_context' ĐÃ ĐƯỢC GIỮ NGUYÊN

        public AdmissionSuggestionService(AppDbContext context)
        {
            _context = context;
        }

        // Phương thức chính để lấy gợi ý
        public async Task<List<AdmissionSuggestionDto>> GetSuggestionsAsync(int userId)
        {
            // 1. Lấy thông tin điểm người dùng (UserScores) và khu vực (Users -> Regions)
            var user = await _context.Users
                .Include(u => u.UserScore)
                .Include(u => u.Region)
                .FirstOrDefaultAsync(u => u.UserID == userId);

            if (user == null || user.UserScore == null)
            {
                return new List<AdmissionSuggestionDto>();
            }

            var bonusScore = user.Region?.BonusScore ?? 0.00m;

            // ************ LOGIC TÍNH ĐIỂM NGƯỜI DÙNG ************
            // Định nghĩa userTotalA00Score ở đây để nó có phạm vi (scope) toàn bộ phương thức

            var thptToan = user.UserScore.Thpt_Toan ?? 0;
            // Đây là điểm mẫu (thực tế phải tính toán các môn THPT QG đã lưu)
            var userA00Score = thptToan + 20.00m;
            var userTotalA00Score = userA00Score + bonusScore; // <--- BIẾN 'userTotalA00Score' ĐÃ ĐƯỢC KHỞI TẠO ĐÚNG CÁCH
            // *******************************************************************


            // 2. Truy vấn dữ liệu điểm chuẩn (Admissions) VÀ JOIN SubjectGroups để lấy GroupName
            var suggestionsWithGroup = await _context.Admissions
                .Where(a => a.Year == 2024)

                // Giữ lại Include University và Major (cần thiết cho DTO)
                .Include(a => a.University)
                .Include(a => a.Major)

                // Thực hiện JOIN ngay trong Select để lấy GroupName mà không cần thuộc tính điều hướng 'Group'
                .Select(a => new
                {
                    Admission = a,
                    GroupName = _context.SubjectGroups
                                        .Where(g => g.GroupID == a.GroupID)
                                        .Select(g => g.GroupName)
                                        .FirstOrDefault()
                })
                .ToListAsync();


            // 3. Xử lý Logic So sánh và Tạo DTO
            var finalResults = suggestionsWithGroup
                .Select(s =>
                {
                    // Lấy điểm tính toán tương ứng với Khối (ví dụ A00)
                    // Biến 'userTotalA00Score' đã có thể truy cập tại đây
                    var calculatedScore = s.GroupName == "A00" ? userTotalA00Score : 0.00m;

                    return new AdmissionSuggestionDto
                    {
                        UniversityName = s.Admission.University.UniversityName,
                        MajorName = s.Admission.Major.MajorName,
                        MajorCode = s.Admission.Major.MajorCode,
                        GroupName = s.GroupName,
                        MinScore = s.Admission.MinScore,

                        UserCalculatedScore = calculatedScore,

                        // Logic so sánh
                        IsPassed = calculatedScore >= s.Admission.MinScore,
                        ScoreDifference = calculatedScore - s.Admission.MinScore
                    };
                })
                .Where(s => s.UserCalculatedScore > 0)
                .OrderByDescending(s => s.IsPassed)
                .ThenBy(s => s.ScoreDifference)
                .ToList();

            return finalResults;
        }
    }
}