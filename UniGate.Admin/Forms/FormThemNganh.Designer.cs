namespace UniGate.Admin.Forms
{
    partial class FormThemNganh
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
            label6 = new Label();
            checkedListBox1_ToHop = new CheckedListBox();
            btnSave = new Button();
            txtYear = new TextBox();
            txtMinScore = new TextBox();
            label5 = new Label();
            label4 = new Label();
            txtMajorName = new TextBox();
            txtMajorCode = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            richtextbox_descriptionnganh = new RichTextBox();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(94, 683);
            label6.Name = "label6";
            label6.Size = new Size(87, 32);
            label6.TabIndex = 42;
            label6.Text = "Mô Tả:";
            // 
            // checkedListBox1_ToHop
            // 
            checkedListBox1_ToHop.FormattingEnabled = true;
            checkedListBox1_ToHop.Location = new Point(202, 230);
            checkedListBox1_ToHop.Name = "checkedListBox1_ToHop";
            checkedListBox1_ToHop.Size = new Size(692, 400);
            checkedListBox1_ToHop.TabIndex = 41;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(445, 1096);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 64);
            btnSave.TabIndex = 40;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(682, 999);
            txtYear.Multiline = true;
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(195, 47);
            txtYear.TabIndex = 39;
            // 
            // txtMinScore
            // 
            txtMinScore.Location = new Point(212, 999);
            txtMinScore.Multiline = true;
            txtMinScore.Name = "txtMinScore";
            txtMinScore.Size = new Size(195, 47);
            txtMinScore.TabIndex = 38;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(606, 1014);
            label5.Name = "label5";
            label5.Size = new Size(70, 32);
            label5.TabIndex = 37;
            label5.Text = "Năm:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 1016);
            label4.Name = "label4";
            label4.Size = new Size(147, 32);
            label4.TabIndex = 36;
            label4.Text = "Điểm Chuẩn";
            // 
            // txtMajorName
            // 
            txtMajorName.Location = new Point(201, 132);
            txtMajorName.Multiline = true;
            txtMajorName.Name = "txtMajorName";
            txtMajorName.Size = new Size(693, 47);
            txtMajorName.TabIndex = 35;
            // 
            // txtMajorCode
            // 
            txtMajorCode.Location = new Point(201, 49);
            txtMajorCode.Multiline = true;
            txtMajorCode.Name = "txtMajorCode";
            txtMajorCode.Size = new Size(195, 47);
            txtMajorCode.TabIndex = 34;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 230);
            label3.Name = "label3";
            label3.Size = new Size(98, 32);
            label3.TabIndex = 33;
            label3.Text = "Tổ Hợp:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 147);
            label2.Name = "label2";
            label2.Size = new Size(136, 32);
            label2.TabIndex = 32;
            label2.Text = "Tên Ngành:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 64);
            label1.Name = "label1";
            label1.Size = new Size(132, 32);
            label1.TabIndex = 31;
            label1.Text = "Mã Ngành:";
            // 
            // richtextbox_descriptionnganh
            // 
            richtextbox_descriptionnganh.Location = new Point(202, 680);
            richtextbox_descriptionnganh.Name = "richtextbox_descriptionnganh";
            richtextbox_descriptionnganh.Size = new Size(692, 263);
            richtextbox_descriptionnganh.TabIndex = 44;
            richtextbox_descriptionnganh.Text = "";
            // 
            // FormThemNganh
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 1175);
            Controls.Add(richtextbox_descriptionnganh);
            Controls.Add(label6);
            Controls.Add(checkedListBox1_ToHop);
            Controls.Add(btnSave);
            Controls.Add(txtYear);
            Controls.Add(txtMinScore);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtMajorName);
            Controls.Add(txtMajorCode);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormThemNganh";
            Text = "FormThemNganh";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label6;
        private CheckedListBox checkedListBox1_ToHop;
        private Button btnSave;
        private TextBox txtYear;
        private TextBox txtMinScore;
        private Label label5;
        private Label label4;
        private TextBox txtMajorName;
        private TextBox txtMajorCode;
        private Label label3;
        private Label label2;
        private Label label1;
        private RichTextBox richtextbox_descriptionnganh;
    }
}