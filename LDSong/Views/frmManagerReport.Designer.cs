namespace LDSong.Views
{
    partial class frmManagerReport
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
            this.gridBaoCao = new DevExpress.XtraGrid.GridControl();
            this.BaoCao = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MABC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENBAOCAO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TIEUDEBAOCAO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHUCDANH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGUOIKY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btSua = new DevExpress.XtraEditors.SimpleButton();
            this.textNguoiKy = new DevExpress.XtraEditors.MemoEdit();
            this.lbNguoiKy = new DevExpress.XtraEditors.LabelControl();
            this.textChucDanh = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textTieuDe = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textTen = new DevExpress.XtraEditors.TextEdit();
            this.lbTenBC = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textNguoiKy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textChucDanh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textTieuDe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textTen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridBaoCao);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(258, 412);
            this.panelControl1.TabIndex = 0;
            // 
            // gridBaoCao
            // 
            this.gridBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBaoCao.Location = new System.Drawing.Point(2, 2);
            this.gridBaoCao.MainView = this.BaoCao;
            this.gridBaoCao.Name = "gridBaoCao";
            this.gridBaoCao.Size = new System.Drawing.Size(254, 408);
            this.gridBaoCao.TabIndex = 0;
            this.gridBaoCao.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.BaoCao});
            // 
            // BaoCao
            // 
            this.BaoCao.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.MABC,
            this.TENBAOCAO,
            this.TIEUDEBAOCAO,
            this.CHUCDANH,
            this.NGUOIKY});
            this.BaoCao.GridControl = this.gridBaoCao;
            this.BaoCao.Name = "BaoCao";
            this.BaoCao.OptionsBehavior.Editable = false;
            this.BaoCao.OptionsView.ShowGroupPanel = false;
            this.BaoCao.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.BaoCao_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // MABC
            // 
            this.MABC.Caption = "MABC";
            this.MABC.FieldName = "MABC";
            this.MABC.Name = "MABC";
            // 
            // TENBAOCAO
            // 
            this.TENBAOCAO.Caption = "TENBAOCAO";
            this.TENBAOCAO.FieldName = "TENBAOCAO";
            this.TENBAOCAO.Name = "TENBAOCAO";
            this.TENBAOCAO.Visible = true;
            this.TENBAOCAO.VisibleIndex = 0;
            // 
            // TIEUDEBAOCAO
            // 
            this.TIEUDEBAOCAO.Caption = "TIEUDEBAOCAO";
            this.TIEUDEBAOCAO.FieldName = "TIEUDEBAOCAO";
            this.TIEUDEBAOCAO.Name = "TIEUDEBAOCAO";
            // 
            // CHUCDANH
            // 
            this.CHUCDANH.Caption = "CHUCDANH";
            this.CHUCDANH.FieldName = "CHUCDANH";
            this.CHUCDANH.Name = "CHUCDANH";
            // 
            // NGUOIKY
            // 
            this.NGUOIKY.Caption = "NGUOIKY";
            this.NGUOIKY.FieldName = "NGUOIKY";
            this.NGUOIKY.Name = "NGUOIKY";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btSua);
            this.panelControl2.Controls.Add(this.textNguoiKy);
            this.panelControl2.Controls.Add(this.lbNguoiKy);
            this.panelControl2.Controls.Add(this.textChucDanh);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.textTieuDe);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.textTen);
            this.panelControl2.Controls.Add(this.lbTenBC);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(258, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(603, 412);
            this.panelControl2.TabIndex = 1;
            // 
            // btSua
            // 
            this.btSua.Location = new System.Drawing.Point(290, 340);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(87, 23);
            this.btSua.TabIndex = 9;
            this.btSua.Text = "Cập nhật";
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // textNguoiKy
            // 
            this.textNguoiKy.Location = new System.Drawing.Point(117, 227);
            this.textNguoiKy.Name = "textNguoiKy";
            this.textNguoiKy.Size = new System.Drawing.Size(440, 90);
            this.textNguoiKy.TabIndex = 8;
            // 
            // lbNguoiKy
            // 
            this.lbNguoiKy.Location = new System.Drawing.Point(28, 261);
            this.lbNguoiKy.Name = "lbNguoiKy";
            this.lbNguoiKy.Size = new System.Drawing.Size(49, 13);
            this.lbNguoiKy.TabIndex = 7;
            this.lbNguoiKy.Text = "Người ký :";
            // 
            // textChucDanh
            // 
            this.textChucDanh.Location = new System.Drawing.Point(117, 113);
            this.textChucDanh.Name = "textChucDanh";
            this.textChucDanh.Size = new System.Drawing.Size(440, 90);
            this.textChucDanh.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(28, 147);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Chức danh :";
            // 
            // textTieuDe
            // 
            this.textTieuDe.Location = new System.Drawing.Point(117, 70);
            this.textTieuDe.Name = "textTieuDe";
            this.textTieuDe.Size = new System.Drawing.Size(440, 20);
            this.textTieuDe.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 73);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(83, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tiêu đề báo cáo :";
            // 
            // textTen
            // 
            this.textTen.Location = new System.Drawing.Point(117, 33);
            this.textTen.Name = "textTen";
            this.textTen.Size = new System.Drawing.Size(440, 20);
            this.textTen.TabIndex = 1;
            // 
            // lbTenBC
            // 
            this.lbTenBC.Location = new System.Drawing.Point(28, 36);
            this.lbTenBC.Name = "lbTenBC";
            this.lbTenBC.Size = new System.Drawing.Size(66, 13);
            this.lbTenBC.TabIndex = 0;
            this.lbTenBC.Text = "Tên báo cáo :";
            // 
            // frmManagerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 412);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmManagerReport";
            this.Text = "Quản lý báo cáo";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textNguoiKy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textChucDanh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textTieuDe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textTen.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridBaoCao;
        private DevExpress.XtraGrid.Views.Grid.GridView BaoCao;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btSua;
        private DevExpress.XtraEditors.MemoEdit textNguoiKy;
        private DevExpress.XtraEditors.LabelControl lbNguoiKy;
        private DevExpress.XtraEditors.MemoEdit textChucDanh;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textTieuDe;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textTen;
        private DevExpress.XtraEditors.LabelControl lbTenBC;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn MABC;
        private DevExpress.XtraGrid.Columns.GridColumn TENBAOCAO;
        private DevExpress.XtraGrid.Columns.GridColumn TIEUDEBAOCAO;
        private DevExpress.XtraGrid.Columns.GridColumn CHUCDANH;
        private DevExpress.XtraGrid.Columns.GridColumn NGUOIKY;
    }
}