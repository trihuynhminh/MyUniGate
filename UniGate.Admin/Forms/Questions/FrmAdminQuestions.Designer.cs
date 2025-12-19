namespace UniGate.Admin.Forms.Questions
{
    partial class FrmAdminQuestions
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cbTestType = new System.Windows.Forms.ComboBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvQuestions = new System.Windows.Forms.DataGridView();

            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();

            this.lblContent = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();

            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();

            this.lblGroup = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();

            this.chkIsActive = new System.Windows.Forms.CheckBox();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).BeginInit();
            this.SuspendLayout();

            // 
            // cbTestType
            // 
            this.cbTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTestType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbTestType.FormattingEnabled = true;
            this.cbTestType.Items.AddRange(new object[] {
            "Holland"});
            this.cbTestType.Location = new System.Drawing.Point(20, 20);
            this.cbTestType.Name = "cbTestType";
            this.cbTestType.Size = new System.Drawing.Size(180, 25);

            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReload.Location = new System.Drawing.Point(210, 20);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(80, 26);
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;

            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(420, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm kiếm...";
            this.txtSearch.Size = new System.Drawing.Size(200, 25);

            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSearch.Location = new System.Drawing.Point(630, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 26);
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;

            // 
            // dgvQuestions
            // 
            this.dgvQuestions.AllowUserToAddRows = false;
            this.dgvQuestions.AllowUserToDeleteRows = false;
            this.dgvQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuestions.BackgroundColor = System.Drawing.Color.White;
            this.dgvQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestions.Location = new System.Drawing.Point(20, 60);
            this.dgvQuestions.MultiSelect = false;
            this.dgvQuestions.Name = "dgvQuestions";
            this.dgvQuestions.ReadOnly = true;
            this.dgvQuestions.RowHeadersVisible = false;
            this.dgvQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestions.Size = new System.Drawing.Size(760, 250);

            // 
            // lblId
            // 
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblId.Location = new System.Drawing.Point(20, 330);
            this.lblId.Text = "Id:";
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtId.Location = new System.Drawing.Point(80, 327);
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(120, 25);

            // 
            // lblContent
            // 
            this.lblContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblContent.Location = new System.Drawing.Point(20, 370);
            this.lblContent.Text = "Nội dung:";
            // 
            // txtContent
            // 
            this.txtContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContent.Location = new System.Drawing.Point(20, 395);
            this.txtContent.Multiline = true;
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(760, 90);

            // 
            // lblCode
            //
            this.lblCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCode.Location = new System.Drawing.Point(20, 500);
            this.lblCode.Text = "Code:";
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCode.Location = new System.Drawing.Point(80, 497);
            this.txtCode.Size = new System.Drawing.Size(120, 25);

            // 
            // lblGroup
            // 
            this.lblGroup.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGroup.Location = new System.Drawing.Point(220, 500);
            this.lblGroup.Text = "Nhóm (R/I/A/S/E/C):";
            // 
            // txtGroup
            // 
            this.txtGroup.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGroup.Location = new System.Drawing.Point(360, 497);
            this.txtGroup.Size = new System.Drawing.Size(80, 25);

            // 
            // chkIsActive
            // 
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkIsActive.Location = new System.Drawing.Point(480, 497);
            this.chkIsActive.Text = "Đang dùng";
            this.chkIsActive.Checked = true;

            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAdd.Location = new System.Drawing.Point(20, 540);
            this.btnAdd.Size = new System.Drawing.Size(120, 35);
            this.btnAdd.Text = "Thêm mới";

            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDelete.Location = new System.Drawing.Point(160, 540);
            this.btnDelete.Size = new System.Drawing.Size(120, 35);
            this.btnDelete.Text = "Xóa";

            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClear.Location = new System.Drawing.Point(300, 540);
            this.btnClear.Size = new System.Drawing.Size(120, 35);
            this.btnClear.Text = "Clear";

            // 
            // FrmAdminQuestions
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.cbTestType);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvQuestions);

            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);

            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.txtContent);

            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtCode);

            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.txtGroup);

            this.Controls.Add(this.chkIsActive);

            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin – Quản lý câu hỏi";

            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cbTestType;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvQuestions;

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;

        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;

        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;

        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TextBox txtGroup;

        private System.Windows.Forms.CheckBox chkIsActive;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
    }
}
