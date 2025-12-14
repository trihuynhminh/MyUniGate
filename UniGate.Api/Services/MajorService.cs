using Microsoft.EntityFrameworkCore;
using UniGate.Infrastructure;
using UniGate.Core.Entities;
using UniGate.Api.DTOs;

namespace UniGate.Api.Services;

public class MajorService
{
    private readonly AppDbContext _context;

    public MajorService(AppDbContext context)
    {
        _context = context;
    }

    // Thêm tham số personalityType (có thể null nếu user chưa test)
    public async Task<List<MajorDto>> GetSuitableMajors(float studentScore, string group, string? personalityType = null)
    {
        decimal scoreDecimal = (decimal)studentScore;
        decimal minLimit = scoreDecimal - 3;

        // BƯỚC 1: Lấy danh sách ID các ngành hợp tính cách (Nếu có)
        List<int> suitableMajorIds = new List<int>();

        if (!string.IsNullOrEmpty(personalityType))
        {
            suitableMajorIds = await _context.CareerSuggestions
                .Where(c => c.ResultCode == personalityType) // VD: result = "INTJ"
                .Select(c => c.MajorID)
                .ToListAsync();
        }

        // BƯỚC 2: Query bảng điểm chuẩn (như cũ)
        var query = _context.Admissions
            .Include(a => a.University)
            .Include(a => a.Major)
            .Include(a => a.SubjectGroup)
            .Where(a => a.SubjectGroup!.GroupName == group &&
                        a.MinScore <= scoreDecimal &&
                        a.MinScore >= minLimit);

        // BƯỚC 3: Map ra DTO và kiểm tra tính cách
        var result = await query.Select(a => new MajorDto
        {
            UniversityName = a.University!.UniversityName,
            MajorName = a.Major!.MajorName,
            MajorCode = a.Major.MajorCode ?? "",
            StandardScore = (float)a.MinScore,
            SafeMargin = (float)(scoreDecimal - a.MinScore),

            // Kiểm tra xem MajorID hiện tại có nằm trong list hợp tính cách không
            IsPersonalityMatch = suitableMajorIds.Contains(a.MajorID),
            MatchNote = suitableMajorIds.Contains(a.MajorID) ? "Phù hợp tính cách của bạn" : ""
        })
        .ToListAsync(); // Lấy về RAM để sắp xếp cho dễ

        // BƯỚC 4: Sắp xếp (Ưu tiên Hợp tính cách -> Sau đó tới Điểm an toàn)
        return result
            .OrderByDescending(m => m.IsPersonalityMatch) // True lên đầu
            .ThenBy(m => m.SafeMargin)                  // Điểm an toàn cao lên tiếp
            .ToList();
    }
}