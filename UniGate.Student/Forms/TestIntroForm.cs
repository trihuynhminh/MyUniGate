using System;
using System.Windows.Forms;

namespace UniGate.Student.Forms
{
    public partial class TestIntroForm : Form
    {
        public TestIntroForm()
        {
            InitializeComponent();
        }

        private void TestIntroForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Test Holland Codes";
            lblSubTitle.Text =
                "Khám phá nhóm tính cách nghề nghiệp và định hướng tương lai\n" +
                "dựa trên mô hình Holland (RIASEC).";

            lblItemCountValue.Text = "60";
            lblTimeValue.Text = "∞";
            lblGroupValue.Text = "6";

            txtIntro.Text =
                "Bài trắc nghiệm Holland (RIASEC) giúp bạn xác định xu hướng nghề nghiệp " +
                "phù hợp thông qua các sở thích và hành vi cá nhân.\r\n\r\n" +

                "Cách thực hiện:\r\n" +
                "Bước 1 – Bắt đầu bài trắc nghiệm.\r\n" +
                "Bước 2 – Trả lời đầy đủ 60 câu hỏi.\r\n" +
                "Bước 3 – Xem kết quả mã Holland và gợi ý nghề nghiệp.\r\n\r\n" +

                "Lưu ý: Hãy chọn đáp án phản ánh đúng suy nghĩ và cảm nhận của bạn nhất.";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            new TestForm().Show();
            this.Hide();
        }
    }
}
