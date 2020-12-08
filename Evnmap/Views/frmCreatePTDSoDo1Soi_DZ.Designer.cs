namespace LDSong.Views
{
    partial class frmCreatePTDSoDo1Soi_DZ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreatePTDSoDo1Soi_DZ));
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textToado = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.radio22 = new System.Windows.Forms.RadioButton();
            this.radio35 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl8.Location = new System.Drawing.Point(32, 10);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(41, 17);
            this.labelControl8.TabIndex = 37;
            this.labelControl8.Text = "Vị trí :";
            this.labelControl8.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(470, 10);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(26, 13);
            this.linkLabel1.TabIndex = 39;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Sửa";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textToado
            // 
            this.textToado.Enabled = false;
            this.textToado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textToado.Location = new System.Drawing.Point(158, 6);
            this.textToado.Name = "textToado";
            this.textToado.Size = new System.Drawing.Size(297, 21);
            this.textToado.TabIndex = 38;
            this.textToado.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl1.Location = new System.Drawing.Point(21, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(114, 17);
            this.labelControl1.TabIndex = 40;
            this.labelControl1.Text = "Tên đường dây :";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(158, 34);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(297, 20);
            this.txtTen.TabIndex = 41;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(244, 104);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(99, 24);
            this.simpleButton1.TabIndex = 42;
            this.simpleButton1.Text = "Tạo phần tử";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl2.Location = new System.Drawing.Point(45, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(90, 17);
            this.labelControl2.TabIndex = 43;
            this.labelControl2.Text = "Cấp điện áp :";
            // 
            // radio22
            // 
            this.radio22.AutoSize = true;
            this.radio22.Checked = true;
            this.radio22.Location = new System.Drawing.Point(229, 71);
            this.radio22.Name = "radio22";
            this.radio22.Size = new System.Drawing.Size(53, 17);
            this.radio22.TabIndex = 44;
            this.radio22.TabStop = true;
            this.radio22.Text = "22 kV";
            this.radio22.UseVisualStyleBackColor = true;
            // 
            // radio35
            // 
            this.radio35.AutoSize = true;
            this.radio35.Location = new System.Drawing.Point(320, 71);
            this.radio35.Name = "radio35";
            this.radio35.Size = new System.Drawing.Size(53, 17);
            this.radio35.TabIndex = 45;
            this.radio35.TabStop = true;
            this.radio35.Text = "35 kV";
            this.radio35.UseVisualStyleBackColor = true;
            // 
            // frmCreatePTDSoDo1Soi_DZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 151);
            this.Controls.Add(this.radio35);
            this.Controls.Add(this.radio22);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textToado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmCreatePTDSoDo1Soi_DZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm đường dây";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textToado;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txtTen;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.RadioButton radio22;
        private System.Windows.Forms.RadioButton radio35;
    }
}