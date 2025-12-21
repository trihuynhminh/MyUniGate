using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using UniGate.Shared.DTOs; // OK nếu đã reference Shared

namespace UniGate.Student.Forms
{
    public partial class FormNhapDiem : Form
    {
        private readonly HttpClient _http;
        private int _userId;
        private readonly string[] _ngoaiNgu =
{
    "Tiếng Anh", "Tiếng Hàn", "Tiếng Nhật",
    "Tiếng Trung", "Tiếng Đức", "Tiếng Pháp", "Tiếng Nga"
};
       




        public FormNhapDiem()
        {
            InitializeComponent();

            // ✅ test cứng trước
            _userId = 1;

            _http = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7062/")
            };

            InitCombos();
            WireEvents();
        }

        private void InitCombos()
        {
            cbForeignLang.Items.AddRange(new[]
            {
                "Tiếng Anh", "Tiếng Nhật", "Tiếng Hàn",
                "Tiếng Trung", "Tiếng Đức", "Tiếng Pháp", "Tiếng Nga"
            });

            var monTuChon = new[]
            {
                "Lý", "Hóa", "Sinh", "Sử", "Địa", "Tin", "Công Nghệ",
                "Tiếng Anh", "Tiếng Nhật", "Tiếng Hàn",
                "Tiếng Trung", "Tiếng Đức", "Tiếng Pháp", "Tiếng Nga"
            };

            cbTHPT_Mon1.Items.AddRange(monTuChon);
            cbTHPT_Mon2.Items.AddRange(monTuChon);

            cbKhuVuc.Items.AddRange(new[] { "KV1", "KV2-NT", "KV2", "KV3" });
            cbDoiTuong.Items.AddRange(new[] { "ƯT1", "ƯT2" });
        }

        private void WireEvents()
        {
            cbTHPT_Mon1.SelectedIndexChanged += CheckDuplicateTHPT;
            cbTHPT_Mon2.SelectedIndexChanged += CheckDuplicateTHPT;
        }

        private void CheckDuplicateTHPT(object? sender, EventArgs e)
        {
            var mon1 = cbTHPT_Mon1.Text;
            var mon2 = cbTHPT_Mon2.Text;

            if (string.IsNullOrWhiteSpace(mon1) || string.IsNullOrWhiteSpace(mon2))
                return;

            // ❌ Trùng môn
            if (mon1 == mon2)
            {
                MessageBox.Show("⚠ Hai môn tự chọn không được trùng nhau");
                (sender as ComboBox)!.SelectedIndex = -1;
                return;
            }

            // ❌ CẢ HAI ĐỀU LÀ NGOẠI NGỮ
            bool mon1LaNgoaiNgu = _ngoaiNgu.Contains(mon1);
            bool mon2LaNgoaiNgu = _ngoaiNgu.Contains(mon2);

            if (mon1LaNgoaiNgu && mon2LaNgoaiNgu)
            {
                MessageBox.Show("⚠ Chỉ được chọn 1 môn Ngoại ngữ trong THPT");
                (sender as ComboBox)!.SelectedIndex = -1;
                return;
            }
        }

        

        private decimal Parse(TextBox txt)
        {
            decimal.TryParse(txt.Text, out var v);
            return v;
        }

