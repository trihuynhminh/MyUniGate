using System;
using System.Windows.Forms;

namespace UniGate.Student.Forms
{
    public partial class FrmDashboard : Form
    {
        private readonly string _username;
        private readonly string _role;

        public FrmDashboard(string username, string role)
        {
            InitializeComponent();
            _username = username;
            _role = role;
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Xin chào, {_username} ({_role})";

            if (_role == "Admin")
            {
                btnManageQuestions.Visible = true;
                btnStartTest.Visible = false;
                btnHistory.Visible = false;
            }
            else
            {
                btnManageQuestions.Visible = false;
                btnStartTest.Visible = true;
                btnHistory.Visible = true;
            }
        }

        private void btnManageQuestions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trang quản lý câu hỏi (Admin) sẽ phát triển sau.");
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            var intro = new TestIntroForm();
            intro.Show();
            this.Hide();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trang xem lịch sử đang được cập nhật.");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Auth.LoginForm().Show();
        }
    }
}
