using System.Drawing;
using System.Windows.Forms;

namespace UniGate.Student.Forms
{
    partial class TestResultForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelMain;
        private Panel panelHeader;
        private Label lblHeaderTitle;
        private Label lblHeaderSub;

        private Panel panelCode;
        private Label lblYourCodeCaption;
        private Label lblYourCodeValue;
        private Label lblTop3Caption;
        private Label lblTop3Value;

        private Panel panelDetail;
        private Label lblR;
        private Label lblI;
        private Label lblA;
        private Label lblS;
        private Label lblE;
        private Label lblC;

        private Label lblSummaryTitle;
        private TextBox txtSummary;

        private Button btnBack;
        private Button btnClose;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestResultForm));
            panelMain = new Panel();
            panelHeader = new Panel();
            lblHeaderTitle = new Label();
            lblHeaderSub = new Label();
            panelCode = new Panel();
            lblYourCodeCaption = new Label();
            lblYourCodeValue = new Label();
            lblTop3Caption = new Label();
            lblTop3Value = new Label();
            panelDetail = new Panel();
            lblR = new Label();
            lblI = new Label();
            lblA = new Label();
            lblS = new Label();
            lblE = new Label();
            lblC = new Label();
            lblSummaryTitle = new Label();
            txtSummary = new TextBox();
            btnBack = new Button();
            btnClose = new Button();
            panelMain.SuspendLayout();
            panelHeader.SuspendLayout();
            panelCode.SuspendLayout();
            panelDetail.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackgroundImage = (Image)resources.GetObject("panelMain.BackgroundImage");
            panelMain.Controls.Add(panelHeader);
            panelMain.Controls.Add(panelCode);
            panelMain.Controls.Add(panelDetail);
            panelMain.Controls.Add(btnBack);
            panelMain.Controls.Add(btnClose);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(20);
            panelMain.Size = new Size(900, 600);
            panelMain.TabIndex = 0;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblHeaderTitle);
            panelHeader.Controls.Add(lblHeaderSub);
            panelHeader.Location = new Point(30, 20);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(840, 84);
            panelHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.ForestGreen;
            lblHeaderTitle.Location = new Point(10, 5);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(391, 52);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Kết quả trắc nghiệm Holland";
            // 
            // lblHeaderSub
            // 
            lblHeaderSub.Location = new Point(10, 57);
            lblHeaderSub.Name = "lblHeaderSub";
            lblHeaderSub.Size = new Size(260, 23);
            lblHeaderSub.TabIndex = 1;
            lblHeaderSub.Text = "Dựa trên mô hình tính cách RIASEC";
            // 
            // panelCode
            // 
            panelCode.BorderStyle = BorderStyle.FixedSingle;
            panelCode.Controls.Add(lblYourCodeCaption);
            panelCode.Controls.Add(lblYourCodeValue);
            panelCode.Controls.Add(lblTop3Caption);
            panelCode.Controls.Add(lblTop3Value);
            panelCode.Location = new Point(30, 110);
            panelCode.Name = "panelCode";
            panelCode.Size = new Size(840, 90);
            panelCode.TabIndex = 1;
            // 
            // lblYourCodeCaption
            // 
            lblYourCodeCaption.Location = new Point(20, 20);
            lblYourCodeCaption.Name = "lblYourCodeCaption";
            lblYourCodeCaption.Size = new Size(100, 23);
            lblYourCodeCaption.TabIndex = 0;
            lblYourCodeCaption.Text = "Mã Holland:";
            // 
            // lblYourCodeValue
            // 
            lblYourCodeValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblYourCodeValue.Location = new Point(140, 10);
            lblYourCodeValue.Name = "lblYourCodeValue";
            lblYourCodeValue.Size = new Size(129, 45);
            lblYourCodeValue.TabIndex = 1;
            // 
            // lblTop3Caption
            // 
            lblTop3Caption.Location = new Point(20, 55);
            lblTop3Caption.Name = "lblTop3Caption";
            lblTop3Caption.Size = new Size(100, 23);
            lblTop3Caption.TabIndex = 2;
            lblTop3Caption.Text = "Top 3 nhóm mạnh nhất:";
            // 
            // lblTop3Value
            // 
            lblTop3Value.Font = new Font("Segoe UI", 12F);
            lblTop3Value.Location = new Point(180, 55);
            lblTop3Value.Name = "lblTop3Value";
            lblTop3Value.Size = new Size(100, 23);
            lblTop3Value.TabIndex = 3;
            // 
            // panelDetail
            // 
            panelDetail.BorderStyle = BorderStyle.FixedSingle;
            panelDetail.Controls.Add(lblR);
            panelDetail.Controls.Add(lblI);
            panelDetail.Controls.Add(lblA);
            panelDetail.Controls.Add(lblS);
            panelDetail.Controls.Add(lblE);
            panelDetail.Controls.Add(lblC);
            panelDetail.Controls.Add(lblSummaryTitle);
            panelDetail.Controls.Add(txtSummary);
            panelDetail.Location = new Point(30, 210);
            panelDetail.Name = "panelDetail";
            panelDetail.Size = new Size(840, 290);
            panelDetail.TabIndex = 2;

            // 
            // lblR
            // 
            lblR.Location = new Point(20, 20);
            lblR.Name = "lblR";
            lblR.Size = new Size(100, 23);
            lblR.TabIndex = 0;
            // 
            // lblI
            // 
            lblI.Location = new Point(20, 50);
            lblI.Name = "lblI";
            lblI.Size = new Size(100, 23);
            lblI.TabIndex = 1;
            // 
            // lblA
            // 
            lblA.Location = new Point(20, 80);
            lblA.Name = "lblA";
            lblA.Size = new Size(100, 23);
            lblA.TabIndex = 2;
            // 
            // lblS
            // 
            lblS.Location = new Point(300, 20);
            lblS.Name = "lblS";
            lblS.Size = new Size(100, 23);
            lblS.TabIndex = 3;
            // 
            // lblE
            // 
            lblE.Location = new Point(300, 50);
            lblE.Name = "lblE";
            lblE.Size = new Size(100, 23);
            lblE.TabIndex = 4;
            // 
            // lblC
            // 
            lblC.Location = new Point(300, 80);
            lblC.Name = "lblC";
            lblC.Size = new Size(100, 23);
            lblC.TabIndex = 5;
            // 
            // lblSummaryTitle
            // 
            lblSummaryTitle.Location = new Point(20, 120);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(100, 23);
            lblSummaryTitle.TabIndex = 6;
            lblSummaryTitle.Text = "Gợi ý nghề nghiệp:";
            // 
            // txtSummary
            // 
            txtSummary.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSummary.Location = new Point(20, 150);
            txtSummary.Multiline = true;
            txtSummary.Name = "txtSummary";
            txtSummary.ScrollBars = ScrollBars.Vertical;
            txtSummary.Size = new Size(790, 120);
            txtSummary.TabIndex = 7;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(250, 520);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(140, 40);
            btnBack.TabIndex = 3;
            btnBack.Text = "← Quay lại";
            btnBack.Click += BtnBack_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(500, 520);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(140, 40);
            btnClose.TabIndex = 4;
            btnClose.Text = "Đóng";
            btnClose.Click += BtnClose_Click;
            // 
            // TestResultForm
            // 
            ClientSize = new Size(900, 600);
            Controls.Add(panelMain);
            Name = "TestResultForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kết quả Holland";
            Load += TestResultForm_Load;
            panelMain.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelCode.ResumeLayout(false);
            panelDetail.ResumeLayout(false);
            panelDetail.PerformLayout();
            ResumeLayout(false);
        }
    }
}
