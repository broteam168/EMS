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
    public partial class frmCreateNotice : Form
    {
        private CreatePTDienControler obj;
        private string userName, DVQuanLy;
        private List<string> lstDVQL;
        public frmCreateNotice()
        {
            InitializeComponent();
        }
        public frmCreateNotice(string toado, string userName, string dvql)
        {
            InitializeComponent();
            textToado.Text = toado;
            this.userName = userName;
            this.DVQuanLy = dvql;
            obj = new CreatePTDienControler();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textToado.Enabled = true;
        }

        private void frmCreateNotice_Load(object sender, EventArgs e)
        {
            cbDonviquanly.Properties.NullText = "Vui lòng chọn đơn vị quản lý";
            cboMauNen.SelectedIndex=1;
            lstDVQL = new List<string>();
            foreach (var item in obj.listDonvi(DVQuanLy))
            {
                if (obj.listDonvi(DVQuanLy).Count == 1)
                {
                    cbDonviquanly.EditValue = item.TEN_DVIQLY;
                    lstDVQL.Add(item.MA_DVIQLY);
                }
                else
                {
                    if (!item.MA_DVIQLY.Equals("PN"))
                    {
                        cbDonviquanly.Properties.Items.Add(item.TEN_DVIQLY.ToString());
                        lstDVQL.Add(item.MA_DVIQLY);
                    }

                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string t;
            int idPTDien = 0, Err = 0;
            if (textToado.Text != "" && txtTen.Text != "" )
                {
                    try
                    {
                        DateTime dt = obj.getDateServer();
                        D_PTDIEN _obj = new D_PTDIEN();
                        _obj.TEN_PTDIEN = txtTen.Text;
                        _obj.MA_DVQLY = DVQuanLy;
                        _obj.MA_CAPDA = "05";
                        _obj.TEN_CAPDA = "22kv";
                        _obj.MA_CMIS = cboMauNen.SelectedText;
                        _obj.LOAI_PTDIEN = "NT";
                        _obj.MA_PMIS = DVQuanLy + "_Notice_AUTO_" + dt.Day.ToString("00") + dt.Month.ToString("00") + dt.Year.ToString("00") + random();
                        _obj.MA_PMISCHA = DVQuanLy + "_Notice_AUTO_" + dt.Day.ToString("00") + dt.Month.ToString("00") + dt.Year.ToString("00") + random();
                        _obj.NGAY_TAO = obj.getDateServer();
                        _obj.NGUOI_TAO = userName; 
                        obj.addPTDien(_obj);
                        idPTDien = obj.getIDPTDien(txtTen.Text);
                        t = "LINESTRING (" + textToado.Text + ")";
                        string query = "INSERT INTO M_VITRI VALUES ('" + DVQuanLy + "'," + idPTDien + ",'','" + _obj.MA_PMIS + "',geometry::STGeomFromText('" + t + "', 0));";
                        Err = 1;
                        obj.insertORupdateVitri(query); 
                        M_TTHAI_PTDIEN _objTT = new M_TTHAI_PTDIEN();
                        _objTT.ID_PTDIEN = idPTDien;
                        _objTT.MA_DVQLY = DVQuanLy;
                        _objTT.TRANG_THAI = 1;
                        _objTT.THOI_DIEM = obj.getDateServer();
                        _objTT.UserName = userName;
                        obj.addTrangThai(_objTT);
                        M_TTHAI_PTDIEN_VM _objTTVM = new M_TTHAI_PTDIEN_VM();
                        _objTTVM.ID_PTDIEN = idPTDien;
                        _objTTVM.MA_DVQLY = DVQuanLy;
                        _objTTVM.TRANG_THAI = 1;
                        _objTTVM.THOI_DIEM = obj.getDateServer();
                        _objTTVM.UserName = userName;
                        obj.addTrangThai_VM(_objTTVM);
                        MessageBox.Show("Tạo phần tử thành công.");
                        this.Close();
                    }
                    catch (Exception)
                    {
                        if (Err == 1)
                        {
                            obj.deleteTT(idPTDien);
                            obj.deleteTTVM(idPTDien);
                            string query = "delete from M_VITRI where ID_PTDIEN=" + idPTDien;
                            obj.deleteVT(query);
                            obj.delete(idPTDien);
                        }
                        MessageBox.Show("Có lỗi xảy ra.Thao tác tạo phần tử chưa thực hiện được.Bạn vui lòng kiểm tra và thử lại.");
                    }
                }
                else {
                    MessageBox.Show("Tiêu đề không được để trống");
                }
            
        }
        private string random()
        {
            int Numrd, Numrd1, Numrd2, Numrd3, Numrd4, Numrd5;
            string Numrd_str, Numrd_str1, Numrd_str2, Numrd_str3, Numrd_str4, Numrd_str5;
            Random rd = new Random();
            Numrd = rd.Next(1, 99);
            Numrd_str = rd.Next(1, 100).ToString("00");
            Numrd1 = rd.Next(1, 99);
            Numrd_str1 = rd.Next(1, 100).ToString("00");
            Numrd2 = rd.Next(1, 99);
            Numrd_str2 = rd.Next(1, 100).ToString("00");
            Numrd3 = rd.Next(1, 99);
            Numrd_str3 = rd.Next(1, 100).ToString("00");
            Numrd4 = rd.Next(1, 99);
            Numrd_str4 = rd.Next(1, 100).ToString("00");
            Numrd5 = rd.Next(1, 99);
            Numrd_str5 = rd.Next(1, 100).ToString("00");
            string TextRdT, TextRdH;
            TextRdH = Convert.ToString((char)rd.Next(65, 90));
            TextRdT = Convert.ToString((char)rd.Next(97, 122));
            return TextRdH + TextRdT + Numrd_str + Numrd_str1 + Numrd_str2 + Numrd_str3 + Numrd_str4 + Numrd_str5;
        }
        private void cbDonviquanly_SelectedIndexChanged(object sender, EventArgs e)
        {
            DVQuanLy = lstDVQL.ElementAt(cbDonviquanly.SelectedIndex);
        
        }
    }
}
