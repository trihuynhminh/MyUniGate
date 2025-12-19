namespace UniGate.Student.Forms
{
    partial class FormChonKhoi
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
            listView_Khoi = new ListView();
            listBox1 = new ListBox();
            lbl_Top1 = new Label();
            lbl_Top2 = new Label();
            lbl_Top3 = new Label();
            btnXemNganh = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(421, 27);
            label1.Name = "label1";
            label1.Size = new Size(593, 71);
            label1.TabIndex = 0;
            label1.Text = "Chọn Tổ Hợp Xét Tuyển";
            // 
            // listView_Khoi
            // 
            listView_Khoi.Location = new Point(36, 128);
            listView_Khoi.Name = "listView_Khoi";
            listView_Khoi.Size = new Size(613, 514);
            listView_Khoi.TabIndex = 1;
            listView_Khoi.UseCompatibleStateImageBehavior = false;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(796, 128);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(578, 516);
            listBox1.TabIndex = 2;
            // 
            // lbl_Top1
            // 
            lbl_Top1.AutoSize = true;
            lbl_Top1.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Top1.Location = new Point(958, 281);
            lbl_Top1.Name = "lbl_Top1";
            lbl_Top1.Size = new Size(120, 50);
            lbl_Top1.TabIndex = 3;
            lbl_Top1.Text = "label2";
            // 
            // lbl_Top2
            // 
            lbl_Top2.AutoSize = true;
            lbl_Top2.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Top2.Location = new Point(958, 409);
            lbl_Top2.Name = "lbl_Top2";
            lbl_Top2.Size = new Size(120, 50);
            lbl_Top2.TabIndex = 4;
            lbl_Top2.Text = "label2";
            // 
            // lbl_Top3
            // 
            lbl_Top3.AutoSize = true;
            lbl_Top3.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Top3.Location = new Point(958, 538);
            lbl_Top3.Name = "lbl_Top3";
            lbl_Top3.Size = new Size(120, 50);
            lbl_Top3.TabIndex = 5;
            lbl_Top3.Text = "label2";
            // 
            // btnXemNganh
            // 
            btnXemNganh.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXemNganh.Location = new Point(537, 672);
            btnXemNganh.Name = "btnXemNganh";
            btnXemNganh.Size = new Size(347, 65);
            btnXemNganh.TabIndex = 6;
            btnXemNganh.Text = "Xem Ngành Phù Hợp";
            btnXemNganh.UseVisualStyleBackColor = true;
            btnXemNganh.Click += btnXemNganh_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(873, 181);
            label2.Name = "label2";
            label2.Size = new Size(449, 45);
            label2.TabIndex = 7;
            label2.Text = "Gợi Ý Các Tổ Hợp Điểm Cao";
            // 
            // FormChonKhoi
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1418, 767);
            Controls.Add(label2);
            Controls.Add(btnXemNganh);
            Controls.Add(lbl_Top3);
            Controls.Add(lbl_Top2);
            Controls.Add(lbl_Top1);
            Controls.Add(listBox1);
            Controls.Add(listView_Khoi);
            Controls.Add(label1);
            Name = "FormChonKhoi";
            Text = "FormChonKhoi";
            Load += FormChonKhoi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListView listView_Khoi;
        private ListBox listBox1;
        private Label lbl_Top1;
        private Label lbl_Top2;
        private Label lbl_Top3;
        private Button btnXemNganh;
        private Label label2;
    }
}