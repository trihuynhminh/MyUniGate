using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UniGate.Student.Models;
using UniGate.Student.Services;

namespace UniGate.Student.Forms
{
    public partial class TestForm : Form
    {
        private readonly ApiClient _apiClient = new ApiClient();
        private readonly HollandApiService _hollandService = new HollandApiService();

        private List<HollandQuestion> _questions = new();
        private Button[] _numberButtons;
        private Dictionary<int, int> _answers = new();

        private int _index = 0;
        private int _currentPage = 0;

        public TestForm()
        {
            InitializeComponent();
        }

        // ================= LOAD =================
        private async void TestForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1️⃣ Gọi API lấy câu hỏi
                var data = await _apiClient.GetHollandQuestionsAsync();

                if (data == null || data.Count == 0)
                {
                    MessageBox.Show("Không tải được dữ liệu câu hỏi!");
                    Close();
                    return;
                }

                // 2️⃣ FIX CỨNG: CHỈ LẤY 60 CÂU ĐẦU
                _questions = data.Take(60).ToList();

                // 3️⃣ BẮT BUỘC PHẢI ĐỦ 60
                if (_questions.Count != 60)
                {
                    MessageBox.Show($"Số câu hỏi không hợp lệ: {_questions.Count}/60");
                    Close();
                    return;
                }

                // 4️⃣ RESET STATE
                _index = 0;
                _currentPage = 0;
                _answers.Clear();

                // 5️⃣ FIX CỨNG SỐ BUTTON = 60
                _numberButtons = new Button[60];

                // 6️⃣ PROGRESS BAR
                progressBar.Minimum = 0;
                progressBar.Maximum = 60;
                progressBar.Value = 1;
                lblProgress.Text = "1 / 60";

                // 7️⃣ KHỞI TẠO UI
                CreateNumberButtons();
                LoadPage(0);
                DisplayQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load câu hỏi: " + ex.Message);
                Close();
            }
        }



        // ================= UI =================
        private void CreateNumberButtons()
        {
            pnlNumberRow.Controls.Clear();

            for (int i = 0; i < _questions.Count; i++)
            {
                int idx = i;
                var btn = new Button
                {
                    Text = (i + 1).ToString(),
                    Width = 55,
                    Height = 35,
                    Tag = i
                };

                btn.Click += (s, e) =>
                {
                    _index = idx;
                    DisplayQuestion();
                };

                _numberButtons[i] = btn;
            }
        }

        private void LoadPage(int page)
        {
            pnlNumberRow.Controls.Clear();

            int start = page * 10;
            int end = Math.Min(start + 10, _questions.Count);

            for (int i = start; i < end; i++)
                pnlNumberRow.Controls.Add(_numberButtons[i]);

            HighlightNumberButtons();
        }

        private void DisplayQuestion()
        {
            if (_index < 0 || _index >= _questions.Count) return;

            var q = _questions[_index];

            lblQuestionNumber.Text = $"Câu {_index + 1} / {_questions.Count}";
            lblQuestionText.Text = q.Content;

            progressBar.Value = _index + 1;
            lblProgress.Text = $"{_index + 1} / {_questions.Count}";

            _currentPage = _index / 10;
            LoadPage(_currentPage);

            HighlightRateButtons();
        }

        private void HighlightNumberButtons()
        {
            for (int i = 0; i < _questions.Count; i++)
            {
                if (i == _index)
                    _numberButtons[i].BackColor = Color.DeepSkyBlue;
                else if (_answers.ContainsKey(i))
                    _numberButtons[i].BackColor = Color.LightGreen;
                else
                    _numberButtons[i].BackColor = Color.White;
            }
        }

        // ================= RATE =================
        private void Rate(int value)
        {
            _answers[_index] = value;
            HighlightNumberButtons();
            HighlightRateButtons();
        }

        private void HighlightRateButtons()
        {
            Button[] rates = { btnRate1, btnRate2, btnRate3, btnRate4, btnRate5 };
            foreach (var b in rates) b.BackColor = Color.White;

            if (_answers.ContainsKey(_index))
                rates[_answers[_index] - 1].BackColor = Color.DeepSkyBlue;
        }

        private void btnRate1_Click(object sender, EventArgs e) => Rate(1);
        private void btnRate2_Click(object sender, EventArgs e) => Rate(2);
        private void btnRate3_Click(object sender, EventArgs e) => Rate(3);
        private void btnRate4_Click(object sender, EventArgs e) => Rate(4);
        private void btnRate5_Click(object sender, EventArgs e) => Rate(5);

        // ================= NAV =================
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_index > 0)
            {
                _index--;
                DisplayQuestion();
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            // Chưa tới câu cuối
            if (_index < _questions.Count - 1)
            {
                _index++;
                DisplayQuestion();
                return;
            }

            // Đã tới câu cuối → kiểm tra đủ câu
            if (_answers.Count != _questions.Count)
            {
                MessageBox.Show($"Bạn mới trả lời {_answers.Count}/{_questions.Count} câu!");
                return;
            }

            if (MessageBox.Show("Xem kết quả?", "Hoàn thành",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                var request = new
                {
                    answers = _answers.Select(a => new
                    {
                        questionId = _questions[a.Key].Id,
                        score = a.Value
                    }).ToList()
                };

                var result = await _hollandService.SubmitAsync(request);
                new TestResultForm(result).Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi submit: " + ex.Message);
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 0)
            {
                _currentPage--;
                LoadPage(_currentPage);
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if ((_currentPage + 1) * 10 < _questions.Count)
            {
                _currentPage++;
                LoadPage(_currentPage);
            }
        }

        // ===== FIX DESIGNER =====
        private void lblQuestionNumber_Click(object sender, EventArgs e)
        {
            // Không xử lý
        }
    }
}
