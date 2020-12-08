namespace LDSong.Views
{
    partial class frmLuachon
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
            this.btTrangThai = new System.Windows.Forms.Button();
            this.btThongTin = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btQuanHe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btTrangThai
            // 
            this.btTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTrangThai.Location = new System.Drawing.Point(-2, -2);
            this.btTrangThai.Name = "btTrangThai";
            this.btTrangThai.Size = new System.Drawing.Size(223, 31);
            this.btTrangThai.TabIndex = 0;
            this.btTrangThai.Text = "Cập nhật trạng thái";
            this.btTrangThai.UseVisualStyleBackColor = true;
            this.btTrangThai.Click += new System.EventHandler(this.btTrangThai_Click);
            // 
            // btThongTin
            // 
            this.btThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThongTin.Location = new System.Drawing.Point(-2, 27);
            this.btThongTin.Name = "btThongTin";
            this.btThongTin.Size = new System.Drawing.Size(223, 31);
            this.btThongTin.TabIndex = 1;
            this.btThongTin.Text = "Cập nhật thông tin + vị trí";
            this.btThongTin.UseVisualStyleBackColor = true;
            this.btThongTin.Click += new System.EventHandler(this.btThongTin_Click);
            // 
            // btThoat
            // 
            this.btThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.Location = new System.Drawing.Point(-2, 114);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(223, 31);
            this.btThoat.TabIndex = 2;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(-3, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Xóa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btQuanHe
            // 
            this.btQuanHe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuanHe.Location = new System.Drawing.Point(-2, 56);
            this.btQuanHe.Name = "btQuanHe";
            this.btQuanHe.Size = new System.Drawing.Size(223, 31);
            this.btQuanHe.TabIndex = 4;
            this.btQuanHe.Text = "Thiết lập quan hệ";
            this.btQuanHe.UseVisualStyleBackColor = true;
            this.btQuanHe.Click += new System.EventHandler(this.btQuanHe_Click);
            // 
            // frmLuachon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 144);
            this.Controls.Add(this.btQuanHe);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btThongTin);
            this.Controls.Add(this.btTrangThai);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLuachon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmLuachon";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btTrangThai;
        private System.Windows.Forms.Button btThongTin;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btQuanHe;
    }
}