namespace LDSong.Views
{
    partial class frmUpdatePTDienSoDo1Soi_DZ
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
            this.radio35 = new System.Windows.Forms.RadioButton();
            this.radio22 = new System.Windows.Forms.RadioButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textToado = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // radio35
            // 
            this.radio35.AutoSize = true;
            this.radio35.Location = new System.Drawing.Point(321, 113);
            this.radio35.Name = "radio35";
            this.radio35.Size = new System.Drawing.Size(53, 17);
            this.radio35.TabIndex = 53;
            this.radio35.TabStop = true;
            this.radio35.Text = "35 kV";
            this.radio35.UseVisualStyleBackColor = true;
            // 
            // radio22
            // 
            this.radio22.AutoSize = true;
            this.radio22.Location = new System.Drawing.Point(230, 113);
            this.radio22.Name = "radio22";
            this.radio22.Size = new System.Drawing.Size(53, 17);
            this.radio22.TabIndex = 52;
            this.radio22.Text = "22 kV";
            this.radio22.UseVisualStyleBackColor = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl2.Location = new System.Drawing.Point(24, 113);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(90, 17);
            this.labelControl2.TabIndex = 51;
            this.labelControl2.Text = "Cấp điện áp :";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(161, 70);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(297, 20);
            this.txtTen.TabIndex = 50;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl1.Location = new System.Drawing.Point(24, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(114, 17);
            this.labelControl1.TabIndex = 49;
            this.labelControl1.Text = "Tên đường dây :";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl8.Location = new System.Drawing.Point(24, 28);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(41, 17);
            this.labelControl8.TabIndex = 46;
            this.labelControl8.Text = "Vị trí :";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(490, 29);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(26, 13);
            this.linkLabel1.TabIndex = 48;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Sửa";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textToado
            // 
            this.textToado.Enabled = false;
            this.textToado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textToado.Location = new System.Drawing.Point(161, 25);
            this.textToado.Name = "textToado";
            this.textToado.Size = new System.Drawing.Size(297, 21);
            this.textToado.TabIndex = 47;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(247, 147);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 24);
            this.simpleButton1.TabIndex = 54;
            this.simpleButton1.Text = "Cập nhật phần tử";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmUpdatePTDienSoDo1Soi_DZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 190);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.radio35);
            this.Controls.Add(this.radio22);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textToado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmUpdatePTDienSoDo1Soi_DZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập nhật phần tử";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radio35;
        private System.Windows.Forms.RadioButton radio22;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox txtTen;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textToado;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}