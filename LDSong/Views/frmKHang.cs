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

using LDSong.Libs;
using LDSong.Controlers;
using LDSong.Models;

namespace LDSong.Views
{
    public partial class frmKHang : DevExpress.XtraEditors.XtraForm
    {
        private KHangControler clsObj;
        private int idYeuCau;
        private string dvql, DVQuanLy, userName;
        public frmKHang()
        {
            InitializeComponent();
        }
        public frmKHang(string phanquyen,string userName)
        {
            dvql = phanquyen;
            this.userName = userName;
            InitializeComponent();
            initLabel();
        }
        private void frmKHang_Load(object sender, EventArgs e)
        {
            clsObj = new KHangControler();
            //cboDonVi.DataSource = LDSongGlobal.listDVQLy(dvql);
            initComboboxDonvi();
            AcceptButton = cmdTim;
            //cboDonVi.EditValue = Program._MaDVQLy;
            //if (Program._MaDVQLy.Length == 6) cboDonVi.Enabled = false;
            cboLoaiYCau.Properties.DataSource = clsObj.listYeucau();
            
        }
        public void initComboboxDonvi()
        {
            DVQuanLy = dvql;
            cboDonVi.Properties.DataSource = LDSongGlobal.listDVQLy(dvql);
            
        }
        private void initLabel() {
            labelLo.Text = "";
            labelTenTram.Text = "";
            labelMatram.Text = "";
            labelTrangThai.Text = "";
            labelNguyenNhan.Visible = false;
            lbNguyenNhan.Visible = false;
        }
        private void cmdTim_Click(object sender, EventArgs e)
        {
            
            try
            {
                string filter = "", txtTKH = "", txtMKH="", txtDC="", txtDT="", txtCT="", txtDV="";
                if (txtTenKHang.Text.Trim() != "")
                {
                    txtTKH = "x.TEN_KHANG.Contains(\"" + txtTenKHang.Text.Trim() + "\")";
                }
                if (txtMaKhang.Text.Trim() != "")
                {
                    txtMKH = "&& x.MA_KHANG.Contains(\"" + txtMaKhang.Text.Trim() + "\")";
                }
                if (txtDChi.Text.Trim() != "")
                {
                    txtDC = "&& x.DIA_CHI.Contains(\"" + txtDChi.Text.Trim() + "\")";
                }
                if (txtDThoai.Text.Trim() != "")
                {
                    txtDT = "&& x.DIEN_THOAI.Contains(\"" + txtDThoai.Text.Trim() + "\")";
                }
                if (txtSoCTo.Text.Trim() != "")
                {
                    txtCT = "&& x.SO_CTO.Contains(\"" + txtSoCTo.Text.Trim() + "\")";
                }
                if (cboDonVi.Text.Trim() != "")
                {
                    txtDV = "&& x.MA_DVIQLY.Equals(\"" + cboDonVi.EditValue.ToString() + "\")";
                }
                filter = txtTKH + txtMKH + txtDC + txtDT + txtCT + txtDV;
                this.Cursor = Cursors.WaitCursor;
                if (filter.Trim() != "")
                {
                    int check = filter.Trim().IndexOf('&');
                    if (check == 0)
                    {
                        string sp = filter.Substring(2, filter.Trim().Length - 2);
                        filter = sp;
                    }
                    dgrCtlKHang.DataSource= clsObj.timKhachHang(filter);
                    if (dgrKHang.RowCount == 0)
                    {
                        MessageBox.Show("Không tìm được kết quả nào với dữ liệu nhập vào.");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn vui lòng nhập thông tin tìm kiếm.");
                }
                this.Cursor = Cursors.Default;
            }
            catch { }
        }

        private void dgrKHang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
            try
            {
                
                lbMaKHang.Text = dgrKHang.GetFocusedRowCellValue("MA_KHANG").ToString();
                lbTenKHang.Text = dgrKHang.GetFocusedRowCellValue("TEN_KHANG").ToString();
                lbDCKHang.Text = dgrKHang.GetFocusedRowCellValue("DIA_CHI").ToString();
                lbDTKHang.Text = dgrKHang.GetFocusedRowCellValue("DIEN_THOAI").ToString();
                dgrCtlDiemDo.DataSource = null;
                dgrCtlDiemDo.DataSource = clsObj.timDiemDo( dgrKHang.GetFocusedRowCellValue("MA_KHANG").ToString());
                
            }
            catch
            {
            }
            try
            {
                //dgrCtlLSYcau.DataSource = null;
                
            }
            catch (Exception)
            {

            }
            dgrCtlLSYcau.DataSource = clsObj.lichSuYeuCau(dgrKHang.GetFocusedRowCellValue("MA_KHANG").ToString());
        }
        private void btGhiYeuCau_Click(object sender, EventArgs e)
        {
            try
            {
                K_YEU_CAU _obj = new K_YEU_CAU();
                _obj.MA_LOAI = cboLoaiYCau.EditValue.ToString();
                _obj.MA_DVIQLY = dgrKHang.GetFocusedRowCellValue("MA_DVIQLY").ToString();
                _obj.MA_KHANG = dgrKHang.GetFocusedRowCellValue("MA_KHANG").ToString();
                if (txtYCau.Text!="")
                {
                    _obj.NOI_DUNG = txtYCau.Text;
                }
                else
                {
                    MessageBox.Show("Nội dung yêu cầu không được bỏ trống", "Thông báo!");
                }
                _obj.NGAY_TAO = clsObj.getDateServer();
                _obj.TT_LienHe = txtLHe.Text;
                _obj.TINH_TRANG = "Chưa xử lý";
                clsObj.addKHYEUCAU(_obj);
                try
                {
                    dgrCtlLSYcau.DataSource = null;
                    
                }
                catch (Exception)
                {
                    
                }
                dgrCtlLSYcau.DataSource = clsObj.lichSuYeuCau(dgrKHang.GetFocusedRowCellValue("MA_KHANG").ToString());
                MessageBox.Show("Tạo yêu cầu khách hàng thành công!","Thông báo!");
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn vui lòng kiểm tra lại dữ liệu nhập", "Thông báo!");
            }
        }

