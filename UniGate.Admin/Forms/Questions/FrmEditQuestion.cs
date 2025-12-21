using System;
using System.Windows.Forms;
using UniGate.Admin.Models;
using UniGate.Admin.Services;

namespace UniGate.Admin.Forms.Questions
{
    public partial class FrmEditQuestion : Form
    {
        private readonly ApiClient _api;
        private readonly AdminQuestionDto _question;

        public FrmEditQuestion(AdminQuestionDto question)
        {
            InitializeComponent();
            _api = new ApiClient();
            _question = question;

            // Fill UI
            txtId.Text = _question.Id.ToString();
            txtContent.Text = _question.Content;
            txtGroup.Text = _question.Group;
            chkActive.Checked = _question.IsActive;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var req = new AdminQuestionDto
            {
                Id = _question.Id,
                Content = txtContent.Text,
                Group = txtGroup.Text,
                IsActive = chkActive.Checked
            };

            await _api.PutAsync($"api/admin/questions/{req.Id}", req);

            MessageBox.Show("Cập nhật thành công!", "Thông báo");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
