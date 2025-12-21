using System.ComponentModel.DataAnnotations;

namespace UniGate.Api.DTOs
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Họ tên không được để trống")]
        public string FullName { get; set; } = string.Empty;

        // RegionID có thể null nếu người dùng chưa chọn khu vực lúc đăng ký
        public int? RegionID { get; set; }
    }
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; } = string.Empty;
    }

    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        // Có thể thêm RegionID, UserID nếu client cần
    }
}