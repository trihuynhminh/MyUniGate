using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniGate.Admin.Services;
using UniGate.Shared.DTOs;

namespace UniGate.Admin.Forms
{
    public partial class FormQuanLyNganh : Form
    {
        private readonly UniversityService _uniService = new();
        private readonly MajorService _majorService = new();

        private List<UniversityDto> _universities = new();
        private List<MajorAdminDto> _majors = new();

        public FormQuanLyNganh()
        {
            InitializeComponent();
            InitListView();
            this.Load += FormQuanLyNganh_Load;

            cbb_Truong.SelectedIndexChanged += cbb_Truong_SelectedIndexChanged;

            btn_Them.Click += btn_Them_Click;
            btn_Sua.Click += btn_Sua_Click;
            btn_Xoa.Click += btn_Xoa_Click;

        }

        // ================= INIT LISTVIEW =================
        private void InitListView()
        {
            lv_Nganh.View = View.Details;
            lv_Nganh.FullRowSelect = true;
            lv_Nganh.GridLines = true;
            lv_Nganh.HideSelection = false;

            lv_Nganh.Columns.Clear();
            lv_Nganh.Columns.Add("STT", 60);
            lv_Nganh.Columns.Add("Mã ngành", 120);
            lv_Nganh.Columns.Add("Tên ngành", 260);
            lv_Nganh.Columns.Add("Điểm chuẩn", 120);
            lv_Nganh.Columns.Add("Năm", 80);
            lv_Nganh.Columns.Add("Tổ hợp", 220);
        }

        // ================= FORM LOAD =================
        private async void FormQuanLyNganh_Load(object sender, EventArgs e)
        {
            await LoadTruong();
        }

        // ================= LOAD TRƯỜNG =================
        private async Task LoadTruong()
        {
            _universities = await _uniService.GetAllAsync();

            cbb_Truong.DataSource = _universities;
            cbb_Truong.DisplayMember = "UniversityName";
            cbb_Truong.ValueMember = "UniversityID";
        }

        // ================= SELECT TRƯỜNG =================
        private async void cbb_Truong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Truong.SelectedValue is int universityId)
            {
                await LoadNganh(universityId);
            }
        }

        // ================= LOAD NGÀNH =================
        private async Task LoadNganh(int universityId)
        {
            lv_Nganh.Items.Clear();
            _majors = await _majorService.GetByUniversityAsync(universityId);

            int stt = 1;
            foreach (var m in _majors)
            {
                var item = new ListViewItem(stt.ToString()); // STT
                item.SubItems.Add(m.MajorCode ?? "");
                item.SubItems.Add(m.Name ?? "");
                item.SubItems.Add(m.CutoffScore.ToString("0.##"));
                item.SubItems.Add(m.Year.ToString());
                item.SubItems.Add(string.Join(", ", m.Combos));

                item.Tag = m; // ⭐ RẤT QUAN TRỌNG
                lv_Nganh.Items.Add(item);

                stt++;
            }
        }

        // ================= THÊM =================
        private async void btn_Them_Click(object sender, EventArgs e)
        {
            if (cbb_Truong.SelectedValue is not int universityId) return;

            var frm = new FormThemNganh(universityId);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await LoadNganh(universityId);
            }
        }

        // ================= SỬA =================
        private async void btn_Sua_Click(object sender, EventArgs e)
        {
            if (lv_Nganh.SelectedItems.Count == 0) return;

            var major = (MajorAdminDto)lv_Nganh.SelectedItems[0].Tag;

            var frm = new FormThemNganh(major.SchoolId, major);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await LoadNganh(major.SchoolId);
            }
        }

        // ================= XÓA =================
        private async void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (lv_Nganh.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ngành cần xóa!");
                return;
            }

            var major = (MajorAdminDto)lv_Nganh.SelectedItems[0].Tag;

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa ngành:\n{major.Name}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            await _majorService.DeleteAsync(major.Id);
            await LoadNganh(major.SchoolId);
        }
    }
}
