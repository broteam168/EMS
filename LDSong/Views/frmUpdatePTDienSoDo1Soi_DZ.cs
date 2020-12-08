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
    public partial class frmUpdatePTDienSoDo1Soi_DZ : Form
    {
        private int idPTDien;
        private string dvql,userName;
        private CreatePTDSoDo1SoiControler obj;
        private M_VITRI_V2 objPTD;
        public frmUpdatePTDienSoDo1Soi_DZ()
        {
            InitializeComponent();
            obj = new CreatePTDSoDo1SoiControler();
            initPTD();
        }
        public frmUpdatePTDienSoDo1Soi_DZ(int idPTDien,string dvql,string userName)
        {
            InitializeComponent();
            this.idPTDien=idPTDien;
            this.dvql=dvql;
            this.userName = userName;
            obj = new CreatePTDSoDo1SoiControler();
            initPTD();
        }
        public void initPTD()
        {
            objPTD = obj.getAllPTDienDZ(idPTDien);
            textToado.Text = obj.toado;
            if (objPTD.MA_CAPDA=="05")
            {
                radio22.Checked = true;
            }
            else
            {
                radio35.Checked = true;
            }
            txtTen.Text = objPTD.TEN_PTDIEN;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textToado.Enabled = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtTen.Text!=""&&textToado.Text!="")
            {
                //try
                //{
                    string macap, tencap;
                    if (radio22.Checked == true)
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
                    _obj.ID_PTDIEN = objPTD.ID_PTDIEN;
                    _obj.TEN_PTDIEN = txtTen.Text;
                    _obj.MA_DVQLY = objPTD.MA_DVQLY;
                    _obj.MA_CAPDA = macap;
                    _obj.TEN_CAPDA = tencap;
                    _obj.LOAI_PTDIEN = "1S";
                    _obj.NGAY_SUA = obj.getDateServer();
                    _obj.NGUOI_SUA = userName;
                    obj.updatePTDien(_obj);
                    string t = "LINESTRING (" + textToado.Text + ")";
                    string query = "update M_VITRI set MA_DVQLY='" + objPTD.MA_DVQLY + "',MA_PMIS='SD1S',TOA_DO =geometry::STGeomFromText('" + t + "',0) where ID_PTDIEN=" + idPTDien;
                    obj.insertORupdateVitri(query);
                    MessageBox.Show("cập nhật phần tử mới thành công");
                    this.Close();
                //}
                //catch (Exception)
                //{
                //    MessageBox.Show("Không thể cập nhật. Bạn vui lòng kiểm tra lại.");
                //}
            }
            else
            {
                MessageBox.Show("Tên đường dây và tọa độ không được để trống.s");
            }
        }
    }
}
