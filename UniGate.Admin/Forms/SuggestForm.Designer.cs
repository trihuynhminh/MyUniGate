namespace UniGate.Admin.Forms
{
    partial class SuggestForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lblNhapDiem = new Label();
            cboToHop = new ComboBox();
            btnXemGoiY = new Button();
            txtDiemUT = new TextBox();
            txtTongDiem = new TextBox();
            lblToHop = new Label();
            lblTongDiem = new Label();
            lblDiemUT = new Label();
            lblTuyChon = new Label();
            cboChonVung = new ComboBox();
            lblChonVung = new Label();
            lblKQ = new Label();
            dgvKetQua = new DataGridView();
            Truong = new DataGridViewTextBoxColumn();
            Manganh = new DataGridViewTextBoxColumn();
            TenNganh = new DataGridViewTextBoxColumn();
            KhoiThi = new DataGridViewTextBoxColumn();
            DiemChuan = new DataGridViewTextBoxColumn();
            DiemCuaBan = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            SuspendLayout();
            // 
            // lblNhapDiem
            // 
            lblNhapDiem.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblNhapDiem.Location = new Point(150, 31);
            lblNhapDiem.Name = "lblNhapDiem";
            lblNhapDiem.Size = new Size(100, 23);
            lblNhapDiem.TabIndex = 0;
            lblNhapDiem.Text = "NHẬP ĐIỂM XÉT TUYỂN";
            // 
            // cboToHop
            // 
            cboToHop.Location = new Point(0, 0);
            cboToHop.Name = "cboToHop";
            cboToHop.Size = new Size(121, 33);
            cboToHop.TabIndex = 0;
            // 
            // btnXemGoiY
            // 
            btnXemGoiY.Location = new Point(1184, 59);
            btnXemGoiY.Name = "btnXemGoiY";
            btnXemGoiY.Size = new Size(131, 59);
            btnXemGoiY.TabIndex = 1;
            btnXemGoiY.Text = "Xem Gợi Ý";
            btnXemGoiY.Click += btnXemGoiY_Click;
            // 
            // txtDiemUT
            // 
            txtDiemUT.Location = new Point(0, 0);
            txtDiemUT.Name = "txtDiemUT";
            txtDiemUT.Size = new Size(100, 31);
            txtDiemUT.TabIndex = 0;
            // 
            // txtTongDiem
            // 
            txtTongDiem.Location = new Point(236, 182);
            txtTongDiem.Name = "txtTongDiem";
            txtTongDiem.Size = new Size(100, 31);
            txtTongDiem.TabIndex = 0;
            // 
            // lblToHop
            // 
            lblToHop.Location = new Point(0, 0);
            lblToHop.Name = "lblToHop";
            lblToHop.Size = new Size(100, 23);
            lblToHop.TabIndex = 0;
            // 
            // lblTongDiem
            // 
            lblTongDiem.Location = new Point(0, 0);
            lblTongDiem.Name = "lblTongDiem";
            lblTongDiem.Size = new Size(100, 23);
            lblTongDiem.TabIndex = 0;
            // 
            // lblDiemUT
            // 
            lblDiemUT.Location = new Point(0, 0);
            lblDiemUT.Name = "lblDiemUT";
            lblDiemUT.Size = new Size(100, 23);
            lblDiemUT.TabIndex = 0;
            // 
            // lblTuyChon
            // 
            lblTuyChon.Location = new Point(0, 0);
            lblTuyChon.Name = "lblTuyChon";
            lblTuyChon.Size = new Size(100, 23);
            lblTuyChon.TabIndex = 0;
            // 
            // cboChonVung
            // 
            cboChonVung.Location = new Point(0, 0);
            cboChonVung.Name = "cboChonVung";
            cboChonVung.Size = new Size(121, 33);
            cboChonVung.TabIndex = 0;
            // 
            // lblChonVung
            // 
            lblChonVung.Location = new Point(0, 0);
            lblChonVung.Name = "lblChonVung";
            lblChonVung.Size = new Size(100, 23);
            lblChonVung.TabIndex = 0;
            // 
            // lblKQ
            // 
            lblKQ.Location = new Point(0, 0);
            lblKQ.Name = "lblKQ";
            lblKQ.Size = new Size(100, 23);
            lblKQ.TabIndex = 0;
            // 
            // dgvKetQua
            // 
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.ColumnHeadersHeight = 34;
            dgvKetQua.Columns.AddRange(new DataGridViewColumn[] { Truong, Manganh, TenNganh, KhoiThi, DiemChuan, DiemCuaBan, Status });
            dgvKetQua.Location = new Point(12, 12);
            dgvKetQua.Name = "dgvKetQua";
            dgvKetQua.ReadOnly = true;
            dgvKetQua.RowHeadersWidth = 62;
            dgvKetQua.Size = new Size(1143, 654);
            dgvKetQua.TabIndex = 0;
            // 
            // Truong
            // 
            Truong.DataPropertyName = "UniversityName";
            Truong.HeaderText = "Trường";
            Truong.MinimumWidth = 8;
            Truong.Name = "Truong";
            Truong.ReadOnly = true;
            Truong.Width = 180;
            // 
            // Manganh
            // 
            Manganh.DataPropertyName = "MajorCode";
            Manganh.HeaderText = "Mã Ngành";
            Manganh.MinimumWidth = 8;
            Manganh.Name = "Manganh";
            Manganh.ReadOnly = true;
            Manganh.Width = 150;
            // 
            // TenNganh
            // 
            TenNganh.DataPropertyName = "MajorName";
            TenNganh.HeaderText = "Tên Ngành";
            TenNganh.MinimumWidth = 8;
            TenNganh.Name = "TenNganh";
            TenNganh.ReadOnly = true;
            TenNganh.Width = 180;
            // 
            // KhoiThi
            // 
            KhoiThi.DataPropertyName = "GroupName";
            KhoiThi.HeaderText = "Khối";
            KhoiThi.MinimumWidth = 8;
            KhoiThi.Name = "KhoiThi";
            KhoiThi.ReadOnly = true;
            KhoiThi.Width = 150;
            // 
            // DiemChuan
            // 
            DiemChuan.DataPropertyName = "MinScore";
            dataGridViewCellStyle3.Format = "N2";
            DiemChuan.DefaultCellStyle = dataGridViewCellStyle3;
            DiemChuan.HeaderText = "Điểm Chuẩn";
            DiemChuan.MinimumWidth = 8;
            DiemChuan.Name = "DiemChuan";
            DiemChuan.ReadOnly = true;
            DiemChuan.Width = 150;
            // 
            // DiemCuaBan
            // 
            DiemCuaBan.DataPropertyName = "UserCalculatedScore";
            dataGridViewCellStyle4.Format = "N2";
            DiemCuaBan.DefaultCellStyle = dataGridViewCellStyle4;
            DiemCuaBan.HeaderText = "Điểm Của Bạn";
            DiemCuaBan.MinimumWidth = 8;
            DiemCuaBan.Name = "DiemCuaBan";
            DiemCuaBan.ReadOnly = true;
            DiemCuaBan.Width = 150;
            // 
            // Status
            // 
            Status.HeaderText = "Khả Năng";
            Status.MinimumWidth = 8;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 120;
            // 
            // SuggestForm
            // 
            ClientSize = new Size(1322, 690);
            Controls.Add(dgvKetQua);
            Controls.Add(btnXemGoiY);
            Name = "SuggestForm";
            Text = "Dự đoán kết quả Tuyển sinh - UniGate";
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            ResumeLayout(false);
        }

        private Label lblNhapDiem, lblToHop, lblTongDiem, lblDiemUT, lblTuyChon, lblChonVung, lblKQ;
        private ComboBox cboToHop, cboChonVung;
        private Button btnXemGoiY;
        private TextBox txtDiemUT, txtTongDiem;
        private DataGridView dgvKetQua;
        private DataGridViewTextBoxColumn Truong, Manganh, TenNganh, KhoiThi, DiemChuan, DiemCuaBan, Status;
    }
}