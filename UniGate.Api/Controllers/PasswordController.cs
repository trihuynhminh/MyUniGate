using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniGate.Infrastructure;
using UniGate.Core.Entities;
using MailKit.Net.Smtp;
using MimeKit;
using UniGate.Api.DTOs;
using System;
using System.Threading.Tasks;

namespace UniGate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly SmtpSettings _smtpSettings;
        private readonly string _appDomain;

        public PasswordController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _smtpSettings = config.GetSection("SMTP").Get<SmtpSettings>()
                            ?? throw new Exception("SMTP config missing");
            _appDomain = config.GetValue<string>("AppDomain") ?? "https://localhost:7062";
        }

        // --------------------------
        // Forgot Password
        // --------------------------
        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(request.Email))
                return BadRequest(new { message = "Email không được để trống." });

            // 2. Kiểm tra tồn tại trong Database
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                // Trả về 404 để WinForms báo lỗi "Email không tồn tại"
                return NotFound(new { message = "Email này chưa được đăng ký trong hệ thống!" });
            }

            // --- BỔ SUNG: Vô hiệu hóa các mã cũ chưa sử dụng của User này ---
            var oldTokens = await _context.PasswordResetTokens
                .Where(t => t.UserID == user.UserID && t.IsUsed == false)
                .ToListAsync();
            foreach (var oldToken in oldTokens)
            {
                oldToken.IsUsed = true; // Coi như đã hỏng, không cho dùng nữa
            }
            // -----------------------------------------------------------

            // 3. Tạo Token
            var token = new PasswordResetToken
            {
                UserID = user.UserID,
                TokenCode = Guid.NewGuid().ToString().Substring(0, 6).ToUpper(), // Token ngắn 6 ký tự cho dễ nhập
                ExpiryDate = DateTime.UtcNow.AddMinutes(15), // Hết hạn sau 15p
                IsUsed = false,
                CreatedDate = DateTime.UtcNow
            };

            _context.PasswordResetTokens.Add(token);
            await _context.SaveChangesAsync();

            // 4. Gửi Email (Chạy ngầm)
            try
            {
                await SendEmailAsync(user.Email, "Mã xác thực đổi mật khẩu",
                    $@"<h3>Mã xác thực của bạn là: <b style='color:red;'>{token.TokenCode}</b></h3>
                   <p>Mã này có hiệu lực trong 15 phút.</p>");

                return Ok(new { message = "Mã xác thực đã được gửi tới Email của bạn." });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Lỗi khi gửi Email. Vui lòng thử lại sau." });
            }
        }
        

        // --------------------------
        // Reset Password
        // --------------------------
        [HttpPost("reset")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            // 1. Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(request.Token) || string.IsNullOrWhiteSpace(request.NewPassword))
                return BadRequest(new { message = "Token và mật khẩu mới không được để trống." });

            // 2. Tìm Token trong DB và nạp luôn thông tin User (Include)
            var tokenEntry = await _context.PasswordResetTokens
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.TokenCode == request.Token);

            // 3. Kiểm tra tính hợp lệ của Token
            if (tokenEntry == null)
                return NotFound(new { message = "Mã xác nhận không chính xác." });

            if (tokenEntry.IsUsed)
                return BadRequest(new { message = "Mã xác nhận này đã được sử dụng trước đó." });

            if (tokenEntry.ExpiryDate < DateTime.UtcNow)
                return BadRequest(new { message = "Mã xác nhận đã hết hạn (quá 15 phút)." });

            if (tokenEntry.User == null)
                return BadRequest(new { message = "Không tìm thấy người dùng liên quan." });

            // 4. Cập nhật mật khẩu mới (Đã dùng BCrypt như bạn đã viết)
            tokenEntry.User.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

            // 5. Đánh dấu Token đã sử dụng để không cho dùng lại lần 2
            tokenEntry.IsUsed = true;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "Mật khẩu đã được cập nhật thành công!" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Lỗi hệ thống khi cập nhật mật khẩu." });
            }
        }


        // --------------------------
        // Send Email
        // --------------------------
        private async Task SendEmailAsync(string toEmail, string subject, string htmlBody)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_smtpSettings.FromName, _smtpSettings.FromEmail));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlBody };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.User, _smtpSettings.AppPassword);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);

            Console.WriteLine($"[DEBUG] Email sent to {toEmail}");
        }
    }

    
}
