using LDSong.Libs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDSong.Views
{
    public partial class frmDangKy : Form
    {
        Key key;
        public frmDangKy()
        {
            InitializeComponent();
            key = new Key();
            lbID.Text = key.getID().Trim();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string keyG = key.xuly(key.EncodeSHA1(lbID.Text.Trim()));
            if (keyG.Equals(textBox1.Text.Trim())||lbID.Text.Equals(""))
            {
                LDSong.Properties.Settings.Default.Key = key.EncodeMD5(keyG);
                LDSong.Properties.Settings.Default.rdPerson = false;
                LDSong.Properties.Settings.Default.Save();
                MessageBox.Show("Đăng ký thành công!");
                Application.Restart();
            }
            else
            {
                MessageBox.Show("Key không chính xác");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmSendMail frm = new frmSendMail(key.getID(), key.getIDMain());
            frm.ShowDialog();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox1.Enabled = false;
                simpleButton3.Enabled = true;
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                groupBox1.Enabled = true;
                simpleButton3.Enabled = false;
            }
        }

        private void SimpleButton3_Click(object sender, EventArgs e)
        {
            LDSong.Properties.Settings.Default.rdPerson = true;
            string keyG = key.xuly(key.EncodeSHA1(lbID.Text.Trim()));
            LDSong.Properties.Settings.Default.Key = key.EncodeMD5(keyG);
            LDSong.Properties.Settings.Default.Save();
            Application.Restart();
        }
    }
}
