namespace LDSong.Views
{
    partial class frmCapdienap
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
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.txtTenDV = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaDV = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dgrCtlDonVi = new DevExpress.XtraGrid.GridControl();
            this.dgrDonVi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MA_CAPDA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MA_PMIS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_CAPDA = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCtlDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDonVi)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(657, 35);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.cmdHuy);
            this.panelControl2.Controls.Add(this.cmdGhi);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(455, 2);
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
            this.groupControl1.Controls.Add(this.txtDiaChi);
            this.groupControl1.Controls.Add(this.txtTenDV);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtMaDV);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 35);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(657, 149);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Thông tin cấp điện áp";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(82, 102);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(244, 20);
            this.txtDiaChi.TabIndex = 6;
            // 
            // txtTenDV
            // 
            this.txtTenDV.Location = new System.Drawing.Point(82, 66);
            this.txtTenDV.Name = "txtTenDV";
            this.txtTenDV.Size = new System.Drawing.Size(244, 20);
            this.txtTenDV.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 105);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(59, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Tên CAPDA:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Mã PMIS:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Mã CAPDA:";
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
            this.groupControl2.Location = new System.Drawing.Point(0, 184);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(657, 270);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Danh sách cấp điện áp";
            // 
            // dgrCtlDonVi
            // 
            this.dgrCtlDonVi.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgrCtlDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrCtlDonVi.Location = new System.Drawing.Point(2, 20);
            this.dgrCtlDonVi.MainView = this.dgrDonVi;
            this.dgrCtlDonVi.Name = "dgrCtlDonVi";
            this.dgrCtlDonVi.Size = new System.Drawing.Size(653, 248);
            this.dgrCtlDonVi.TabIndex = 0;
            this.dgrCtlDonVi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgrDonVi});
            // 
            // dgrDonVi
            // 
            this.dgrDonVi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MA_CAPDA,
            this.MA_PMIS,
            this.TEN_CAPDA});
            this.dgrDonVi.GridControl = this.dgrCtlDonVi;
            this.dgrDonVi.Name = "dgrDonVi";
            this.dgrDonVi.OptionsView.ShowGroupPanel = false;
            this.dgrDonVi.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.ChosseRow);
            // 
            // MA_CAPDA
            // 
            this.MA_CAPDA.Caption = "Mã CAPDA";
            this.MA_CAPDA.FieldName = "MA_CAPDA";
            this.MA_CAPDA.Name = "MA_CAPDA";
            this.MA_CAPDA.Visible = true;
            this.MA_CAPDA.VisibleIndex = 0;
            // 
            // MA_PMIS
            // 
            this.MA_PMIS.Caption = "Mã PMIS";
            this.MA_PMIS.FieldName = "MA_PMIS";
            this.MA_PMIS.Name = "MA_PMIS";
            this.MA_PMIS.Visible = true;
            this.MA_PMIS.VisibleIndex = 1;
            // 
            // TEN_CAPDA
            // 
            this.TEN_CAPDA.Caption = "Tên CAPDA";
            this.TEN_CAPDA.FieldName = "TEN_CAPDA";
            this.TEN_CAPDA.Name = "TEN_CAPDA";
            this.TEN_CAPDA.Visible = true;
            this.TEN_CAPDA.VisibleIndex = 2;
            // 
            // frmCapdienap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 454);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmCapdienap";
            this.Text = "Cấp Điện Áp";
            this.Load += new System.EventHandler(this.frmLoad);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrCtlDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDonVi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton cmdHuy;
        private DevExpress.XtraEditors.SimpleButton cmdGhi;
        private DevExpress.XtraEditors.SimpleButton cmdXoa;
        private DevExpress.XtraEditors.SimpleButton cmdSua;
        private DevExpress.XtraEditors.SimpleButton cmdThem;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraEditors.TextEdit txtTenDV;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMaDV;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl dgrCtlDonVi;
        private DevExpress.XtraGrid.Views.Grid.GridView dgrDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn MA_CAPDA;
        private DevExpress.XtraGrid.Columns.GridColumn MA_PMIS;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_CAPDA;
    }
}