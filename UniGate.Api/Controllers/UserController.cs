using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniGate.Core.Entities;
using UniGate.Infrastructure;
using UniGate.Api.DTOs; // Nhớ dòng này để nhận diện RegisterRequest

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

    // --- API ĐĂNG KÝ (Đã sửa) ---
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        // 1. Kiểm tra request null
        if (request == null) return BadRequest("Dữ liệu gửi lên bị rỗng!");

        // 2. Kiểm tra trùng Email
        if (await _context.Users.AnyAsync(u => u.Email == request.Email))
        {
            return BadRequest("Email này đã được đăng ký!");
        }

        // 3. Tạo User mới từ thông tin Request
        var newUser = new User
        {
            FullName = request.FullName,
            Email = request.Email,
            PasswordHash = request.Password, // Lưu ý: Thực tế nên mã hóa password nhé
            
            CreatedAt = DateTime.Now,
            RoleID = 2, // Mặc định đăng ký mới là Student (Role=2). Đừng để 1 là Admin nguy hiểm lắm!
            RegionID = request.RegionID == 0 ? 1 : request.RegionID // Nếu không chọn thì mặc định vùng 1
        };

        // 4. Lưu vào Database
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Đăng ký thành công!", userId = newUser.UserID });
    }

    // --- CÁC API KHÁC GIỮ NGUYÊN ---

    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound("Không tìm thấy người dùng này!");

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
                u.UserID,
                u.FullName,
                u.Email,
                u.RoleID,
                u.CreatedAt
            })
            .ToListAsync();

        return Ok(users);
    }

    // API Đăng nhập
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email && u.PasswordHash == request.Password);

        if (user == null)
        {
            return Unauthorized("Sai Email hoặc Mật khẩu rồi!");
        }

        return Ok(new
        {
            user.UserID,
            user.FullName,
            user.Email,
            user.RoleID
        });
    }
}

// Class DTO nhận dữ liệu đăng nhập
public class LoginRequest
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}