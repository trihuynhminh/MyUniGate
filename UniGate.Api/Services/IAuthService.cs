using UniGate.Api.DTOs;

namespace UniGate.Api.Services
{
    public interface IAuthService
    {
        // Hàm đăng ký trả về true nếu thành công, hoặc ném Exception nếu lỗi
        Task<bool> RegisterAsync(RegisterRequest request);

        // Hàm Login trả về AuthResponse chứa Token
        Task<AuthResponse> LoginAsync(LoginRequest request);
    }
}