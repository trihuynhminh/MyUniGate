using System.Windows.Forms;

namespace UniGate.Admin.Forms.Questions
{
    partial class FrmAdminQuestions
    {
        private DataGridView dgvQuestions;
        private TextBox txtContent;
        private ComboBox cboGroup;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtSearch;
        private ComboBox cboFilter;
        private Label lblTitle;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvQuestions = new DataGridView();
            txtContent = new TextBox();
            cboGroup = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtSearch = new TextBox();
            cboFilter = new ComboBox();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvQuestions).BeginInit();
            SuspendLayout();
            // 
            // dgvQuestions
            // 
            dgvQuestions.AllowUserToAddRows = false;
            dgvQuestions.AllowUserToDeleteRows = false;
            dgvQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQuestions.ColumnHeadersHeight = 29;
            dgvQuestions.Location = new System.Drawing.Point(12, 95);
            dgvQuestions.MultiSelect = false;
            dgvQuestions.Name = "dgvQuestions";
            dgvQuestions.ReadOnly = true;
            dgvQuestions.RowHeadersWidth = 51;
            dgvQuestions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuestions.Size = new System.Drawing.Size(683, 220);
            dgvQuestions.TabIndex = 3;
            dgvQuestions.CellClick += dgvQuestions_CellClick;
            // 
            // txtContent
            // 
            txtContent.Location = new System.Drawing.Point(12, 330);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new System.Drawing.Size(522, 60);
            txtContent.TabIndex = 4;
            // 
            // cboGroup
            // 
            cboGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGroup.Location = new System.Drawing.Point(556, 340);
            cboGroup.Name = "cboGroup";
            cboGroup.Size = new System.Drawing.Size(60, 28);
            cboGroup.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(24, 405);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(100, 35);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "➕ Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new System.Drawing.Point(230, 405);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(100, 35);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "✏ Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(434, 405);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(100, 35);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "🗑 Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new System.Drawing.Point(12, 55);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍 Tìm nội dung câu hỏi...";
            txtSearch.Size = new System.Drawing.Size(280, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cboFilter
            // 
            cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilter.Location = new System.Drawing.Point(305, 55);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new System.Drawing.Size(80, 28);
            cboFilter.TabIndex = 2;
            cboFilter.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.ForestGreen;
            lblTitle.Location = new System.Drawing.Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(401, 36);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ CÂU HỎI HOLLAND";
            // 
            // FrmAdminQuestions
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(707, 460);
            Controls.Add(lblTitle);
            Controls.Add(txtSearch);
            Controls.Add(cboFilter);
            Controls.Add(dgvQuestions);
            Controls.Add(txtContent);
            Controls.Add(cboGroup);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Name = "FrmAdminQuestions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin – Holland Questions";
            Load += FrmAdminQuestions_Load;
            ((System.ComponentModel.ISupportInitialize)dgvQuestions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
