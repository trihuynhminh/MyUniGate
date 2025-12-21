using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UniGate.Student.Services
{
    public static class ValidationService
    {
        /// <summary>
        /// Kiểm tra định dạng Email chuẩn
        /// </summary>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            // Regex chuẩn để bắt các định dạng email phổ biến
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        /// <summary>
        /// Kiểm tra mật khẩu: Tối thiểu 8 ký tự, phải có cả CHỮ và SỐ
        /// </summary>
        public static bool IsStrongPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;

            // 1. Kiểm tra độ dài tối thiểu 8
            if (password.Length < 8) return false;

            // 2. Kiểm tra có ít nhất 1 chữ cái (a-z, A-Z)
            bool hasLetter = password.Any(char.IsLetter);

            // 3. Kiểm tra có ít nhất 1 chữ số (0-9)
            bool hasDigit = password.Any(char.IsDigit);

            return hasLetter && hasDigit;
        }
    }
}
