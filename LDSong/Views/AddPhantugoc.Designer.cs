namespace LDSong.Views
{
    partial class AddPhantugoc
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLoaiphantu = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLoaidienap = new DevExpress.XtraEditors.LookUpEdit();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDonviquanly = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiphantu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaidienap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDonviquanly.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên phần tử :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(146, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Loại phần tử điện :";
            // 
            // cbLoaiphantu
            // 
            this.cbLoaiphantu.Location = new System.Drawing.Point(146, 64);
            this.cbLoaiphantu.Name = "cbLoaiphantu";
            this.cbLoaiphantu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLoaiphantu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_LOAI", "Tên phần tử điện")});
            this.cbLoaiphantu.Properties.DisplayMember = "TEN_LOAI";
            this.cbLoaiphantu.Properties.ValueMember = "MA_LOAI";
            this.cbLoaiphantu.Size = new System.Drawing.Size(159, 20);
            this.cbLoaiphantu.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Loại điện áp :";
            // 
            // cbLoaidienap
            // 
            this.cbLoaidienap.Location = new System.Drawing.Point(146, 103);
            this.cbLoaidienap.Name = "cbLoaidienap";
            this.cbLoaidienap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLoaidienap.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_CAPDA", "Tên điện áp")});
            this.cbLoaidienap.Properties.DisplayMember = "TEN_CAPDA";
            this.cbLoaidienap.Properties.ValueMember = "MA_CAPDA";
            this.cbLoaidienap.Size = new System.Drawing.Size(159, 20);
            this.cbLoaidienap.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(146, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Thêm phần tử";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Đơn vị quản lý :";
            // 
            // cbDonviquanly
            // 
            this.cbDonviquanly.Location = new System.Drawing.Point(146, 143);
            this.cbDonviquanly.Name = "cbDonviquanly";
            this.cbDonviquanly.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDonviquanly.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_DVIQLY", "Tên đơn vị quản lý")});
            this.cbDonviquanly.Properties.DisplayMember = "TEN_DVIQLY";
            this.cbDonviquanly.Properties.ValueMember = "MA_DVIQLY";
            this.cbDonviquanly.Size = new System.Drawing.Size(159, 20);
            this.cbDonviquanly.TabIndex = 9;
            // 
            // AddPhantugoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 239);
            this.Controls.Add(this.cbDonviquanly);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbLoaidienap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbLoaiphantu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "AddPhantugoc";
            this.Text = "Thêm phần tử gốc";
            this.Load += new System.EventHandler(this.initThemphantu);
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiphantu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaidienap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDonviquanly.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit cbLoaiphantu;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit cbLoaidienap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LookUpEdit cbDonviquanly;
    }
}