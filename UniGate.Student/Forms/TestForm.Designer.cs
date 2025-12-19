using System.Drawing;
using System.Windows.Forms;

namespace UniGate.Student.Forms
{
    partial class TestForm
    {
        private Label lblTitle;
        private Label lblProgress;
        private ProgressBar progressBar;
        private FlowLayoutPanel pnlNumberRow;
        private Label lblQuestionNumber;
        private Label lblActivityTitle;
        private Label lblQuestionText;
        private FlowLayoutPanel pnlRateButtons;
        private Button btnRate1, btnRate2, btnRate3, btnRate4, btnRate5;
        private Button btnPrev, btnNext, btnPrevPage, btnNextPage;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            lblTitle = new Label();
            lblProgress = new Label();
            progressBar = new ProgressBar();
            pnlNumberRow = new FlowLayoutPanel();
            lblQuestionNumber = new Label();
            lblActivityTitle = new Label();
            lblQuestionText = new Label();
            pnlRateButtons = new FlowLayoutPanel();
            btnRate1 = new Button();
            btnRate2 = new Button();
            btnRate3 = new Button();
            btnRate4 = new Button();
            btnRate5 = new Button();
            btnPrev = new Button();
            btnNext = new Button();
            btnPrevPage = new Button();
            btnNextPage = new Button();
            pnlRateButtons.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Bookman Old Style", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Green;
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(640, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Bài Test Holland (RIASEC)";
            // 
            // lblProgress
            // 
            lblProgress.Location = new Point(20, 54);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(89, 29);
            lblProgress.TabIndex = 1;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(20, 86);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(760, 12);
            progressBar.TabIndex = 2;
            // 
            // pnlNumberRow
            // 
            pnlNumberRow.Location = new Point(20, 104);
            pnlNumberRow.Name = "pnlNumberRow";
            pnlNumberRow.Size = new Size(760, 46);
            pnlNumberRow.TabIndex = 3;
            // 
            // lblQuestionNumber
            // 
            lblQuestionNumber.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblQuestionNumber.Location = new Point(20, 155);
            lblQuestionNumber.Name = "lblQuestionNumber";
            lblQuestionNumber.Size = new Size(128, 29);
            lblQuestionNumber.TabIndex = 4;
            lblQuestionNumber.Click += lblQuestionNumber_Click;
            // 
            // lblActivityTitle
            // 
            lblActivityTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblActivityTitle.Location = new Point(20, 184);
            lblActivityTitle.Name = "lblActivityTitle";
            lblActivityTitle.Size = new Size(450, 41);
            lblActivityTitle.TabIndex = 5;
            lblActivityTitle.Text = "Mức độ yêu thích với hoạt động:";
            // 
            // lblQuestionText
            // 
            lblQuestionText.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuestionText.Location = new Point(20, 233);
            lblQuestionText.Name = "lblQuestionText";
            lblQuestionText.Size = new Size(760, 62);
            lblQuestionText.TabIndex = 6;
            // 
            // pnlRateButtons
            // 
            pnlRateButtons.Controls.Add(btnRate1);
            pnlRateButtons.Controls.Add(btnRate2);
            pnlRateButtons.Controls.Add(btnRate3);
            pnlRateButtons.Controls.Add(btnRate4);
            pnlRateButtons.Controls.Add(btnRate5);
            pnlRateButtons.Location = new Point(163, 298);
            pnlRateButtons.Name = "pnlRateButtons";
            pnlRateButtons.Size = new Size(429, 71);
            pnlRateButtons.TabIndex = 7;
            // 
            // btnRate1
            // 
            btnRate1.Location = new Point(3, 3);
            btnRate1.Name = "btnRate1";
            btnRate1.Size = new Size(75, 43);
            btnRate1.TabIndex = 0;
            btnRate1.Text = "1";
            btnRate1.Click += btnRate1_Click;
            // 
            // btnRate2
            // 
            btnRate2.Location = new Point(84, 3);
            btnRate2.Name = "btnRate2";
            btnRate2.Size = new Size(75, 43);
            btnRate2.TabIndex = 1;
            btnRate2.Text = "2";
            btnRate2.Click += btnRate2_Click;
            // 
            // btnRate3
            // 
            btnRate3.Location = new Point(165, 3);
            btnRate3.Name = "btnRate3";
            btnRate3.Size = new Size(75, 43);
            btnRate3.TabIndex = 2;
            btnRate3.Text = "3";
            btnRate3.Click += btnRate3_Click;
            // 
            // btnRate4
            // 
            btnRate4.Location = new Point(246, 3);
            btnRate4.Name = "btnRate4";
            btnRate4.Size = new Size(75, 43);
            btnRate4.TabIndex = 3;
            btnRate4.Text = "4";
            btnRate4.Click += btnRate4_Click;
            // 
            // btnRate5
            // 
            btnRate5.Location = new Point(327, 3);
            btnRate5.Name = "btnRate5";
            btnRate5.Size = new Size(81, 43);
            btnRate5.TabIndex = 4;
            btnRate5.Text = "5";
            btnRate5.Click += btnRate5_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(20, 420);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(89, 42);
            btnPrev.TabIndex = 8;
            btnPrev.Text = "← Trước";
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(660, 420);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(76, 42);
            btnNext.TabIndex = 9;
            btnNext.Text = "Tiếp →";
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevPage
            // 
            btnPrevPage.Location = new Point(20, 360);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(75, 23);
            btnPrevPage.TabIndex = 10;
            btnPrevPage.Text = "<";
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.Location = new Point(705, 360);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(75, 23);
            btnNextPage.TabIndex = 11;
            btnNextPage.Text = ">";
            btnNextPage.Click += btnNextPage_Click;
            // 
            // TestForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(820, 520);
            Controls.Add(lblTitle);
            Controls.Add(lblProgress);
            Controls.Add(progressBar);
            Controls.Add(pnlNumberRow);
            Controls.Add(lblQuestionNumber);
            Controls.Add(lblActivityTitle);
            Controls.Add(lblQuestionText);
            Controls.Add(pnlRateButtons);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);
            Controls.Add(btnPrevPage);
            Controls.Add(btnNextPage);
            Name = "TestForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Holland Test";
            Load += TestForm_Load;
            pnlRateButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
