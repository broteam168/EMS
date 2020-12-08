using LDSong.Controlers;
using LDSong.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDSong.Views
{
    public partial class frmUpdatePTDien : Form
    {
        PTDiencontroler td;
        private int idPTDien;
        private string userName;
        private D_PTDIEN objPTD;
        public frmUpdatePTDien()
        {
            InitializeComponent();
        }
        public frmUpdatePTDien(int idPTDien,string userName)
        {
            this.idPTDien = idPTDien;
            this.userName = userName;
            td = new PTDiencontroler();
            InitializeComponent();
        }

        private void initPTDien(object sender, EventArgs e)
        {
            objPTD = td.getthongtinDiem(idPTDien);
            txtTen.Text = objPTD.TEN_PTDIEN;
            txtDienAp.Text = objPTD.TEN_CAPDA;
            txtLoaiPhanTu.Text = objPTD.D_LOAI_TBI.TEN_LOAI;
            txtMaCmis.Text = objPTD.MA_CMIS;
            txtMaScada.Text = objPTD.MA_SCADA;
            txtMaPmis.Text = objPTD.MA_PMIS;
            txtMaPmischa.Text = objPTD.MA_PMISCHA;
            if (!objPTD.LOAI_PTDIEN.Equals("TT"))
            {
                txtMaCmis.Enabled = false;
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                objPTD.TEN_PTDIEN = txtTen.Text;
                objPTD.MA_CMIS = txtMaCmis.Text;
                objPTD.MA_SCADA = txtMaScada.Text;
                objPTD.NGAY_SUA = td.getDateServer();
                objPTD.NGUOI_SUA = userName;
                td.update(objPTD);
                MessageBox.Show("Cập nhật thông tin Phần tử điện thành công!");
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Không thể thực hiện cập nhật được.Có lỗi xảy ra vui lòng kiểm tra lại.");
            }
        }
    }
}
