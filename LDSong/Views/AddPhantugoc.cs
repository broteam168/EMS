using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LDSong.Models;
using LDSong.Controlers;

namespace LDSong.Views
{
    public partial class AddPhantugoc : Form
    {
        private QHPTDiencontroler clsObj;
        public AddPhantugoc()
        {
            InitializeComponent();
        }

        private void initThemphantu(object sender, EventArgs e)
        {
            clsObj = new QHPTDiencontroler();
            
        }
    }
}
