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
    public partial class frmLuachon_SD1S : Form
    {
        private string dvql, userName,loai;
        private int idPTDien;
        private bool tt,dz;
        public static bool del = false;
        public frmLuachon_SD1S()
        {
            InitializeComponent();
        }
        public frmLuachon_SD1S(int idPTDien, string userName, string dvql, bool dz,bool _tt = false,string loai="")
        {
            del = false;
            InitializeComponent();
            this.idPTDien = idPTDien;
            this.dvql = dvql;
            this.userName = userName;
            this.dz = dz;
            this.loai = loai;
            if (_tt == true||loai.Equals("NT"))
            {
                this.tt = _tt;
                btTrangThai.Enabled = false;
            }
            
        }

        private void BtTrangThai_Click(object sender, EventArgs e)
        {

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btThongTin_Click(object sender, EventArgs e)
        {
            if (dz)
            {
                frmUpdatePTDienSoDo1Soi_DZ updateDZ = new frmUpdatePTDienSoDo1Soi_DZ(idPTDien, dvql, userName);
                updateDZ.ShowDialog();
            }
            else
            {
                frmUpdatePTDienSoDo1Soi updatePTD = new frmUpdatePTDienSoDo1Soi(idPTDien, dvql,loai);
                updatePTD.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phần tử này không?", "xác thực", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (frmXacThuc.Show("Bạn vui lòng nhập mã xác thực sau :", "Tiếp tục", "Hủy bỏ") == true)
                {
                    CreatePTDSoDo1SoiControler obj = new CreatePTDSoDo1SoiControler();
                    if (!loai.Equals("NT")) {
                        if (!dz)
                        {
                            string query = "delete from M_VITRI_SD1S where ID_PTDIEN=" + idPTDien;
                            obj.deleteVT(query);
                            MessageBox.Show("Xóa phần tử điện thành công!");
                            del = true;
                            this.Close();
                        }
                        else
                        {
                            if (obj.checkQH(idPTDien))
                            {
                                D_PTDIEN dp = obj.getthongtinDiem(idPTDien);
                                HISTORY_DELETE_DPTIDEN _objHDelete = new HISTORY_DELETE_DPTIDEN();
                                _objHDelete.ID_PTDIEN = dp.ID_PTDIEN;
                                _objHDelete.TEN_PTDIEN = dp.TEN_PTDIEN;
                                _objHDelete.LOAI_PTDIEN = dp.LOAI_PTDIEN;
                                _objHDelete.MA_CAPDA = dp.MA_CAPDA;
                                _objHDelete.MA_CMIS = dp.MA_CMIS;
                                _objHDelete.MA_DVQLY = dp.MA_DVQLY;
                                _objHDelete.MA_PMIS = dp.MA_PMIS;
                                _objHDelete.MA_PMISCHA = dp.MA_PMISCHA;
                                _objHDelete.MA_SCADA = dp.MA_SCADA;
                                _objHDelete.NGAY_SUA = dp.NGAY_SUA;
                                _objHDelete.NGAY_TAO = dp.NGAY_TAO;
                                _objHDelete.NGUOI_SUA = dp.NGUOI_SUA;
                                _objHDelete.NGUOI_TAO = dp.NGUOI_TAO;
                                _objHDelete.NGUOI_XOA = userName;
                                _objHDelete.NGAY_XOA = obj.getDateServer();
                                obj.addHisStoryDelete(_objHDelete);
                                obj.delete(idPTDien.ToString());
                                obj.deleteTT(idPTDien);
                                obj.deleteTTLR(idPTDien);
                                string query = "delete from M_VITRI where ID_PTDIEN=" + idPTDien;
                                obj.deleteVT(query);
                                obj.deleteQH(idPTDien);
                                MessageBox.Show("Xóa phần tử điện thành công!");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Phần tư điện này không thể xóa. Vì đang được thiết lập mối quan hệ với các phần tử khác");
                            }
                        }
                    }// het if ko phai note
                    else // xoa note
                    {
                        string query = "delete from M_NOTE where ID=" + idPTDien;
                        obj.deleteVT(query);
                        MessageBox.Show("Xóa thành công!");
                        del = true;
                        this.Close();
                    }
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
