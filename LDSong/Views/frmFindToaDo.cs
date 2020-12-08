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
    public partial class frmFindToaDo : Form
    {
        public static string td;
        public frmFindToaDo(bool map=true)
        {
            InitializeComponent();
            if (map==false)
            {
                lbToaDo.Text = "Tên điểm :";
                labelControl1.Text = "Bạn nên nhập chính xác tên cần tìm.";
                labelControl2.Text = "Hệ thống sẽ chỉ 1 điểm gần đúng nhất với từ khóa đã nhập.";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            td = textEdit1.Text;
            this.Close();
        }
    }
}
