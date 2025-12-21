using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniGate.Student.Services;

namespace UniGate.Student.Forms
{
    public partial class FormForgetPassword : Form
    {
        private readonly string _baseUrl = "https://localhost:7062/api/Password";
        private static readonly HttpClient _httpClient = new HttpClient();
        private int _secondsLeft = 0; // Đếm ngược gửi lại

        public FormForgetPassword()
        {
            InitializeComponent();
            SetupInitialUI();
        }

        private void SetupInitialUI()
        {
            // Ẩn các ô nhập liệu bước 2
            lblToken.Visible = txtToken.Visible = false;
            lblNewPassword.Visible = txtNewPassword.Visible = false;
            lblConfirmPassword.Visible = txtConfirmPassword.Visible = false;
            btnConfirm.Visible = false;
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (!ValidationService.IsValidEmail(email))
            {
                MessageBox.Show("Email không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnSend.Enabled = false;
                btnSend.Text = "Đang gửi...";

                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/forgot", new { Email = email });

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Mã xác thực đã được gửi!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Hiện UI bước 2
                    ShowResetFields();
                    StartResendCooldown(); // Bắt đầu đếm ngược 60s
                }
                else
                {
                    var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                    MessageBox.Show(error?["message"] ?? "Lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSend.Enabled = true;
                    btnSend.Text = "Gửi mã";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
                btnSend.Enabled = true;
            }
        }

        private void ShowResetFields()
        {
            txtEmail.Enabled = false;
            lblToken.Visible = txtToken.Visible = true;
            lblNewPassword.Visible = txtNewPassword.Visible = true;
            lblConfirmPassword.Visible = txtConfirmPassword.Visible = true;
            btnConfirm.Visible = true;
            txtToken.Focus();
        }

        private void StartResendCooldown()
        {
            _secondsLeft = 60;
            btnSend.Enabled = false;
            timerResend.Interval = 1000;
            timerResend.Start();
        }

        private void timerResend_Tick(object sender, EventArgs e)
        {
            if (_secondsLeft > 0)
            {
                _secondsLeft--;
                btnSend.Text = $"Gửi lại ({_secondsLeft}s)";
            }
            else
            {
                timerResend.Stop();
                btnSend.Enabled = true;
                btnSend.Text = "Gửi lại mã";
            }
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            string token = txtToken.Text.Trim();
            string newPass = txtNewPassword.Text.Trim();
            string confirmPass = txtConfirmPassword.Text.Trim();

            // 1. Kiểm tra mã OTP
            if (string.IsNullOrEmpty(token)) { MessageBox.Show("Vui lòng nhập mã!"); return; }

            // 2. Validation mật khẩu (Dùng Service của bạn)
            if (!ValidationService.IsStrongPassword(newPass))
            {
                MessageBox.Show("Mật khẩu phải tối thiểu 8 ký tự, bao gồm cả chữ và số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. So khớp
            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                return;
            }

            try
            {
                btnConfirm.Enabled = false;
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/reset", new { Token = token, NewPassword = newPass });

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thành công");
                    this.Close();
                }
                else
                {
                    var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                    MessageBox.Show(error?["message"] ?? "Lỗi xác thực mã");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            finally { btnConfirm.Enabled = true; }
        }
    }
}