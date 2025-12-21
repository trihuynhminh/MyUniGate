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
        private readonly QuestionAdminClient _service = new();
        private List<AdminQuestionDto> _allQuestions = new();

        public FrmAdminQuestions()
        {
            InitializeComponent();

            cboGroup.Items.AddRange(new object[] { "R", "I", "A", "S", "E", "C" });
            cboFilter.Items.AddRange(new object[] { "All", "R", "I", "A", "S", "E", "C" });
            cboFilter.SelectedIndex = 0;
        }

        private async void FrmAdminQuestions_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            _allQuestions = await _service.GetAllAsync();
            ApplyFilterAndSearch();
        }

        // ================= FILTER + SEARCH =================
        private void ApplyFilterAndSearch()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string group = cboFilter.SelectedItem?.ToString();

            var result = _allQuestions.AsEnumerable();

            if (!string.IsNullOrEmpty(keyword))
                result = result.Where(q => q.Content.ToLower().Contains(keyword));

            if (group != "All")
                result = result.Where(q => q.Group == group);

            dgvQuestions.DataSource = result.ToList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSearch();
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSearch();
        }

        // ================= CRUD =================
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContent.Text) || cboGroup.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập nội dung và chọn nhóm");
                return;
            }

            var q = new AdminQuestionDto
            {
                Content = txtContent.Text,
                Code = cboGroup.Text + DateTime.Now.Ticks.ToString().Substring(10),
                Group = cboGroup.Text,
                TestType = "Holland",
                IsActive = true
            };

            await _service.AddAsync(q);
            await LoadData();
            ClearInput();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.CurrentRow == null) return;

            int id = (int)dgvQuestions.CurrentRow.Cells["Id"].Value;

            var q = new AdminQuestionDto
            {
                Content = txtContent.Text,
                Group = cboGroup.Text,
                TestType = "Holland",
                IsActive = true
            };

            await _service.UpdateAsync(id, q);
            await LoadData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.CurrentRow == null) return;

            int id = (int)dgvQuestions.CurrentRow.Cells["Id"].Value;

            if (MessageBox.Show("Xóa câu hỏi này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _service.DeleteAsync(id);
                await LoadData();
                ClearInput();
            }
        }

        private void dgvQuestions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtContent.Text = dgvQuestions.Rows[e.RowIndex].Cells["Content"].Value.ToString();
            cboGroup.SelectedItem = dgvQuestions.Rows[e.RowIndex].Cells["Group"].Value.ToString();
        }

        private void ClearInput()
        {
            txtContent.Clear();
            cboGroup.SelectedIndex = -1;
        }
    }
}
