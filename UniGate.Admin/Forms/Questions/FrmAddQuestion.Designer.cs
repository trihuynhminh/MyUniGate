using System.Windows.Forms;
using System.Drawing;


namespace UniGate.Admin.Forms.Questions
{
    partial class FrmAddQuestion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblContent = new Label();
            txtContent = new TextBox();
            lblCode = new Label();
            txtCode = new TextBox();
            lblGroup = new Label();
            txtGroup = new TextBox();
            chkActive = new CheckBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Location = new Point(20, 20);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(126, 20);
            lblContent.TabIndex = 7;
            lblContent.Text = "Nội dung câu hỏi:";
            // 
            // txtContent
            // 
            txtContent.Location = new Point(20, 45);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(400, 120);
            txtContent.TabIndex = 6;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(20, 175);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(105, 20);
            lblCode.TabIndex = 5;
            lblCode.Text = "Code (R1/I2...):";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(20, 200);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(150, 27);
            txtCode.TabIndex = 4;
            // 
            // lblGroup
            // 
            lblGroup.AutoSize = true;
            lblGroup.Location = new Point(200, 175);
            lblGroup.Name = "lblGroup";
            lblGroup.Size = new Size(145, 20);
            lblGroup.TabIndex = 3;
            lblGroup.Text = "Nhóm (R/I/A/S/E/C):";
            // 
            // txtGroup
            // 
            txtGroup.Location = new Point(200, 200);
            txtGroup.Name = "txtGroup";
            txtGroup.Size = new Size(100, 27);
            txtGroup.TabIndex = 2;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(20, 240);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(105, 24);
            chkActive.TabIndex = 1;
            chkActive.Text = "Đang dùng";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(275, 235);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(145, 35);
            btnSave.TabIndex = 0;
            btnSave.Text = "Thêm mới";
            btnSave.Click += btnSave_Click;
            // 
            // FrmAddQuestion
            // 
            ClientSize = new Size(522, 383);
            Controls.Add(btnSave);
            Controls.Add(chkActive);
            Controls.Add(txtGroup);
            Controls.Add(lblGroup);
            Controls.Add(txtCode);
            Controls.Add(lblCode);
            Controls.Add(txtContent);
            Controls.Add(lblContent);
            Name = "FrmAddQuestion";
            Text = "Thêm câu hỏi mới";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblContent;
        private TextBox txtContent;
        private Label lblCode;
        private TextBox txtCode;
        private Label lblGroup;
        private TextBox txtGroup;
        private CheckBox chkActive;
        private Button btnSave;
    }
}
