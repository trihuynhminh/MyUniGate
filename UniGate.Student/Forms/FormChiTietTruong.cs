using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using UniGate.Shared.DTOs;

namespace UniGate.Student.Forms
{
    public partial class FormChiTietTruong : Form
    {
        private readonly int _universityId;

        private readonly HttpClient _http = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7062/")
        };
        public FormChiTietTruong(int universityId)
        {
            InitializeComponent();
            _universityId = universityId;
        }

        private async void FormChiTietTruong_Load(object sender, EventArgs e)
        {
            try
            {
                var data = await _http.GetFromJsonAsync<UniversityDto>(
                    $"api/universities/{_universityId}");

                if (data == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin trường");
                    this.Close();
                    return;
                }

                BindData(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin trường:\n" + ex.Message);
            }
        }

        private void BindData(UniversityDto u)
        {
            txtUniversityCode.Text = u.UniversityCode ?? "";
            txtUniversityName.Text = u.UniversityName;
            txtProvince.Text = u.Province ?? "";
            linklabel_Website.Text = u.Website ?? "";
            richtextbox_descriptionchitiet.Text = u.Description ?? "";

            // Website
            linklabel_Website.Text = u.Website ?? "";
            linklabel_Website.Links.Clear();

            if (!string.IsNullOrWhiteSpace(u.Website))
            {
                linklabel_Website.Links.Add(
                    0,
                    linklabel_Website.Text.Length,
                    u.Website
                );
            }

            // Disable edit (chỉ xem)
            txtUniversityCode.ReadOnly = true;
            txtUniversityName.ReadOnly = true;
            txtProvince.ReadOnly = true;
            richtextbox_descriptionchitiet.ReadOnly = true;

            LoadLogo(u.LogoUrl);
        }

        // =============================
        // LOAD LOGO
        // =============================
        private void LoadLogo(string? logoUrl)
        {
            picturebox_logo.Image = null;

            if (string.IsNullOrWhiteSpace(logoUrl))
                return;

            try
            {
                picturebox_logo.SizeMode = PictureBoxSizeMode.Zoom;
                picturebox_logo.LoadAsync(logoUrl);
            }
            catch
            {
                // nếu lỗi load ảnh → bỏ qua, không crash
            }
        }

    
        private void linklabel_Website_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = e.Link.LinkData?.ToString();

            if (string.IsNullOrWhiteSpace(url))
                return;

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch
            {
                MessageBox.Show("Không thể mở website");
            }
        }
    }
}
