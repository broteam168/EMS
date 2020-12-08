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
    public partial class MessageboxMap : Form
    {
        public static bool xt=false;
        static MessageboxMap msgb;
        public MessageboxMap()
        {
            InitializeComponent();
        }
        public MessageboxMap(string msg,string bt1,string bt2)
        {
            InitializeComponent();
            labelMessage.Text = msg;
            button1.Text = bt1;
            button2.Text = bt2;

        }
        public static bool Show(string msg, string bt1, string bt2)
        {
            msgb = new MessageboxMap();
            msgb.labelMessage.Text = msg;
            msgb.button1.Text = bt1;
            msgb.button2.Text = bt2;
            msgb.ShowDialog();
            return xt;
        }
        public static bool result() {
            return xt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            xt = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xt = false;
            this.Close();
        }
        
    }
}
