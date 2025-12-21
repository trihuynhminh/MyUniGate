using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniGate.Admin.Services;
using UniGate.Shared.DTOs;

namespace UniGate.Admin.Forms
{
    public partial class FormThemTruong : Form
    {
        private readonly UniversityService _service = new();
        private bool _isEdit = false;
        private int _universityId;
        public FormThemTruong()
        {
            InitializeComponent();
            txtWebsite.ForeColor = Color.Blue;
            txtWebsite.Cursor = Cursors.Hand;
        }

        public FormThemTruong(UniversityDto uni) : this()
        {
            _isEdit = true;
            _universityId = uni.UniversityID;

            txtUniversityCode.Text = uni.UniversityCode;
            txtUniversityName.Text = uni.UniversityName;
            txtProvince.Text = uni.Province;
            txtWebsite.Text = uni.Website;
            richTextBox1_description.Text = uni.Description;
            txtLogo.Text = uni.LogoUrl;

        }

        //load logo từ link image
        private void txtLogo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLogo.Text))
                {
                    picturebox_logo.Image = null;
                    return;
                }

                picturebox_logo.Load(txtLogo.Text.Trim());
                picturebox_logo.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
                picturebox_logo.Image = null;
            }
        }

        //nhấn double mở link trường
        private void txtWebsite_DoubleClick(object sender, EventArgs e)
        {
            var url = txtWebsite.Text.Trim();
            if (string.IsNullOrWhiteSpace(url)) return;

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                url = "https://" + url;

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch
            {
                MessageBox.Show(
                    "Link website không hợp lệ!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // validate tối thiểu
            if (string.IsNullOrWhiteSpace(txtUniversityCode.Text) ||
                string.IsNullOrWhiteSpace(txtUniversityName.Text))
            {
                MessageBox.Show(
                    "Mã trường và Tên trường là bắt buộc!",
                    "Thiếu thông tin",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                if (_isEdit)
                {
                    var req = new UniversityUpdateRequest
                    {
                        UniversityID = _universityId,
                        UniversityCode = txtUniversityCode.Text.Trim(),
                        UniversityName = txtUniversityName.Text.Trim(),
                        Province = txtProvince.Text.Trim(),
                        Website = txtWebsite.Text.Trim(),
                        Description = richTextBox1_description.Text.Trim(),
                        LogoUrl = txtLogo.Text.Trim()
                    };

                    await _service.UpdateAsync(_universityId, req);
                }
                else
                {
                    var req = new UniversityCreateRequest
                    {
                        UniversityCode = txtUniversityCode.Text.Trim(),
                        UniversityName = txtUniversityName.Text.Trim(),
                        Province = txtProvince.Text.Trim(),
                        Website = txtWebsite.Text.Trim(),
                        Description = richTextBox1_description.Text.Trim(),
                        LogoUrl = txtLogo.Text.Trim()
                    };

                    await _service.CreateAsync(req);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lưu thất bại:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
