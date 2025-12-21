using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UniGate.Admin.Forms
{
    public partial class FormQuanLiPhoDiem : Form
    {
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7062/") };
        private Chart chartPreview;

        public FormQuanLiPhoDiem()
        {
            InitializeComponent();
            // Khởi tạo UI cho Grid trước
            SetupAdminUI();

            // Khởi tạo Chart ngay tại đây để chắc chắn nó không bị null
            InitChart();
        }

        private void SetupAdminUI()
        {
            // Cấu hình Năm
            numYear.Minimum = 2000;
            numYear.Maximum = 2100;
            numYear.Value = 2024;

            // Khởi tạo Grid 30 dòng
            dgvDist.Columns.Clear();
            dgvDist.Columns.Add("Level", "Mức điểm");
            dgvDist.Columns.Add("Count", "Số lượng thí sinh");
            dgvDist.Columns[0].ReadOnly = true;
            dgvDist.AllowUserToAddRows = false;
            for (int i = 1; i <= 30; i++) dgvDist.Rows.Add(i, 0);

            // Gắn sự kiện để cập nhật biểu đồ khi nhập số vào Grid
            dgvDist.CellEndEdit += (s, e) => UpdatePreviewChart();
        }

        private async void FormQuanLiPhoDiem_Load(object sender, EventArgs e)
        {

            await LoadGroups();
        }

        private void InitChart()
        {
            chartPreview = new Chart { Dock = DockStyle.Fill };
            ChartArea area = new ChartArea("Main");

            // Trục X cố định từ 0-30 điểm
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = 30;
            area.AxisX.Interval = 1;

            // Trục Y: ĐỂ TỰ ĐỘNG hoàn toàn
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = double.NaN; // Đây là chìa khóa để tự fix giá trị lớn
            area.AxisY.Interval = double.NaN;

            // Thêm lưới mờ cho dễ nhìn
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.MajorGrid.LineColor = Color.LightGray;

            chartPreview.ChartAreas.Add(area);
            pnlChart.Controls.Clear();
            pnlChart.Controls.Add(chartPreview);
        }

        private async Task LoadGroups()
        {
            var json = await _httpClient.GetStringAsync("api/subject-groups");
            cbGroup.DataSource = JsonConvert.DeserializeObject<List<SubjectGroupDto>>(json);
            cbGroup.DisplayMember = "GroupName";
        }

        // --- CÁC CHỨC NĂNG CHÍNH (CRUD) ---

        // 1. TẢI DỮ LIỆU (READ)
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            string url = $"api/GroupScoreDistributions?groupCode={cbGroup.Text}&year={numYear.Value}";
            var response = await _httpClient.GetAsync(url);
            var result = JsonConvert.DeserializeObject<ApiResponse<List<ScoreDistDto>>>(await response.Content.ReadAsStringAsync());

            if (result.success && result.data.Count > 0)
            {
                foreach (var item in result.data)
                {
                    int idx = (int)item.totalScoreLevel - 1;
                    if (idx >= 0 && idx < 30) dgvDist.Rows[idx].Cells[1].Value = item.countStudents;
                }
                UpdatePreviewChart();
            }
            else MessageBox.Show(result.message ?? "Chưa có dữ liệu cho năm này.");
        }

        // 2. LƯU/CẬP NHẬT (CREATE/UPDATE)
        private async void btnSave_Click(object sender, EventArgs e)
        {
            var data = new List<ScoreDistDto>();
            for (int i = 0; i < 30; i++)
            {
                data.Add(new ScoreDistDto
                {
                    totalScoreLevel = i + 1,
                    countStudents = Convert.ToInt32(dgvDist.Rows[i].Cells[1].Value ?? 0)
                });
            }

            string url = $"api/GroupScoreDistributions/update?groupCode={cbGroup.Text}&year={numYear.Value}";
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode) MessageBox.Show("Cập nhật phổ điểm thành công!");
            else MessageBox.Show("Lỗi: " + await response.Content.ReadAsStringAsync());
        }

        // 3. XÓA (DELETE)
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa toàn bộ dữ liệu phổ điểm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No) return;

            string url = $"api/GroupScoreDistributions/delete?groupCode={cbGroup.Text}&year={numYear.Value}";
            var response = await _httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Đã xóa.");
                foreach (DataGridViewRow row in dgvDist.Rows) row.Cells[1].Value = 0;
                UpdatePreviewChart();
            }
        }

        private void UpdatePreviewChart()
        {
            // 1. Kiểm tra an toàn: Nếu chart chưa được khởi tạo thì thoát ngay
            if (chartPreview == null || chartPreview.ChartAreas.Count == 0) return;

            try
            {
                // 2. Đảm bảo luôn có ít nhất 1 Series
                if (chartPreview.Series.Count == 0)
                {
                    var newSeries = new Series("Preview")
                    {
                        ChartType = SeriesChartType.Column,
                        Color = Color.SeaGreen
                    };
                    chartPreview.Series.Add(newSeries);
                }

                var series = chartPreview.Series[0];
                series.Points.Clear();

                // 3. Nạp dữ liệu từ Grid
                for (int i = 0; i < 30; i++)
                {
                    // Kiểm tra dòng và ô có tồn tại không
                    if (dgvDist.Rows[i].Cells[1] != null)
                    {
                        var cellValue = dgvDist.Rows[i].Cells[1].Value;
                        int count = (cellValue == null || cellValue == DBNull.Value) ? 0 : Convert.ToInt32(cellValue);
                        series.Points.AddXY(i + 1, count);
                    }
                }

                // 4. FIX LỖI GIÁ TRỊ LỚN: Ép trục Y tự động co giãn
                var area = chartPreview.ChartAreas[0];
                area.AxisY.Minimum = 0;
                area.AxisY.Maximum = double.NaN; // Cho phép tự động tính Max
                area.AxisY.Interval = double.NaN; // Cho phép tự động tính khoảng chia

                // Lệnh quan trọng nhất để biểu đồ nhảy theo giá trị mới
                area.RecalculateAxesScale();
                chartPreview.ResetAutoValues();
                chartPreview.Invalidate();
            }
            catch (Exception ex)
            {
                // Tránh làm sập ứng dụng nếu có lỗi render
                Console.WriteLine("Chart Error: " + ex.Message);
            }
        }

        // --- DTOs ---
        public class SubjectGroupDto { public string GroupName { get; set; } }
        public class ScoreDistDto { public decimal totalScoreLevel { get; set; } public int countStudents { get; set; } }
        public class ApiResponse<T> { public bool success { get; set; } public string message { get; set; } public T data { get; set; } }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // 1. Xác nhận với người dùng để tránh xóa nhầm
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đặt lại toàn bộ 30 mức điểm về 0 không?",
                "Xác nhận làm mới",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // 2. Duyệt qua tất cả các dòng trong Grid và gán giá trị 0
                foreach (DataGridViewRow row in dgvDist.Rows)
                {
                    // Cột index 1 là cột "Số lượng thí sinh"
                    row.Cells[1].Value = 0;
                }

                // 3. Cập nhật lại biểu đồ Preview để hiển thị các cột bằng 0
                UpdatePreviewChart();

                // 4. Thông báo cho người dùng
                MessageBox.Show("Đã đặt lại dữ liệu về 0. Lưu ý: Dữ liệu trên Database chưa bị thay đổi cho đến khi bạn nhấn 'Save'.");
            }
        }
    }
}