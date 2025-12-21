using UniGate.Api.DTOs;
using System.Threading.Tasks;

namespace UniGate.Api.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterRequest request);

        // Sửa lại: Chỉ nhận 1 tham số request, trả về AuthResponse
        Task<AuthResponse> LoginAsync(LoginRequest request);
    }
}