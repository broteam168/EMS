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

using LDSong.Models;
using LDSong.Controlers;

namespace LDSong.Views
{
    public partial class frmChangeUserInfo : DevExpress.XtraEditors.XtraForm
    {
        private S_USER Obj;
        private UserControler clsObj;
        public frmChangeUserInfo()
        {
            clsObj = new UserControler();
            InitializeComponent();
        }

        private void frmChangeUserInfo_Load(object sender, EventArgs e)
        {
            try
            {
                //Obj = clsObj.getByUserName(Program._User);
                Obj = Program._User;
                txtUserName.Text = Obj.UserName;
                txtFullName.Text = Obj.UserFullname;
                txtGhiChu.Text = Obj.UserPoss;
                txtDienThoai.Text = Obj.Phone;
            }
            catch { }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Obj.UserFullname = txtFullName.Text;
                Obj.UserPoss = txtGhiChu.Text;
                Obj.Phone = txtDienThoai.Text;
                clsObj.update(Obj);
                MessageBox.Show("Cập nhật thông tin thành công.", "Thông báo");
            }catch(Exception Ex)
            {
                MessageBox.Show("Có lỗi:" + Ex.Message + "\n Liên lạc với người quản trị.", "Lỗi");
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}