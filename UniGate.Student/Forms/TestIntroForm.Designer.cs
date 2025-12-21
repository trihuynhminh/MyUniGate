using System.Drawing;
using System.Windows.Forms;

namespace UniGate.Student.Forms
{
    partial class TestIntroForm
    {
        private Label lblTitle;
        private Label lblSubTitle;

        private Panel pnlInfo;
        private Label lblItemCount;
        private Label lblTime;
        private Label lblGroup;

        private Label lblItemCountValue;
        private Label lblTimeValue;
        private Label lblGroupValue;

        private TextBox txtIntro;
        private Button btnStart;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestIntroForm));
            lblTitle = new Label();
            lblSubTitle = new Label();
            pnlInfo = new Panel();
            lblItemCount = new Label();
            lblTime = new Label();
            lblGroup = new Label();
            lblItemCountValue = new Label();
            lblTimeValue = new Label();
            lblGroupValue = new Label();
            txtIntro = new TextBox();
            btnStart = new Button();
            pnlInfo.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Green;
            lblTitle.Location = new Point(200, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(500, 45);
            lblTitle.TabIndex = 0;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubTitle
            // 
            lblSubTitle.Font = new Font("Segoe UI", 11F);
            lblSubTitle.Location = new Point(150, 80);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(600, 50);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlInfo
            // 
            pnlInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlInfo.Controls.Add(lblItemCount);
            pnlInfo.Controls.Add(lblTime);
            pnlInfo.Controls.Add(lblGroup);
            pnlInfo.Controls.Add(lblItemCountValue);
            pnlInfo.Controls.Add(lblTimeValue);
            pnlInfo.Controls.Add(lblGroupValue);
            pnlInfo.Location = new Point(120, 150);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Size = new Size(580, 80);
            pnlInfo.TabIndex = 2;
            // 
            // lblItemCount
            // 
            lblItemCount.Location = new Point(40, 10);
            lblItemCount.Name = "lblItemCount";
            lblItemCount.Size = new Size(100, 23);
            lblItemCount.TabIndex = 0;
            lblItemCount.Text = "Số câu hỏi";
            // 
            // lblTime
            // 
            lblTime.Location = new Point(250, 10);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(100, 23);
            lblTime.TabIndex = 1;
            lblTime.Text = "Thời gian";
            // 
            // lblGroup
            // 
            lblGroup.Location = new Point(430, 10);
            lblGroup.Name = "lblGroup";
            lblGroup.Size = new Size(100, 23);
            lblGroup.TabIndex = 2;
            lblGroup.Text = "Nhóm RIASEC";
            // 
            // lblItemCountValue
            // 
            lblItemCountValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblItemCountValue.Location = new Point(50, 35);
            lblItemCountValue.Name = "lblItemCountValue";
            lblItemCountValue.Size = new Size(100, 43);
            lblItemCountValue.TabIndex = 3;
            // 
            // lblTimeValue
            // 
            lblTimeValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTimeValue.Location = new Point(250, 35);
            lblTimeValue.Name = "lblTimeValue";
            lblTimeValue.Size = new Size(115, 43);
            lblTimeValue.TabIndex = 4;
            // 
            // lblGroupValue
            // 
            lblGroupValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblGroupValue.Location = new Point(445, 35);
            lblGroupValue.Name = "lblGroupValue";
            lblGroupValue.Size = new Size(100, 44);
            lblGroupValue.TabIndex = 5;
            // 
            // txtIntro
            // 
            txtIntro.Font = new Font("Segoe UI", 10F);
            txtIntro.Location = new Point(120, 250);
            txtIntro.Multiline = true;
            txtIntro.Name = "txtIntro";
            txtIntro.ReadOnly = true;
            txtIntro.ScrollBars = ScrollBars.Vertical;
            txtIntro.Size = new Size(580, 140);
            txtIntro.TabIndex = 3;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.DeepSkyBlue;
            btnStart.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(330, 410);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(180, 45);
            btnStart.TabIndex = 4;
            btnStart.Text = "Bắt đầu làm bài";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // TestIntroForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(820, 520);
            Controls.Add(lblTitle);
            Controls.Add(lblSubTitle);
            Controls.Add(pnlInfo);
            Controls.Add(txtIntro);
            Controls.Add(btnStart);
            Name = "TestIntroForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giới thiệu trắc nghiệm Holland";
            Load += TestIntroForm_Load;
            pnlInfo.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
