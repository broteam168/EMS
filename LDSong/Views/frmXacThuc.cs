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
    public partial class frmXacThuc : Form
    {
        public static bool xt = false;
        private string xacthuc;
        static frmXacThuc msgb;
        public frmXacThuc()
        {
            InitializeComponent();
        }
        public frmXacThuc(string msg, string bt1, string bt2)
        {
            InitializeComponent();
            xacthuc = random();
            labelMa.Text = xacthuc;
            labelMa.Font = new Font("Tahoma", 12, FontStyle.Bold);
            labelMa.ForeColor = Color.Red; 
            labelMessage.Text = msg;
            button1.Text = bt1;
            button2.Text = bt2;
        }
        public static bool Show(string msg, string bt1, string bt2)
        {
            msgb = new frmXacThuc(msg,bt1,bt2);
            msgb.ShowDialog();
            return xt;
        }
        public static bool result()
        {
            return xt;
        }

        private string random() {
            int Numrd;
            string Numrd_str;
            Random rd = new Random();
            Numrd = rd.Next(1, 99);
            Numrd_str = rd.Next(1, 100).ToString("00");
            string TextRdT, TextRdH;
            TextRdH = Convert.ToString((char)rd.Next(65, 90));
            TextRdT = Convert.ToString((char)rd.Next(97, 122));
            return TextRdH + Numrd_str + TextRdT;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (xacthuc.Equals(textEdit1.Text.Trim()))
            {
                xt = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn nhập mã xác thực không chính xác");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            xt = false;
            this.Close();
        }
    }
}
