namespace LDSong.Views
{
    partial class frmUpdatePTDienSoDo1Soi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtIDPTDien = new System.Windows.Forms.TextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textToado = new System.Windows.Forms.TextBox();
            this.radioDoc = new System.Windows.Forms.RadioButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.radioNgang = new System.Windows.Forms.RadioButton();
            this.btCreate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTen);
            this.panel1.Controls.Add(this.txtIDPTDien);
            this.panel1.Controls.Add(this.labelControl8);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.textToado);
            this.panel1.Controls.Add(this.radioDoc);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.radioNgang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 126);
            this.panel1.TabIndex = 39;
            // 
            // txtTen
            // 
            this.txtTen.Enabled = false;
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(229, 94);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(252, 21);
            this.txtTen.TabIndex = 38;
            // 
            // txtIDPTDien
            // 
            this.txtIDPTDien.Enabled = false;
            this.txtIDPTDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDPTDien.Location = new System.Drawing.Point(145, 94);
            this.txtIDPTDien.Name = "txtIDPTDien";
            this.txtIDPTDien.Size = new System.Drawing.Size(85, 21);
            this.txtIDPTDien.TabIndex = 37;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl8.Location = new System.Drawing.Point(24, 10);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(41, 17);
            this.labelControl8.TabIndex = 30;
            this.labelControl8.Text = "Vị trí :";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(491, 13);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(26, 13);
            this.linkLabel1.TabIndex = 36;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Sửa";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textToado
            // 
            this.textToado.Enabled = false;
            this.textToado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textToado.Location = new System.Drawing.Point(143, 9);
            this.textToado.Name = "textToado";
            this.textToado.Size = new System.Drawing.Size(338, 21);
            this.textToado.TabIndex = 31;
            // 
            // radioDoc
            // 
            this.radioDoc.AutoSize = true;
            this.radioDoc.Location = new System.Drawing.Point(233, 51);
            this.radioDoc.Name = "radioDoc";
            this.radioDoc.Size = new System.Drawing.Size(45, 17);
            this.radioDoc.TabIndex = 35;
            this.radioDoc.TabStop = true;
            this.radioDoc.Text = "Dọc";
            this.radioDoc.UseVisualStyleBackColor = true;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl1.Location = new System.Drawing.Point(26, 98);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 17);
            this.labelControl1.TabIndex = 32;
            this.labelControl1.Text = "Phần tử điện :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl2.Location = new System.Drawing.Point(26, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 17);
            this.labelControl2.TabIndex = 34;
            this.labelControl2.Text = "Kiểu :";
            // 
            // radioNgang
            // 
            this.radioNgang.AutoSize = true;
            this.radioNgang.Location = new System.Drawing.Point(145, 51);
            this.radioNgang.Name = "radioNgang";
            this.radioNgang.Size = new System.Drawing.Size(57, 17);
            this.radioNgang.TabIndex = 33;
            this.radioNgang.TabStop = true;
            this.radioNgang.Text = "Ngang";
            this.radioNgang.UseVisualStyleBackColor = true;
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(233, 132);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(106, 23);
            this.btCreate.TabIndex = 41;
            this.btCreate.Text = "Cập nhật";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // frmUpdatePTDienSoDo1Soi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 164);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmUpdatePTDienSoDo1Soi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập nhật phần tử điện";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtIDPTDien;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textToado;
        private System.Windows.Forms.RadioButton radioDoc;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.RadioButton radioNgang;
        private System.Windows.Forms.Button btCreate;
    }
}