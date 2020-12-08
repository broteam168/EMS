namespace LDSong.Views
{
    partial class Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbDvi = new DevExpress.XtraEditors.LookUpEdit();
            this.lbEnd = new DevExpress.XtraEditors.LabelControl();
            this.lbbegin = new DevExpress.XtraEditors.LabelControl();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbYeuCauKH = new DevExpress.XtraEditors.LookUpEdit();
            this.lbLoaiYeuCau = new DevExpress.XtraEditors.LabelControl();
            this.btDSDaoKDCB = new DevExpress.XtraEditors.SimpleButton();
            this.cbLo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cbBaoCao = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.imageSlider1 = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDvi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbYeuCauKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBaoCao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Enabled = false;
            this.dateEnd.Location = new System.Drawing.Point(117, 194);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Size = new System.Drawing.Size(146, 20);
            this.dateEnd.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(9, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Đơn vị :";
            // 
            // cbDvi
            // 
            this.cbDvi.Location = new System.Drawing.Point(117, 68);
            this.cbDvi.Name = "cbDvi";
            this.cbDvi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDvi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_DVIQLY", "Tên đơn vị quản lý")});
            this.cbDvi.Properties.DisplayMember = "TEN_DVIQLY";
            this.cbDvi.Properties.ValueMember = "MA_DVIQLY";
            this.cbDvi.Size = new System.Drawing.Size(146, 20);
            this.cbDvi.TabIndex = 5;
            this.cbDvi.EditValueChanged += new System.EventHandler(this.cbDvi_EditValueChanged);
            // 
            // lbEnd
            // 
            this.lbEnd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbEnd.Enabled = false;
            this.lbEnd.Location = new System.Drawing.Point(6, 197);
            this.lbEnd.Name = "lbEnd";
            this.lbEnd.Size = new System.Drawing.Size(107, 13);
            this.lbEnd.TabIndex = 4;
            this.lbEnd.Text = "Thời gian kết thúc :";
            // 
            // lbbegin
            // 
            this.lbbegin.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbbegin.Enabled = false;
            this.lbbegin.Location = new System.Drawing.Point(9, 156);
            this.lbbegin.Name = "lbbegin";
            this.lbbegin.Size = new System.Drawing.Size(103, 13);
            this.lbbegin.TabIndex = 3;
            this.lbbegin.Text = "Thời gian bắt đầu :";
            // 
            // dateBegin
            // 
            this.dateBegin.EditValue = null;
            this.dateBegin.Enabled = false;
            this.dateBegin.Location = new System.Drawing.Point(117, 153);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Size = new System.Drawing.Size(146, 20);
            this.dateBegin.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cbYeuCauKH);
            this.panelControl1.Controls.Add(this.lbLoaiYeuCau);
            this.panelControl1.Controls.Add(this.btDSDaoKDCB);
            this.panelControl1.Controls.Add(this.cbLo);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.cbBaoCao);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.dateBegin);
            this.panelControl1.Controls.Add(this.cbDvi);
            this.panelControl1.Controls.Add(this.dateEnd);
            this.panelControl1.Controls.Add(this.lbEnd);
            this.panelControl1.Controls.Add(this.lbbegin);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl1.Location = new System.Drawing.Point(690, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(269, 476);
            this.panelControl1.TabIndex = 4;
            // 
            // cbYeuCauKH
            // 
            this.cbYeuCauKH.Location = new System.Drawing.Point(115, 235);
            this.cbYeuCauKH.Name = "cbYeuCauKH";
            this.cbYeuCauKH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbYeuCauKH.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_LOAI", "Loại yêu cầu")});
            this.cbYeuCauKH.Properties.DisplayMember = "TEN_LOAI";
            this.cbYeuCauKH.Properties.ValueMember = "MA_LOAI";
            this.cbYeuCauKH.Size = new System.Drawing.Size(146, 20);
            this.cbYeuCauKH.TabIndex = 15;
            this.cbYeuCauKH.Visible = false;
            // 
            // lbLoaiYeuCau
            // 
            this.lbLoaiYeuCau.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbLoaiYeuCau.Location = new System.Drawing.Point(7, 238);
            this.lbLoaiYeuCau.Name = "lbLoaiYeuCau";
            this.lbLoaiYeuCau.Size = new System.Drawing.Size(76, 13);
            this.lbLoaiYeuCau.TabIndex = 14;
            this.lbLoaiYeuCau.Text = "Loại yêu cầu :";
            this.lbLoaiYeuCau.Visible = false;
            // 
            // btDSDaoKDCB
            // 
            this.btDSDaoKDCB.Enabled = false;
            this.btDSDaoKDCB.Location = new System.Drawing.Point(117, 268);
            this.btDSDaoKDCB.Name = "btDSDaoKDCB";
            this.btDSDaoKDCB.Size = new System.Drawing.Size(120, 23);
            this.btDSDaoKDCB.TabIndex = 13;
            this.btDSDaoKDCB.Text = "Danh sách dao KDCB";
            this.btDSDaoKDCB.Click += new System.EventHandler(this.btDSDaoKDCB_Click);
            // 
            // cbLo
            // 
            this.cbLo.Enabled = false;
            this.cbLo.Location = new System.Drawing.Point(117, 111);
            this.cbLo.Name = "cbLo";
            this.cbLo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_PTDIEN", "Tên lộ")});
            this.cbLo.Properties.DisplayMember = "TEN_PTDIEN";
            this.cbLo.Properties.ValueMember = "MA_PMIS";
            this.cbLo.Size = new System.Drawing.Size(146, 20);
            this.cbLo.TabIndex = 12;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Enabled = false;
            this.labelControl4.Location = new System.Drawing.Point(9, 114);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(19, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Lộ :";
            // 
            // cbBaoCao
            // 
            this.cbBaoCao.Location = new System.Drawing.Point(117, 25);
            this.cbBaoCao.Name = "cbBaoCao";
            this.cbBaoCao.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBaoCao.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TENBAOCAO", "Loại báo cáo")});
            this.cbBaoCao.Properties.DisplayMember = "TENBAOCAO";
            this.cbBaoCao.Properties.ValueMember = "ID";
            this.cbBaoCao.Size = new System.Drawing.Size(146, 20);
            this.cbBaoCao.TabIndex = 10;
            this.cbBaoCao.EditValueChanged += new System.EventHandler(this.cbBaoCao_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(9, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Loại báo cáo :";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(117, 305);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(121, 32);
            this.simpleButton2.TabIndex = 8;
            this.simpleButton2.Text = "Xem báo cáo";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.imageSlider1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(690, 476);
            this.panelControl2.TabIndex = 5;
            // 
            // imageSlider1
            // 
            this.imageSlider1.AllowLooping = true;
            this.imageSlider1.AnimationTime = 3000;
            this.imageSlider1.CurrentImageIndex = 0;
            this.imageSlider1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images1"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images2"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images3"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images4"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images5"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images6"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images7"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images8"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images9"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images10"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images11"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images12"))));
            this.imageSlider1.ImeMode = System.Windows.Forms.ImeMode.HangulFull;
            this.imageSlider1.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            this.imageSlider1.Location = new System.Drawing.Point(2, 2);
            this.imageSlider1.Name = "imageSlider1";
            this.imageSlider1.Size = new System.Drawing.Size(686, 472);
            this.imageSlider1.TabIndex = 0;
            this.imageSlider1.Text = "imageSlider1";
            this.imageSlider1.UseDisabledStatePainter = true;
            // 
            // timerAnimation
            // 
            this.timerAnimation.Enabled = true;
            this.timerAnimation.Interval = 8000;
            this.timerAnimation.Tick += new System.EventHandler(this.slide);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 476);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "Report";
            this.Text = "Tổng hợp báo cáo";
            this.Load += new System.EventHandler(this.loadform);
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDvi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbYeuCauKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBaoCao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageSlider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cbDvi;
        private DevExpress.XtraEditors.LabelControl lbEnd;
        private DevExpress.XtraEditors.LabelControl lbbegin;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit cbBaoCao;
        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider1;
        private System.Windows.Forms.Timer timerAnimation;
        private DevExpress.XtraEditors.LookUpEdit cbLo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btDSDaoKDCB;
        private DevExpress.XtraEditors.LookUpEdit cbYeuCauKH;
        private DevExpress.XtraEditors.LabelControl lbLoaiYeuCau;
    }
}