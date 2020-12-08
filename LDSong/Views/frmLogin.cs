using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.IO;

using LDSong.Libs;
using LDSong.Controlers;
using LDSong.Models;

namespace LDSong.Views
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public SetTextFunc SetMenuFunc;
        public string khuvuc,username,loai ;
        public int groupID;
        private UserControler clsObj;
        private S_USER Obj;
        private clsFunction Fn;
        private bool closeForm = true;

        public frmLogin()
        {

            InitializeComponent();
            
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                clsObj = new UserControler();
                Fn = new clsFunction();
                //cboDonVi.Properties.DataSource = clsObj.listDVQL();
                //cboDonVi.ItemIndex = 0;

                DataSet ds = new DataSet();
                ds.ReadXml(Directory.GetCurrentDirectory() + @"\Config\USER.xml");

                DataTable tbl = ds.Tables[0];
                DataRow dr = ds.Tables[0].Rows[0];
                txtUserName.Text = dr["UserName"].ToString();
                txtPassWord.Text = (dr["Password"].ToString().Length > 0) ? clsFunction.Decrypt(dr["Password"].ToString()) : "";
                //cboDonVi.EditValue = dr["DonVi"].ToString();
                chkSavePass.CheckState = (dr["SavePass"].ToString() == "1") ? CheckState.Checked : CheckState.Unchecked;
                txtUserName.Focus();
            }
            catch { }
        }

        private Boolean checkLogin()
        {
            if (txtUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa nhập tên đăng nhập !", "Cảnh báo");
                txtUserName.Focus();
                return false;
            }
            /*else if (cboDonVi.GetColumnValue("MaDVQL") == null)
            {
                MessageBox.Show("Chưa chọn đơn vị quản lý !", "Cảnh báo");
                cboDonVi.Focus();
                return false;
            }*/
            return true;
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            
                if (checkLogin())
                {
                    Obj = clsObj.getByUserName(txtUserName.Text);
                    if (Obj == null)
                    {
                        MessageBox.Show("Tên đăng nhập không tồn tại trong hệ thống !", "Lỗi");
                        txtUserName.Focus();
                    }
                    else if (Obj.UserPassword != txtPassWord.Text)
                    {
                        MessageBox.Show( "Mật khẩu không đúng !", "Lỗi");
                        txtPassWord.Focus();
                    }
                    else if (Obj.IsActive == 0)
                    {
                        MessageBox.Show("Tên đăng nhập đang bị khóa !", "Lỗi");
                        txtPassWord.Focus();
                    }
                    else
                    {
                        Program._User = Obj;
                        DataTable tbl = new DataTable();
                        tbl.TableName = "tblUser";
                        tbl.Columns.Add("UserName", typeof(string));
                        tbl.Columns.Add("Password", typeof(string));
                        tbl.Columns.Add("SavePass", typeof(int));
                        tbl.Columns.Add("DonVi", typeof(string));

                        DataRow dr = tbl.NewRow();
                        dr["UserName"] = txtUserName.Text.Trim();

                        if (chkSavePass.Checked == true)
                        {
                            dr["Password"] = clsFunction.Encrypt(txtPassWord.Text);
                        }
                        else
                        {
                            dr["Password"] = "";
                        }
                        dr["SavePass"] = (chkSavePass.Checked) ? 1 : 0;
                        //dr["DonVi"] = cboDonVi.EditValue.ToString();
                        tbl.Rows.Add(dr);

                        DataSet ds = new DataSet();
                        ds.DataSetName = "USER";
                        ds.Tables.Add(tbl);
                        khuvuc = Obj.MaDVQL.ToString();
                        loai = Obj.S_GROUP.GroupDesc;
                        username = txtUserName.Text;
                        groupID = Obj.UserGroup;
                        ds.WriteXml(Directory.GetCurrentDirectory() + @"\Config\USER.xml");
                        SetMenuFunc("ok");
                        closeForm = false;
                        Close();
                        
                    }
                }
           
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            Fn.changeFocus(txtPassWord, e);
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            Fn.changeFocus(cmdLogin, e);
        }

        private void cmdCauHinh_Click(object sender, EventArgs e)
        {
            frmServer frm = new frmServer();
            frm.ShowDialog();
        }


        private void btCauhinh_Click(object sender, EventArgs e)
        {
            frmServer frm = new frmServer();
            frm.Show();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeForm)
            {
                Application.Exit();
            }
        }
    }
}