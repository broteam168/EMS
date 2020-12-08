using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
namespace Evnmap
{
    public delegate void SetTextFunc(string text);
    public partial class MainWindow : DevExpress.XtraBars.Ribbon.RibbonPage
    {
        /// <summary>
        ///Decentralization<=phanquyen, Username<=username, Kind=<Loai 
        /// </summary>
        private string Decentralization, Username, Kind;
        frmMap frmmap;
        public MainWindow()
        {
             InitializeComponent();
        }
        public MainWindow(string decentralization)
        {
            InitializeComponent();
            this.Decentralization = decentralization;
        }
        public void PhanQuyen(string MenuStr)
        {
            try
            {
                LDSFunction Fn = new LDSFunction();
                List<string> menus = Fn.getMenuByUser();
                foreach (string item in menus)
                {
                    BarItem ctl = ribbon.Manager.Items[item];
                    ctl.Enabled = true;
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void RibbonForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            setTimeLogout();
        }
        private void setTimeLogout()
        {
            HISTRORY_LOGINcontroler objHS = new HISTRORY_LOGINcontroler();
            objHS.update(this.username);
        }

        private void mnMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmmap = new frmMap(phanquyen, username, loai);
            loadForm(frmmap);
            var method = ribbon.GetType().GetMethod("OnFullScreenModeChangeCore", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            method.Invoke(ribbon, null);
        }

        private void mnSD1S_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSoDoDienMotSoi_2 frm = new frmSoDoDienMotSoi_2(username, phanquyen, loai);
            loadForm(frm);
            var method = ribbon.GetType().GetMethod("OnFullScreenModeChangeCore", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            method.Invoke(ribbon, null);
        }

        private void mnLichSuTram_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTraCuuMatDien frm = new frmTraCuuMatDien(phanquyen);
            loadForm(frm);
        }

        private void mnThongKe_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongKe frm = new frmThongKe(phanquyen);
            loadForm(frm);
        }

        private void mnLichSuTram2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Report frm = new Report(phanquyen, loai);
            loadForm(frm);
        }

        private void mnKHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmKHang frm = new frmKHang(phanquyen, username);
            loadForm(frm);
        }

        private void mnDSYC_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmListYeuCau frm = new frmListYeuCau(phanquyen);
            loadForm(frm);
        }

        private void mnPTDien_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPTDien frm = new frmPTDien(phanquyen, username);
            loadForm(frm);
        }

        private void mnQHPTDien_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmQHPTDIEN frm = new frmQHPTDIEN(phanquyen, username);
            loadForm(frm);
            this.Cursor = Cursors.Default;
        }

        private void mnCapDAp_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCapdienap frm = new frmCapdienap();
            loadForm(frm);
        }

        private void mnDVQLy_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDMDonVi frm = new frmDMDonVi();
            loadForm(frm);
        }

        private void mnGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUserGroup frm = new frmUserGroup();
            loadForm(frm);
        }

        private void mnUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUsers frm = new frmUsers();
            loadForm(frm);
        }

        private void mnUserInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChangeUserInfo frm = new frmChangeUserInfo();
            loadForm(frm);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChangePass frm = new frmChangePass();
            loadForm(frm);
        }

        private void mnManagerBC_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmManagerReport frm = new frmManagerReport(phanquyen);
            loadForm(frm);
        }

        private void mnLoaiYC_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLoaiYeuCau frm = new frmLoaiYeuCau();
            loadForm(frm);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.ShowDialog();
        }

        private void mnLoaiThietBi_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLoaiThietBi frm = new frmLoaiThietBi();
            loadForm(frm);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Restart();
            setTimeLogout();
        }

        private void loadForm(XtraForm frm)
        {
            //Program._User = "admin";
            try
            {
                foreach (XtraForm f in MdiChildren)
                {
                    if (f.Name == frm.Name)
                    {
                        f.Activate();
                        return;
                    }
                }
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception)
            {

            }
        }

        private void RibbonForm2_Load(object sender, EventArgs e)
        {
            string keyS = LDSong.Properties.Settings.Default.Key;
            Key objK = new Key();
            string keyG = objK.EncodeMD5(objK.xuly(objK.EncodeSHA1(objK.getID())));
            if (keyS.Equals(keyG))
            {
                frmLogin frm = new frmLogin();
                frm.SetMenuFunc = PhanQuyen;
                frm.ShowDialog();
                this.phanquyen = frm.khuvuc;
                this.username = frm.username;
                this.loai = frm.loai;
                //ribbonStatusBar.Text = "Tài khoản đăng nhập :" + this.username;
                Wellcome frmWellcome = new Wellcome(this.username);
                loadForm(frmWellcome); 
            }
            else
            {
                frmDangKy frm = new frmDangKy();
                frm.ShowDialog();
            }

        }
    }
}