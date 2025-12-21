using System.Windows.Forms;

namespace UniGate.Admin.Forms

{
    partial class FormQuanLyTruong: Form
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
            lvTruong = new ListView();
            txtTim = new TextBox();
            btnTim = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightCoral;
            label1.Location = new Point(412, 37);
            label1.Name = "label1";
            label1.Size = new Size(314, 50);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Trường";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(113, 122);
            label2.Name = "label2";
            label2.Size = new Size(134, 37);
            label2.TabIndex = 1;
            label2.Text = "Tìm Kiếm:";
            // 
            // lvTruong
            // 
            lvTruong.Location = new Point(65, 183);
            lvTruong.Name = "lvTruong";
            lvTruong.Size = new Size(781, 407);
            lvTruong.TabIndex = 2;
            lvTruong.UseCompatibleStateImageBehavior = false;
            // 
            // txtTim
            // 
            txtTim.Location = new Point(253, 116);
            txtTim.Multiline = true;
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(554, 49);
            txtTim.TabIndex = 3;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(843, 119);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(150, 46);
            btnTim.TabIndex = 4;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
           
            // 
            // btnThem
            // 
            btnThem.Location = new Point(884, 257);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(150, 46);
            btnThem.TabIndex = 5;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
           
            // 
            // btnSua
            // 
            btnSua.Location = new Point(884, 360);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(150, 46);
            btnSua.TabIndex = 6;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(884, 483);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(150, 46);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            
            // 
            // FormQuanLyTruong
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1063, 635);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(btnTim);
            Controls.Add(txtTim);
            Controls.Add(lvTruong);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormQuanLyTruong";
            Text = "FormQuanLyTruong";
          
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ListView lvTruong;
        private TextBox txtTim;
        private Button btnTim;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
    }
}