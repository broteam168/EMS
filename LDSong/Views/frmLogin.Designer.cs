namespace LDSong.Views
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btCauhinh = new DevExpress.XtraEditors.SimpleButton();
            this.mallIcon = new System.Windows.Forms.ImageList(this.components);
            this.cmdThoat = new DevExpress.XtraEditors.SimpleButton();
            this.cmdLogin = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtPassWord = new DevExpress.XtraEditors.TextEdit();
            this.chkSavePass = new DevExpress.XtraEditors.CheckEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSavePass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btCauhinh);
            this.panelControl1.Controls.Add(this.cmdThoat);
            this.panelControl1.Controls.Add(this.cmdLogin);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 200);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(395, 36);
            this.panelControl1.TabIndex = 0;
            // 
            // btCauhinh
            // 
            this.btCauhinh.Image = ((System.Drawing.Image)(resources.GetObject("btCauhinh.Image")));
            this.btCauhinh.ImageIndex = 1;
            this.btCauhinh.ImageList = this.mallIcon;
            this.btCauhinh.Location = new System.Drawing.Point(22, 7);
            this.btCauhinh.Name = "btCauhinh";
            this.btCauhinh.Size = new System.Drawing.Size(91, 23);
            this.btCauhinh.TabIndex = 2;
            this.btCauhinh.Text = "Cấu hình";
            this.btCauhinh.Click += new System.EventHandler(this.btCauhinh_Click);
            // 
            // mallIcon
            // 
            this.mallIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mallIcon.ImageStream")));
            this.mallIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.mallIcon.Images.SetKeyName(0, "khoa.png");
            this.mallIcon.Images.SetKeyName(1, "saas-large.png");
            this.mallIcon.Images.SetKeyName(2, "Crystal_Project_Exit.png");
            this.mallIcon.Images.SetKeyName(3, "login.png");
            // 
            // cmdThoat
            // 
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.ImageIndex = 2;
            this.cmdThoat.ImageList = this.mallIcon;
            this.cmdThoat.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.cmdThoat.Location = new System.Drawing.Point(288, 7);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(91, 23);
            this.cmdThoat.TabIndex = 1;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // cmdLogin
            // 
            this.cmdLogin.Image = ((System.Drawing.Image)(resources.GetObject("cmdLogin.Image")));
            this.cmdLogin.ImageIndex = 3;
            this.cmdLogin.ImageList = this.mallIcon;
            this.cmdLogin.Location = new System.Drawing.Point(158, 7);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(91, 23);
            this.cmdLogin.TabIndex = 0;
            this.cmdLogin.Text = "Đăng nhập";
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(125, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(181, 19);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "VẬN HÀNH LƯỚI ĐIỆN";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(30, 82);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Tên đăng nhập:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(58, 117);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Mật khẩu:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(127, 79);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Size = new System.Drawing.Size(150, 20);
            this.txtUserName.TabIndex = 7;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(127, 114);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPassWord.Properties.Appearance.Options.UseFont = true;
            this.txtPassWord.Properties.PasswordChar = '*';
            this.txtPassWord.Properties.UseSystemPasswordChar = true;
            this.txtPassWord.Size = new System.Drawing.Size(150, 20);
            this.txtPassWord.TabIndex = 8;
            this.txtPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassWord_KeyDown);
            // 
            // chkSavePass
            // 
            this.chkSavePass.Location = new System.Drawing.Point(125, 152);
            this.chkSavePass.Name = "chkSavePass";
            this.chkSavePass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkSavePass.Properties.Appearance.Options.UseFont = true;
            this.chkSavePass.Properties.Caption = "Nhớ mật khẩu đăng nhập";
            this.chkSavePass.Size = new System.Drawing.Size(178, 19);
            this.chkSavePass.TabIndex = 12;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.PictureAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.StretchHorizontal;
            this.pictureEdit1.Size = new System.Drawing.Size(395, 236);
            this.pictureEdit1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 5F);
            this.label1.Location = new System.Drawing.Point(372, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 8);
            this.label1.TabIndex = 15;
            this.label1.Text = "V2.1";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(179, 41);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 19);
            this.labelControl4.TabIndex = 16;
            this.labelControl4.Text = "EVNMAP";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 236);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkSavePass);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pictureEdit1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSavePass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton cmdThoat;
        private DevExpress.XtraEditors.SimpleButton cmdLogin;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtPassWord;
        private DevExpress.XtraEditors.CheckEdit chkSavePass;
        private System.Windows.Forms.ImageList mallIcon;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btCauhinh;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}