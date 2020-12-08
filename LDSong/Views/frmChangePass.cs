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
using LDSong.Libs;

namespace LDSong.Views
{
    public partial class frmChangePass : DevExpress.XtraEditors.XtraForm
    {
        private UserControler clsObj;
        private S_USER Obj;

        public frmChangePass()
        {
            clsObj = new UserControler();
            InitializeComponent();
            txtConfirmPass.Properties.PasswordChar = '*';
            txtNewPass.Properties.PasswordChar = '*';
            txtOldPass.Properties.PasswordChar = '*';
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            //Obj = clsObj.getByUserName(Program._User);
            Obj = Program._User;
            if (Obj.UserPassword != txtOldPass.Text)
            {
                MessageBox.Show("Mật khẩu cũ không đúng !","Lỗi");
            }
            else if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng !", "Lỗi");
            }
            else
            {
                Obj.UserPassword = txtNewPass.Text;
                clsObj.update(Obj);
                MessageBox.Show("Thay đổi mật khẩu thành công !", "Thông báo");
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}