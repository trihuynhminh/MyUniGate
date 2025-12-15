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
            if (string.IsNullOrWhiteSpace(request.Email))
                return BadRequest("Email is required.");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user != null)
            {
                var token = new PasswordResetToken
                {
                    UserID = user.UserID,
                    TokenCode = Guid.NewGuid().ToString(),
                    ExpiryDate = DateTime.UtcNow.AddHours(1),
                    IsUsed = false,
                    CreatedDate = DateTime.UtcNow
                };

                _context.PasswordResetTokens.Add(token);
                await _context.SaveChangesAsync();

                var resetLink = $"{_appDomain}/reset-password?token={token.TokenCode}";

                //Console.WriteLine($"[DEBUG] Reset link: {resetLink}");
                Console.WriteLine($"[DEBUG] Token: {token.TokenCode}");

                await SendEmailAsync(user.Email, "Reset your password",
                    $@"Use this token: <b>{token.TokenCode}</b></p>");
            }

            return Ok(new { message = "If the email exists, a reset link has been sent." });
        }

        // --------------------------
        // Reset Password
        // --------------------------
        [HttpPost("reset")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Token) || string.IsNullOrWhiteSpace(request.NewPassword))
                return BadRequest("Token and new password are required.");

            var token = await _context.PasswordResetTokens
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.TokenCode == request.Token);

            if (token == null || token.IsUsed || token.ExpiryDate < DateTime.UtcNow)
                return BadRequest("Invalid or expired token.");

            if (token.User == null)
                return BadRequest("Associated user not found.");

            // Cập nhật password
            token.User.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

            // Bắt EF Core track entity để chắc chắn cập nhật
            _context.Entry(token.User).State = EntityState.Modified;

            token.IsUsed = true;
            _context.Entry(token).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            Console.WriteLine($"[DEBUG] Password updated for user {token.User.Email}");
            return Ok(new { message = "Password has been reset successfully." });
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
