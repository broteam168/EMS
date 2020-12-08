namespace LDSong.Views
{
    partial class frmCreateNotice
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
            this.cbDonviquanly = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textToado = new System.Windows.Forms.TextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.cboMauNen = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDonviquanly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMauNen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDonviquanly
            // 
            this.cbDonviquanly.Location = new System.Drawing.Point(140, 129);
            this.cbDonviquanly.Name = "cbDonviquanly";
            this.cbDonviquanly.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDonviquanly.Size = new System.Drawing.Size(304, 20);
            this.cbDonviquanly.TabIndex = 46;
            this.cbDonviquanly.SelectedIndexChanged += new System.EventHandler(this.cbDonviquanly_SelectedIndexChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl9.Appearance.ForeColor = System.Drawing.SystemColors.MenuText;
            this.labelControl9.Location = new System.Drawing.Point(21, 129);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(107, 17);
            this.labelControl9.TabIndex = 45;
            this.labelControl9.Text = "Đơn vị quản lý :";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(447, 30);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(26, 13);
            this.linkLabel1.TabIndex = 42;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Sửa";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textToado
            // 
            this.textToado.Enabled = false;
            this.textToado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textToado.Location = new System.Drawing.Point(140, 26);
            this.textToado.Name = "textToado";
            this.textToado.Size = new System.Drawing.Size(304, 21);
            this.textToado.TabIndex = 41;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl8.Location = new System.Drawing.Point(21, 27);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(57, 17);
            this.labelControl8.TabIndex = 40;
            this.labelControl8.Text = "Tọa độ :";
            // 
            // txtTen
            // 
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(140, 62);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(304, 21);
            this.txtTen.TabIndex = 39;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.MenuText;
            this.labelControl2.Location = new System.Drawing.Point(21, 95);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(68, 17);
            this.labelControl2.TabIndex = 37;
            this.labelControl2.Text = "Màu nền :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl1.Location = new System.Drawing.Point(21, 63);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 17);
            this.labelControl1.TabIndex = 36;
            this.labelControl1.Text = "Tiêu đề :";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(210, 165);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(135, 29);
            this.simpleButton1.TabIndex = 49;
            this.simpleButton1.Text = "Tạo ghi chú";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // cboMauNen
            // 
            this.cboMauNen.Location = new System.Drawing.Point(140, 95);
            this.cboMauNen.Name = "cboMauNen";
            this.cboMauNen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMauNen.Properties.Items.AddRange(new object[] {
            "Đỏ",
            "Vàng",
            "Xanh",
            "Đen"});
            this.cboMauNen.Size = new System.Drawing.Size(304, 20);
            this.cboMauNen.TabIndex = 50;
            // 
            // frmCreateNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 215);
            this.Controls.Add(this.cboMauNen);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.cbDonviquanly);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textToado);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmCreateNotice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo đánh dấu cảnh báo";
            this.Load += new System.EventHandler(this.frmCreateNotice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbDonviquanly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMauNen.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cbDonviquanly;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textToado;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.TextBox txtTen;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.ComboBoxEdit cboMauNen;
    }
}