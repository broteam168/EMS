namespace LDSong.Views
{
    partial class frmInforQuanHe
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lbTenCon = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lbIDNut = new DevExpress.XtraEditors.LabelControl();
            this.labelRoot = new DevExpress.XtraEditors.LabelControl();
            this.gridQuanHe = new DevExpress.XtraGrid.GridControl();
            this.quanHe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID_PTDienCha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_PTDIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_LOAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VITRI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MenuDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuanHe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanHe)).BeginInit();
            this.MenuDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lbTenCon);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.lbIDNut);
            this.panelControl1.Controls.Add(this.labelRoot);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(467, 75);
            this.panelControl1.TabIndex = 0;
            // 
            // lbTenCon
            // 
            this.lbTenCon.Location = new System.Drawing.Point(80, 34);
            this.lbTenCon.Name = "lbTenCon";
            this.lbTenCon.Size = new System.Drawing.Size(44, 13);
            this.lbTenCon.TabIndex = 7;
            this.lbTenCon.Text = "Tên nút :";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(27, 34);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Tên con :";
            // 
            // lbIDNut
            // 
            this.lbIDNut.Location = new System.Drawing.Point(80, 12);
            this.lbIDNut.Name = "lbIDNut";
            this.lbIDNut.Size = new System.Drawing.Size(18, 13);
            this.lbIDNut.TabIndex = 5;
            this.lbIDNut.Text = "ID :";
            // 
            // labelRoot
            // 
            this.labelRoot.Location = new System.Drawing.Point(26, 12);
            this.labelRoot.Name = "labelRoot";
            this.labelRoot.Size = new System.Drawing.Size(18, 13);
            this.labelRoot.TabIndex = 4;
            this.labelRoot.Text = "ID :";
            // 
            // gridQuanHe
            // 
            this.gridQuanHe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridQuanHe.Location = new System.Drawing.Point(0, 75);
            this.gridQuanHe.MainView = this.quanHe;
            this.gridQuanHe.Name = "gridQuanHe";
            this.gridQuanHe.Size = new System.Drawing.Size(467, 260);
            this.gridQuanHe.TabIndex = 1;
            this.gridQuanHe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.quanHe});
            // 
            // quanHe
            // 
            this.quanHe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.ID_PTDienCha,
            this.TEN_PTDIEN,
            this.TEN_LOAI,
            this.VITRI});
            this.quanHe.GridControl = this.gridQuanHe;
            this.quanHe.Name = "quanHe";
            this.quanHe.OptionsBehavior.Editable = false;
            this.quanHe.OptionsFind.AlwaysVisible = true;
            this.quanHe.OptionsView.ShowGroupPanel = false;
            this.quanHe.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.quanHe_RowClick);
            this.quanHe.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.quanHe_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // ID_PTDienCha
            // 
            this.ID_PTDienCha.AppearanceHeader.Options.UseTextOptions = true;
            this.ID_PTDienCha.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ID_PTDienCha.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ID_PTDienCha.Caption = "ID Cha";
            this.ID_PTDienCha.FieldName = "ID_PTDienCha";
            this.ID_PTDienCha.Name = "ID_PTDienCha";
            this.ID_PTDienCha.Visible = true;
            this.ID_PTDienCha.VisibleIndex = 0;
            // 
            // TEN_PTDIEN
            // 
            this.TEN_PTDIEN.AppearanceHeader.Options.UseTextOptions = true;
            this.TEN_PTDIEN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TEN_PTDIEN.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TEN_PTDIEN.Caption = "Tên phần tử cha";
            this.TEN_PTDIEN.FieldName = "TEN_PTDIEN";
            this.TEN_PTDIEN.Name = "TEN_PTDIEN";
            this.TEN_PTDIEN.Visible = true;
            this.TEN_PTDIEN.VisibleIndex = 1;
            // 
            // TEN_LOAI
            // 
            this.TEN_LOAI.AppearanceHeader.Options.UseTextOptions = true;
            this.TEN_LOAI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TEN_LOAI.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.TEN_LOAI.Caption = "Loại ";
            this.TEN_LOAI.FieldName = "TEN_LOAI";
            this.TEN_LOAI.Name = "TEN_LOAI";
            this.TEN_LOAI.Visible = true;
            this.TEN_LOAI.VisibleIndex = 2;
            // 
            // VITRI
            // 
            this.VITRI.AppearanceHeader.Options.UseTextOptions = true;
            this.VITRI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VITRI.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.VITRI.Caption = "Vị trí";
            this.VITRI.FieldName = "VITRI";
            this.VITRI.Name = "VITRI";
            this.VITRI.Visible = true;
            this.VITRI.VisibleIndex = 3;
            // 
            // MenuDelete
            // 
            this.MenuDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem});
            this.MenuDelete.Name = "MenuDelete";
            this.MenuDelete.Size = new System.Drawing.Size(95, 26);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // frmInforQuanHe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 335);
            this.Controls.Add(this.gridQuanHe);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmInforQuanHe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin liên hệ";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuanHe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanHe)).EndInit();
            this.MenuDelete.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridQuanHe;
        private DevExpress.XtraGrid.Views.Grid.GridView quanHe;
        private DevExpress.XtraEditors.LabelControl lbTenCon;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lbIDNut;
        private DevExpress.XtraEditors.LabelControl labelRoot;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn ID_PTDienCha;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_PTDIEN;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_LOAI;
        private DevExpress.XtraGrid.Columns.GridColumn VITRI;
        private System.Windows.Forms.ContextMenuStrip MenuDelete;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
    }
}