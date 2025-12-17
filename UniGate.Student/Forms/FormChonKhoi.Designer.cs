using System.Windows.Forms;
using System;
using System.Drawing;



namespace UniGate.Student.Forms
{
    partial class FormChonKhoi: Form
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
            btnXemNganh = new Button();
            listViewKhoi = new ListView();
            listBox1 = new ListBox();
            lblTop1 = new Label();
            lblTop2 = new Label();
            lblTop3 = new Label();
            label2 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Segoe UI Black", 13.875F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Brown;
            label1.Location = new Point(425, 33);
            label1.Name = "label1";
            label1.Size = new Size(450, 52);
            label1.TabIndex = 1;
            label1.Text = "Chọn Tổ Hợp Xét Tuyển";
            // 
            // btnXemNganh
            // 
            btnXemNganh.BackColor = Color.Transparent;
            btnXemNganh.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXemNganh.Location = new Point(438, 497);
            btnXemNganh.Name = "btnXemNganh";
            btnXemNganh.Size = new Size(358, 67);
            btnXemNganh.TabIndex = 2;
            btnXemNganh.Text = "Xem Ngành Phù Hợp";
            btnXemNganh.UseVisualStyleBackColor = false;
            // 
            // listViewKhoi
            // 
            listViewKhoi.Location = new Point(69, 115);
            listViewKhoi.Name = "listViewKhoi";
            listViewKhoi.Size = new Size(598, 363);
            listViewKhoi.TabIndex = 4;
            listViewKhoi.UseCompatibleStateImageBehavior = false;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(783, 115);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(394, 356);
            listBox1.TabIndex = 5;
            // 
            // lblTop1
            // 
            lblTop1.AutoSize = true;
            lblTop1.BackColor = Color.Bisque;
            lblTop1.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTop1.Location = new Point(886, 206);
            lblTop1.Name = "lblTop1";
            lblTop1.Size = new Size(0, 40);
            lblTop1.TabIndex = 6;
            // 
            // lblTop2
            // 
            lblTop2.AutoSize = true;
            lblTop2.BackColor = SystemColors.Info;
            lblTop2.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTop2.Location = new Point(943, 283);
            lblTop2.Name = "lblTop2";
            lblTop2.Size = new Size(103, 40);
            lblTop2.TabIndex = 7;
            lblTop2.Text = "label3";
            // 
            // lblTop3
            // 
            lblTop3.AutoSize = true;
            lblTop3.BackColor = Color.MistyRose;
            lblTop3.Font = new Font("Segoe UI Black", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTop3.Location = new Point(943, 373);
            lblTop3.Name = "lblTop3";
            lblTop3.Size = new Size(104, 40);
            lblTop3.TabIndex = 8;
            lblTop3.Text = "label4";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(827, 144);
            label2.Name = "label2";
            label2.Size = new Size(324, 40);
            label2.TabIndex = 9;
            label2.Text = "Gợi Ý Tổ Hợp Nên Chọn";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(943, 214);
            label4.Name = "label4";
            label4.Size = new Size(78, 32);
            label4.TabIndex = 11;
            label4.Text = "label4";
            // 
            // FormChonKhoi
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1220, 576);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(lblTop3);
            Controls.Add(lblTop2);
            Controls.Add(lblTop1);
            Controls.Add(listViewKhoi);
            Controls.Add(btnXemNganh);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Name = "FormChonKhoi";
            Text = "FormChonKhoi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button btnXemNganh;
        private ListView listViewKhoi;
        private ListBox listBox1;
        private Label lblTop1;
        private Label lblTop2;
        private Label lblTop3;
        private Label label2;
        private Label label4;
    }
}