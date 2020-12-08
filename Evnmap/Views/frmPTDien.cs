using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LDSong.Controlers;
using LDSong.Libs;
using LDSong.Models;


namespace LDSong.Views
{
    public partial class frmPTDien : DevExpress.XtraEditors.XtraForm
    {
        private static int _MenuId = 4;
        private D_PTDIEN obj;
        private int idPTD;
        private string _Action;
        private string dvql, userName;
        private PTDiencontroler objPTDien;
        private bool t, s, x;
        //private D_PTDIENs obj;
        public frmPTDien()
        {
            InitializeComponent();
        }
        public frmPTDien(string dvql,string userName)
        {
            this.dvql = dvql;
            this.userName = userName;
            InitializeComponent(); 
        }
        private void initPTDien(object sender, EventArgs e)
        {
            objPTDien = new PTDiencontroler();
            PTDien.DataSource = objPTDien.list(dvql);
            if (gridPTDien.DataRowCount != 0)
            {
                gridPTDien.FocusedRowHandle= 1;
            }
            LDSFunction Fn = new LDSFunction();
            List<string> menus = Fn.getMenuByUser("cmd",_MenuId);
            
            foreach (string item in menus)
            {
                SimpleButton ctl = this.Controls.Find(item, true).FirstOrDefault() as SimpleButton;
                ctl.Enabled = true;
            }
            t = cmdThem.Enabled;
            s = cmdSua.Enabled;
            x = cmdXoa.Enabled;
            cbdonviquanly.Properties.DataSource = objPTDien.listDVQLY(dvql);
            cbdonviquanly.Properties.NullText = "Vui lòng chọn đơn vị";
            changeControlState(true);
            initComboLoaiPTDien();
        }
        private void initComboLoaiPTDien() {
            cboLoaiPTDien.Properties.DataSource = objPTDien.listTB();
        }
        private void chooseRowPTDien(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                idPTD = int.Parse(gridPTDien.GetFocusedRowCellValue("ID_PTDIEN").ToString());
            }
            catch (Exception)
            {
                
            }
            try
            {
                cbdonviquanly.EditValue = gridPTDien.GetFocusedRowCellValue("MA_DVQLY").ToString();
            }
            catch (Exception)
            {
                
            }
            try
            {
                cboLoaiPTDien.EditValue = gridPTDien.GetFocusedRowCellValue("LOAI_PTDIEN").ToString();
                
                txtMaPMISCHA.Text = gridPTDien.GetFocusedRowCellValue("MA_PMISCHA").ToString();
                
            }
            catch { }
            try
            {
                txtTenPTDien.Text = gridPTDien.GetFocusedRowCellValue("TEN_PTDIEN").ToString();
            }
            catch (Exception)
            {

            }
            try
            {
                txtTenCapda.Text = gridPTDien.GetFocusedRowCellValue("TEN_CAPDA").ToString();
            }
            catch (Exception)
            {
                
                
            }
            try
            {
                txtMaCMIS.Text = gridPTDien.GetFocusedRowCellValue("MA_CMIS").ToString();
            }
            catch (Exception)
            {
                txtMaCMIS.Text = "";
                
            }
            try
            {
                txtMaSCADA.Text = gridPTDien.GetFocusedRowCellValue("MA_SCADA").ToString();
            }
            catch (Exception)
            {
                txtMaSCADA.Text = "";
            }
            try
            {
                txtMaCapda.Text = gridPTDien.GetFocusedRowCellValue("MA_CAPDA").ToString();
            }
            catch (Exception)
            {
                
            }
            try
            {
                txtMaPMIS.Text=gridPTDien.GetFocusedRowCellValue("MA_PMIS").ToString();
            }
            catch (Exception)
            {
                
            }
        }
        private void changeControlState(Boolean _State)
        {
            if (_State)
            {
                if (t)
                {
                    cmdThem.Enabled = _State;
                }
                if (s)
                {
                    cmdSua.Enabled = _State;
                }
                if (x)
                {
                    cmdXoa.Enabled = _State;
                }
            }
            else
            {
                cmdThem.Enabled = _State;
                cmdSua.Enabled = _State;
                cmdXoa.Enabled = _State;
            }
            

            cmdGhi.Enabled = !_State;
            cmdHuy.Enabled = !_State;
            cboLoaiPTDien.Enabled = !_State;
            txtMaCapda.Enabled = !_State;
            txtMaCMIS.Enabled = !_State;
            txtMaPMISCHA.Enabled = !_State;
            txtMaSCADA.Enabled = !_State;
            txtTenCapda.Enabled = !_State;
            txtTenPTDien.Enabled = !_State;
            cbdonviquanly.Enabled = !_State;
            //trPhanQuyen.Enabled = !_State;
            //trPhanQuyen.OptionsView.ShowCheckBoxes = !_State;

            
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            int idPTDien = int.Parse(gridPTDien.GetFocusedRowCellValue("ID_PTDIEN").ToString());
            PTDiencontroler obj = new PTDiencontroler();
            if (obj.checkQH(idPTDien))
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phần tử này không?", "xác thực", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    D_PTDIEN dp = objPTDien.getthongtinDiem(idPTDien);
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
                    _objHDelete.NGAY_XOA = objPTDien.getDateServer();
                    objPTDien.addHisStoryDelete(_objHDelete);
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
                    MessageBox.Show("Xóa thành công");
                    PTDien.DataSource = objPTDien.list(dvql);
                    if (gridPTDien.DataRowCount != 0)
                    {
                        gridPTDien.FocusedRowHandle = 1;
                    }
                    changeControlState(true);
                }
            }
            else
            {
                MessageBox.Show("Phần tư điện này không thể xóa. Vì đang được thiết lập mối quan hệ với các phần tử khác");
            }
                
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            _Action = "Edit";
            changeControlState(false);
            //obj.NGUOI_SUA=
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            try
            {
                obj = new D_PTDIEN();
                obj.TEN_PTDIEN = txtTenPTDien.Text; 
                obj.MA_DVQLY = cbdonviquanly.EditValue.ToString();
                obj.MA_CAPDA = txtMaCapda.Text;
                obj.TEN_CAPDA = txtTenCapda.Text;
                obj.MA_CMIS = txtMaCMIS.Text;
                obj.LOAI_PTDIEN = cboLoaiPTDien.EditValue.ToString(); 
                obj.MA_PMIS = txtMaPMIS.Text;
                obj.MA_PMISCHA = txtMaPMISCHA.Text;
                if (_Action=="Edit")
                {
                    obj.ID_PTDIEN = idPTD;
                    obj.NGUOI_SUA = userName;
                    obj.NGAY_SUA = objPTDien.getDateServer();
                    objPTDien.update(obj);
                    MessageBox.Show("Cập nhật thành công");
                    PTDien.DataSource = objPTDien.list(dvql);
                    if (gridPTDien.DataRowCount != 0)
                    {
                        gridPTDien.FocusedRowHandle = 1;
                    }
                }
                if (_Action=="Add")
                {
                    obj.NGAY_TAO = objPTDien.getDateServer();
                    obj.NGUOI_TAO = userName;
                    objPTDien.add(obj);
                    MessageBox.Show("Thêm mới thành công");
                    PTDien.DataSource = objPTDien.list(dvql);
                    if (gridPTDien.DataRowCount != 0)
                    {
                        gridPTDien.FocusedRowHandle = 1;
                    }
                }
                changeControlState(true);
                cbdonviquanly.Properties.DataSource = objPTDien.listDVQLY(dvql);
            }
            catch (Exception)
            {
                
                MessageBox.Show("Bạn vui lòng kiểm tra lại giá trị nhập vào. Thực hiện không thành công!");
            }
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            _Action = "Add";
            changeControlState(false);
        }

        private void cmdHuy_Click(object sender, EventArgs e)
        {
            changeControlState(true);
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                PTDien.DataSource = null;
                PTDien.DataSource = objPTDien.search(textSearch.Text,dvql);
                if (gridPTDien.DataRowCount != 0)
                {
                    gridPTDien.FocusedRowHandle = 1;
                }
                else
                {
                    MessageBox.Show("Không tìm được kết quả nào theo điều kiện bạn nhập");
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void initDSphantu(object sender, EventArgs e)
        {
            if (textSearch.Text=="")
            {
                PTDien.DataSource = objPTDien.list(dvql);
                if (gridPTDien.DataRowCount != 0)
                {
                    gridPTDien.FocusedRowHandle = 1;
                }
            }
        }
       
       
    }
}