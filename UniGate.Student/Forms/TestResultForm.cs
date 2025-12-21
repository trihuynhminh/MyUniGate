using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UniGate.Student.Models;

namespace UniGate.Student.Forms
{
    public partial class TestResultForm : Form
    {
        private readonly Dictionary<string, int> _scores;

        public TestResultForm(HollandSubmitResponse result)
        {
            InitializeComponent();

            if (result == null)
                throw new ArgumentNullException(nameof(result));

            // 🔥 FIX: ĐẢM BẢO LUÔN ĐỦ 6 NHÓM
            _scores = new Dictionary<string, int>
            {
                { "R", 0 },
                { "I", 0 },
                { "A", 0 },
                { "S", 0 },
                { "E", 0 },
                { "C", 0 }
            };

            if (result.Scores != null)
            {
                foreach (var item in result.Scores)
                {
                    if (_scores.ContainsKey(item.Key))
                        _scores[item.Key] = item.Value;
                }
            }
        }

        private void TestResultForm_Load(object sender, EventArgs e)
        {
            // ===== HIỂN THỊ ĐIỂM =====
            lblR.Text = $"Realistic (R): {_scores["R"]}";
            lblI.Text = $"Investigative (I): {_scores["I"]}";
            lblA.Text = $"Artistic (A): {_scores["A"]}";
            lblS.Text = $"Social (S): {_scores["S"]}";
            lblE.Text = $"Enterprising (E): {_scores["E"]}";
            lblC.Text = $"Conventional (C): {_scores["C"]}";

            // ===== SẮP XẾP =====
            var ordered = _scores
                .OrderByDescending(x => x.Value)
                .ToList();

            lblYourCodeValue.Text = string.Concat(ordered.Select(x => x.Key));
            lblTop3Value.Text = string.Join(" - ", ordered.Take(3).Select(x => x.Key));

            txtSummary.Text = BuildSummary(ordered);
        }

        // ================== SUMMARY ==================
        private string BuildSummary(List<KeyValuePair<string, int>> ordered)
        {
            var sb = new StringBuilder();
            var strongest = ordered.First().Key;

            sb.AppendLine("Bạn thuộc nhóm tính cách:");
            sb.AppendLine(string.Join(" - ", ordered.Take(3).Select(x => x.Key)));
            sb.AppendLine();

            sb.AppendLine("MÔ TẢ TÍNH CÁCH:");
            sb.AppendLine(GetDescription(strongest));
            sb.AppendLine();

            sb.AppendLine("GỢI Ý NGHỀ NGHIỆP:");
            sb.AppendLine(GetCareer(strongest));

            return sb.ToString();
        }

        // ================== MÔ TẢ ==================
        private string GetDescription(string g) => g switch
        {
            "R" => "Thực tiễn (R): Thích làm việc với máy móc, kỹ thuật, thực hành.",
            "I" => "Nghiên cứu (I): Phân tích, tư duy logic, khám phá kiến thức.",
            "A" => "Nghệ thuật (A): Sáng tạo, thẩm mỹ, không thích khuôn mẫu.",
            "S" => "Xã hội (S): Giao tiếp, giúp đỡ người khác, đồng cảm.",
            "E" => "Quản lý (E): Lãnh đạo, thuyết phục, kinh doanh.",
            "C" => "Nghiệp vụ (C): Chính xác, quy trình, tổ chức.",
            _ => ""
        };

        // ================== NGHỀ NGHIỆP ==================
        private string GetCareer(string g) => g switch
        {
            "R" => "Cơ khí, Điện – Điện tử, Công nghệ ô tô, Xây dựng.",
            "I" => "CNTT, AI, Khoa học dữ liệu, Toán – Thống kê.",
            "A" => "Thiết kế đồ họa, Kiến trúc, Truyền thông, Nghệ thuật.",
            "S" => "Sư phạm, Tâm lý học, Điều dưỡng, Công tác xã hội.",
            "E" => "Quản trị kinh doanh, Marketing, Tài chính, Luật.",
            "C" => "Kế toán, Kiểm toán, Hành chính – Văn phòng.",
            _ => ""
        };

        private void BtnBack_Click(object sender, EventArgs e) => Close();
        private void BtnClose_Click(object sender, EventArgs e) => Close();
    }
}
