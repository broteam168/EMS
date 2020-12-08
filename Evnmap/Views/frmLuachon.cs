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
    public partial class frmLuachon : Form
    {
        private string userName;
        private int idPTDien;
        private string dvql;
        private string loai;
        //public static bool t = false;
        private bool tt = false;
        public bool qhe = false;
        public frmLuachon()
        {
            //t = false;
            InitializeComponent();
        }
        public frmLuachon(int idPTDien,string userName,string dvql,string loai,bool _tt=false)
        {
            //t = false;
            qhe = false;
            this.idPTDien = idPTDien;
            this.userName = userName;
            this.dvql = dvql;
            this.loai = loai;
            InitializeComponent();
            if (_tt==true)
            {
                this.tt = _tt;
                btTrangThai.Enabled = false;
                btQuanHe.Enabled=false;
            }
        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btTrangThai_Click(object sender, EventArgs e)
        {
            frmTrangthaiTram trangthai = new frmTrangthaiTram(idPTDien.ToString(),userName);
            trangthai.ShowDialog();
            this.Close();
        }

        private void btThongTin_Click(object sender, EventArgs e)
        {
            frmUpdateAllPTDien update = new frmUpdateAllPTDien(idPTDien, userName, dvql,tt);
            update.ShowDialog();
            this.Close();
        }
        public void FrmThongTin()
        {
            frmUpdateAllPTDien update = new frmUpdateAllPTDien(idPTDien, userName, dvql, tt);
            update.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PTDiencontroler obj = new PTDiencontroler();
            if (obj.checkQH(idPTDien))
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phần tử này không?", "xác thực", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (frmXacThuc.Show("Bạn vui lòng nhập mã xác thực sau :", "Tiếp tục", "Hủy bỏ") == true)
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
                        
                        List<M_TTHAI_PTDIEN> tt = obj.listTT(idPTDien);
                        foreach (var item in tt)
                        {
                            HISTORY_TTHAI_PTDIEN _objTT =new HISTORY_TTHAI_PTDIEN();
                            _objTT.ID_PTDIEN = item.ID_PTDIEN;
                            _objTT.MA_DVQLY = item.MA_DVQLY;
                            _objTT.THOI_DIEM = item.THOI_DIEM;
                            _objTT.TRANG_THAI = item.TRANG_THAI;
                            _objTT.UserName = item.UserName;
                            obj.addHisStoryDeleteTT(_objTT);
                        }
                        obj.deleteTT(idPTDien);
                        obj.deleteTTVM(idPTDien);
                        List<M_TTHAI_PTDIEN_LR> ttLR = obj.listTTLR(idPTDien);
                        foreach (var item in ttLR)
                        {
                            HISTORY_TTHAI_PTDIEN_LR _objTTLR = new HISTORY_TTHAI_PTDIEN_LR();
                            _objTTLR.ID_PTDIEN = item.ID_PTDIEN;
                            _objTTLR.LEFT_TRANGTHAI = item.LEFT_TRANGTHAI;
                            _objTTLR.RIGHT_TRANGTHAI = item.RIGHT_TRANGTHAI;
                            _objTTLR.NGAY_CAP_NHAT = item.NGAY_CAP_NHAT;
                            _objTTLR.THOIGIANKETTHUC = item.THOIGIANKETTHUC;
                            _objTTLR.NGUYENNHAN = item.NGUYENNHAN;
                            _objTTLR.CHIEUDONGDIEN = item.CHIEUDONGDIEN;
                            obj.addHisStoryDeleteTTLR(_objTTLR);
                        }
                        obj.deleteTTLR(idPTDien);
                        obj.deleteTTLRVM(idPTDien);
                        obj.deleteQH(idPTDien); 
                        string query = "delete from M_VITRI where ID_PTDIEN="+idPTDien;
                        obj.deleteVT(query);
                        string query1 = "delete from M_VITRI_SD1S where ID_PTDIEN=" + idPTDien;
                        obj.deleteVT(query);
                        //t = true;
                        obj.deleteNodeTree(idPTDien);
                        obj.delete(idPTDien);
                        MessageBox.Show("Xóa phần tử điện thành công!");
                        this.Close();
                    
                    }
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Phần tư điện này không thể xóa. Vì đang được thiết lập mối quan hệ với các phần tử khác");
                this.Close();
            }
        }
        public void xoa()
        {
            PTDiencontroler obj = new PTDiencontroler();
            if (obj.checkQH(idPTDien))
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phần tử này không?", "xác thực", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (loai.Equals("0")||frmXacThuc.Show("Bạn vui lòng nhập mã xác thực sau :", "Tiếp tục", "Hủy bỏ") == true)
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

                        List<M_TTHAI_PTDIEN> tt = obj.listTT(idPTDien);
                        foreach (var item in tt)
                        {
                            HISTORY_TTHAI_PTDIEN _objTT = new HISTORY_TTHAI_PTDIEN();
                            _objTT.ID_PTDIEN = item.ID_PTDIEN;
                            _objTT.MA_DVQLY = item.MA_DVQLY;
                            _objTT.THOI_DIEM = item.THOI_DIEM;
                            _objTT.TRANG_THAI = item.TRANG_THAI;
                            _objTT.UserName = item.UserName;
                            obj.addHisStoryDeleteTT(_objTT);
                        }
                        obj.deleteTT(idPTDien);
                        obj.deleteTTVM(idPTDien);
                        List<M_TTHAI_PTDIEN_LR> ttLR = obj.listTTLR(idPTDien);
                        foreach (var item in ttLR)
                        {
                            HISTORY_TTHAI_PTDIEN_LR _objTTLR = new HISTORY_TTHAI_PTDIEN_LR();
                            _objTTLR.ID_PTDIEN = item.ID_PTDIEN;
                            _objTTLR.LEFT_TRANGTHAI = item.LEFT_TRANGTHAI;
                            _objTTLR.RIGHT_TRANGTHAI = item.RIGHT_TRANGTHAI;
                            _objTTLR.NGAY_CAP_NHAT = item.NGAY_CAP_NHAT;
                            _objTTLR.THOIGIANKETTHUC = item.THOIGIANKETTHUC;
                            _objTTLR.NGUYENNHAN = item.NGUYENNHAN;
                            _objTTLR.CHIEUDONGDIEN = item.CHIEUDONGDIEN;
                            obj.addHisStoryDeleteTTLR(_objTTLR);
                        }
                        obj.deleteTTLR(idPTDien);
                        obj.deleteTTLRVM(idPTDien);
                        obj.deleteQH(idPTDien);
                        string query = "delete from M_VITRI where ID_PTDIEN=" + idPTDien;
                        obj.deleteVT(query);
                        string query1 = "delete from M_VITRI_SD1S where ID_PTDIEN=" + idPTDien;
                        obj.deleteVT(query);
                        //t = true;
                        obj.deleteNodeTree(idPTDien);
                        obj.delete(idPTDien);
                        MessageBox.Show("Xóa phần tử điện thành công!");
                        this.Close();

                    }
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Phần tư điện này không thể xóa. Vì đang được thiết lập mối quan hệ với các phần tử khác");
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //panel
        }
        private void btQuanHe_Click(object sender, EventArgs e)
        {
            qhe = true;
            this.Close();
        }
    }
}
