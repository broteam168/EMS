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
    public partial class frmCreatePTDSoDo1Soi_DZ : Form
    {
        private CreatePTDSoDo1SoiControler obj;
        private string dvql,userName;
        public frmCreatePTDSoDo1Soi_DZ()
        {
            InitializeComponent();
        }
        public frmCreatePTDSoDo1Soi_DZ(string toado, string dvql,string userName)
        {
            obj = new CreatePTDSoDo1SoiControler();
            InitializeComponent();
            textToado.Text = toado;
            this.dvql = dvql;
            this.userName = userName;
            txtTen.Text = AutoName();
        }
        private string AutoName()
        {
            string date = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            return dvql + userName + date;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtTen.Text!="")
            {
                try
                {
                    string macap,tencap;
                    if (radio22.Checked==true)
                    {
                        macap = "05";
                        tencap = "22 KV";
                    }
                    else
                    {
                        macap = "06";
                        tencap = "35 KV";
                    }
                    D_PTDIEN _obj = new D_PTDIEN();
                    _obj.TEN_PTDIEN = txtTen.Text;
                    _obj.MA_DVQLY = dvql;
                    _obj.MA_CAPDA = macap;
                    _obj.TEN_CAPDA = tencap;
                    _obj.LOAI_PTDIEN = "1S";
                    _obj.NGAY_TAO = obj.getDateServer();
                    _obj.NGUOI_TAO = userName;
                    obj.addPTDien(_obj);
                    int idPTDien = obj.getIDPTDien(txtTen.Text); 
                    string t = "LINESTRING (" + textToado.Text + ")";
                    string query = "INSERT INTO M_VITRI VALUES ('" + dvql + "'," + idPTDien + ",'','" + "SD1S" + "',geometry::STGeomFromText('" + t + "', 0));";
                    obj.insertORupdateVitri(query);
                    M_TTHAI_PTDIEN _objTT = new M_TTHAI_PTDIEN();
                    _objTT.ID_PTDIEN = idPTDien;
                    _objTT.MA_DVQLY = dvql;
                    _objTT.TRANG_THAI = 1;
                    _objTT.THOI_DIEM = obj.getDateServer();
                    _objTT.UserName = userName;
                    obj.addTrangThai(_objTT);
                    M_TTHAI_PTDIEN_LR _objLR = new M_TTHAI_PTDIEN_LR();
                    _objLR.ID_PTDIEN = idPTDien;
                    _objLR.LEFT_TRANGTHAI = true;
                    _objLR.RIGHT_TRANGTHAI = true;
                    _objLR.CHIEUDONGDIEN = 'L';
                    _objLR.NGAY_CAP_NHAT = obj.getDateServer();
                    obj.addTrangThai(_objLR);
                    MessageBox.Show("Thêm phần tử mới thành công");
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể thêm phần tử. Bạn vui lòng kiểm tra lại.");
                } 
            }
            else
            {
                MessageBox.Show("Tên không được để trống.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textToado.Enabled = true;
        }
    }
}
