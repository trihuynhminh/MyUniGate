using System.Windows.Forms.DataVisualization.Charting;
using System.Net.Http;
using Newtonsoft.Json;

namespace UniGate.Student.Forms
{
    public partial class FormPhanViTrungVi : Form
    {
        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7062/") // Đảm bảo đúng Port API của bạn
        };

        // Khai báo biến toàn cục cho Chart
        private Chart chartScores;

        public FormPhanViTrungVi()
        {
            InitializeComponent();
        }

        private async void FormPhanViTrungVi_Load(object sender, EventArgs e)
        {
            // 1. Khởi tạo Chart bằng code (vì Designer .NET 8 thường không hiện Chart trong Toolbox)
            InitChart();

            // 2. Load danh sách tổ hợp vào ComboBox
            try
            {
                var response = await _httpClient.GetStringAsync("api/subject-groups");
                var groups = JsonConvert.DeserializeObject<List<SubjectGroupDto>>(response);
                cbGroup.DataSource = groups;
                cbGroup.DisplayMember = "GroupName";
                cbGroup.ValueMember = "GroupID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối API để lấy danh sách tổ hợp: " + ex.Message);
            }
        }

        private void InitChart()
        {
            // Khởi tạo đối tượng Chart
            chartScores = new Chart();
            chartScores.Dock = DockStyle.Fill;

            // Tạo vùng vẽ biểu đồ (ChartArea)
            ChartArea chartArea = new ChartArea("MainArea");

            // Cấu hình trục tọa độ
            chartArea.AxisX.Title = "Điểm số";
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 30;
            chartArea.AxisX.Interval = 1; // Hiển thị từng vạch điểm từ 1-30

            chartArea.AxisY.Title = "Số lượng thí sinh";
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;

            chartScores.ChartAreas.Add(chartArea);

            // Thêm Chart vào Panel đã thiết kế trên Form
            if (pnlChartContainer != null)
            {
                pnlChartContainer.Controls.Clear();
                pnlChartContainer.Controls.Add(chartScores);
            }
        }

        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            try
            {
                string group = cbGroup.Text;
                int year = (int)numYear.Value;
                decimal score = numUserScore.Value;

                // 1. Gọi API phân tích
                var response = await _httpClient.GetAsync($"api/ScoreAnalysis?groupCode={group}&year={year}&userScore={score}");

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Lỗi khi gọi API phân tích.");
                    return;
                }

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AnalysisResponse>(content);

                if (result == null || result.data == null)
                {
                    MessageBox.Show(result?.message ?? "Không tìm thấy dữ liệu phổ điểm.");
                    return;
                }

                // 2. Hiển thị thông số văn bản
                var d = result.data;
                lblResult.Text = $"Tổng thí sinh: {d.totalStudents:N0}\n" +
                                 $"P25: {d.percentile25} | Trung vị: {d.median} | P75: {d.percentile75}\n" +
                                 $"Bạn cao hơn: {d.percentBelowUser}% thí sinh\n" +
                                 $"Đánh giá: {d.position}";

                // 3. Vẽ lại biểu đồ
                UpdateChart(d.chart, score);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void UpdateChart(List<ScoreChartData> data, decimal userScore)
        {
            if (chartScores == null || chartScores.ChartAreas.Count == 0) return;

            chartScores.Series.Clear();

            var series = new Series
            {
                Name = "Phổ điểm",
                Color = Color.SteelBlue,
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.Int32
            };

            int roundedUserScore = (int)Math.Round(userScore);

            foreach (var item in data)
            {
                int index = series.Points.AddXY(item.score, item.count);

                if (item.score == roundedUserScore)
                {
                    series.Points[index].Color = Color.Red;
                    series.Points[index].Label = "Bạn";
                    series.Points[index].ToolTip = $"Điểm của bạn: {userScore}\nSố lượng: {item.count}";
                }
            }

            chartScores.Series.Add(series);

            // FIX LỖI GIÁ TRỊ LỚN
            var area = chartScores.ChartAreas[0];
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = double.NaN;

            area.RecalculateAxesScale();
            chartScores.ResetAutoValues();
            chartScores.Invalidate();
        }

        // --- Các lớp DTO để nhận dữ liệu ---
        public class SubjectGroupDto { public int GroupID { get; set; } public string GroupName { get; set; } }
        public class ScoreChartData { public int score { get; set; } public int count { get; set; } }
        public class AnalysisResponse { public string message { get; set; } public AnalysisData data { get; set; } }
        public class AnalysisData
        {
            public decimal userScore { get; set; }
            public int totalStudents { get; set; }
            public decimal? percentile25 { get; set; }
            public decimal? median { get; set; }
            public decimal? percentile75 { get; set; }
            public decimal percentBelowUser { get; set; }
            public string position { get; set; }
            public List<ScoreChartData> chart { get; set; }
        }
    }
}