namespace LDSong.Views
{
    partial class frmViewImage
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
            this.lstImage = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemẢnhBằngPhầnMềmEvnMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstImage
            // 
            this.lstImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstImage.LargeImageList = this.imageList1;
            this.lstImage.Location = new System.Drawing.Point(0, 0);
            this.lstImage.Name = "lstImage";
            this.lstImage.Size = new System.Drawing.Size(693, 404);
            this.lstImage.SmallImageList = this.imageList1;
            this.lstImage.TabIndex = 0;
            this.lstImage.UseCompatibleStateImageBehavior = false;
            this.lstImage.SelectedIndexChanged += new System.EventHandler(this.lstImage_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(68, 68);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemToolStripMenuItem,
            this.xemẢnhBằngPhầnMềmEvnMapToolStripMenuItem,
            this.xóaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(259, 70);
            // 
            // xemToolStripMenuItem
            // 
            this.xemToolStripMenuItem.Name = "xemToolStripMenuItem";
            this.xemToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.xemToolStripMenuItem.Text = "Xem ảnh bằng ứng dụng Window";
            this.xemToolStripMenuItem.Click += new System.EventHandler(this.xemToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Enabled = false;
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // xemẢnhBằngPhầnMềmEvnMapToolStripMenuItem
            // 
            this.xemẢnhBằngPhầnMềmEvnMapToolStripMenuItem.Name = "xemẢnhBằngPhầnMềmEvnMapToolStripMenuItem";
            this.xemẢnhBằngPhầnMềmEvnMapToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.xemẢnhBằngPhầnMềmEvnMapToolStripMenuItem.Text = "Xem ảnh bằng phần mềm EvnMap";
            this.xemẢnhBằngPhầnMềmEvnMapToolStripMenuItem.Click += new System.EventHandler(this.xemẢnhBằngPhầnMềmEvnMapToolStripMenuItem_Click);
            // 
            // frmViewImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 404);
            this.Controls.Add(this.lstImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmViewImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xem ảnh";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstImage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemẢnhBằngPhầnMềmEvnMapToolStripMenuItem;
    }
}