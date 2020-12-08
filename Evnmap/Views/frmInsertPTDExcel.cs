using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToExcel;
using LDSong.Models;
using LDSong.Controlers;

namespace LDSong.Views
{
    public partial class frmInsertPTDExcel :  Form
    {
        private string fileName, username,madv;
        public frmInsertPTDExcel(string fileName, string username,string madv)
        {
            InitializeComponent();
            label1.Visible = false;
            label1.Visible = false;
            txtLoi.Text = "\r\n\r\n";
            txtThongTin.Text = "\r\n\r\n";
            this.fileName = fileName;
            this.username = username;
            this.madv = madv;
        }
        public void insertPTDien(string fileName, string username)
        {
            this.Cursor = Cursors.WaitCursor;
            int i = 1;
            var excel = new ExcelQueryFactory(fileName);
            var insert = from pt in excel.Worksheet<InsertPTDien>("Sheet1") select pt;
            CreatePTDienControler obj = new CreatePTDienControler();
            label1.Visible = true;
            label2.Visible = true;
            foreach (var item in insert)
            {
                i++;
                int idPTDien = 0, Err = 0;
                try
                {
                    if (madv.Equals("PN") || madv.Equals(item.MA_DVQLY.Trim()))
                    {
                        if (obj.checkMaPmiss(item.MA_PMIS.Trim()))
                        {
                            if (obj.checkMaCapda(item.MA_CAPDA.Trim()))
                            {
                                if (obj.checkTenCapda(item.TEN_CAPDA.Trim()))
                                {
                                    if (obj.checkLoaiPTDien(item.LOAI_PTDIEN.Trim()))
                                    {
                                        if (obj.checkDVQL(item.MA_DVQLY.Trim()))
                                        {
                                            D_PTDIEN _obj = new D_PTDIEN();
                                            _obj.TEN_PTDIEN = item.TEN_PTDIEN;
                                            _obj.MA_DVQLY = item.MA_DVQLY;
                                            _obj.MA_CAPDA = item.MA_CAPDA;
                                            _obj.TEN_CAPDA = item.TEN_CAPDA;
                                            //_obj.MA_CMIS = 
                                            _obj.LOAI_PTDIEN = item.LOAI_PTDIEN;
                                            _obj.MA_PMIS = item.MA_PMIS;
                                            _obj.MA_PMISCHA = item.MA_PMISCHA;
                                            _obj.NGAY_TAO = obj.getDateServer();
                                            //_obj.MA_SCADA = ;
                                            _obj.NGUOI_TAO = username;
                                            obj.addPTDien(_obj);
                                            idPTDien = obj.getIDPTDien(item.TEN_PTDIEN);
                                            string query = "INSERT INTO M_VITRI VALUES ('" + item.MA_DVQLY + "'," + idPTDien + ",'','" + item.MA_PMIS + "',geometry::STGeomFromText('" + item.TOA_DO + "', 0));";
                                            Err = 1;
                                            obj.insertORupdateVitri(query);
                                            M_TTHAI_PTDIEN _objTT = new M_TTHAI_PTDIEN();
                                            _objTT.ID_PTDIEN = idPTDien;
                                            _objTT.MA_DVQLY = item.MA_DVQLY;
                                            _objTT.TRANG_THAI = 1;
                                            _objTT.THOI_DIEM = obj.getDateServer();
                                            _objTT.UserName = username;
                                            obj.addTrangThai(_objTT);
                                            M_TTHAI_PTDIEN_VM _objTTVM = new M_TTHAI_PTDIEN_VM();
                                            _objTTVM.ID_PTDIEN = idPTDien;
                                            _objTTVM.MA_DVQLY = item.MA_DVQLY;
                                            _objTTVM.TRANG_THAI = 1;
                                            _objTTVM.THOI_DIEM = obj.getDateServer();
                                            _objTTVM.UserName = username;
                                            obj.addTrangThai_VM(_objTTVM);
                                            M_TTHAI_PTDIEN_LR _objLR = new M_TTHAI_PTDIEN_LR();
                                            _objLR.ID_PTDIEN = idPTDien;
                                            _objLR.LEFT_TRANGTHAI = true;
                                            _objLR.RIGHT_TRANGTHAI = true;
                                            _objLR.CHIEUDONGDIEN = 'L';
                                            _objLR.NGAY_CAP_NHAT = obj.getDateServer();
                                            obj.addTrangThai(_objLR);
                                            M_TTHAI_PTDIEN_LR_VM _objLRVM = new M_TTHAI_PTDIEN_LR_VM();
                                            _objLRVM.ID_PTDIEN = idPTDien;
                                            _objLRVM.LEFT_TRANGTHAI = true;
                                            _objLRVM.RIGHT_TRANGTHAI = true;
                                            _objLRVM.CHIEUDONGDIEN = true;
                                            _objLRVM.NGAY_CAP_NHAT = obj.getDateServer();
                                            obj.addTrangThai_VM(_objLRVM);
                                            txtThongTin.Text = txtThongTin.Text + "- Nhập phần tử điện " + item.TEN_CAPDA + "(" + idPTDien + ") xong.\r\n";
                                            txtThongTin.Focus();
                                            txtThongTin.SelectionStart = txtThongTin.Text.Length;
                                            txtThongTin.ScrollToCaret();
                                        }
                                        else
                                        {
                                            txtLoi.Text = txtLoi.Text + "-Dòng thứ " + i + " trong file excel không thể thêm. Mã đơn vị quản lý : " + item.MA_DVQLY + " không tồn tại\r\n";
                                            txtLoi.Select(); // to Set Focus
                                            txtLoi.Select(txtLoi.Text.Length, 0);
                                            txtLoi.ScrollToCaret();
                                        }
                                    }
                                    else
                                    {
                                        txtLoi.Text = txtLoi.Text + "-Dòng thứ " + i + " trong file excel không thể thêm. Loại phần tử điện : " + item.LOAI_PTDIEN + " không tồn tại\r\n";
                                        txtLoi.Select(); // to Set Focus
                                        txtLoi.Select(txtLoi.Text.Length, 0);
                                        txtLoi.ScrollToCaret();
                                    }
                                }
                                else
                                {
                                    txtLoi.Text = txtLoi.Text + "-Dòng thứ " + i + " trong file excel không thể thêm. Tên cấp điện áp : " + item.TEN_CAPDA + " không tồn tại\r\n";
                                    txtLoi.Select(); // to Set Focus
                                    txtLoi.Select(txtLoi.Text.Length, 0);
                                    txtLoi.ScrollToCaret();
                                }
                            }
                            else
                            {
                                txtLoi.Text = txtLoi.Text + "-Dòng thứ " + i + " trong file excel không thể thêm. Mã cấp điện áp : " + item.MA_CAPDA + " không tồn tại\r\n";
                                txtLoi.Select(); // to Set Focus
                                txtLoi.Select(txtLoi.Text.Length, 0);
                                txtLoi.ScrollToCaret();
                            }
                        }
                        else
                        {
                            txtLoi.Text = txtLoi.Text + "-Dòng thứ " + i + " trong file excel không thể thêm. Mã Pmis : " + item.MA_PMIS + " đã tồn tại\r\n";
                            txtLoi.Select(); // to Set Focus
                            txtLoi.Select(txtLoi.Text.Length, 0);
                            txtLoi.ScrollToCaret();
                        }
                    }
                    else
                    {
                        txtLoi.Text = txtLoi.Text + "-Dòng thứ " + i + " trong file excel không thể thêm. Mã DVQL : " + item.MA_DVQLY + " không thuộc phạm vi của bạn.\r\n";
                        txtLoi.Select(); // to Set Focus
                        txtLoi.Select(txtLoi.Text.Length, 0);
                        txtLoi.ScrollToCaret();
                    }
                }
                catch (Exception)
                {
                    if (Err == 1)
                    {
                        obj.deleteTT(idPTDien);
                        obj.deleteTTVM(idPTDien);
                        obj.deleteTTLR(idPTDien);
                        obj.deleteTTLRVM(idPTDien);
                        string query = "delete from M_VITRI where ID_PTDIEN=" + idPTDien;
                        obj.deleteVT(query);
                        obj.delete(idPTDien);
                    }
                    txtLoi.Text = txtLoi.Text  +"-Lỗi tại dòng thứ " + i + " trong file excel.\r\n";
                    txtLoi.Focus();
                    txtLoi.SelectionStart = txtLoi.Text.Length;
                    txtLoi.ScrollToCaret();
                }
            }
            txtThongTin.Text = txtThongTin.Text + "-Quá trình nhập dữ liệu kết thúc...!";
            txtThongTin.Focus();
            txtThongTin.SelectionStart = txtThongTin.Text.Length;
            txtThongTin.ScrollToCaret();
            label1.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            insertPTDien(fileName, username);
            timer1.Enabled = false;
        }
    }
}
