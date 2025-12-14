/*controler trường đại học của trí, dùng lấy dữ liệu của trí*/
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniGate.Core.Entities;
using UniGate.Infrastructure;

namespace UniGate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversityController : ControllerBase
{
    private readonly AppDbContext _context;

    public UniversityController(AppDbContext context)
    {
        _context = context;
    }

    // 1. Lấy danh sách trường
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Universities.ToListAsync());
    }

    // 2. Thêm mới một trường
    [HttpPost]
    public async Task<IActionResult> Create(University uni)
    {
        _context.Universities.Add(uni);
        await _context.SaveChangesAsync();
        return Ok(uni);
    }

    //xoá một trường
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // Bước 1: Phải tìm xem cái trường đó có tồn tại không đã
        var uni = await _context.Universities.FindAsync(id);

        // Bước 2: Nếu tìm không ra (null) thì báo lỗi 404 Not Found
        if (uni == null)
        {
            return NotFound("Tìm đỏ mắt không thấy trường này đâu!");
        }

        // Bước 3: Nếu thấy thì lệnh chém
        _context.Universities.Remove(uni);

        // Bước 4: Lưu thay đổi vào Database (Lúc này mới xóa thật)
        await _context.SaveChangesAsync();

        // Bước 5: Báo về là xóa xong rồi
        return Ok(new { message = "Đã xóa banh xác!", idDeleted = id });
    }
}