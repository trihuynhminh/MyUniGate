using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using UniGate.Api.DTOs; // Đảm bảo namespace này đúng

namespace UniGate.Admin.Forms
{
    public partial class SuggestForm : Form
    {
        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7062/") // Port API của bạn
        };

        public SuggestForm()
        {
            InitializeComponent();
            dgvKetQua.CellFormatting += dgvKetQua_CellFormatting; // Đăng ký tô màu
        }

        private async void btnXemGoiY_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtTongDiem.Text, out int userId))
            {
                MessageBox.Show("Vui lòng nhập UserId hợp lệ để lấy điểm từ hệ thống.");
                return;
            }

            var request = new MajorPredictionRequest
            {
                UserId = userId,
                ExamYear = short.Parse(cboChonVung.SelectedItem?.ToString() ?? "2024")
            };

            try
            {
                btnXemGoiY.Enabled = false;
                var response = await _httpClient.PostAsJsonAsync("api/AdmissionSuggestion/predict", request);

                if (response.IsSuccessStatusCode)
                {
                    var results = await response.Content.ReadFromJsonAsync<List<AdmissionSuggestionDto>>();
                    dgvKetQua.DataSource = results;
                }
                else
                {
                    MessageBox.Show("Lỗi kết nối Server.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally { btnXemGoiY.Enabled = true; }
        }

        // ⭐ TO MÀU DÒNG KẾT QUẢ ĐỂ HOÀN THÀNH NHIỆM VỤ
        private void dgvKetQua_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKetQua.Columns[e.ColumnIndex].Name == "Status" && e.RowIndex >= 0)
            {
                var data = dgvKetQua.Rows[e.RowIndex].DataBoundItem as AdmissionSuggestionDto;
                if (data != null)
                {
                    if (data.IsPassed)
                    {
                        e.Value = "ĐẬU";
                        dgvKetQua.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (data.ScoreDifference >= -1) // Suýt soát đậu
                    {
                        e.Value = "CÂN NHẮC";
                        dgvKetQua.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                    else
                    {
                        e.Value = "RỚT";
                        dgvKetQua.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                    }
                }
            }
        }

        private void SuggestForm_Load(object sender, EventArgs e)
        {
            cboChonVung.Items.AddRange(new object[] { "2023", "2024", "2025" });
            cboChonVung.SelectedIndex = 1;
        }
    }
}