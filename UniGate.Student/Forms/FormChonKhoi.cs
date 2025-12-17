using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using UniGate.Shared.DTOs;
using UniGate.Shared.DTOs;

using UniGate.Student.Services;

namespace UniGate.Student.Forms
{
    public partial class FormChonKhoi : Form
    {
        private readonly HttpClient _http;

        private readonly int _userId = 1; // test
        private List<ComboInfoDto> _combos = new();
        private UserScoreResponse _scores = new();
        private readonly List<string> _selectedCombos = new();

        public FormChonKhoi()
        {
            InitializeComponent();

            _http = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7062/")
            };

            InitListView();
            this.Load += FormChonKhoi_Load;
            listView_Khoi.ItemChecked += ListViewKhoi_ItemChecked;
        }

        // ================= UI =================
        private void InitListView()
        {
            listView_Khoi.View = View.Details;
            listView_Khoi.CheckBoxes = true;
            listView_Khoi.FullRowSelect = true;
            listView_Khoi.GridLines = true;

            listView_Khoi.Columns.Clear();
            listView_Khoi.Columns.Add("Tổ hợp", 80);
            listView_Khoi.Columns.Add("Điểm", 70);
            listView_Khoi.Columns.Add("Chi tiết", 300);
        }

        // ================= LOAD =================
        private async void FormChonKhoi_Load(object? sender, EventArgs e)
        {
            try
            {
                _scores = await _http
                    .GetFromJsonAsync<UserScoreResponse>($"api/user-scores/{_userId}")
                    ?? new UserScoreResponse();

                _combos = await _http
                    .GetFromJsonAsync<List<ComboInfoDto>>("api/combos/with-subjects")
                    ?? new List<ComboInfoDto>();

                HienThiDiemToHop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu:\n" + ex.Message);
            }
        }

        // ================= HIỂN THỊ =================
        private void HienThiDiemToHop()
        {
            listView_Khoi.Items.Clear();

            var service = new ComboScoreService(_scores);
            var results = service.TinhDiemToHop(_combos);

            foreach (var r in results)
            {
                var item = new ListViewItem(r.Code);
                item.SubItems.Add(r.Score.ToString("0.00"));
                item.SubItems.Add(r.Detail);
                listView_Khoi.Items.Add(item);
            }

            var top3 = results
                .OrderByDescending(x => x.Score)
                .Take(3)
                .ToList();

            lbl_Top1.Text = top3.Count > 0 ? $"{top3[0].Code} – {top3[0].Score:0.00}" : "";
            lbl_Top2.Text = top3.Count > 1 ? $"{top3[1].Code} – {top3[1].Score:0.00}" : "";
            lbl_Top3.Text = top3.Count > 2 ? $"{top3[2].Code} – {top3[2].Score:0.00}" : "";
        }

        // ================= SELECT =================
        private void ListViewKhoi_ItemChecked(object? sender, ItemCheckedEventArgs e)
        {
            string code = e.Item.Text;

            if (e.Item.Checked)
            {
                if (!_selectedCombos.Contains(code))
                    _selectedCombos.Add(code);
            }
            else
            {
                _selectedCombos.Remove(code);
            }
        }

        // ================= BUTTON =================
        

        private async void btnXemNganh_Click_1(object sender, EventArgs e)
        {
            if (_selectedCombos.Count == 0)
            {
                MessageBox.Show("Bạn phải chọn ít nhất một tổ hợp!");
                return;
            }

            var req = new UserComboSelectRequest
            {
                UserId = _userId,
                GroupNames = _selectedCombos
            };

            var res = await _http.PostAsJsonAsync("api/user-combos/select", req);
            if (!res.IsSuccessStatusCode)
            {
                MessageBox.Show("Lưu tổ hợp thất bại!");
                return;
            }

            //var frm = new FormNganhTheoKhoi(_selectedCombos);
            //frm.ShowDialog();
        }
    }
}
