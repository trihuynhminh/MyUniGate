using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniGate.Admin.Services;
using UniGate.Shared.DTOs;

namespace UniGate.Admin.Forms
{
    public partial class FormQuanLyTruong : Form
    {
        private readonly UniversityService _service = new();
        private List<UniversityDto> _data = new();

        public FormQuanLyTruong()
        {
            InitializeComponent();
            InitListView();

            Load += async (_, __) => await LoadData();

            btnTim.Click += async (_, __) => await LoadData();
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
        }

        // ================== INIT LISTVIEW ==================
        private void InitListView()
        {
            lvTruong.View = View.Details;
            lvTruong.FullRowSelect = true;
            lvTruong.GridLines = true;

            lvTruong.Columns.Clear();
            lvTruong.Columns.Add("ID", 60);
            lvTruong.Columns.Add("Mã", 100);
            lvTruong.Columns.Add("Tên trường", 250);
            lvTruong.Columns.Add("Tỉnh", 150);
            lvTruong.Columns.Add("Website", 200);
        }

        // ================== LOAD DATA ==================
        private async Task LoadData()
        {
            lvTruong.Items.Clear();

            _data = await _service.GetAllAsync(txtTim.Text);

            foreach (var u in _data)
            {
                var item = new ListViewItem(u.UniversityID.ToString());
                item.SubItems.Add(u.UniversityCode);
                item.SubItems.Add(u.UniversityName);
                item.SubItems.Add(u.Province);
                item.SubItems.Add(u.Website);

                item.Tag = u; // QUAN TRỌNG
                lvTruong.Items.Add(item);
            }
        }

        // ================== THÊM ==================
        private async void BtnThem_Click(object? sender, EventArgs e)
        {
            var frm = new FormThemTruong();
            if (frm.ShowDialog() == DialogResult.OK)
                await LoadData();
        }

        // ================== SỬA ==================
        private async void BtnSua_Click(object? sender, EventArgs e)
        {
            if (lvTruong.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn trường cần sửa!");
                return;
            }

            var uni = (UniversityDto)lvTruong.SelectedItems[0].Tag;

            var frm = new FormThemTruong(uni);
            if (frm.ShowDialog() == DialogResult.OK)
                await LoadData();
        }

        // ================== XÓA ==================
        private async void BtnXoa_Click(object? sender, EventArgs e)
        {
            if (lvTruong.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn trường cần xóa!");
                return;
            }

            var uni = (UniversityDto)lvTruong.SelectedItems[0].Tag;

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa trường:\n{uni.UniversityName}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            await _service.DeleteAsync(uni.UniversityID);
            await LoadData();
        }
    }
}
