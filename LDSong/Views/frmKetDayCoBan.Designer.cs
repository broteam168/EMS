namespace LDSong.Views
{
    partial class frmKetDayCoBan
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
            this.btGoBoDao = new DevExpress.XtraEditors.SimpleButton();
            this.btThemDao = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridDSDao = new DevExpress.XtraGrid.GridControl();
            this.DanhSachDao = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MA_DVQLY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_CAPDA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridConDaoALL = new DevExpress.XtraGrid.GridControl();
            this.DanhSachDaoALL = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MA_DVQL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_PTDIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID_PTDIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSDao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DanhSachDao)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridConDaoALL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DanhSachDaoALL)).BeginInit();
            this.SuspendLayout();
            // 
            // btGoBoDao
            // 
            this.btGoBoDao.Location = new System.Drawing.Point(7, 192);
            this.btGoBoDao.Name = "btGoBoDao";
            this.btGoBoDao.Size = new System.Drawing.Size(81, 23);
            this.btGoBoDao.TabIndex = 1;
            this.btGoBoDao.Text = "Gỡ bỏ dao >>";
            this.btGoBoDao.Click += new System.EventHandler(this.btGoBoDao_Click);
            // 
            // btThemDao
            // 
            this.btThemDao.Location = new System.Drawing.Point(7, 150);
            this.btThemDao.Name = "btThemDao";
            this.btThemDao.Size = new System.Drawing.Size(81, 23);
            this.btThemDao.TabIndex = 0;
            this.btThemDao.Text = "<< Thêm dao";
            this.btThemDao.Click += new System.EventHandler(this.btThemDao_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridDSDao);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 378);
            this.panel2.TabIndex = 1;
            // 
            // gridDSDao
            // 
            this.gridDSDao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDSDao.Location = new System.Drawing.Point(0, 0);
            this.gridDSDao.MainView = this.DanhSachDao;
            this.gridDSDao.Name = "gridDSDao";
            this.gridDSDao.Size = new System.Drawing.Size(344, 378);
            this.gridDSDao.TabIndex = 0;
            this.gridDSDao.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DanhSachDao});
            // 
            // DanhSachDao
            // 
            this.DanhSachDao.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MA_DVQLY,
            this.gridColumn1,
            this.gridColumn2,
            this.TEN_CAPDA});
            this.DanhSachDao.GridControl = this.gridDSDao;
            this.DanhSachDao.Name = "DanhSachDao";
            this.DanhSachDao.OptionsFind.AlwaysVisible = true;
            this.DanhSachDao.OptionsFind.FindNullPrompt = "Nhập tên dao cách ly cần tìm ....";
            this.DanhSachDao.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.DanhSachDao.OptionsView.ShowGroupPanel = false;
            this.DanhSachDao.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.DanhSachDao_FocusedRowChanged);
            // 
            // MA_DVQLY
            // 
            this.MA_DVQLY.Caption = "Đơn vị quản lý";
            this.MA_DVQLY.FieldName = "D_PTDIEN.MA_DVQLY";
            this.MA_DVQLY.Name = "MA_DVQLY";
            this.MA_DVQLY.Visible = true;
            this.MA_DVQLY.VisibleIndex = 0;
            this.MA_DVQLY.Width = 54;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên phần tử điện";
            this.gridColumn1.FieldName = "D_PTDIEN.TEN_PTDIEN";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 135;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "ID_PTDIEN";
            this.gridColumn2.FieldName = "ID_PTDIEN";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // TEN_CAPDA
            // 
            this.TEN_CAPDA.Caption = "Điện áp";
            this.TEN_CAPDA.FieldName = "D_PTDIEN.TEN_CAPDA";
            this.TEN_CAPDA.Name = "TEN_CAPDA";
            this.TEN_CAPDA.Visible = true;
            this.TEN_CAPDA.VisibleIndex = 2;
            this.TEN_CAPDA.Width = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btGoBoDao);
            this.panel1.Controls.Add(this.btThemDao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(344, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(96, 378);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridConDaoALL);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(440, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(330, 378);
            this.panel3.TabIndex = 4;
            // 
            // gridConDaoALL
            // 
            this.gridConDaoALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridConDaoALL.Location = new System.Drawing.Point(0, 0);
            this.gridConDaoALL.MainView = this.DanhSachDaoALL;
            this.gridConDaoALL.Name = "gridConDaoALL";
            this.gridConDaoALL.Size = new System.Drawing.Size(330, 378);
            this.gridConDaoALL.TabIndex = 2;
            this.gridConDaoALL.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DanhSachDaoALL});
            // 
            // DanhSachDaoALL
            // 
            this.DanhSachDaoALL.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MA_DVQL,
            this.TEN_PTDIEN,
            this.ID_PTDIEN});
            this.DanhSachDaoALL.GridControl = this.gridConDaoALL;
            this.DanhSachDaoALL.Name = "DanhSachDaoALL";
            this.DanhSachDaoALL.OptionsBehavior.Editable = false;
            this.DanhSachDaoALL.OptionsDetail.EnableMasterViewMode = false;
            this.DanhSachDaoALL.OptionsDetail.ShowDetailTabs = false;
            this.DanhSachDaoALL.OptionsFind.AlwaysVisible = true;
            this.DanhSachDaoALL.OptionsFind.FindNullPrompt = "Nhập tên Dao cần tìm...";
            this.DanhSachDaoALL.OptionsSelection.MultiSelect = true;
            this.DanhSachDaoALL.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.DanhSachDaoALL.OptionsView.ShowGroupPanel = false;
            this.DanhSachDaoALL.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.DanhSachDaoALL_FocusedRowChanged);
            // 
            // MA_DVQL
            // 
            this.MA_DVQL.Caption = "Đơn vị quản lý";
            this.MA_DVQL.FieldName = "MA_DVQLY";
            this.MA_DVQL.Name = "MA_DVQL";
            this.MA_DVQL.Visible = true;
            this.MA_DVQL.VisibleIndex = 0;
            this.MA_DVQL.Width = 30;
            // 
            // TEN_PTDIEN
            // 
            this.TEN_PTDIEN.Caption = "Tên phần tử điện";
            this.TEN_PTDIEN.FieldName = "TEN_PTDIEN";
            this.TEN_PTDIEN.Name = "TEN_PTDIEN";
            this.TEN_PTDIEN.Visible = true;
            this.TEN_PTDIEN.VisibleIndex = 1;
            this.TEN_PTDIEN.Width = 282;
            // 
            // ID_PTDIEN
            // 
            this.ID_PTDIEN.Caption = "ID_PTDIEN";
            this.ID_PTDIEN.FieldName = "ID_PTDIEN";
            this.ID_PTDIEN.Name = "ID_PTDIEN";
            // 
            // frmKetDayCoBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 378);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmKetDayCoBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách dao";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDSDao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DanhSachDao)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridConDaoALL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DanhSachDaoALL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridDSDao;
        private DevExpress.XtraGrid.Views.Grid.GridView DanhSachDao;
        private DevExpress.XtraEditors.SimpleButton btGoBoDao;
        private DevExpress.XtraEditors.SimpleButton btThemDao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl gridConDaoALL;
        private DevExpress.XtraGrid.Views.Grid.GridView DanhSachDaoALL;
        private DevExpress.XtraGrid.Columns.GridColumn MA_DVQL;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_PTDIEN;
        private DevExpress.XtraGrid.Columns.GridColumn MA_DVQLY;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn ID_PTDIEN;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_CAPDA;
    }
}