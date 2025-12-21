using System.Drawing;
using System.Windows.Forms;

namespace UniGate.Student.Forms
{
    partial class FrmDashboard
    {
        private Label lblWelcome;
        private Button btnManageQuestions;
        private Button btnStartTest;
        private Button btnHistory;
        private Button btnLogout;

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            btnManageQuestions = new Button();
            btnStartTest = new Button();
            btnHistory = new Button();
            btnLogout = new Button();

            SuspendLayout();

            lblWelcome.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblWelcome.Location = new Point(25, 20);
            lblWelcome.Size = new Size(300, 30);
            lblWelcome.Text = "Xin chào";

            btnManageQuestions.Text = "Quản lý câu hỏi (Admin)";
            btnManageQuestions.Size = new Size(250, 45);
            btnManageQuestions.Location = new Point(25, 70);
            btnManageQuestions.Click += btnManageQuestions_Click;

            btnStartTest.Text = "Bắt đầu Test Holland";
            btnStartTest.Size = new Size(250, 45);
            btnStartTest.Location = new Point(25, 130);
            btnStartTest.Click += btnStartTest_Click;

            btnHistory.Text = "Xem kết quả trước";
            btnHistory.Size = new Size(250, 45);
            btnHistory.Location = new Point(25, 190);
            btnHistory.Click += btnHistory_Click;

            btnLogout.Text = "Đăng xuất";
            btnLogout.Size = new Size(250, 45);
            btnLogout.Location = new Point(25, 250);
            btnLogout.Click += btnLogout_Click;

            ClientSize = new Size(320, 330);
            Controls.Add(lblWelcome);
            Controls.Add(btnManageQuestions);
            Controls.Add(btnStartTest);
            Controls.Add(btnHistory);
            Controls.Add(btnLogout);

            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bảng điều khiển";
            Load += FrmDashboard_Load;

            ResumeLayout(false);
        }
    }
}
