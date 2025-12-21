namespace UniGate.Admin.Forms
{
    partial class FormQuanLiPhoDiem
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
            cbGroup = new ComboBox();
            numYear = new NumericUpDown();
            dgvDist = new DataGridView();
            lblTile = new Label();
            lblGroup = new Label();
            lblYear = new Label();
            btnLoad = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            pnlChart = new Panel();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDist).BeginInit();
            SuspendLayout();
            // 
            // cbGroup
            // 
            cbGroup.FormattingEnabled = true;
            cbGroup.Location = new Point(103, 101);
            cbGroup.Name = "cbGroup";
            cbGroup.Size = new Size(151, 28);
            cbGroup.TabIndex = 0;
            // 
            // numYear
            // 
            numYear.Location = new Point(104, 151);
            numYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(150, 27);
            numYear.TabIndex = 1;
            numYear.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // dgvDist
            // 
            dgvDist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDist.Location = new Point(510, 25);
            dgvDist.Name = "dgvDist";
            dgvDist.RowHeadersWidth = 51;
            dgvDist.Size = new Size(261, 321);
            dgvDist.TabIndex = 2;
            // 
            // lblTile
            // 
            lblTile.AutoSize = true;
            lblTile.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTile.Location = new Point(90, 9);
            lblTile.Name = "lblTile";
            lblTile.Size = new Size(295, 46);
            lblTile.TabIndex = 3;
            lblTile.Text = "Quản Lý Phổ Điểm";
            // 
            // lblGroup
            // 
            lblGroup.AutoSize = true;
            lblGroup.Location = new Point(19, 105);
            lblGroup.Name = "lblGroup";
            lblGroup.Size = new Size(56, 20);
            lblGroup.TabIndex = 4;
            lblGroup.Text = "Tổ họp";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(19, 158);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(41, 20);
            lblYear.TabIndex = 5;
            lblYear.Text = "Năm";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(287, 92);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(79, 37);
            btnLoad.TabIndex = 6;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(391, 92);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(79, 37);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(287, 153);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(79, 37);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(391, 153);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(79, 37);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // pnlChart
            // 
            pnlChart.BorderStyle = BorderStyle.FixedSingle;
            pnlChart.Location = new Point(0, 352);
            pnlChart.Name = "pnlChart";
            pnlChart.Size = new Size(771, 302);
            pnlChart.TabIndex = 10;
            // 
            // FormQuanLiPhoDiem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 655);
            Controls.Add(pnlChart);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnLoad);
            Controls.Add(lblYear);
            Controls.Add(lblGroup);
            Controls.Add(lblTile);
            Controls.Add(dgvDist);
            Controls.Add(numYear);
            Controls.Add(cbGroup);
            Name = "FormQuanLiPhoDiem";
            Text = "FormQuanLiPhoDiem";
            Load += FormQuanLiPhoDiem_Load;
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDist).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbGroup;
        private NumericUpDown numYear;
        private DataGridView dgvDist;
        private Label lblTile;
        private Label lblGroup;
        private Label lblYear;
        private Button btnLoad;
        private Button btnSave;
        private Button btnDelete;
        private Button btnClear;
        private Panel pnlChart;
    }
}