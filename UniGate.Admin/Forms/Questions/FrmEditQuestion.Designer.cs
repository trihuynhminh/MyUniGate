namespace UniGate.Admin.Forms.Questions
{
    partial class FrmEditQuestion
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(30, 20);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(80, 23);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(30, 60);
            this.txtContent.Multiline = true;
            this.txtContent.Size = new System.Drawing.Size(400, 80);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(30, 160);
            this.txtCode.Size = new System.Drawing.Size(120, 23);
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(180, 160);
            this.txtGroup.Size = new System.Drawing.Size(120, 23);
            // 
            // chkActive
            // 
            this.chkActive.Location = new System.Drawing.Point(30, 200);
            this.chkActive.Text = "Đang dùng";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(30, 240);
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.Text = "Lưu thay đổi";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmEditQuestion
            // 
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btnSave);
            this.Text = "Sửa câu hỏi";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
