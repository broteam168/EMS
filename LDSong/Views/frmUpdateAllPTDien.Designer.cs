namespace LDSong.Views
{
    partial class frmUpdateAllPTDien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateAllPTDien));
            this.cbDonviquanly = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.cbLoaiphantu = new DevExpress.XtraEditors.LookUpEdit();
            this.cbCapdienap = new DevExpress.XtraEditors.LookUpEdit();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textToado = new System.Windows.Forms.TextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaPmischa = new System.Windows.Forms.TextBox();
            this.txtMaPmis = new System.Windows.Forms.TextBox();
            this.txtMaScada = new System.Windows.Forms.TextBox();
            this.txtMaCmis = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbDonviquanly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiphantu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCapdienap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDonviquanly
            // 
            this.cbDonviquanly.Location = new System.Drawing.Point(178, 166);
            this.cbDonviquanly.Name = "cbDonviquanly";
            this.cbDonviquanly.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbDonviquanly.Properties.Appearance.Options.UseFont = true;
            this.cbDonviquanly.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDonviquanly.Size = new System.Drawing.Size(304, 20);
            this.cbDonviquanly.TabIndex = 55;
            this.cbDonviquanly.SelectedIndexChanged += new System.EventHandler(this.cbDonviquanly_SelectedIndexChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl9.Appearance.ForeColor = System.Drawing.SystemColors.MenuText;
            this.labelControl9.Location = new System.Drawing.Point(68, 169);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(85, 14);
            this.labelControl9.TabIndex = 54;
            this.labelControl9.Text = "Đơn vị quản lý :";
            // 
            // cbLoaiphantu
            // 
            this.cbLoaiphantu.Location = new System.Drawing.Point(178, 133);
            this.cbLoaiphantu.Name = "cbLoaiphantu";
            this.cbLoaiphantu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbLoaiphantu.Properties.Appearance.Options.UseFont = true;
            this.cbLoaiphantu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLoaiphantu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_LOAI", "Tên phần tử điện"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MA_LOAI", "MA_LOAI", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.cbLoaiphantu.Properties.DisplayMember = "TEN_LOAI";
            this.cbLoaiphantu.Properties.ValueMember = "MA_LOAI";
            this.cbLoaiphantu.Size = new System.Drawing.Size(304, 20);
            this.cbLoaiphantu.TabIndex = 52;
            // 
            // cbCapdienap
            // 
            this.cbCapdienap.Location = new System.Drawing.Point(178, 101);
            this.cbCapdienap.Name = "cbCapdienap";
            this.cbCapdienap.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cbCapdienap.Properties.Appearance.Options.UseFont = true;
            this.cbCapdienap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCapdienap.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_CAPDA", "Cấp điện áp"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MA_CAPDA", "MA_CAPDA", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.cbCapdienap.Properties.DisplayMember = "TEN_CAPDA";
            this.cbCapdienap.Properties.ValueMember = "MA_CAPDA";
            this.cbCapdienap.Size = new System.Drawing.Size(304, 20);
            this.cbCapdienap.TabIndex = 51;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(492, 36);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(26, 13);
            this.linkLabel1.TabIndex = 50;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Sửa";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textToado
            // 
            this.textToado.Enabled = false;
            this.textToado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textToado.Location = new System.Drawing.Point(178, 32);
            this.textToado.Name = "textToado";
            this.textToado.Size = new System.Drawing.Size(304, 21);
            this.textToado.TabIndex = 49;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl8.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl8.Location = new System.Drawing.Point(106, 33);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(47, 14);
            this.labelControl8.TabIndex = 48;
            this.labelControl8.Text = "Tọa độ :";
            // 
            // txtMaPmischa
            // 
            this.txtMaPmischa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPmischa.Location = new System.Drawing.Point(178, 302);
            this.txtMaPmischa.Name = "txtMaPmischa";
            this.txtMaPmischa.Size = new System.Drawing.Size(304, 21);
            this.txtMaPmischa.TabIndex = 47;
            // 
            // txtMaPmis
            // 
            this.txtMaPmis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPmis.Location = new System.Drawing.Point(178, 268);
            this.txtMaPmis.Name = "txtMaPmis";
            this.txtMaPmis.Size = new System.Drawing.Size(304, 21);
            this.txtMaPmis.TabIndex = 46;
            // 
            // txtMaScada
            // 
            this.txtMaScada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaScada.Location = new System.Drawing.Point(178, 233);
            this.txtMaScada.Name = "txtMaScada";
            this.txtMaScada.Size = new System.Drawing.Size(304, 21);
            this.txtMaScada.TabIndex = 45;
            // 
            // txtMaCmis
            // 
            this.txtMaCmis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaCmis.Location = new System.Drawing.Point(178, 198);
            this.txtMaCmis.Name = "txtMaCmis";
            this.txtMaCmis.Size = new System.Drawing.Size(304, 21);
            this.txtMaCmis.TabIndex = 44;
            // 
            // txtTen
            // 
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(178, 68);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(304, 21);
            this.txtTen.TabIndex = 43;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl7.Appearance.ForeColor = System.Drawing.SystemColors.MenuText;
            this.labelControl7.Location = new System.Drawing.Point(76, 306);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(77, 14);
            this.labelControl7.TabIndex = 42;
            this.labelControl7.Text = "Mã PMISCHA :";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl6.Appearance.ForeColor = System.Drawing.SystemColors.MenuText;
            this.labelControl6.Location = new System.Drawing.Point(99, 272);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(54, 14);
            this.labelControl6.TabIndex = 41;
            this.labelControl6.Text = "Mã PMIS :";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl5.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl5.Location = new System.Drawing.Point(88, 237);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(65, 14);
            this.labelControl5.TabIndex = 40;
            this.labelControl5.Text = "Mã SCADA :";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl4.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl4.Location = new System.Drawing.Point(99, 202);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(54, 14);
            this.labelControl4.TabIndex = 39;
            this.labelControl4.Text = "Mã CMIS :";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl3.Appearance.ForeColor = System.Drawing.SystemColors.MenuText;
            this.labelControl3.Location = new System.Drawing.Point(76, 136);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(77, 14);
            this.labelControl3.TabIndex = 38;
            this.labelControl3.Text = "Loại phần tử :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.MenuText;
            this.labelControl2.Location = new System.Drawing.Point(81, 104);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 14);
            this.labelControl2.TabIndex = 37;
            this.labelControl2.Text = "Cấp điện áp :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl1.Location = new System.Drawing.Point(75, 69);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 14);
            this.labelControl1.TabIndex = 36;
            this.labelControl1.Text = "Tên phần tử :";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl10.Location = new System.Drawing.Point(485, 304);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(6, 13);
            this.labelControl10.TabIndex = 56;
            this.labelControl10.Text = "*";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl11.Location = new System.Drawing.Point(485, 268);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(6, 13);
            this.labelControl11.TabIndex = 57;
            this.labelControl11.Text = "*";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Location = new System.Drawing.Point(485, 166);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(6, 13);
            this.labelControl12.TabIndex = 58;
            this.labelControl12.Text = "*";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl13.Location = new System.Drawing.Point(485, 134);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(6, 13);
            this.labelControl13.TabIndex = 59;
            this.labelControl13.Text = "*";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl14.Location = new System.Drawing.Point(485, 101);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(6, 13);
            this.labelControl14.TabIndex = 60;
            this.labelControl14.Text = "*";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl15.Location = new System.Drawing.Point(485, 68);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(6, 13);
            this.labelControl15.TabIndex = 61;
            this.labelControl15.Text = "*";
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl16.Location = new System.Drawing.Point(484, 32);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(6, 13);
            this.labelControl16.TabIndex = 62;
            this.labelControl16.Text = "*";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(520, 36);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(30, 13);
            this.linkLabel3.TabIndex = 71;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Tính";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // ofdMain
            // 
            this.ofdMain.FileName = "openFileDialog1";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(229, 345);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(83, 29);
            this.simpleButton2.TabIndex = 72;
            this.simpleButton2.Text = "Tải ảnh";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(340, 345);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(93, 29);
            this.simpleButton1.TabIndex = 53;
            this.simpleButton1.Text = "Cập nhật";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmUpdateAllPTDien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 407);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.cbDonviquanly);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.cbLoaiphantu);
            this.Controls.Add(this.cbCapdienap);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textToado);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtMaPmischa);
            this.Controls.Add(this.txtMaPmis);
            this.Controls.Add(this.txtMaScada);
            this.Controls.Add(this.txtMaCmis);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmUpdateAllPTDien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sửa thông tin - vị trí phần tử điện";
            ((System.ComponentModel.ISupportInitialize)(this.cbDonviquanly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiphantu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCapdienap.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cbDonviquanly;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LookUpEdit cbLoaiphantu;
        private DevExpress.XtraEditors.LookUpEdit cbCapdienap;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textToado;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.TextBox txtMaPmischa;
        private System.Windows.Forms.TextBox txtMaPmis;
        private System.Windows.Forms.TextBox txtMaScada;
        private System.Windows.Forms.TextBox txtMaCmis;
        private System.Windows.Forms.TextBox txtTen;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.OpenFileDialog ofdMain;
    }
}