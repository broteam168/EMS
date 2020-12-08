namespace LDSong.Views
{
    partial class frmListYeuCau
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTinhTrang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDvql = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridListYC = new DevExpress.XtraGrid.GridControl();
            this.ListYC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MA_KHANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_KHANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NOI_DUNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAY_TAO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TINH_TRANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGUOI_XU_LY = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDvql.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListYC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListYC)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.dateEnd);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.dateBegin);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.cbTinhTrang);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.cbDvql);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(946, 41);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(848, 8);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "Xem yêu cầu";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(699, 10);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Size = new System.Drawing.Size(115, 20);
            this.dateEnd.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(639, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Kết thúc :";
            // 
            // dateBegin
            // 
            this.dateBegin.EditValue = null;
            this.dateBegin.Location = new System.Drawing.Point(502, 10);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Size = new System.Drawing.Size(116, 20);
            this.dateBegin.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bắt đầu :";
            // 
            // cbTinhTrang
            // 
            this.cbTinhTrang.FormattingEnabled = true;
            this.cbTinhTrang.Items.AddRange(new object[] {
            "Tất cả",
            "Chưa xử lý",
            "Đang xử lý",
            "Đã xử lý xong"});
            this.cbTinhTrang.Location = new System.Drawing.Point(282, 10);
            this.cbTinhTrang.Name = "cbTinhTrang";
            this.cbTinhTrang.Size = new System.Drawing.Size(121, 21);
            this.cbTinhTrang.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tình trạng :";
            // 
            // cbDvql
            // 
            this.cbDvql.Location = new System.Drawing.Point(82, 11);
            this.cbDvql.Name = "cbDvql";
            this.cbDvql.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDvql.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MA_DVIQLY", "MA_DVIQLY", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_DVIQLY", "Tên đơn vị quản lý")});
            this.cbDvql.Properties.DisplayMember = "TEN_DVIQLY";
            this.cbDvql.Properties.ValueMember = "MA_DVIQLY";
            this.cbDvql.Size = new System.Drawing.Size(107, 20);
            this.cbDvql.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đơn vị :";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridListYC);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 41);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(946, 406);
            this.panelControl2.TabIndex = 1;
            // 
            // gridListYC
            // 
            this.gridListYC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridListYC.Location = new System.Drawing.Point(2, 2);
            this.gridListYC.MainView = this.ListYC;
            this.gridListYC.Name = "gridListYC";
            this.gridListYC.Size = new System.Drawing.Size(942, 402);
            this.gridListYC.TabIndex = 0;
            this.gridListYC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ListYC});
            // 
            // ListYC
            // 
            this.ListYC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MA_KHANG,
            this.TEN_KHANG,
            this.NOI_DUNG,
            this.NGAY_TAO,
            this.TINH_TRANG,
            this.NGUOI_XU_LY});
            this.ListYC.GridControl = this.gridListYC;
            this.ListYC.Name = "ListYC";
            this.ListYC.OptionsBehavior.Editable = false;
            this.ListYC.OptionsView.ShowGroupPanel = false;
            // 
            // MA_KHANG
            // 
            this.MA_KHANG.Caption = "Mã khách hàng";
            this.MA_KHANG.FieldName = "MA_KHANG";
            this.MA_KHANG.Name = "MA_KHANG";
            this.MA_KHANG.Visible = true;
            this.MA_KHANG.VisibleIndex = 0;
            // 
            // TEN_KHANG
            // 
            this.TEN_KHANG.Caption = "Tên khách hàng";
            this.TEN_KHANG.FieldName = "K_KHACH_HANG.TEN_KHANG";
            this.TEN_KHANG.Name = "TEN_KHANG";
            this.TEN_KHANG.Visible = true;
            this.TEN_KHANG.VisibleIndex = 1;
            // 
            // NOI_DUNG
            // 
            this.NOI_DUNG.Caption = "Nội dung";
            this.NOI_DUNG.FieldName = "NOI_DUNG";
            this.NOI_DUNG.Name = "NOI_DUNG";
            this.NOI_DUNG.Visible = true;
            this.NOI_DUNG.VisibleIndex = 2;
            // 
            // NGAY_TAO
            // 
            this.NGAY_TAO.Caption = "Ngày tạo yêu cầu";
            this.NGAY_TAO.FieldName = "NGAY_TAO";
            this.NGAY_TAO.Name = "NGAY_TAO";
            this.NGAY_TAO.Visible = true;
            this.NGAY_TAO.VisibleIndex = 3;
            // 
            // TINH_TRANG
            // 
            this.TINH_TRANG.Caption = "Tình trạng";
            this.TINH_TRANG.FieldName = "TINH_TRANG";
            this.TINH_TRANG.Name = "TINH_TRANG";
            this.TINH_TRANG.Visible = true;
            this.TINH_TRANG.VisibleIndex = 4;
            // 
            // NGUOI_XU_LY
            // 
            this.NGUOI_XU_LY.Caption = "Người xử lý";
            this.NGUOI_XU_LY.FieldName = "NGUOI_XU_LY";
            this.NGUOI_XU_LY.Name = "NGUOI_XU_LY";
            this.NGUOI_XU_LY.Visible = true;
            this.NGUOI_XU_LY.VisibleIndex = 5;
            // 
            // frmListYeuCau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 447);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmListYeuCau";
            this.Text = "Danh sách yêu cầu";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDvql.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridListYC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListYC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox cbTinhTrang;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit cbDvql;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl gridListYC;
        private DevExpress.XtraGrid.Views.Grid.GridView ListYC;
        private DevExpress.XtraGrid.Columns.GridColumn MA_KHANG;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_KHANG;
        private DevExpress.XtraGrid.Columns.GridColumn NOI_DUNG;
        private DevExpress.XtraGrid.Columns.GridColumn NGAY_TAO;
        private DevExpress.XtraGrid.Columns.GridColumn TINH_TRANG;
        private DevExpress.XtraGrid.Columns.GridColumn NGUOI_XU_LY;
    }
}