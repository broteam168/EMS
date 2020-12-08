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
    public partial class frmTBADetail : Form
    {
        int idPTDien;
        ThongSoTBAControler cls;
        bool c;
        public frmTBADetail(int idPTDien,bool update)
        {
            InitializeComponent();
            cls = new ThongSoTBAControler();
            this.idPTDien = idPTDien;
            simpleButton1.Enabled = update;
            c = checkTS(idPTDien);
        }
        private bool checkTS(int idPTD)
        {
            D_ChiTiet_TBA obj = cls.DetailTBA(idPTD);
            if (obj!=null)
            {
                txtF.Text = obj.fHz.ToString();
                txtGhiChu.Text = obj.Note.ToString();
                txtI0.Text = obj.I0.ToString();
                txtIdm1.Text = obj.Idm1.ToString();
                txtIdm2.Text = obj.Idm2.ToString();
                txtP0.Text = obj.P0.ToString();
                txtSdm.Text = obj.Sdm.ToString();
                txtTLDau.Text = obj.Trong_Luong_Dau.ToString();
                txtTLTBA.Text = obj.Trong_Luong_TBA.ToString();
                txtUdm1.Text = obj.Udm1.ToString();
                txtUdm2.Text = obj.Udm2.ToString();
                txtUn.Text = obj.UN.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            D_ChiTiet_TBA obj = new D_ChiTiet_TBA();
            obj.fHz = double.Parse(txtF.Text.Trim());
            obj.I0 = double.Parse(txtI0.Text.Trim());
            obj.Idm1 = double.Parse(txtIdm1.Text.Trim());
            obj.Idm2 = double.Parse(txtIdm2.Text.Trim());
            obj.Note = txtGhiChu.Text.Trim();
            obj.P0 = double.Parse(txtP0.Text.Trim());
            obj.Sdm = double.Parse(txtSdm.Text.Trim());
            obj.Trong_Luong_Dau = double.Parse(txtTLDau.Text.Trim());
            obj.Trong_Luong_TBA = double.Parse(txtTLTBA.Text.Trim());
            obj.Udm1 = double.Parse(txtUdm1.Text.Trim());
            obj.Udm2 = double.Parse(txtUdm2.Text.Trim());
            obj.UN = double.Parse(txtUn.Text.Trim());
            obj.ID_PTDIEN = idPTDien;
            if (c)
            {
                cls.update(obj);
                MessageBox.Show("Cập nhật thành công.");
            }
            else
            {
                cls.add(obj);
                MessageBox.Show("Thêm mới thành công.");
            }
        }
    }
}
