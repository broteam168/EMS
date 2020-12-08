namespace LDSong.Views
{
    partial class frmUsers
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dgrCtlUser = new DevExpress.XtraGrid.GridControl();
            this.dgrUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Password = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmdClearPass = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cmdHuy = new DevExpress.XtraEditors.SimpleButton();
            this.cmdGhi = new DevExpress.XtraEditors.SimpleButton();
            this.cmdXoa = new DevExpress.XtraEditors.SimpleButton();
            this.cmdSua = new DevExpress.XtraEditors.SimpleButton();
            this.cmdThem = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.cboNhom = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDienThoai = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.chkEnable = new DevExpress.XtraEditors.CheckEdit();
            this.cboDonVi = new DevExpress.XtraEditors.LookUpEdit();
            this.txtGhiChu = new DevExpress.XtraEditors.TextEdit();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCtlUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienThoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dgrCtlUser);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 35);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(346, 398);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Danh sách người dùng";
            // 
            // dgrCtlUser
            // 
            this.dgrCtlUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgrCtlUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrCtlUser.Location = new System.Drawing.Point(2, 20);
            this.dgrCtlUser.MainView = this.dgrUser;
            this.dgrCtlUser.Name = "dgrCtlUser";
            this.dgrCtlUser.Size = new System.Drawing.Size(342, 376);
            this.dgrCtlUser.TabIndex = 0;
            this.dgrCtlUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgrUser});
            // 
            // dgrUser
            // 
            this.dgrUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.GroupId,
            this.UserName,
            this.FullName,
            this.Password,
            this.Description,
            this.MaDV,
            this.TrangThai});
            this.dgrUser.GridControl = this.dgrCtlUser;
            this.dgrUser.Name = "dgrUser";
            this.dgrUser.OptionsBehavior.Editable = false;
            this.dgrUser.OptionsFind.AlwaysVisible = true;
            this.dgrUser.OptionsFind.FindNullPrompt = "";
            this.dgrUser.OptionsView.ShowGroupPanel = false;
            this.dgrUser.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgrUser_FocusedRowChanged);
            // 
            // ID
            // 
            this.ID.Caption = "gridColumn1";
            this.ID.FieldName = "UserId";
            this.ID.Name = "ID";
            // 
            // GroupId
            // 
            this.GroupId.Caption = "gridColumn1";
            this.GroupId.FieldName = "UserGroup";
            this.GroupId.Name = "GroupId";
            // 
            // UserName
            // 
            this.UserName.Caption = "Tên đăng nhập";
            this.UserName.FieldName = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.Visible = true;
            this.UserName.VisibleIndex = 0;
            // 
            // FullName
            // 
            this.FullName.Caption = "Họ và tên";
            this.FullName.FieldName = "UserFullname";
            this.FullName.Name = "FullName";
            this.FullName.Visible = true;
            this.FullName.VisibleIndex = 1;
            // 
            // Password
            // 
            this.Password.Caption = "gridColumn1";
            this.Password.FieldName = "Password";
            this.Password.Name = "Password";
            // 
            // Description
            // 
            this.Description.Caption = "gridColumn1";
            this.Description.FieldName = "UserPoss";
            this.Description.Name = "Description";
            // 
            // MaDV
            // 
            this.MaDV.Caption = "Mã ĐV";
            this.MaDV.FieldName = "MaDVQL";
            this.MaDV.Name = "MaDV";
            this.MaDV.Visible = true;
            this.MaDV.VisibleIndex = 2;
            // 
            // TrangThai
            // 
            this.TrangThai.Caption = "gridColumn1";
            this.TrangThai.FieldName = "IsActive";
            this.TrangThai.Name = "TrangThai";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cmdClearPass);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.cmdXoa);
            this.panelControl1.Controls.Add(this.cmdSua);
            this.panelControl1.Controls.Add(this.cmdThem);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(831, 35);
            this.panelControl1.TabIndex = 2;
            // 
            // cmdClearPass
            // 
            this.cmdClearPass.Enabled = false;
            this.cmdClearPass.Location = new System.Drawing.Point(249, 6);
            this.cmdClearPass.Name = "cmdClearPass";
            this.cmdClearPass.Size = new System.Drawing.Size(75, 23);
            this.cmdClearPass.TabIndex = 6;
            this.cmdClearPass.Text = "Xóa mật khẩu";
            this.cmdClearPass.Click += new System.EventHandler(this.cmdClearPass_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.cmdHuy);
            this.panelControl2.Controls.Add(this.cmdGhi);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(542, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(287, 31);
            this.panelControl2.TabIndex = 5;
            // 
            // cmdHuy
            // 
            this.cmdHuy.Enabled = false;
            this.cmdHuy.Location = new System.Drawing.Point(209, 4);
            this.cmdHuy.Name = "cmdHuy";
            this.cmdHuy.Size = new System.Drawing.Size(75, 23);
            this.cmdHuy.TabIndex = 4;
            this.cmdHuy.Text = "Hủy";
            this.cmdHuy.Click += new System.EventHandler(this.cmdHuy_Click);
            // 
            // cmdGhi
            // 
            this.cmdGhi.Enabled = false;
            this.cmdGhi.Location = new System.Drawing.Point(128, 4);
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
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.cboNhom);
            this.panelControl3.Controls.Add(this.txtDienThoai);
            this.panelControl3.Controls.Add(this.labelControl3);
            this.panelControl3.Controls.Add(this.chkEnable);
            this.panelControl3.Controls.Add(this.cboDonVi);
            this.panelControl3.Controls.Add(this.txtGhiChu);
            this.panelControl3.Controls.Add(this.txtFullName);
            this.panelControl3.Controls.Add(this.txtUserName);
            this.panelControl3.Controls.Add(this.labelControl7);
            this.panelControl3.Controls.Add(this.labelControl6);
            this.panelControl3.Controls.Add(this.labelControl5);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(346, 35);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(485, 398);
            this.panelControl3.TabIndex = 3;
            // 
            // cboNhom
            // 
            this.cboNhom.Location = new System.Drawing.Point(119, 150);
            this.cboNhom.Name = "cboNhom";
            this.cboNhom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhom.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GroupName", "Nhóm sử dụng")});
            this.cboNhom.Properties.DisplayMember = "GroupName";
            this.cboNhom.Properties.NullText = "";
            this.cboNhom.Properties.ShowFooter = false;
            this.cboNhom.Properties.ValueMember = "GroupId";
            this.cboNhom.Size = new System.Drawing.Size(278, 20);
            this.cboNhom.TabIndex = 17;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(121, 83);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(100, 20);
            this.txtDienThoai.TabIndex = 16;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(59, 86);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(53, 13);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "Điện thoại:";
            // 
            // chkEnable
            // 
            this.chkEnable.Location = new System.Drawing.Point(121, 217);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Properties.Caption = "Trạng thái";
            this.chkEnable.Size = new System.Drawing.Size(75, 19);
            this.chkEnable.TabIndex = 14;
            // 
            // cboDonVi
            // 
            this.cboDonVi.Location = new System.Drawing.Point(121, 185);
            this.cboDonVi.Name = "cboDonVi";
            this.cboDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDonVi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_DVIQLY", "Tên đơn vị")});
            this.cboDonVi.Properties.DisplayMember = "TEN_DVIQLY";
            this.cboDonVi.Properties.NullText = "";
            this.cboDonVi.Properties.ShowFooter = false;
            this.cboDonVi.Properties.ValueMember = "MA_DVIQLY";
            this.cboDonVi.Size = new System.Drawing.Size(278, 20);
            this.cboDonVi.TabIndex = 13;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(121, 116);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(278, 20);
            this.txtGhiChu.TabIndex = 11;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(121, 51);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(164, 20);
            this.txtFullName.TabIndex = 8;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(121, 20);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 7;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(77, 189);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(35, 13);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "Đơn vị:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(24, 155);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(88, 13);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Nhóm người dùng:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(73, 119);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(41, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Vị trí CT:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(61, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Họ và tên:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(36, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên đăng nhập:";
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 433);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmUsers";
            this.Text = "Quản lý người dùng";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrCtlUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienThoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton cmdHuy;
        private DevExpress.XtraEditors.SimpleButton cmdGhi;
        private DevExpress.XtraEditors.SimpleButton cmdXoa;
        private DevExpress.XtraEditors.SimpleButton cmdSua;
        private DevExpress.XtraEditors.SimpleButton cmdThem;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl dgrCtlUser;
        private DevExpress.XtraGrid.Views.Grid.GridView dgrUser;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn GroupId;
        private DevExpress.XtraGrid.Columns.GridColumn UserName;
        private DevExpress.XtraGrid.Columns.GridColumn FullName;
        private DevExpress.XtraGrid.Columns.GridColumn Password;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private DevExpress.XtraGrid.Columns.GridColumn MaDV;
        private DevExpress.XtraEditors.SimpleButton cmdClearPass;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LookUpEdit cboDonVi;
        private DevExpress.XtraEditors.TextEdit txtGhiChu;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.CheckEdit chkEnable;
        private DevExpress.XtraGrid.Columns.GridColumn TrangThai;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtDienThoai;
        private DevExpress.XtraEditors.LookUpEdit cboNhom;
    }
}