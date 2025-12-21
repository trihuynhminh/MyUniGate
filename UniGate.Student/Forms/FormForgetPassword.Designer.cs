namespace UniGate.Student.Forms
{
    partial class FormForgetPassword
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
            components = new System.ComponentModel.Container();
            txtEmail = new TextBox();
            txtToken = new TextBox();
            lblEmail = new Label();
            lblToken = new Label();
            btnSend = new Button();
            btnConfirm = new Button();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            lblNewPassword = new Label();
            lblConfirmPassword = new Label();
            lnlTile = new Label();
            timerResend = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(176, 84);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(298, 27);
            txtEmail.TabIndex = 0;
            // 
            // txtToken
            // 
            txtToken.Location = new Point(178, 141);
            txtToken.Name = "txtToken";
            txtToken.Size = new Size(296, 27);
            txtToken.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(38, 91);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblToken
            // 
            lblToken.AutoSize = true;
            lblToken.Location = new Point(38, 144);
            lblToken.Name = "lblToken";
            lblToken.Size = new Size(48, 20);
            lblToken.TabIndex = 3;
            lblToken.Text = "Token";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(176, 310);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 4;
            btnSend.Text = "Gửi token";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(380, 310);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 29);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "Xác nhận";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(178, 197);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(296, 27);
            txtNewPassword.TabIndex = 6;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(178, 249);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(294, 27);
            txtConfirmPassword.TabIndex = 7;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(38, 204);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(100, 20);
            lblNewPassword.TabIndex = 8;
            lblNewPassword.Text = "Mật khẩu mới";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(38, 256);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(130, 20);
            lblConfirmPassword.TabIndex = 9;
            lblConfirmPassword.Text = "Nhập lại mật khẩu";
            // 
            // lnlTile
            // 
            lnlTile.AutoSize = true;
            lnlTile.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnlTile.Location = new Point(161, 9);
            lnlTile.Name = "lnlTile";
            lnlTile.Size = new Size(289, 46);
            lnlTile.TabIndex = 10;
            lnlTile.Text = "QUÊN MẬT KHẨU";
            // 
            // timerResend
            // 
            timerResend.Interval = 1000;
            timerResend.Tick += timerResend_Tick;
            // 
            // FormForgetPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 374);
            Controls.Add(lnlTile);
            Controls.Add(lblConfirmPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(btnConfirm);
            Controls.Add(btnSend);
            Controls.Add(lblToken);
            Controls.Add(lblEmail);
            Controls.Add(txtToken);
            Controls.Add(txtEmail);
            Name = "FormForgetPassword";
            Text = "FormForgetPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private TextBox txtToken;
        private Label lblEmail;
        private Label lblToken;
        private Button btnSend;
        private Button btnConfirm;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Label lblNewPassword;
        private Label lblConfirmPassword;
        private Label lnlTile;
        private System.Windows.Forms.Timer timerResend;
    }
}