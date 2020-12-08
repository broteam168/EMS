using LDSong.Controlers;
using LDSong.Models;
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
    public partial class frmViewImage : Form
    {
        ImageControler cls;
        private string idImage;
        private int slItem = -1;
        List<D_Image> lst;
        int idPTD;
        public frmViewImage(string phanQ,int idPTD, string name,bool bt)
        {
            InitializeComponent();
            this.idPTD = idPTD;
            this.Text = "Ảnh " + name;
            cls = new ImageControler();
            initImagelst();
            xóaToolStripMenuItem.Enabled = bt;
        }
        public void initImagelst()
        {
            lstImage.Clear();
            imageList1.Images.Clear();
            lst = cls.listFile(idPTD);
            foreach (var item in lst)
            {
                imageList1.Images.Add(BinaryToImage(item.Image));
                lstImage.Items.Add(item.ID.ToString(), imageList1.Images.Count - 1);
            }
            
            lstImage.LargeImageList = imageList1;
            lstImage.SmallImageList = imageList1;
        }
        public Image BinaryToImage(System.Data.Linq.Binary binaryData)
        {
            if (binaryData == null) return null;

            byte[] buffer = binaryData.ToArray();
            MemoryStream memStream = new MemoryStream();
            memStream.Write(buffer, 0, buffer.Length);
            return Image.FromStream(memStream);
        }

        private void lstImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstImage.FocusedItem != null)
            {
                slItem = lstImage.FocusedItem.Index ;
                idImage = lstImage.FocusedItem.Text;
                contextMenuStrip1.Show(lstImage, lstImage.PointToClient(Cursor.Position));
            }
            else
            {
                slItem = -1;
                idImage = "";
            }
        }

        private void xemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!idImage.Equals(""))
            {
                try
                {
                    string temp = Environment.CurrentDirectory + "\\temp\\" + idImage.ToString();
                    byte[] objData = lst.ElementAt(slItem).Image.ToArray(); //cls.attachment(int.Parse(idImage));
                    FileStream objFileStream = new FileStream(temp, FileMode.Create, FileAccess.Write);
                    objFileStream.Write(objData, 0, objData.Length);
                    objFileStream.Close();
                    System.Diagnostics.Process.Start(temp);
                }
                catch (Exception)
                {
                    MessageBox.Show("Có lỗi xảy ra bạn vui lòng kiểm tra lại");
                }
            }
            else
            {
                MessageBox.Show("Bạn vui lòng chọn file cần xem");
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ảnh này không?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    cls.delete(int.Parse(idImage));
                    MessageBox.Show("Xóa ảnh thành công!");
                    initImagelst();
                }
                catch (Exception)
                {
                    MessageBox.Show("Có lỗi xảy ra bạn vui lòng kiểm tra lại.");
                }
            }
        }
        private void xemẢnhBằngPhầnMềmEvnMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!idImage.Equals(""))
                {
                    frmImageViewDetail frm = new frmImageViewDetail(BinaryToImage(lst.ElementAt(slItem).Image));
                    frm.Show();
                }
                    
            }
            catch (Exception)
            {

                MessageBox.Show("Có lỗi xảy ra bạn vui lòng kiểm tra lại.");
            }
        }
    }
}
