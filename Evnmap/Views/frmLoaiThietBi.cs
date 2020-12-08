using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDSong.Views
{
    public partial class frmLoaiThietBi   : DevExpress.XtraEditors.XtraForm
    {
        public frmLoaiThietBi()
        {
            InitializeComponent();
            loadImage();
        }
        public void loadImage()
        {
            pTT0.Image = Image.FromFile(@"icon\TBA_PP_open.png");
            pTT0.SizeMode = PictureBoxSizeMode.CenterImage;
            pTT1.Image = Image.FromFile(@"icon\TBA_PP.png");
            pTT1.SizeMode = PictureBoxSizeMode.CenterImage;

            pMCDZ0.Image = Image.FromFile(@"icon\MCDZ_open.png");
            pMCDZ0.SizeMode = PictureBoxSizeMode.CenterImage;
            pMCDZ1.Image = Image.FromFile(@"icon\MCDZ_close.png");
            pMCDZ1.SizeMode = PictureBoxSizeMode.CenterImage;

            pSI0.Image = Image.FromFile(@"icon\SI_open.png");
            pSI0.SizeMode = PictureBoxSizeMode.CenterImage;
            pSI1.Image = Image.FromFile(@"icon\SI_close.png");
            pSI1.SizeMode = PictureBoxSizeMode.CenterImage;

            pTG0.Image = Image.FromFile(@"icon\TBA_TG.png");
            pTG0.SizeMode = PictureBoxSizeMode.CenterImage;
            pTG1.Image = Image.FromFile(@"icon\TBA_TG_ON.png");
            pTG1.SizeMode = PictureBoxSizeMode.CenterImage;

            pMC0.Image = Image.FromFile(@"icon\MC_on.png");
            pMC0.SizeMode = PictureBoxSizeMode.CenterImage;
            pMC1.Image = Image.FromFile(@"icon\MC.png");
            pMC1.SizeMode = PictureBoxSizeMode.CenterImage;

            pDS0.Image = Image.FromFile(@"icon\CD_on.png");
            pDS0.SizeMode = PictureBoxSizeMode.CenterImage;
            pDS1.Image = Image.FromFile(@"icon\CD.png");
            pDS1.SizeMode = PictureBoxSizeMode.CenterImage;
        }
        public void saveImage(string fileName)
        {
            saveFileDialog1.Filter = "Png Image (.png)|*.png|Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif |JPEG Image (.jpeg)|*.jpeg ";
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                string exportFilePath = saveFileDialog1.FileName;
                try
                {
                    string sourceFile = System.IO.Path.Combine(exportFilePath);
                    string destFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\icon\"+ fileName);
                    System.IO.File.Copy(sourceFile, destFile, true);
                    MessageBox.Show("Lưu file thành công !");
                }
                catch
                {
                    String msg = "Không thể save file. Bạn vui lòng kiểm tra lại" + Environment.NewLine + Environment.NewLine + "Đường dẫn: " + exportFilePath;
                    MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
        }
        private void BTT1_Click(object sender, EventArgs e)
        {
            pTT1.Image.Dispose();
            saveImage("TBA_PP.png");
            loadImage();
        }

        private void BTT0_Click(object sender, EventArgs e)
        {
            pTT0.Image.Dispose();
            saveImage("TBA_PP_open.png");
            loadImage();
        }

        private void BDS1_Click(object sender, EventArgs e)
        {
            pDS1.Image.Dispose();
            saveImage("CD.png");
            loadImage();
        }

        private void BDS0_Click(object sender, EventArgs e)
        {
            pDS0.Image.Dispose();
            saveImage("CD_on.png");
            loadImage();
        }

        private void BSI1_Click(object sender, EventArgs e)
        {
            pSI1.Image.Dispose();
            saveImage("SI_close.png");
            loadImage();
        }

        private void BSI0_Click(object sender, EventArgs e)
        {
            pSI0.Image.Dispose();
            saveImage("SI_open.png");
            loadImage();
        }

        private void BMC1_Click(object sender, EventArgs e)
        {
            pMC1.Image.Dispose();
            saveImage("MC.png");
            loadImage();
        }

        private void BMC0_Click(object sender, EventArgs e)
        {
            pMC0.Image.Dispose();
            saveImage("MC_on.png");
            loadImage();
        }

        private void BMCDZ1_Click(object sender, EventArgs e)
        {
            pMCDZ1.Image.Dispose();
            saveImage("MCDZ_close.png");
            loadImage();
        }

        private void BMCDZ0_Click(object sender, EventArgs e)
        {
            pMCDZ0.Image.Dispose();
            saveImage("MCDZ_open.png");
            loadImage();
        }

        private void BTG1_Click(object sender, EventArgs e)
        {
            pTG1.Image.Dispose();
            saveImage("TBA_TG_ON.png");
            loadImage();
        }

        private void BTG0_Click(object sender, EventArgs e)
        {
            pTG0.Image.Dispose();
            saveImage("TBA_TG.png");
            loadImage();
        }
    }
}
