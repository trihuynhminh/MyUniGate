using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniGate.Infrastructure;

namespace UniGate.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScoreAnalysisController : ControllerBase
{
    private readonly AppDbContext _context;

    public ScoreAnalysisController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> AnalyzeScore(
    [FromQuery] string groupCode,
    [FromQuery] short year,
    [FromQuery] decimal userScore)
    {
        // ===== Lấy GroupID từ tên tổ hợp =====
        var group = await _context.SubjectGroups
            .SingleOrDefaultAsync(g => g.GroupName == groupCode);

        if (group == null)
        {
            return Ok(new
            {
                message = $"Không tìm thấy tổ hợp '{groupCode}'",
                data = (object?)null
            });
        }

        int groupId = group.GroupID;

        // ===== Lấy dữ liệu phổ điểm =====
        var rawData = await _context.GroupScoreDistributions
            .Where(x => x.GroupID == groupId && x.ExamYear == year)
            .ToListAsync();

        if (!rawData.Any())
        {
            return Ok(new
            {
                message = $"Chưa có dữ liệu phổ điểm cho tổ hợp '{groupCode}' năm {year}",
                data = (object?)null
            });
        }

        // ===== Chuẩn hóa phổ điểm 1 → 30 =====
        var scoreMap = rawData
            .GroupBy(x => (int)Math.Round(x.TotalScoreLevel))
            .ToDictionary(
                g => g.Key,
                g => g.Sum(x => x.CountStudents)
            );

        var chart = new List<object>();
        int totalStudents = 0;

        for (int score = 1; score <= 30; score++)
        {
            int count = scoreMap.ContainsKey(score) ? scoreMap[score] : 0;
            totalStudents += count;

            chart.Add(new { score, count });
        }

        // ===== Tính phân vị, trung vị =====
        int cumulative = 0;
        decimal? p25 = null;
        decimal? median = null;
        decimal? p75 = null;
        decimal percentBelowUser = 0;

        foreach (var item in chart)
        {
            int score = (int)item.GetType().GetProperty("score")!.GetValue(item)!;
            int count = (int)item.GetType().GetProperty("count")!.GetValue(item)!;

            cumulative += count;
            if (totalStudents == 0) continue;

            decimal ratio = (decimal)cumulative / totalStudents;

            if (p25 == null && ratio >= 0.25m) p25 = score;
            if (median == null && ratio >= 0.50m) median = score;
            if (p75 == null && ratio >= 0.75m) p75 = score;

            if (score <= userScore)
                percentBelowUser = ratio * 100;
        }

        string position =
            userScore >= p75 ? "Top 25%" :
            userScore >= median ? "Trên trung vị" :
            userScore >= p25 ? "Dưới trung vị" :
            "Nguy cơ thấp";

        return Ok(new
        {
            message = "Phân tích điểm thành công",
            data = new
            {
                userScore,
                totalStudents,
                percentile25 = p25,
                median,
                percentile75 = p75,
                percentBelowUser = Math.Round(percentBelowUser, 2),
                position,
                chart
            }
        });
    }

}
