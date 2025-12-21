namespace UniGate.Student.Forms
{
    partial class FormPhanViTrungVi
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
            lblTile = new Label();
            cbGroup = new ComboBox();
            numYear = new NumericUpDown();
            numUserScore = new NumericUpDown();
            btnAnalyze = new Button();
            lblResult = new Label();
            lblToHop = new Label();
            lblNam = new Label();
            lblScore = new Label();
            pnlChartContainer = new Panel();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numUserScore).BeginInit();
            SuspendLayout();
            // 
            // lblTile
            // 
            lblTile.AutoSize = true;
            lblTile.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTile.Location = new Point(228, 9);
            lblTile.Name = "lblTile";
            lblTile.Size = new Size(287, 46);
            lblTile.TabIndex = 0;
            lblTile.Text = "Phân Vị - Trung Vị";
            // 
            // cbGroup
            // 
            cbGroup.FormattingEnabled = true;
            cbGroup.Location = new Point(151, 85);
            cbGroup.Name = "cbGroup";
            cbGroup.Size = new Size(151, 28);
            cbGroup.TabIndex = 1;
            // 
            // numYear
            // 
            numYear.Location = new Point(151, 129);
            numYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(150, 27);
            numYear.TabIndex = 2;
            numYear.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // numUserScore
            // 
            numUserScore.DecimalPlaces = 2;
            numUserScore.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            numUserScore.Location = new Point(151, 182);
            numUserScore.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numUserScore.Name = "numUserScore";
            numUserScore.Size = new Size(150, 27);
            numUserScore.TabIndex = 3;
            // 
            // btnAnalyze
            // 
            btnAnalyze.Location = new Point(198, 237);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(94, 29);
            btnAnalyze.TabIndex = 4;
            btnAnalyze.Text = "Phân tích";
            btnAnalyze.UseVisualStyleBackColor = true;
            btnAnalyze.Click += btnAnalyze_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(391, 88);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(49, 20);
            lblResult.TabIndex = 5;
            lblResult.Text = "Result";
            // 
            // lblToHop
            // 
            lblToHop.AutoSize = true;
            lblToHop.Location = new Point(31, 88);
            lblToHop.Name = "lblToHop";
            lblToHop.Size = new Size(56, 20);
            lblToHop.TabIndex = 6;
            lblToHop.Text = "Tổ hợp";
            // 
            // lblNam
            // 
            lblNam.AutoSize = true;
            lblNam.Location = new Point(31, 136);
            lblNam.Name = "lblNam";
            lblNam.Size = new Size(41, 20);
            lblNam.TabIndex = 7;
            lblNam.Text = "Năm";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(31, 189);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(93, 20);
            lblScore.TabIndex = 8;
            lblScore.Text = "Điểm tổ hợp";
            // 
            // pnlChartContainer
            // 
            pnlChartContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlChartContainer.Location = new Point(0, 292);
            pnlChartContainer.Name = "pnlChartContainer";
            pnlChartContainer.Size = new Size(799, 261);
            pnlChartContainer.TabIndex = 9;
            // 
            // FormPhanViTrungVi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 556);
            Controls.Add(pnlChartContainer);
            Controls.Add(lblScore);
            Controls.Add(lblNam);
            Controls.Add(lblToHop);
            Controls.Add(lblResult);
            Controls.Add(btnAnalyze);
            Controls.Add(numUserScore);
            Controls.Add(numYear);
            Controls.Add(cbGroup);
            Controls.Add(lblTile);
            Name = "FormPhanViTrungVi";
            Text = "FormPhanViTrungVi";
            Load += FormPhanViTrungVi_Load;
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)numUserScore).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTile;
        private ComboBox cbGroup;
        private NumericUpDown numYear;
        private NumericUpDown numUserScore;
        private Button btnAnalyze;
        private Label lblResult;
        private Label lblToHop;
        private Label lblNam;
        private Label lblScore;
        private Panel pnlChartContainer;
    }
}