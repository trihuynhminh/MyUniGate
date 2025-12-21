using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using UniGate.Api.DTOs;
using UniGate.Core.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using UniGate.Infrastructure; // Check lại namespace chứa AppDbContext của m

namespace UniGate.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;

        // CHỈ GIỮ 1 CONSTRUCTOR NÀY THÔI
        public AuthService(AppDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public AuthService()
        {
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            // 1. Check Email
            var existingUser = await _db.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (existingUser != null)
                throw new Exception("Email này đã được sử dụng.");

            // 2. Hash Password
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // 3. Lấy Role (Nên dùng hằng số hoặc Enum thay vì string cứng "Student" nếu được)
            var defaultRole = await _db.Roles.FirstOrDefaultAsync(r => r.RoleName == "Student");
            int roleId = defaultRole?.RoleID ?? 1;

            // 4. Tạo User
            var newUser = new User
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                FullName = request.FullName,
                RoleID = roleId,
                RegionID = request.RegionID,
                CreatedAt = DateTime.Now
            };

            _db.Users.Add(newUser);
            await _db.SaveChangesAsync();

            return true;
        }

        // SỬA LẠI HÀM NÀY: Khớp với Interface
        public async Task<AuthResponse> LoginAsync(string email, LoginRequest request)
        {
            // 1. Tìm user
            var user = await _db.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
                throw new Exception("Tài khoản hoặc mật khẩu không chính xác."); // Gộp thông báo lỗi để bảo mật hơn

            // 2. Check Pass
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isPasswordValid)
                throw new Exception("Tài khoản hoặc mật khẩu không chính xác.");

            // 3. Tạo Token
            string token = CreateToken(user);

            // 4. Trả về
            return new AuthResponse
            {
                Token = token,
                FullName = user.FullName ?? "",
                Role = user.Role?.RoleName ?? "Student"
            };
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new Claim(ClaimTypes.Name, user.FullName ?? ""),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role?.RoleName ?? "Student")
            };

            if (user.RegionID.HasValue)
                claims.Add(new Claim("RegionID", user.RegionID.Value.ToString()));

            // Lấy key từ appsettings.json
            var keyString = _configuration.GetSection("JwtSettings:Key").Value;
            if (string.IsNullOrEmpty(keyString)) throw new Exception("JWT Key chưa được cấu hình!");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<AuthResponse?> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}