        private async void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!ValidateAllScores(out var error))
            {
                MessageBox.Show(
                    error,
                    "Lỗi nhập điểm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return; // ⛔ dừng, KHÔNG gửi API
            }

            var req = new UserScoreRequest
            {
                UserId = _userId,

                HB_Toan_10 = Parse(txt10_Toan),
                HB_Toan_11 = Parse(txt11_Toan),
                HB_Toan_12 = Parse(txt12_Toan),

                HB_Van_10 = Parse(txt10_Van),
                HB_Van_11 = Parse(txt11_Van),
                HB_Van_12 = Parse(txt12_Van),

                HB_Ly_10 = Parse(txt10_Ly),
                HB_Ly_11 = Parse(txt11_Ly),
                HB_Ly_12 = Parse(txt12_Ly),

                HB_Hoa_10 = Parse(txt10_Hoa),
                HB_Hoa_11 = Parse(txt11_Hoa),
                HB_Hoa_12 = Parse(txt12_Hoa),

                HB_Sinh_10 = Parse(txt10_Sinh),
                HB_Sinh_11 = Parse(txt11_Sinh),
                HB_Sinh_12 = Parse(txt12_Sinh),

                HB_Su_10 = Parse(txt10_Su),
                HB_Su_11 = Parse(txt11_Su),
                HB_Su_12 = Parse(txt12_Su),

                // ĐỊA
                HB_Dia_10 = Parse(txt10_Dia),
                HB_Dia_11 = Parse(txt11_Dia),
                HB_Dia_12 = Parse(txt12_Dia),

                // TIN
                HB_Tin_10 = Parse(txt10_Tin),
                HB_Tin_11 = Parse(txt11_Tin),
                HB_Tin_12 = Parse(txt12_Tin),

                // CÔNG NGHỆ
                HB_CongNghe_10 = Parse(txt10_CongNghe),
                HB_CongNghe_11 = Parse(txt11_CongNghe),
                HB_CongNghe_12 = Parse(txt12_CongNghe),

                // GDKTPL
                HB_GDKTPL_10 = Parse(txt10_GDKTPL),
                HB_GDKTPL_11 = Parse(txt11_GDKTPL),
                HB_GDKTPL_12 = Parse(txt12_GDKTPL),

                HB_NgoaiNgu_Mon = cbForeignLang.Text,
                HB_NgoaiNgu_10 = Parse(txt10_NN),
                HB_NgoaiNgu_11 = Parse(txt11_NN),
                HB_NgoaiNgu_12 = Parse(txt12_NN),

                Thpt_Toan = Parse(txtTHPT_Toan),
                Thpt_Van = Parse(txtTHPT_Van),

                Thpt_TuChon1_Mon = cbTHPT_Mon1.Text,
                Thpt_TuChon1_Diem = Parse(txtTHPT_Mon1),

                Thpt_TuChon2_Mon = cbTHPT_Mon2.Text,
                Thpt_TuChon2_Diem = Parse(txtTHPT_Mon2),

                DGNL_NgonNgu = Parse(txtDgnl_NgonNgu),
                DGNL_Toan = Parse(txtDgnl_Toan),
                DGNL_TuDuy = Parse(txtDgnl_TuDuy),

                KhuVuc = cbKhuVuc.Text,
                DoiTuong = cbDoiTuong.Text,
                DiemCongThem = Parse(txtDiemCong)
            };

            var res = await _http.PostAsJsonAsync("api/user-scores/save", req);

            if (res.IsSuccessStatusCode)
                MessageBox.Show("✅ Lưu điểm thành công!");
            else
                MessageBox.Show(await res.Content.ReadAsStringAsync());
        }

        private bool RequireNumber(TextBox txt, string label, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                errors.Add($"Thiếu điểm {label}");
                return false;
            }

            if (!decimal.TryParse(txt.Text, out _))
            {
                errors.Add($"{label} phải là số");
                return false;
            }

            return true;
        }

        private bool RequireCombo(ComboBox cb, string label, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(cb.Text))
            {
                errors.Add($"Chưa chọn {label}");
                return false;
            }
            return true;
        }

        private bool ValidateAllScores(out string message)
        {
            var errors = new List<string>();

            // ===== HỌC BẠ =====
            RequireNumber(txt10_Toan, "Toán 10", errors);
            RequireNumber(txt11_Toan, "Toán 11", errors);
            RequireNumber(txt12_Toan, "Toán 12", errors);

            RequireNumber(txt10_Van, "Văn 10", errors);
            RequireNumber(txt11_Van, "Văn 11", errors);
            RequireNumber(txt12_Van, "Văn 12", errors);

            RequireNumber(txt10_Ly, "Lý 10", errors);
            RequireNumber(txt11_Ly, "Lý 11", errors);
            RequireNumber(txt12_Ly, "Lý 12", errors);

            RequireNumber(txt10_Hoa, "Hóa 10", errors);
            RequireNumber(txt11_Hoa, "Hóa 11", errors);
            RequireNumber(txt12_Hoa, "Hóa 12", errors);

            RequireNumber(txt10_Sinh, "Sinh 10", errors);
            RequireNumber(txt11_Sinh, "Sinh 11", errors);
            RequireNumber(txt12_Sinh, "Sinh 12", errors);

            RequireNumber(txt10_Su, "Sử 10", errors);
            RequireNumber(txt11_Su, "Sử 11", errors);
            RequireNumber(txt12_Su, "Sử 12", errors);

            RequireNumber(txt10_Dia, "Địa 10", errors);
            RequireNumber(txt11_Dia, "Địa 11", errors);
            RequireNumber(txt12_Dia, "Địa 12", errors);

            RequireNumber(txt10_Tin, "Tin 10", errors);
            RequireNumber(txt11_Tin, "Tin 11", errors);
            RequireNumber(txt12_Tin, "Tin 12", errors);

            RequireNumber(txt10_CongNghe, "Công nghệ 10", errors);
            RequireNumber(txt11_CongNghe, "Công nghệ 11", errors);
            RequireNumber(txt12_CongNghe, "Công nghệ 12", errors);

            RequireNumber(txt10_GDKTPL, "GDKTPL 10", errors);
            RequireNumber(txt11_GDKTPL, "GDKTPL 11", errors);
            RequireNumber(txt12_GDKTPL, "GDKTPL 12", errors);

            // ===== NGOẠI NGỮ =====
            RequireCombo(cbForeignLang, "môn Ngoại ngữ", errors);
            RequireNumber(txt10_NN, "Ngoại ngữ 10", errors);
            RequireNumber(txt11_NN, "Ngoại ngữ 11", errors);
            RequireNumber(txt12_NN, "Ngoại ngữ 12", errors);

            // ===== THPT =====
            RequireNumber(txtTHPT_Toan, "THPT Toán", errors);
            RequireNumber(txtTHPT_Van, "THPT Văn", errors);

            RequireCombo(cbTHPT_Mon1, "môn THPT tự chọn 1", errors);
            RequireNumber(txtTHPT_Mon1, "điểm THPT tự chọn 1", errors);

            RequireCombo(cbTHPT_Mon2, "môn THPT tự chọn 2", errors);
            RequireNumber(txtTHPT_Mon2, "điểm THPT tự chọn 2", errors);

            if (cbTHPT_Mon1.Text == cbTHPT_Mon2.Text)
                errors.Add("Hai môn THPT tự chọn không được trùng nhau");

            // ===== DGNL =====
            RequireNumber(txtDgnl_NgonNgu, "DGNL Ngôn ngữ", errors);
            RequireNumber(txtDgnl_Toan, "DGNL Toán", errors);
            RequireNumber(txtDgnl_TuDuy, "DGNL Tư duy", errors);

            // ===== ƯU TIÊN =====
            RequireCombo(cbKhuVuc, "khu vực ưu tiên", errors);
            RequireCombo(cbDoiTuong, "đối tượng ưu tiên", errors);
            RequireNumber(txtDiemCong, "điểm cộng", errors);

            if (errors.Any())
            {
                message = "❌ Chưa nhập đủ hoặc sai dữ liệu:\n\n- " +
                          string.Join("\n- ", errors);
                return false;
            }

            message = "";
            return true;
        }

    }
}
