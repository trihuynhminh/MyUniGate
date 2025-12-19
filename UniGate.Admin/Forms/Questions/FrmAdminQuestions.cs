using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniGate.Admin.Models;
using UniGate.Admin.Services;

namespace UniGate.Admin.Forms.Questions
{
    public partial class FrmAdminQuestions : Form
    {
        private readonly ApiClient _api;
        private List<AdminQuestionDto> _questions = new();

        public FrmAdminQuestions()
        {
            InitializeComponent();
            _api = new ApiClient();
        }

        private async void FrmAdminQuestions_Load(object sender, EventArgs e)
        {
            await LoadQuestions();
        }

        private async Task LoadQuestions()
        {
            try
            {
                _questions = await _api.GetAsync<List<AdminQuestionDto>>("api/admin/questions");

                dgvQuestions.DataSource = null;
                dgvQuestions.DataSource = _questions;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var f = new FrmAddQuestion();
            f.ShowDialog();

            _ = LoadQuestions();
        }

        private void dgvQuestions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Lấy ID từ grid
            int id = (int)dgvQuestions.Rows[e.RowIndex].Cells["Id"].Value;

            // Tìm object trong list
            var q = _questions.First(x => x.Id == id);

            var frm = new FrmEditQuestion(q);
            frm.ShowDialog();

            _ = LoadQuestions();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.SelectedRows.Count == 0) return;

            int id = (int)dgvQuestions.SelectedRows[0].Cells["Id"].Value;

            if (MessageBox.Show("Xóa câu hỏi?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            await _api.DeleteAsync($"api/admin/questions/{id}");

            MessageBox.Show("Đã xóa");
            await LoadQuestions();
        }
    }
}
