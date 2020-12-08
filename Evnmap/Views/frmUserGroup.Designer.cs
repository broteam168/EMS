namespace LDSong.Views
{
    partial class frmUserGroup
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
            this.dgrCtlNhom = new DevExpress.XtraGrid.GridControl();
            this.dgrNhom = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GroupId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Permission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.chkInvert = new DevExpress.XtraEditors.CheckEdit();
            this.trPhanQuyen = new DevExpress.XtraTreeList.TreeList();
            this.MenuId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.MenuText = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.cbLoai = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lThuGon = new DevExpress.XtraEditors.HyperLinkEdit();
            this.lMoRong = new DevExpress.XtraEditors.HyperLinkEdit();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.txtGroupName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCtlNhom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrNhom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInvert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPhanQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lThuGon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lMoRong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(756, 35);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.cmdHuy);
            this.panelControl2.Controls.Add(this.cmdGhi);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(554, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(200, 31);
            this.panelControl2.TabIndex = 5;
            // 
            // cmdHuy
            // 
            this.cmdHuy.Enabled = false;
            this.cmdHuy.Location = new System.Drawing.Point(121, 4);
            this.cmdHuy.Name = "cmdHuy";
            this.cmdHuy.Size = new System.Drawing.Size(75, 23);
            this.cmdHuy.TabIndex = 4;
            this.cmdHuy.Text = "Hủy";
            this.cmdHuy.Click += new System.EventHandler(this.cmdHuy_Click);
            // 
            // cmdGhi
            // 
            this.cmdGhi.Enabled = false;
            this.cmdGhi.Location = new System.Drawing.Point(40, 4);
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
            this.groupControl1.Controls.Add(this.dgrCtlNhom);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 35);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(276, 386);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Danh sách nhóm người dùng";
            // 
            // dgrCtlNhom
            // 
            this.dgrCtlNhom.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgrCtlNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrCtlNhom.Location = new System.Drawing.Point(2, 20);
            this.dgrCtlNhom.MainView = this.dgrNhom;
            this.dgrCtlNhom.Name = "dgrCtlNhom";
            this.dgrCtlNhom.Size = new System.Drawing.Size(272, 364);
            this.dgrCtlNhom.TabIndex = 0;
            this.dgrCtlNhom.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgrNhom});
            // 
            // dgrNhom
            // 
            this.dgrNhom.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GroupId,
            this.GroupName,
            this.GroupDesc,
            this.Permission});
            this.dgrNhom.GridControl = this.dgrCtlNhom;
            this.dgrNhom.Name = "dgrNhom";
            this.dgrNhom.OptionsBehavior.Editable = false;
            this.dgrNhom.OptionsView.ShowGroupPanel = false;
            this.dgrNhom.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgrNhom_FocusedRowChanged);
            // 
            // GroupId
            // 
            this.GroupId.Caption = "gridColumn1";
            this.GroupId.FieldName = "GroupId";
            this.GroupId.Name = "GroupId";
            // 
            // GroupName
            // 
            this.GroupName.Caption = "Tên nhóm";
            this.GroupName.FieldName = "GroupName";
            this.GroupName.Name = "GroupName";
            this.GroupName.OptionsColumn.AllowEdit = false;
            this.GroupName.Visible = true;
            this.GroupName.VisibleIndex = 0;
            // 
            // GroupDesc
            // 
            this.GroupDesc.Caption = "gridColumn1";
            this.GroupDesc.FieldName = "GroupDesc";
            this.GroupDesc.Name = "GroupDesc";
            // 
            // Permission
            // 
            this.Permission.Caption = "gridColumn1";
            this.Permission.FieldName = "Permission";
            this.Permission.Name = "Permission";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Tên nhóm:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(26, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Loại :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 69);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(61, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Phân quyền:";
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(5, 90);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "Chọn hết";
            this.chkAll.Size = new System.Drawing.Size(75, 19);
            this.chkAll.TabIndex = 6;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkInvert
            // 
            this.chkInvert.Location = new System.Drawing.Point(86, 90);
            this.chkInvert.Name = "chkInvert";
            this.chkInvert.Properties.Caption = "Đảo chọn";
            this.chkInvert.Size = new System.Drawing.Size(70, 19);
            this.chkInvert.TabIndex = 7;
            this.chkInvert.CheckedChanged += new System.EventHandler(this.chkInvert_CheckedChanged);
            // 
            // trPhanQuyen
            // 
            this.trPhanQuyen.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.MenuId,
            this.MenuText});
            this.trPhanQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trPhanQuyen.Enabled = false;
            this.trPhanQuyen.Location = new System.Drawing.Point(2, 120);
            this.trPhanQuyen.Name = "trPhanQuyen";
            this.trPhanQuyen.OptionsSelection.InvertSelection = true;
            this.trPhanQuyen.OptionsSelection.MultiSelect = true;
            this.trPhanQuyen.OptionsSelection.UseIndicatorForSelection = true;
            this.trPhanQuyen.OptionsView.ShowCheckBoxes = true;
            this.trPhanQuyen.Size = new System.Drawing.Size(476, 264);
            this.trPhanQuyen.TabIndex = 8;
            this.trPhanQuyen.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.trPhanQuyen_AfterCheckNode);
            this.trPhanQuyen.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trPhanQuyen_FocusedNodeChanged);
            // 
            // MenuId
            // 
            this.MenuId.Caption = "treeListColumn1";
            this.MenuId.FieldName = "MenuId";
            this.MenuId.Name = "MenuId";
            // 
            // MenuText
            // 
            this.MenuText.Caption = "Chức năng";
            this.MenuText.FieldName = "MenuText";
            this.MenuText.MinWidth = 32;
            this.MenuText.Name = "MenuText";
            this.MenuText.OptionsColumn.AllowEdit = false;
            this.MenuText.Visible = true;
            this.MenuText.VisibleIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.trPhanQuyen);
            this.panelControl3.Controls.Add(this.panelControl5);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(276, 35);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(480, 386);
            this.panelControl3.TabIndex = 9;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.cbLoai);
            this.panelControl5.Controls.Add(this.lThuGon);
            this.panelControl5.Controls.Add(this.lMoRong);
            this.panelControl5.Controls.Add(this.labelControl2);
            this.panelControl5.Controls.Add(this.panelControl4);
            this.panelControl5.Controls.Add(this.labelControl3);
            this.panelControl5.Controls.Add(this.txtGroupName);
            this.panelControl5.Controls.Add(this.labelControl1);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl5.Location = new System.Drawing.Point(2, 2);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(476, 118);
            this.panelControl5.TabIndex = 12;
            // 
            // cbLoai
            // 
            this.cbLoai.Location = new System.Drawing.Point(70, 40);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLoai.Properties.Items.AddRange(new object[] {
            "Administrator",
            "Điều độ",
            "Thông Tin",
            "Cá nhân"});
            this.cbLoai.Size = new System.Drawing.Size(222, 20);
            this.cbLoai.TabIndex = 14;
            // 
            // lThuGon
            // 
            this.lThuGon.EditValue = "- Thu gọn";
            this.lThuGon.Location = new System.Drawing.Point(80, 90);
            this.lThuGon.Name = "lThuGon";
            this.lThuGon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lThuGon.Properties.Appearance.Options.UseBackColor = true;
            this.lThuGon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lThuGon.Size = new System.Drawing.Size(55, 18);
            this.lThuGon.TabIndex = 13;
            this.lThuGon.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.lThuGon_OpenLink);
            // 
            // lMoRong
            // 
            this.lMoRong.EditValue = "+ Mở rộng";
            this.lMoRong.Location = new System.Drawing.Point(12, 90);
            this.lMoRong.Name = "lMoRong";
            this.lMoRong.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lMoRong.Properties.Appearance.Options.UseBackColor = true;
            this.lMoRong.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lMoRong.Size = new System.Drawing.Size(61, 18);
            this.lMoRong.TabIndex = 12;
            this.lMoRong.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.lMoRong_OpenLink);
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.chkInvert);
            this.panelControl4.Controls.Add(this.chkAll);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl4.Location = new System.Drawing.Point(314, 2);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(160, 114);
            this.panelControl4.TabIndex = 9;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(70, 9);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(222, 20);
            this.txtGroupName.TabIndex = 10;
            // 
            // frmUserGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 421);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmUserGroup";
            this.Text = "Quản lý nhóm người dùng";
            this.Load += new System.EventHandler(this.frmUserGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrCtlNhom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrNhom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInvert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trPhanQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lThuGon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lMoRong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton cmdHuy;
        private DevExpress.XtraEditors.SimpleButton cmdGhi;
        private DevExpress.XtraEditors.SimpleButton cmdXoa;
        private DevExpress.XtraEditors.SimpleButton cmdSua;
        private DevExpress.XtraEditors.SimpleButton cmdThem;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl dgrCtlNhom;
        private DevExpress.XtraGrid.Views.Grid.GridView dgrNhom;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.CheckEdit chkInvert;
        private DevExpress.XtraTreeList.TreeList trPhanQuyen;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.TextEdit txtGroupName;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraGrid.Columns.GridColumn GroupId;
        private DevExpress.XtraGrid.Columns.GridColumn GroupName;
        private DevExpress.XtraGrid.Columns.GridColumn GroupDesc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn MenuId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn MenuText;
        private DevExpress.XtraEditors.HyperLinkEdit lMoRong;
        private DevExpress.XtraEditors.HyperLinkEdit lThuGon;
        private DevExpress.XtraGrid.Columns.GridColumn Permission;
        private DevExpress.XtraEditors.ComboBoxEdit cbLoai;
    }
}