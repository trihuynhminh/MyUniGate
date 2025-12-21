namespace UniGate.Admin.Forms
{
    partial class FormThemTruong
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtUniversityCode = new TextBox();
            txtUniversityName = new TextBox();
            txtWebsite = new TextBox();
            picturebox_logo = new PictureBox();
            btnSave = new Button();
            txtProvince = new TextBox();
            txtLogo = new TextBox();
            richTextBox1_description = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)picturebox_logo).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 53);
            label1.Name = "label1";
            label1.Size = new Size(135, 32);
            label1.TabIndex = 0;
            label1.Text = "Mã Trường:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 139);
            label2.Name = "label2";
            label2.Size = new Size(139, 32);
            label2.TabIndex = 1;
            label2.Text = "Tên Trường:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 227);
            label3.Name = "label3";
            label3.Size = new Size(61, 32);
            label3.TabIndex = 2;
            label3.Text = "Tỉnh";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 309);
            label4.Name = "label4";
            label4.Size = new Size(104, 32);
            label4.TabIndex = 3;
            label4.Text = "Website:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(73, 406);
            label5.Name = "label5";
            label5.Size = new Size(82, 32);
            label5.TabIndex = 4;
            label5.Text = "Mô tả:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(73, 704);
            label6.Name = "label6";
            label6.Size = new Size(72, 32);
            label6.TabIndex = 5;
            label6.Text = "Logo:";
            // 
            // txtUniversityCode
            // 
            txtUniversityCode.Location = new Point(250, 38);
            txtUniversityCode.Multiline = true;
            txtUniversityCode.Name = "txtUniversityCode";
            txtUniversityCode.Size = new Size(195, 47);
            txtUniversityCode.TabIndex = 6;
            // 
            // txtUniversityName
            // 
            txtUniversityName.Location = new Point(250, 124);
            txtUniversityName.Multiline = true;
            txtUniversityName.Name = "txtUniversityName";
            txtUniversityName.Size = new Size(693, 47);
            txtUniversityName.TabIndex = 7;
            // 
            // txtWebsite
            // 
            txtWebsite.Location = new Point(250, 294);
            txtWebsite.Multiline = true;
            txtWebsite.Name = "txtWebsite";
            txtWebsite.Size = new Size(693, 47);
            txtWebsite.TabIndex = 8;
            txtWebsite.DoubleClick += txtWebsite_DoubleClick;
            // 
            // picturebox_logo
            // 
            picturebox_logo.Location = new Point(240, 788);
            picturebox_logo.Name = "picturebox_logo";
            picturebox_logo.Size = new Size(360, 244);
            picturebox_logo.TabIndex = 10;
            picturebox_logo.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(775, 788);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(168, 69);
            btnSave.TabIndex = 11;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtProvince
            // 
            txtProvince.Location = new Point(245, 212);
            txtProvince.Multiline = true;
            txtProvince.Name = "txtProvince";
            txtProvince.Size = new Size(276, 47);
            txtProvince.TabIndex = 12;
            // 
            // txtLogo
            // 
            txtLogo.Location = new Point(245, 689);
            txtLogo.Multiline = true;
            txtLogo.Name = "txtLogo";
            txtLogo.Size = new Size(693, 47);
            txtLogo.TabIndex = 13;
            txtLogo.TextChanged += txtLogo_TextChanged;
            // 
            // richTextBox1_description
            // 
            richTextBox1_description.Location = new Point(250, 403);
            richTextBox1_description.Name = "richTextBox1_description";
            richTextBox1_description.Size = new Size(693, 236);
            richTextBox1_description.TabIndex = 14;
            richTextBox1_description.Text = "";
            // 
            // FormThemTruong
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 1105);
            Controls.Add(richTextBox1_description);
            Controls.Add(txtLogo);
            Controls.Add(txtProvince);
            Controls.Add(btnSave);
            Controls.Add(picturebox_logo);
            Controls.Add(txtWebsite);
            Controls.Add(txtUniversityName);
            Controls.Add(txtUniversityCode);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormThemTruong";
            Text = "FormThemTruong";
            ((System.ComponentModel.ISupportInitialize)picturebox_logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtUniversityCode;
        private TextBox txtUniversityName;
        private TextBox txtWebsite;
        private PictureBox picturebox_logo;
        private Button btnSave;
        private TextBox txtProvince;
        private TextBox txtLogo;
        private RichTextBox richTextBox1_description;
    }
}