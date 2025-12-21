using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniGate.Core.Entities;
using UniGate.Infrastructure;
using UniGate.Api.DTOs;

namespace UniGate.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupScoreDistributionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public GroupScoreDistributionsController(AppDbContext context)
    {
        _context = context;
    }

    
    // =========================================================
    // READ: Xem phổ điểm theo groupCode + năm
    // =========================================================
    [HttpGet]
    public async Task<IActionResult> Get(string groupCode, short year)
    {
        var group = await _context.SubjectGroups
            .FirstOrDefaultAsync(g => g.GroupName == groupCode);

        if (group == null)
            return BadRequest(new { success = false, message = $"Tổ hợp {groupCode} không tồn tại" });

        var data = await _context.GroupScoreDistributions
            .Where(x => x.GroupID == group.GroupID && x.ExamYear == year)
            .OrderBy(x => x.TotalScoreLevel)
            .ToListAsync();

        if (!data.Any())
            return Ok(new
            {
                success = false,
                message = "Phổ điểm đang được cập nhật",
                data = new object[0]
            });

        return Ok(new { success = true, data });
    }

    // =========================================================
    // CREATE: Thêm toàn bộ phổ điểm (1–30)
    // =========================================================
    [HttpPost("add")]
    public async Task<IActionResult> Add(string groupCode, short year, List<GroupScoreDistributionDTO> items)
    {
        var group = await _context.SubjectGroups
            .FirstOrDefaultAsync(g => g.GroupName == groupCode);

        if (group == null)
            return BadRequest(new { success = false, message = $"Tổ hợp {groupCode} không tồn tại" });

        int groupID = group.GroupID;

        // Kiểm tra đã tồn tại
        bool existed = await _context.GroupScoreDistributions
            .AnyAsync(x => x.GroupID == groupID && x.ExamYear == year);

        if (existed)
            return BadRequest(new { success = false, message = "Phổ điểm đã tồn tại" });

        if (items.Count != 30)
            return BadRequest("Phổ điểm phải đủ 30 mức điểm (1–30)");

        if (items.Any(x => x.TotalScoreLevel < 1 || x.TotalScoreLevel > 30))
            return BadRequest("Mức điểm không hợp lệ");

        // Tạo entity
        var entities = items.Select(x => new GroupScoreDistribution
        {
            GroupID = groupID,
            ExamYear = year,
            TotalScoreLevel = x.TotalScoreLevel,
            CountStudents = x.CountStudents,
            ProbDistribution = 0m
        }).ToList();

        _context.GroupScoreDistributions.AddRange(entities);
        await _context.SaveChangesAsync();

        // Tính xác suất
        int totalStudents = entities.Sum(e => e.CountStudents);
        if (totalStudents > 0)
        {
            foreach (var e in entities)
                e.ProbDistribution = (decimal)e.CountStudents / totalStudents;

            await _context.SaveChangesAsync();
        }

        return Ok(new { success = true, message = "Thêm phổ điểm thành công" });
    }

    // =========================================================
    // UPDATE: Sửa toàn bộ phổ điểm
    // =========================================================
    [HttpPut("update")]
    public async Task<IActionResult> Update(string groupCode, short year, List<GroupScoreDistributionDTO> items)
    {
        var group = await _context.SubjectGroups
            .FirstOrDefaultAsync(g => g.GroupName == groupCode);

        if (group == null)
            return BadRequest(new { success = false, message = $"Tổ hợp {groupCode} không tồn tại" });

        int groupID = group.GroupID;

        var oldData = await _context.GroupScoreDistributions
            .Where(x => x.GroupID == groupID && x.ExamYear == year)
            .ToListAsync();

        if (!oldData.Any())
            return BadRequest(new { success = false, message = "Không có phổ điểm để cập nhật" });

        if (items.Count != 30)
            return BadRequest("Phổ điểm phải đủ 30 mức điểm (1–30)");

        // Xóa cũ
        _context.GroupScoreDistributions.RemoveRange(oldData);

        // Thêm mới
        var entities = items.Select(x => new GroupScoreDistribution
        {
            GroupID = groupID,
            ExamYear = year,
            TotalScoreLevel = x.TotalScoreLevel,
            CountStudents = x.CountStudents,
            ProbDistribution = 0m
        }).ToList();

        _context.GroupScoreDistributions.AddRange(entities);
        await _context.SaveChangesAsync();

        // Tính xác suất
        int totalStudents = entities.Sum(e => e.CountStudents);
        if (totalStudents > 0)
        {
            foreach (var e in entities)
                e.ProbDistribution = (decimal)e.CountStudents / totalStudents;

            await _context.SaveChangesAsync();
        }

        return Ok(new { success = true, message = "Cập nhật phổ điểm thành công" });
    }

    // =========================================================
    // DELETE: Xóa toàn bộ phổ điểm
    // =========================================================
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(string groupCode, short year)
    {
        var group = await _context.SubjectGroups
            .FirstOrDefaultAsync(g => g.GroupName == groupCode);

        if (group == null)
            return BadRequest(new { success = false, message = $"Tổ hợp {groupCode} không tồn tại" });

        int groupID = group.GroupID;

        var data = await _context.GroupScoreDistributions
            .Where(x => x.GroupID == groupID && x.ExamYear == year)
            .ToListAsync();

        if (!data.Any())
            return Ok(new { success = false, message = "Không có phổ điểm để xóa" });

        _context.GroupScoreDistributions.RemoveRange(data);
        await _context.SaveChangesAsync();

        return Ok(new { success = true, message = "Đã xóa toàn bộ phổ điểm", deletedRows = data.Count });
    }
}