        private void FocusedRow_DoKiem(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                initLabel(); 
                clsObj.getALLDuongDAY(clsObj.getMaPmisCha(dgrDiemDo.GetFocusedRowCellValue("MA_TRAM").ToString()).MA_PMISCHA);
                List<string> name = clsObj.listTenPTDien;
                labelLo.Text=name[name.Count-1];
                labelMatram.Text = dgrDiemDo.GetFocusedRowCellValue("MA_TRAM").ToString();
                M_VITRI_V1 infor1 = clsObj.trangThai(dgrDiemDo.GetFocusedRowCellValue("MA_TRAM").ToString());
                M_VITRI_V2 infor2 = clsObj.trangThai2(dgrDiemDo.GetFocusedRowCellValue("MA_TRAM").ToString());
                labelTenTram.Text = infor1.TEN_PTDIEN;
                if (infor2.TRANG_THAI == 0)
                {
                
                    labelTrangThai.Text = "Mất điện";
                    labelTrangThai.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    labelTrangThai.ForeColor = Color.Red;
                    labelNguyenNhan.Visible = true;
                    lbNguyenNhan.Visible = true;
                    lbNguyenNhan.Text = infor1.NGUYENNHAN;
                }
                else
                {
                    if (infor1.LEFT_TRANGTHAI==false && infor1.RIGHT_TRANGTHAI==false)
                    {
                        labelTrangThai.Text = "Mất điện";
                        labelTrangThai.Font = new Font("Tahoma",9, FontStyle.Bold);
                        labelTrangThai.ForeColor = Color.Red;
                        labelNguyenNhan.Visible = true;
                        lbNguyenNhan.Visible = true;
                        lbNguyenNhan.Text = infor1.NGUYENNHAN;
                    }
                    else
                    {
                        labelTrangThai.Text = "Có điện";
                        labelNguyenNhan.Visible = false;
                        lbNguyenNhan.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void getMadvql(object sender, EventArgs e)
        {
            if (cboDonVi.SelectedText == "CÔNG TY TNHH MTV ĐIỆN LỰC NINH BÌNH")
            {

                DVQuanLy = "PN";

            }
            if (cboDonVi.SelectedText == "Điện Lực Gia Viễn")
            {
                DVQuanLy = "PNGV00";

            }
            if (cboDonVi.SelectedText == "Điện Lực Hoa Lư")
            {
                DVQuanLy = "PNHL00";

            }
            if (cboDonVi.SelectedText == "Điện Lực Kim Sơn")
            {
                DVQuanLy = "PNKS00";
            }
            if (cboDonVi.SelectedText == "Điện lực TP Ninh Bình")
            {
                DVQuanLy = "PNNB00";

            }
            if (cboDonVi.SelectedText == "Điện lực Nho Quan")
            {
                DVQuanLy = "PNNQ00";

            }
            if (cboDonVi.SelectedText == "Điện Lực Tam Điệp")
            {
                DVQuanLy = "PNTD00";

            }
            if (cboDonVi.SelectedText == "Xưởng 110kV")
            {
                DVQuanLy = "PNX110  ";

            }
            if (cboDonVi.SelectedText == "Điện Lực Yên Khánh")
            {
                DVQuanLy = "PNYK00";

            }
            if (cboDonVi.SelectedText == "Điện Lực Yên Mô")
            {
                DVQuanLy = "PNYM00";

            }
        }

        private void dgrLSYCau_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            frmCSKH cskh = new frmCSKH(idYeuCau,userName);
            cskh.ShowDialog();
            if (frmCSKH.st)
            {
                try
                {
                    dgrCtlLSYcau.DataSource = clsObj.lichSuYeuCau(lbMaKHang.Text);
                }
                catch (Exception)
                {
                    
                }
            }
        }

        private void dgrLSYCau_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                idYeuCau = int.Parse(dgrLSYCau.GetFocusedRowCellValue("ID_YCAU").ToString());
            }
            catch (Exception)
            {
                
            }
        }
    }
}