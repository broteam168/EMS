namespace LDSong.Views
{
    partial class frmThongKe
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
            this.btTime = new DevExpress.XtraEditors.SimpleButton();
            this.btSoLan = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textTop = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateBegin = new DevExpress.XtraEditors.DateEdit();
            this.cbDvi = new DevExpress.XtraEditors.LookUpEdit();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbbegin = new DevExpress.XtraEditors.LabelControl();
            this.gridThongKe = new DevExpress.XtraGrid.GridControl();
            this.ThongKe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MA_DVQLY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID_PTDIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_PTDIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MA_CAPDA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.time = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textTop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDvi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btTime);
            this.panelControl1.Controls.Add(this.btSoLan);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.textTop);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.dateBegin);
            this.panelControl1.Controls.Add(this.cbDvi);
            this.panelControl1.Controls.Add(this.dateEnd);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lbbegin);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(831, 100);
            this.panelControl1.TabIndex = 0;
            // 
            // btTime
            // 
            this.btTime.Location = new System.Drawing.Point(422, 62);
            this.btTime.Name = "btTime";
            this.btTime.Size = new System.Drawing.Size(100, 23);
            this.btTime.TabIndex = 16;
            this.btTime.Text = "Thời gian mất điện";
            this.btTime.Click += new System.EventHandler(this.btTime_Click);
            // 
            // btSoLan
            // 
            this.btSoLan.Location = new System.Drawing.Point(314, 62);
            this.btSoLan.Name = "btSoLan";
            this.btSoLan.Size = new System.Drawing.Size(90, 23);
            this.btSoLan.TabIndex = 15;
            this.btSoLan.Text = "Số lần mất điện";
            this.btSoLan.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(65, 67);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(25, 13);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Top :";
            // 
            // textTop
            // 
            this.textTop.EditValue = "1";
            this.textTop.Location = new System.Drawing.Point(116, 64);
            this.textTop.Name = "textTop";
            this.textTop.Size = new System.Drawing.Size(100, 20);
            this.textTop.TabIndex = 13;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(65, 25);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 13);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Đơn vị :";
            // 
            // dateBegin
            // 
            this.dateBegin.EditValue = null;
            this.dateBegin.Location = new System.Drawing.Point(422, 22);
            this.dateBegin.Name = "dateBegin";
            this.dateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBegin.Size = new System.Drawing.Size(100, 20);
            this.dateBegin.TabIndex = 7;
            // 
            // cbDvi
            // 
            this.cbDvi.Location = new System.Drawing.Point(116, 22);
            this.cbDvi.Name = "cbDvi";
            this.cbDvi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDvi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_DVIQLY", "Tên đơn vị quản lý")});
            this.cbDvi.Properties.DisplayMember = "TEN_DVIQLY";
            this.cbDvi.Properties.ValueMember = "MA_DVIQLY";
            this.cbDvi.Size = new System.Drawing.Size(169, 20);
            this.cbDvi.TabIndex = 11;
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = null;
            this.dateEnd.Location = new System.Drawing.Point(658, 22);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Size = new System.Drawing.Size(100, 20);
            this.dateEnd.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(547, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Thời gian kết thúc :";
            // 
            // lbbegin
            // 
            this.lbbegin.Location = new System.Drawing.Point(314, 25);
            this.lbbegin.Name = "lbbegin";
            this.lbbegin.Size = new System.Drawing.Size(90, 13);
            this.lbbegin.TabIndex = 9;
            this.lbbegin.Text = "Thời gian bắt đầu :";
            // 
            // gridThongKe
            // 
            this.gridThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridThongKe.Location = new System.Drawing.Point(0, 100);
            this.gridThongKe.MainView = this.ThongKe;
            this.gridThongKe.Name = "gridThongKe";
            this.gridThongKe.Size = new System.Drawing.Size(831, 342);
            this.gridThongKe.TabIndex = 1;
            this.gridThongKe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ThongKe});
            // 
            // ThongKe
            // 
            this.ThongKe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MA_DVQLY,
            this.ID_PTDIEN,
            this.TEN_PTDIEN,
            this.MA_CAPDA,
            this.gridColumn1,
            this.time});
            this.ThongKe.GridControl = this.gridThongKe;
            this.ThongKe.Name = "ThongKe";
            this.ThongKe.OptionsView.ShowGroupPanel = false;
            // 
            // MA_DVQLY
            // 
            this.MA_DVQLY.Caption = "Mã đơn vị quản lý";
            this.MA_DVQLY.FieldName = "MA_DVQLY";
            this.MA_DVQLY.Name = "MA_DVQLY";
            this.MA_DVQLY.Visible = true;
            this.MA_DVQLY.VisibleIndex = 0;
            this.MA_DVQLY.Width = 43;
            // 
            // ID_PTDIEN
            // 
            this.ID_PTDIEN.Caption = "ID PTDien";
            this.ID_PTDIEN.FieldName = "ID_PTDIEN";
            this.ID_PTDIEN.Name = "ID_PTDIEN";
            this.ID_PTDIEN.Visible = true;
            this.ID_PTDIEN.VisibleIndex = 1;
            this.ID_PTDIEN.Width = 117;
            // 
            // TEN_PTDIEN
            // 
            this.TEN_PTDIEN.Caption = "Tên trạm";
            this.TEN_PTDIEN.FieldName = "TEN_PTDIEN";
            this.TEN_PTDIEN.Name = "TEN_PTDIEN";
            this.TEN_PTDIEN.Visible = true;
            this.TEN_PTDIEN.VisibleIndex = 2;
            this.TEN_PTDIEN.Width = 303;
            // 
            // MA_CAPDA
            // 
            this.MA_CAPDA.Caption = "Cấp điện áp";
            this.MA_CAPDA.FieldName = "MA_CAPDA";
            this.MA_CAPDA.Name = "MA_CAPDA";
            this.MA_CAPDA.Visible = true;
            this.MA_CAPDA.VisibleIndex = 3;
            this.MA_CAPDA.Width = 67;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số lần mất điện";
            this.gridColumn1.FieldName = "count";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 100;
            // 
            // time
            // 
            this.time.Caption = "Tổng thời gian mất điện";
            this.time.FieldName = "time";
            this.time.Name = "time";
            this.time.Visible = true;
            this.time.VisibleIndex = 5;
            this.time.Width = 183;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 442);
            this.Controls.Add(this.gridThongKe);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmThongKe";
            this.Text = "Thống kế ";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textTop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDvi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThongKe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textTop;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateBegin;
        private DevExpress.XtraEditors.LookUpEdit cbDvi;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbbegin;
        private DevExpress.XtraEditors.SimpleButton btTime;
        private DevExpress.XtraEditors.SimpleButton btSoLan;
        private DevExpress.XtraGrid.GridControl gridThongKe;
        private DevExpress.XtraGrid.Views.Grid.GridView ThongKe;
        private DevExpress.XtraGrid.Columns.GridColumn MA_DVQLY;
        private DevExpress.XtraGrid.Columns.GridColumn ID_PTDIEN;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_PTDIEN;
        private DevExpress.XtraGrid.Columns.GridColumn MA_CAPDA;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn time;

    }
}