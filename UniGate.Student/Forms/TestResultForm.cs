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
        private readonly HollandSubmitResponse _result;
        private readonly Dictionary<string, int> _scores;

        public TestResultForm(HollandSubmitResponse result)
        {
            InitializeComponent();
            _result = result;
            _scores = result.Scores;
        }

        private void TestResultForm_Load(object sender, EventArgs e)
        {
            // ===== HIỂN THỊ ĐIỂM =====
            lblR.Text = $"Thực tiễn (R): {_scores["R"]}";
            lblI.Text = $"Nghiên cứu (I): {_scores["I"]}";
            lblA.Text = $"Nghệ thuật (A): {_scores["A"]}";
            lblS.Text = $"Xã hội (S): {_scores["S"]}";
            lblE.Text = $"Quản lý (E): {_scores["E"]}";
            lblC.Text = $"Nghiệp vụ (C): {_scores["C"]}";

            // ===== SẮP XẾP THEO ĐIỂM =====
            var ordered = _scores
                .OrderByDescending(x => x.Value)
                .ToList();

            string fullCode = string.Concat(ordered.Select(x => x.Key));
            string top3 = string.Join(" - ", ordered.Take(3).Select(x => x.Key));

            lblYourCodeValue.Text = fullCode;
            lblTop3Value.Text = top3;

            // ===== GỢI Ý NGHỀ NGHIỆP =====
            txtSummary.Text = BuildCareerSummary(ordered);
        }

        // ================== TỔNG HỢP GỢI Ý ==================
        private string BuildCareerSummary(List<KeyValuePair<string, int>> ordered)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Bạn thuộc nhóm tính cách:");
            sb.AppendLine(string.Join(" - ", ordered.Take(3).Select(x => x.Key)));
            sb.AppendLine();
            sb.AppendLine("GỢI Ý NGHỀ NGHIỆP:");
            sb.AppendLine();

            foreach (var item in ordered.Take(3))
            {
                sb.AppendLine(GetGroupDetail(item.Key));
                sb.AppendLine();
            }

            return sb.ToString();
        }

        // ================== 6 NHÓM RIASEC ==================
        private string GetGroupDetail(string group)
        {
            switch (group)
            {
                case "R":
                    return
                        "Thực tiễn (R):\r\n" +
                        "- Thích làm việc với máy móc, công cụ, kỹ thuật.\r\n" +
                        "- Ưa hành động, thực hành hơn lý thuyết.\r\n" +
                        "Ngành phù hợp: Cơ khí, Điện – Điện tử, Công nghệ ô tô, Xây dựng.";

                case "I":
                    return
                        "Nghiên cứu (I):\r\n" +
                        "- Thích phân tích, tư duy logic, khám phá kiến thức.\r\n" +
                        "- Ưa nghiên cứu chuyên sâu.\r\n" +
                        "Ngành phù hợp: Công nghệ thông tin, Khoa học dữ liệu, AI, Toán – Thống kê.";

                case "A":
                    return
                        "Nghệ thuật (A):\r\n" +
                        "- Sáng tạo, giàu cảm xúc, yêu cái đẹp.\r\n" +
                        "- Không thích khuôn mẫu cứng nhắc.\r\n" +
                        "Ngành phù hợp: Thiết kế đồ họa, Kiến trúc, Truyền thông, Nghệ thuật.";

                case "S":
                    return
                        "Xã hội (S):\r\n" +
                        "- Thích giúp đỡ người khác, giao tiếp tốt.\r\n" +
                        "- Giỏi lắng nghe, đồng cảm.\r\n" +
                        "Ngành phù hợp: Sư phạm, Tâm lý học, Công tác xã hội, Điều dưỡng.";

                case "E":
                    return
                        "Quản lý (E):\r\n" +
                        "- Thích lãnh đạo, thuyết phục, kinh doanh.\r\n" +
                        "- Có khả năng tổ chức, ra quyết định.\r\n" +
                        "Ngành phù hợp: Quản trị kinh doanh, Marketing, Tài chính, Luật.";

                case "C":
                    return
                        "Nghiệp vụ (C):\r\n" +
                        "- Cẩn thận, có tổ chức, làm việc theo quy trình.\r\n" +
                        "- Ưa sự ổn định, chính xác.\r\n" +
                        "Ngành phù hợp: Kế toán, Kiểm toán, Hành chính – Văn phòng.";

                default:
                    return "";
            }
        }

        // ===== EVENTS BẮT BUỘC (KHỚP DESIGNER) =====
        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panelDetail_Paint(object sender, PaintEventArgs e)
        {
            // Không xử lý gì
        }
    }
}
