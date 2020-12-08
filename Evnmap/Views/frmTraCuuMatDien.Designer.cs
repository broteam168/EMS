namespace LDSong.Views
{
    partial class frmTraCuuMatDien
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraCuuMatDien));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btBaocao = new DevExpress.XtraEditors.SimpleButton();
            this.imageSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.textMatram = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTenTram = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlPT = new DevExpress.XtraGrid.GridControl();
            this.PTDien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID_PTDIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MA_DVQLY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_PTDIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gridTrangthaiDongcat = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlTrangThai = new DevExpress.XtraGrid.GridControl();
            this.TrangThaiLR = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NGAY_CAP_NHAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.THOIGIANKETTHUC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGUYENNHAN = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTDien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrangthaiDongcat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrangThaiLR)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.checkBox1);
            this.panelControl1.Controls.Add(this.btBaocao);
            this.panelControl1.Controls.Add(this.dateEnd);
            this.panelControl1.Controls.Add(this.dateBegin);
            this.panelControl1.Controls.Add(this.textMatram);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.textBoxTenTram);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.textBoxID);
            this.panelControl1.Controls.Add(this.labelID);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(842, 100);
            this.panelControl1.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(770, 27);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(41, 17);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "OC";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // btBaocao
            // 
            this.btBaocao.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btBaocao.Appearance.Options.UseFont = true;
            this.btBaocao.Enabled = false;
            this.btBaocao.ImageIndex = 1;
            this.btBaocao.ImageList = this.imageSmall;
            this.btBaocao.Location = new System.Drawing.Point(656, 57);
            this.btBaocao.Name = "btBaocao";
            this.btBaocao.Size = new System.Drawing.Size(92, 25);
            this.btBaocao.TabIndex = 24;
            this.btBaocao.Text = "Báo cáo";
            this.btBaocao.Click += new System.EventHandler(this.btBaocao_Click);
            // 
            // imageSmall
            // 
            this.imageSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageSmall.ImageStream")));
            this.imageSmall.Images.SetKeyName(0, "ieframe_dll_52_13.png");
            this.imageSmall.Images.SetKeyName(1, "msdasqlr_dll_01_10.png");
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(375, 60);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.dateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateEnd.TabIndex = 23;
            // 
            // dateBegin
            // 
            this.dateBegin.EditValue = null;
            this.dateBegin.Location = new System.Drawing.Point(128, 60);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.dateBegin.Size = new System.Drawing.Size(100, 20);
            this.dateBegin.TabIndex = 22;
            // 
            // textMatram
            // 
            this.textMatram.Location = new System.Drawing.Point(375, 24);
            this.textMatram.Name = "textMatram";
            this.textMatram.Size = new System.Drawing.Size(100, 21);
            this.textMatram.TabIndex = 21;
            this.textMatram.TextChanged += new System.EventHandler(this.textMatram_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Mã Trạm :";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageIndex = 0;
            this.simpleButton1.ImageList = this.imageSmall;
            this.simpleButton1.Location = new System.Drawing.Point(558, 57);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(92, 25);
            this.simpleButton1.TabIndex = 19;
            this.simpleButton1.Text = "Tìm kiếm";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Thời gian kết thúc :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Thời gian bắt đầu :";
            // 
            // textBoxTenTram
            // 
            this.textBoxTenTram.Location = new System.Drawing.Point(558, 24);
            this.textBoxTenTram.Name = "textBoxTenTram";
            this.textBoxTenTram.Size = new System.Drawing.Size(190, 21);
            this.textBoxTenTram.TabIndex = 14;
            this.textBoxTenTram.TextChanged += new System.EventHandler(this.textBoxTenTram_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(493, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tên Trạm :";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(130, 24);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(98, 21);
            this.textBoxID.TabIndex = 12;
            this.textBoxID.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(22, 27);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(52, 13);
            this.labelID.TabIndex = 11;
            this.labelID.Text = "ID Trạm :";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControlPT);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 100);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(274, 379);
            this.panelControl2.TabIndex = 2;
            // 
            // gridControlPT
            // 
            this.gridControlPT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPT.Location = new System.Drawing.Point(2, 2);
            this.gridControlPT.MainView = this.PTDien;
            this.gridControlPT.Name = "gridControlPT";
            this.gridControlPT.Size = new System.Drawing.Size(270, 375);
            this.gridControlPT.TabIndex = 0;
            this.gridControlPT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PTDien});
            // 
            // PTDien
            // 
            this.PTDien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID_PTDIEN,
            this.MA_DVQLY,
            this.TEN_PTDIEN});
            this.PTDien.GridControl = this.gridControlPT;
            this.PTDien.Name = "PTDien";
            this.PTDien.OptionsBehavior.Editable = false;
            this.PTDien.OptionsView.ShowGroupPanel = false;
            this.PTDien.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.PTDien_FocusedRowChanged);
            // 
            // ID_PTDIEN
            // 
            this.ID_PTDIEN.Caption = "ID";
            this.ID_PTDIEN.FieldName = "ID_PTDIEN";
            this.ID_PTDIEN.Name = "ID_PTDIEN";
            this.ID_PTDIEN.Visible = true;
            this.ID_PTDIEN.VisibleIndex = 0;
            this.ID_PTDIEN.Width = 45;
            // 
            // MA_DVQLY
            // 
            this.MA_DVQLY.Caption = "MÃ DVQL";
            this.MA_DVQLY.FieldName = "MA_DVQLY";
            this.MA_DVQLY.Name = "MA_DVQLY";
            this.MA_DVQLY.Visible = true;
            this.MA_DVQLY.VisibleIndex = 1;
            this.MA_DVQLY.Width = 50;
            // 
            // TEN_PTDIEN
            // 
            this.TEN_PTDIEN.Caption = "Tên Trạm";
            this.TEN_PTDIEN.FieldName = "TEN_PTDIEN";
            this.TEN_PTDIEN.Name = "TEN_PTDIEN";
            this.TEN_PTDIEN.Visible = true;
            this.TEN_PTDIEN.VisibleIndex = 2;
            this.TEN_PTDIEN.Width = 157;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gridTrangthaiDongcat);
            this.panelControl3.Controls.Add(this.gridControlTrangThai);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(274, 100);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(568, 379);
            this.panelControl3.TabIndex = 3;
            // 
            // gridTrangthaiDongcat
            // 
            this.gridTrangthaiDongcat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTrangthaiDongcat.Location = new System.Drawing.Point(2, 2);
            this.gridTrangthaiDongcat.MainView = this.gridView1;
            this.gridTrangthaiDongcat.Name = "gridTrangthaiDongcat";
            this.gridTrangthaiDongcat.Size = new System.Drawing.Size(564, 375);
            this.gridTrangthaiDongcat.TabIndex = 1;
            this.gridTrangthaiDongcat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridTrangthaiDongcat.Visible = false;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridTrangthaiDongcat;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Thời gian bắt đầu ";
            this.gridColumn1.DisplayFormat.FormatString = "dd/MM/yyyy H:mm:ss";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn1.FieldName = "THOI_DIEM";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 112;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Thời gian kết thúc mất điện";
            this.gridColumn2.DisplayFormat.FormatString = "dd/MM/yyyy H:mm:ss";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "THOIGIANKETTHUC";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Người thao tác";
            this.gridColumn3.FieldName = "UserName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 354;
            // 
            // gridControlTrangThai
            // 
            this.gridControlTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTrangThai.Location = new System.Drawing.Point(2, 2);
            this.gridControlTrangThai.MainView = this.TrangThaiLR;
            this.gridControlTrangThai.Name = "gridControlTrangThai";
            this.gridControlTrangThai.Size = new System.Drawing.Size(564, 375);
            this.gridControlTrangThai.TabIndex = 0;
            this.gridControlTrangThai.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.TrangThaiLR});
            // 
            // TrangThaiLR
            // 
            this.TrangThaiLR.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NGAY_CAP_NHAT,
            this.THOIGIANKETTHUC,
            this.NGUYENNHAN});
            this.TrangThaiLR.GridControl = this.gridControlTrangThai;
            this.TrangThaiLR.Name = "TrangThaiLR";
            this.TrangThaiLR.OptionsBehavior.Editable = false;
            this.TrangThaiLR.OptionsView.ShowGroupPanel = false;
            // 
            // NGAY_CAP_NHAT
            // 
            this.NGAY_CAP_NHAT.Caption = "Thời gian bắt đầu mất điện";
            this.NGAY_CAP_NHAT.DisplayFormat.FormatString = "dd/MM/yyyy H:mm:ss";
            this.NGAY_CAP_NHAT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.NGAY_CAP_NHAT.FieldName = "NGAY_CAP_NHAT";
            this.NGAY_CAP_NHAT.Name = "NGAY_CAP_NHAT";
            this.NGAY_CAP_NHAT.Visible = true;
            this.NGAY_CAP_NHAT.VisibleIndex = 0;
            this.NGAY_CAP_NHAT.Width = 112;
            // 
            // THOIGIANKETTHUC
            // 
            this.THOIGIANKETTHUC.Caption = "Thời gian kết thúc mất điện";
            this.THOIGIANKETTHUC.DisplayFormat.FormatString = "dd/MM/yyyy H:mm:ss";
            this.THOIGIANKETTHUC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.THOIGIANKETTHUC.FieldName = "THOIGIANKETTHUC";
            this.THOIGIANKETTHUC.Name = "THOIGIANKETTHUC";
            this.THOIGIANKETTHUC.Visible = true;
            this.THOIGIANKETTHUC.VisibleIndex = 1;
            this.THOIGIANKETTHUC.Width = 80;
            // 
            // NGUYENNHAN
            // 
            this.NGUYENNHAN.Caption = "Nguyên nhân mất điện";
            this.NGUYENNHAN.FieldName = "NGUYENNHAN";
            this.NGUYENNHAN.Name = "NGUYENNHAN";
            this.NGUYENNHAN.Visible = true;
            this.NGUYENNHAN.VisibleIndex = 2;
            this.NGUYENNHAN.Width = 354;
            // 
            // frmTraCuuMatDien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 479);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmTraCuuMatDien";
            this.Text = "Lịch sử mất điện từng trạm";
            this.Load += new System.EventHandler(this.frmTraCuuMatDien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTDien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTrangthaiDongcat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrangThaiLR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TextBox textMatram;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTenTram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label labelID;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControlPT;
        private DevExpress.XtraGrid.Views.Grid.GridView PTDien;
        private DevExpress.XtraGrid.Columns.GridColumn ID_PTDIEN;
        private DevExpress.XtraGrid.Columns.GridColumn MA_DVQLY;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_PTDIEN;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gridControlTrangThai;
        private DevExpress.XtraGrid.Views.Grid.GridView TrangThaiLR;
        private DevExpress.XtraGrid.Columns.GridColumn NGAY_CAP_NHAT;
        private DevExpress.XtraGrid.Columns.GridColumn THOIGIANKETTHUC;
        private DevExpress.XtraGrid.Columns.GridColumn NGUYENNHAN;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.SimpleButton btBaocao;
        private DevExpress.Utils.ImageCollection imageSmall;
        private System.Windows.Forms.CheckBox checkBox1;
        private DevExpress.XtraGrid.GridControl gridTrangthaiDongcat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}