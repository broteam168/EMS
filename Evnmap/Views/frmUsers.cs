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
using LDSong.Models;
using LDSong.Controlers;

namespace LDSong.Views
{
    public partial class frmUsers : DevExpress.XtraEditors.XtraForm
    {
        private static int _MenuId = 13;
        private S_USER obj;
        private UserControler clsObj;
        private string _Action;
        private clsFunction Fn;
        private bool t, s, x,xmk;
        public frmUsers()
        {
            InitializeComponent();
            
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            Fn = new clsFunction();
            obj = new S_USER();
            clsObj = new UserControler();
            LDSFunction Fn1 = new LDSFunction();
            List<string> menus = Fn1.getMenuByUser("cmd", _MenuId);
            foreach (string item in menus)
            {

                SimpleButton ctl = this.Controls.Find(item, true).FirstOrDefault() as SimpleButton;
                ctl.Enabled = true;
            }
            t = cmdThem.Enabled;
            s = cmdSua.Enabled;
            x = cmdXoa.Enabled;
            xmk = cmdClearPass.Enabled;
            dgrCtlUser.DataSource = clsObj.list();

            cboNhom.Properties.DataSource = clsObj.listGroup();

            cboDonVi.Properties.DataSource = clsObj.listDVQL();
            changeStatus(true);
        }

        private void changeStatus(Boolean _Status)
        {
            try
            {
                if (_Status)
                {
                    if (t)
                    {
                        cmdThem.Enabled = _Status;
                    }
                    if (s)
                    {
                        cmdSua.Enabled = _Status;
                    }
                    if (x)
                    {
                        cmdXoa.Enabled = _Status;
                    }
                }
                else
                {
                    cmdThem.Enabled = _Status;
                    cmdSua.Enabled = _Status;
                    cmdXoa.Enabled = _Status;
                    cmdClearPass.Enabled = _Status;
                }
                

                cmdGhi.Enabled = !_Status;
                cmdHuy.Enabled = !_Status;
                txtUserName.Enabled = !_Status;
                txtFullName.Enabled = !_Status;
                txtGhiChu.Enabled = !_Status;
                txtDienThoai.Enabled = !_Status;
                chkEnable.Enabled = !_Status;

                cboDonVi.Enabled = !_Status;
                cboNhom.Enabled = !_Status;
            }
            catch { }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
            {
                Fn.showMSG("Lỗi", "Chưa nhập tên đăng nhập !");
                txtUserName.Focus();
            }
            else
            {
                obj = new S_USER();
                obj.UserName = txtUserName.Text;
                obj.UserFullname = txtFullName.Text;
                obj.UserPoss = txtGhiChu.Text;
                obj.UserGroup = int.Parse(cboNhom.EditValue.ToString());
                obj.MaDVQL = cboDonVi.EditValue.ToString();
                obj.IsActive = chkEnable.Checked ? 1 : 0;
                obj.Phone = txtDienThoai.Text;
                
                if (_Action == "EDIT")
                {
                    clsObj.update(obj);
                }
                else if (!clsObj.checkExists(obj.UserName))
                {
                    obj.UserPassword = obj.UserName;
                    clsObj.add(obj);
                }
                else {
                    Fn.showMSG("Lỗi", "Tên đăng nhập đã tồn tại !");
                    txtUserName.Focus();
                    return;
                }
                Fn.showMSG("Thông báo", "Cập nhật thông tin thành công !");
                dgrCtlUser.DataSource = clsObj.list();
                changeStatus(true);
            }
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            _Action = "ADD";
            changeStatus(false);

            txtUserName.Text = "";
            txtFullName.Text = "";
            txtGhiChu.Text = "";
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            _Action = "EDIT";
            changeStatus(false);
            txtUserName.Enabled = false;
        }

        private void cmdHuy_Click(object sender, EventArgs e)
        {
            changeStatus(true);
        }

        private void dgrUser_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
            obj.UserId = int.Parse(dgrUser.GetFocusedRowCellValue("UserId").ToString());
            txtUserName.Text = dgrUser.GetFocusedRowCellValue("UserName").ToString();
            txtFullName.Text = dgrUser.GetFocusedRowCellValue("UserFullname").ToString();
            txtDienThoai.Text = dgrUser.GetFocusedRowCellValue("Phone").ToString(); ;
            txtGhiChu.Text = dgrUser.GetFocusedRowCellValue("UserPoss").ToString();
            cboNhom.EditValue = int.Parse(dgrUser.GetFocusedRowCellValue("UserGroup").ToString());
            cboDonVi.EditValue = dgrUser.GetFocusedRowCellValue("MaDVQL").ToString();
            if (dgrUser.GetFocusedRowCellValue("IsActive").ToString() == "1") 
            {
                chkEnable.Checked = true;
            }
            if (dgrUser.GetFocusedRowCellValue("IsActive").ToString() == "0") 
            {
                chkEnable.Checked = false;
            }

        }

        private void cmdClearPass_Click(object sender, EventArgs e)
        {
            try
            {
                clsObj.clearPass(obj.UserId);
                MessageBox.Show("Reset mật khẩu thành công!");
            }
            catch { }
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            try {
                clsObj.delete(obj.UserId);
                dgrCtlUser.DataSource = clsObj.list();
                MessageBox.Show("Xóa tài khoản thành công");
            }
            catch {
                MessageBox.Show("Có lỗi xảy ra, thao tác xóa chưa thực hiện được.");
            }
        }
    }
}