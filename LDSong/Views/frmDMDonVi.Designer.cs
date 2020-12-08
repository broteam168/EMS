namespace LDSong.Views
{
    partial class frmDMDonVi
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cmdHuy = new DevExpress.XtraEditors.SimpleButton();
            this.cmdGhi = new DevExpress.XtraEditors.SimpleButton();
            this.cmdXoa = new DevExpress.XtraEditors.SimpleButton();
            this.cmdSua = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThem = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtDienThoai = new DevExpress.XtraEditors.TextEdit();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.txtTenDV = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaDV = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dgrCtlDonVi = new DevExpress.XtraGrid.GridControl();
            this.dgrDonVi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaDVQL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenDVQL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.textToaDo = new DevExpress.XtraEditors.TextEdit();
            this.TOA_DO = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienThoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCtlDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textToaDo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.cmdXoa);
            this.panelControl1.Controls.Add(this.cmdSua);
            this.panelControl1.Controls.Add(this.cmdThem);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(821, 35);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.cmdHuy);
            this.panelControl2.Controls.Add(this.cmdGhi);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(619, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(200, 31);
            this.panelControl2.TabIndex = 5;
            // 
            // cmdHuy
            // 
            this.cmdHuy.Location = new System.Drawing.Point(118, 4);
            this.cmdHuy.Name = "cmdHuy";
            this.cmdHuy.Size = new System.Drawing.Size(75, 23);
            this.cmdHuy.TabIndex = 4;
            this.cmdHuy.Text = "Hủy";
            this.cmdHuy.Click += new System.EventHandler(this.cmdHuy_Click);
            // 
            // cmdGhi
            // 
            this.cmdGhi.Location = new System.Drawing.Point(37, 4);
            this.cmdGhi.Name = "cmdGhi";
            this.cmdGhi.Size = new System.Drawing.Size(75, 23);
            this.cmdGhi.TabIndex = 3;
            this.cmdGhi.Text = "Ghi";
            this.cmdGhi.Click += new System.EventHandler(this.cmdGhi_Click);
            // 
            // cmdXoa
            // 
            this.cmdXoa.Enabled = false;
            this.cmdXoa.Location = new System.Drawing.Point(167, 6);
            this.cmdXoa.Name = "cmdXoa";
            this.cmdXoa.Size = new System.Drawing.Size(75, 23);
            this.cmdXoa.TabIndex = 2;
            this.cmdXoa.Text = "Xóa";
            this.cmdXoa.Click += new System.EventHandler(this.cmdXoa_Click);
            // 
            // cmdSua
            // 
            this.cmdSua.Enabled = false;
            this.cmdSua.Location = new System.Drawing.Point(86, 6);
            this.cmdSua.Name = "cmdSua";
            this.cmdSua.Size = new System.Drawing.Size(75, 23);
            this.cmdSua.TabIndex = 1;
            this.cmdSua.Text = "Sửa";
            this.cmdSua.Click += new System.EventHandler(this.cmdSua_Click);
            // 
            // cmdThem
            // 
            this.cmdThem.Enabled = false;
            this.cmdThem.Location = new System.Drawing.Point(5, 6);
            this.cmdThem.Name = "cmdThem";
            this.cmdThem.Size = new System.Drawing.Size(75, 23);
            this.cmdThem.TabIndex = 0;
            this.cmdThem.Text = "Thêm mới";
            this.cmdThem.Click += new System.EventHandler(this.cmdThem_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.textToaDo);
            this.groupControl1.Controls.Add(this.txtDienThoai);
            this.groupControl1.Controls.Add(this.txtDiaChi);
            this.groupControl1.Controls.Add(this.txtTenDV);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtMaDV);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 35);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(821, 179);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Thông tin đơn vị";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(82, 137);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(373, 20);
            this.txtDienThoai.TabIndex = 7;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(82, 102);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(373, 20);
            this.txtDiaChi.TabIndex = 6;
            // 
            // txtTenDV
            // 
            this.txtTenDV.Location = new System.Drawing.Point(82, 66);
            this.txtTenDV.Name = "txtTenDV";
            this.txtTenDV.Size = new System.Drawing.Size(373, 20);
            this.txtTenDV.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 141);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(53, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Điện thoại:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 105);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Địa chỉ:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Tên đơn vị:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Mã đơn vị:";
            // 
            // txtMaDV
            // 
            this.txtMaDV.Location = new System.Drawing.Point(82, 33);
            this.txtMaDV.Name = "txtMaDV";
            this.txtMaDV.Size = new System.Drawing.Size(100, 20);
            this.txtMaDV.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgrCtlDonVi);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 214);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(821, 288);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Danh sách đơn vị";
            // 
            // dgrCtlDonVi
            // 
            this.dgrCtlDonVi.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgrCtlDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrCtlDonVi.Location = new System.Drawing.Point(2, 20);
            this.dgrCtlDonVi.MainView = this.dgrDonVi;
            this.dgrCtlDonVi.Name = "dgrCtlDonVi";
            this.dgrCtlDonVi.Size = new System.Drawing.Size(817, 266);
            this.dgrCtlDonVi.TabIndex = 0;
            this.dgrCtlDonVi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgrDonVi});
            // 
            // dgrDonVi
            // 
            this.dgrDonVi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaDVQL,
            this.TenDVQL,
            this.DiaChi,
            this.TOA_DO,
            this.DienThoai});
            this.dgrDonVi.GridControl = this.dgrCtlDonVi;
            this.dgrDonVi.Name = "dgrDonVi";
            this.dgrDonVi.OptionsView.ShowGroupPanel = false;
            this.dgrDonVi.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgrDonVi_FocusedRowChanged);
            // 
            // MaDVQL
            // 
            this.MaDVQL.Caption = "Mã đơn vị";
            this.MaDVQL.FieldName = "MA_DVIQLY";
            this.MaDVQL.Name = "MaDVQL";
            this.MaDVQL.OptionsColumn.AllowEdit = false;
            this.MaDVQL.Visible = true;
            this.MaDVQL.VisibleIndex = 0;
            this.MaDVQL.Width = 99;
            // 
            // TenDVQL
            // 
            this.TenDVQL.Caption = "Tên đơn vị";
            this.TenDVQL.FieldName = "TEN_DVIQLY";
            this.TenDVQL.Name = "TenDVQL";
            this.TenDVQL.OptionsColumn.AllowEdit = false;
            this.TenDVQL.Visible = true;
            this.TenDVQL.VisibleIndex = 1;
            this.TenDVQL.Width = 214;
            // 
            // DiaChi
            // 
            this.DiaChi.Caption = "Địa chỉ";
            this.DiaChi.FieldName = "DIA_CHI";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.OptionsColumn.AllowEdit = false;
            this.DiaChi.Visible = true;
            this.DiaChi.VisibleIndex = 2;
            this.DiaChi.Width = 383;
            // 
            // DienThoai
            // 
            this.DienThoai.Caption = "Điện thoại";
            this.DienThoai.FieldName = "TOA_DO";
            this.DienThoai.Name = "DienThoai";
            this.DienThoai.OptionsColumn.AllowEdit = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(203, 36);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(39, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Tọa độị:";
            // 
            // textToaDo
            // 
            this.textToaDo.EditValue = "20.250567 105.974863";
            this.textToaDo.Location = new System.Drawing.Point(262, 33);
            this.textToaDo.Name = "textToaDo";
            this.textToaDo.Size = new System.Drawing.Size(193, 20);
            this.textToaDo.TabIndex = 8;
            // 
            // TOA_DO
            // 
            this.TOA_DO.Caption = "TOA_DO";
            this.TOA_DO.FieldName = "TOA_DO";
            this.TOA_DO.Name = "TOA_DO";
            // 
            // frmDMDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 502);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmDMDonVi";
            this.Text = "Danh mục đơn vị";
            this.Load += new System.EventHandler(this.frmDMDonVi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienThoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrCtlDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textToaDo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton cmdHuy;
        private DevExpress.XtraEditors.SimpleButton cmdGhi;
        private DevExpress.XtraEditors.SimpleButton cmdXoa;
        private DevExpress.XtraEditors.SimpleButton cmdSua;
        private DevExpress.XtraEditors.SimpleButton cmdThem;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMaDV;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraEditors.TextEdit txtTenDV;
        private DevExpress.XtraGrid.GridControl dgrCtlDonVi;
        private DevExpress.XtraGrid.Views.Grid.GridView dgrDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn MaDVQL;
        private DevExpress.XtraGrid.Columns.GridColumn TenDVQL;
        private DevExpress.XtraGrid.Columns.GridColumn DiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn DienThoai;
        private DevExpress.XtraEditors.TextEdit txtDienThoai;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit textToaDo;
        private DevExpress.XtraGrid.Columns.GridColumn TOA_DO;
    }
}