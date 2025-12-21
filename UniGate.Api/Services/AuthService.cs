using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens; // Cần cái này cho JWT
using System.Security.Claims; // Cần cái này cho Claims
using System.Text;
using UniGate.Api.DTOs;
using UniGate.Core.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using UniGate.Infrastructure;

namespace UniGate.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration; // Để đọc key JWT

        public AuthService(AppDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            // 1. Kiểm tra Email đã tồn tại chưa
            var existingUser = await _db.Users
                .AsNoTracking() // Tối ưu hiệu năng vì chỉ cần kiểm tra
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (existingUser != null)
            {
                throw new Exception("Email này đã được sử dụng.");
            }

            // 2. Mã hóa mật khẩu (Quan trọng!)
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // 3. Xác định Role mặc định (Ví dụ: Student)
            // Tìm Role ID = 1 hoặc theo tên "Student"
            var defaultRole = await _db.Roles.FirstOrDefaultAsync(r => r.RoleName == "Student");
            int roleId = defaultRole?.RoleID ?? 1; // Fallback về 1 nếu không tìm thấy

            // 4. Tạo Entity User mới
            var newUser = new User
            {
                Email = request.Email,
                PasswordHash = passwordHash, // Lưu pass đã mã hóa
                FullName = request.FullName,
                RoleID = roleId,
                RegionID = request.RegionID,
                CreatedAt = DateTime.Now
            };

            // 5. Lưu vào Database
            _db.Users.Add(newUser);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            // 1. Tìm user theo Email
            // Include Role để lấy tên quyền hạn (Admin/Student)
            var user = await _db.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
            {
                throw new Exception("Tài khoản không tồn tại.");
            }

            // 2. Kiểm tra mật khẩu (So sánh pass nhập vào với Hash trong DB)
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                throw new Exception("Mật khẩu không chính xác.");
            }

            // 3. Tạo JWT Token
            string token = CreateToken(user);

            // 4. Trả về kết quả
            return new AuthResponse
            {
                Token = token,
                FullName = user.FullName ?? "",
                Role = user.Role?.RoleName ?? "Student"
            };
        }

        // Hàm phụ trợ để tạo chuỗi Token
        private string CreateToken(UniGate.Core.Entities.User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()), // Lưu ID user
                new Claim(ClaimTypes.Name, user.FullName ?? ""),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role?.RoleName ?? "Student") // Lưu Role
            };
            // Nếu có RegionID thì thêm vào luôn nếu cần
            if (user.RegionID.HasValue)
                claims.Add(new Claim("RegionID", user.RegionID.Value.ToString()));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JwtSettings:Key").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1), // Token hết hạn sau 1 ngày
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}