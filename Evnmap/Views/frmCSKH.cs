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
    public partial class frmCSKH : Form
    {
        private K_YEU_CAU yk;
        private CSKHcontroler obj;
        private int idYeuCau;
        private string userName;
        public static bool st = false;
        public frmCSKH()
        {
            InitializeComponent();
        }
        public frmCSKH(int idYeuCau, string userName)
        {
            obj = new CSKHcontroler();
            this.idYeuCau = idYeuCau;
            this.userName = userName;
            InitializeComponent();
            yk = obj.getYeuCau(idYeuCau);
            init();
            st = false;
        }
        public void init() {
            tbNoiDung.Text = yk.NOI_DUNG;
            tbNguoiXuLy.Text = yk.NGUOI_XU_LY;
            if (yk.TINH_TRANG=="" || yk.TINH_TRANG==null || yk.TINH_TRANG=="Chưa xử lý")
            {
                cbTinhTrang.SelectedIndex = 0;
            }
            if ( yk.TINH_TRANG=="Đang xử lý")
            {
                cbTinhTrang.SelectedIndex = 1;
            }
            if (yk.TINH_TRANG == "Đã xử lý xong")
            {
                cbTinhTrang.SelectedIndex = 2;
                cbTinhTrang.Enabled = false;
                btCapNhat.Enabled = false;
                tbNguoiXuLy.Enabled = false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbNguoiXuLy.Text!="" && tbNguoiXuLy.Text!=null)
                {
                    K_YEU_CAU YC = new K_YEU_CAU();
                    YC.ID_YCAU = idYeuCau;
                    YC.NGUOI_XU_LY = tbNguoiXuLy.Text;
                    if (cbTinhTrang.SelectedIndex==0)
                    {
                        YC.TINH_TRANG = "Chưa xử lý";
                    }
                    else if (cbTinhTrang.SelectedIndex == 1)
                    {
                        YC.TINH_TRANG = "Đang xử lý";
                    }
                    else
                    {
                        YC.TINH_TRANG = "Đã xử lý xong";
                    }
                    obj.updateYeuCau(YC,userName);
                    MessageBox.Show("Cập nhật trạng thái thành công!");
                    st = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bạn không được để trống người xử lý");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể cập nhật, bạn vui lòng kiểm tra lại");
            }
        }
    }
}
