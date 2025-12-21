using Microsoft.AspNetCore.Mvc;
using UniGate.Api.DTOs;
using UniGate.Api.Services;

namespace UniGate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            // Kiểm tra validate (DataAnnotations trong DTO)
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _authService.RegisterAsync(request);
                return Ok(new { Message = "Đăng ký thành công!" });
            }
            catch (Exception ex)
            {
                // Trả về lỗi 400 kèm thông báo từ Service (ví dụ: Email trùng)
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UniGate.Api.DTOs.LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _authService.LoginAsync(request);
                return Ok(result); // Trả về Token
            }
            catch (Exception ex)
            {
                // Trả về 401 Unauthorized nếu sai tk/mk
                return Unauthorized(new { Message = ex.Message });
            }
        }
    }
}