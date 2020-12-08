namespace LDSong.Views
{
    partial class frmTrangthaiTram
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
            this.labelName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTrangThaiTram = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bttrangthaiOFF = new System.Windows.Forms.Button();
            this.bttrangthaiON = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbtentram = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelDuongDay = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(36, 51);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(113, 24);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Tên thiết bị :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trạng thái :";
            // 
            // lbTrangThaiTram
            // 
            this.lbTrangThaiTram.AutoSize = true;
            this.lbTrangThaiTram.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTrangThaiTram.Location = new System.Drawing.Point(164, 220);
            this.lbTrangThaiTram.Name = "lbTrangThaiTram";
            this.lbTrangThaiTram.Size = new System.Drawing.Size(60, 24);
            this.lbTrangThaiTram.TabIndex = 3;
            this.lbTrangThaiTram.Text = "label3";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bttrangthaiOFF);
            this.panel1.Controls.Add(this.bttrangthaiON);
            this.panel1.Location = new System.Drawing.Point(97, 257);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 90);
            this.panel1.TabIndex = 4;
            // 
            // bttrangthaiOFF
            // 
            this.bttrangthaiOFF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bttrangthaiOFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttrangthaiOFF.Location = new System.Drawing.Point(270, 0);
            this.bttrangthaiOFF.Name = "bttrangthaiOFF";
            this.bttrangthaiOFF.Size = new System.Drawing.Size(239, 87);
            this.bttrangthaiOFF.TabIndex = 1;
            this.bttrangthaiOFF.Text = "Cắt (Open)";
            this.bttrangthaiOFF.UseVisualStyleBackColor = false;
            this.bttrangthaiOFF.Click += new System.EventHandler(this.bttrangthaiOFF_Click);
            // 
            // bttrangthaiON
            // 
            this.bttrangthaiON.BackColor = System.Drawing.Color.Red;
            this.bttrangthaiON.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttrangthaiON.Location = new System.Drawing.Point(-1, 0);
            this.bttrangthaiON.Name = "bttrangthaiON";
            this.bttrangthaiON.Size = new System.Drawing.Size(244, 87);
            this.bttrangthaiON.TabIndex = 0;
            this.bttrangthaiON.Text = "Đóng (Close)";
            this.bttrangthaiON.UseVisualStyleBackColor = false;
            this.bttrangthaiON.Click += new System.EventHandler(this.bttrangthaiON_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Đường dây :";
            // 
            // lbtentram
            // 
            this.lbtentram.AutoSize = true;
            this.lbtentram.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtentram.Location = new System.Drawing.Point(162, 51);
            this.lbtentram.Name = "lbtentram";
            this.lbtentram.Size = new System.Drawing.Size(60, 24);
            this.lbtentram.TabIndex = 2;
            this.lbtentram.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(165, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "Xem nguồn cấp";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nguồn cấp :";
            // 
            // labelDuongDay
            // 
            this.labelDuongDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDuongDay.Location = new System.Drawing.Point(166, 87);
            this.labelDuongDay.Multiline = true;
            this.labelDuongDay.Name = "labelDuongDay";
            this.labelDuongDay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.labelDuongDay.Size = new System.Drawing.Size(440, 127);
            this.labelDuongDay.TabIndex = 10;
            // 
            // frmTrangthaiTram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 362);
            this.Controls.Add(this.labelDuongDay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTrangThaiTram);
            this.Controls.Add(this.lbtentram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmTrangthaiTram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin trạm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTrangThaiTram;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bttrangthaiOFF;
        private System.Windows.Forms.Button bttrangthaiON;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbtentram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox labelDuongDay;
    }
}