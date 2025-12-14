using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniGate.Core.Entities;
using UniGate.Infrastructure;

namespace UniGate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;
    public UserController(AppDbContext context)
    {
        _context = context;
    }

    //api đăng ký
    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        if (await _context.Users.AnyAsync(u => u.Email == user.Email))
        {
            return BadRequest("Email này đã được đăng ký!");
        }
        user.RoleID = 1;
        user.CreatedAt = DateTime.Now; // Gán ngày tạo

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Đăng ký thành công!", userId = user.UserID });
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound("Không tìm thấy ông này đâu!");
        }

        // Trả về dữ liệu (ẩn pass đi)
        return Ok(new
        {
            user.UserID,
            user.FullName,
            user.Email,
            user.RoleID,
            user.CreatedAt
        });
    }

    // GET: api/User/get-all
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _context.Users
            .Select(u => new
            {
                u.UserID,       // Lấy ID
                u.FullName,     // Lấy tên đầy đủ
                u.Email,        // Lấy Email
                u.RoleID,       // Lấy quyền
                u.CreatedAt     // Lấy ngày tạo
                // KHÔNG LẤY PASSWORD NHA
            })
            .ToListAsync();

        return Ok(users);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // Tìm user có Email và Password khớp
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email && u.PasswordHash == request.Password);

        if (user == null)
        {
            return Unauthorized("Sai Email hoặc Mật khẩu rồi!");
        }

        // Trả về thông tin (Che mật khẩu đi cho an toàn)
        return Ok(new
        {
            user.UserID,
            user.FullName,
            user.Email,
            user.RoleID
        });
    }
}
// Class hứng dữ liệu gửi lên
public class LoginRequest
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}