using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniGate.Shared.DTOs;
using UniGate.Student.Forms;

namespace UniGate.Student.Forms
{
    public partial class FormNganhTheoKhoi : Form
    {
        private readonly HttpClient _http = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7062/") // sửa đúng base api của bạn
        };
        private readonly List<string> _groupCodes;
        private readonly short? _year;
        private List<MajorByComboRowDto> _rows = new();
        public FormNganhTheoKhoi(List<string>groupCodes, short? year = null)
        {
            InitializeComponent();
            _groupCodes = groupCodes;
            _year = year;

            SetupGrid();
            this.Load += FormNganhTheoKhoi_Load;

        }

        private async void FormNganhTheoKhoi_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            

        }

        private void SetupGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã ngành",
                DataPropertyName = "MajorCode",
                Name = "colMajorCode",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Link: Tên ngành
            dataGridView1.Columns.Add(new DataGridViewLinkColumn
            {
                HeaderText = "Tên ngành",
                DataPropertyName = "MajorName",
                Name = "colMajorName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Link: Tên trường
            dataGridView1.Columns.Add(new DataGridViewLinkColumn
            {
                HeaderText = "Tên trường",
                DataPropertyName = "UniversityName",
                Name = "colUniversityName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tổ hợp",
                DataPropertyName = "GroupName",
                Name = "colGroupName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Điểm",
                DataPropertyName = "MinScore",
                Name = "colScore",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Năm",
                DataPropertyName = "Year",
                Name = "colYear",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });


        }

        private async Task LoadDataAsync()
        {
            try
            {
                var codes = string.Join(",", _groupCodes);
                var url = $"api/admin/admissions/by-group-codes?codes={codes}";

                if (_year.HasValue)
                    url += $"&year={_year.Value}";

                var data = await _http.GetFromJsonAsync<List<MajorByComboRowDto>>(url);
                _rows = data ?? new List<MajorByComboRowDto>();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _rows;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = _rows[e.RowIndex];

            var colName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (colName == "colMajorName")
            {
                // mở chi tiết ngành
                //var f = new FormChiTietNganh(row.MajorId);
                //f.ShowDialog();
            }
            else if (colName == "colUniversityName")
            {
                // mở chi tiết trường
                var f = new FormChiTietTruong(row.UniversityId);
                f.ShowDialog();
            }
        }
    }
}
