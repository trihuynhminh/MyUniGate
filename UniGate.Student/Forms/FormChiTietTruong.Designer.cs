namespace UniGate.Student.Forms
{
    partial class FormChiTietTruong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtProvince = new TextBox();
            picturebox_logo = new PictureBox();
            txtUniversityName = new TextBox();
            txtUniversityCode = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            linklabel_Website = new LinkLabel();
            richtextbox_descriptionchitiet = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)picturebox_logo).BeginInit();
            SuspendLayout();
            // 
            // txtProvince
            // 
            txtProvince.Location = new Point(221, 240);
            txtProvince.Multiline = true;
            txtProvince.Name = "txtProvince";
            txtProvince.Size = new Size(276, 47);
            txtProvince.TabIndex = 24;
            // 
            // picturebox_logo
            // 
            picturebox_logo.Location = new Point(221, 815);
            picturebox_logo.Name = "picturebox_logo";
            picturebox_logo.Size = new Size(520, 373);
            picturebox_logo.TabIndex = 23;
            picturebox_logo.TabStop = false;
            // 
            // txtUniversityName
            // 
            txtUniversityName.Location = new Point(226, 142);
            txtUniversityName.Multiline = true;
            txtUniversityName.Name = "txtUniversityName";
            txtUniversityName.Size = new Size(693, 47);
            txtUniversityName.TabIndex = 20;
            // 
            // txtUniversityCode
            // 
            txtUniversityCode.Location = new Point(226, 56);
            txtUniversityCode.Multiline = true;
            txtUniversityCode.Name = "txtUniversityCode";
            txtUniversityCode.Size = new Size(195, 47);
            txtUniversityCode.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold);
            label5.Location = new Point(32, 419);
            label5.Name = "label5";
            label5.Size = new Size(104, 37);
            label5.TabIndex = 17;
            label5.Text = "Mô tả:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold);
            label4.Location = new Point(32, 322);
            label4.Name = "label4";
            label4.Size = new Size(133, 37);
            label4.TabIndex = 16;
            label4.Text = "Website:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold);
            label3.Location = new Point(32, 240);
            label3.Name = "label3";
            label3.Size = new Size(85, 37);
            label3.TabIndex = 15;
            label3.Text = "Tỉnh:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold);
            label2.Location = new Point(32, 152);
            label2.Name = "label2";
            label2.Size = new Size(182, 37);
            label2.TabIndex = 14;
            label2.Text = "Tên Trường:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold);
            label1.Location = new Point(32, 66);
            label1.Name = "label1";
            label1.Size = new Size(175, 37);
            label1.TabIndex = 13;
            label1.Text = "Mã Trường:";
            // 
            // linklabel_Website
            // 
            linklabel_Website.AutoSize = true;
            linklabel_Website.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linklabel_Website.Location = new Point(221, 322);
            linklabel_Website.Name = "linklabel_Website";
            linklabel_Website.Size = new Size(138, 37);
            linklabel_Website.TabIndex = 25;
            linklabel_Website.TabStop = true;
            linklabel_Website.Text = "linkLabel1";
            linklabel_Website.LinkClicked += linklabel_Website_LinkClicked;
            // 
            // richtextbox_descriptionchitiet
            // 
            richtextbox_descriptionchitiet.Location = new Point(221, 420);
            richtextbox_descriptionchitiet.Name = "richtextbox_descriptionchitiet";
            richtextbox_descriptionchitiet.Size = new Size(677, 336);
            richtextbox_descriptionchitiet.TabIndex = 26;
            richtextbox_descriptionchitiet.Text = "";
            // 
            // FormChiTietTruong
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 1273);
            Controls.Add(richtextbox_descriptionchitiet);
            Controls.Add(linklabel_Website);
            Controls.Add(txtProvince);
            Controls.Add(picturebox_logo);
            Controls.Add(txtUniversityName);
            Controls.Add(txtUniversityCode);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormChiTietTruong";
            Text = "FormChiTietTruong";
            Load += FormChiTietTruong_Load;
            ((System.ComponentModel.ISupportInitialize)picturebox_logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtProvince;
        private PictureBox picturebox_logo;
        private TextBox txtUniversityName;
        private TextBox txtUniversityCode;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private LinkLabel linklabel_Website;
        private RichTextBox richtextbox_descriptionchitiet;
    }
}