namespace UniGate.Admin.Forms
{
    partial class FormQuanLyNganh
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
            cbb_Truong = new ComboBox();
            lv_Nganh = new ListView();
            btn_Them = new Button();
            btn_Sua = new Button();
            btn_Xoa = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightCoral;
            label1.Location = new Point(320, 14);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(222, 37);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Ngành";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(198, 69);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(68, 23);
            label2.TabIndex = 1;
            label2.Text = "Trường:";
            // 
            // cbb_Truong
            // 
            cbb_Truong.FormattingEnabled = true;
            cbb_Truong.Location = new Point(278, 69);
            cbb_Truong.Margin = new Padding(2, 2, 2, 2);
            cbb_Truong.Name = "cbb_Truong";
            cbb_Truong.Size = new Size(300, 28);
            cbb_Truong.TabIndex = 2;
            // 
            // lv_Nganh
            // 
            lv_Nganh.Location = new Point(46, 118);
            lv_Nganh.Margin = new Padding(2, 2, 2, 2);
            lv_Nganh.Name = "lv_Nganh";
            lv_Nganh.Size = new Size(562, 288);
            lv_Nganh.TabIndex = 3;
            lv_Nganh.UseCompatibleStateImageBehavior = false;
            // 
            // btn_Them
            // 
            btn_Them.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Them.Location = new Point(652, 134);
            btn_Them.Margin = new Padding(2, 2, 2, 2);
            btn_Them.Name = "btn_Them";
            btn_Them.Size = new Size(92, 39);
            btn_Them.TabIndex = 4;
            btn_Them.Text = "Thêm";
            btn_Them.UseVisualStyleBackColor = true;
            // 
            // btn_Sua
            // 
            btn_Sua.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Sua.Location = new Point(652, 209);
            btn_Sua.Margin = new Padding(2, 2, 2, 2);
            btn_Sua.Name = "btn_Sua";
            btn_Sua.Size = new Size(92, 39);
            btn_Sua.TabIndex = 5;
            btn_Sua.Text = "Sửa";
            btn_Sua.UseVisualStyleBackColor = true;
            // 
            // btn_Xoa
            // 
            btn_Xoa.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Xoa.Location = new Point(652, 293);
            btn_Xoa.Margin = new Padding(2, 2, 2, 2);
            btn_Xoa.Name = "btn_Xoa";
            btn_Xoa.Size = new Size(92, 37);
            btn_Xoa.TabIndex = 6;
            btn_Xoa.Text = "Xóa";
            btn_Xoa.UseVisualStyleBackColor = true;
            // 
            // FormQuanLyNganh
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 431);
            Controls.Add(btn_Xoa);
            Controls.Add(btn_Sua);
            Controls.Add(btn_Them);
            Controls.Add(lv_Nganh);
            Controls.Add(cbb_Truong);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormQuanLyNganh";
            Text = "FormQuanLyNganh";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbb_Truong;
        private ListView lv_Nganh;
        private Button btn_Them;
        private Button btn_Sua;
        private Button btn_Xoa;
    }
}