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
    public partial class frmNguyenNhanMatDien : Form
    {
        public string nguyenNhan;
        public frmNguyenNhanMatDien()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            nguyenNhan = txtNguyennhan.Text;
            this.Close();
        }


    }
}
