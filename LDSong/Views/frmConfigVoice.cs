using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechLib;

namespace LDSong.Views
{
    public partial class frmConfigVoice : Form
    {
        public frmConfigVoice()
        {
            InitializeComponent();
            bool tv = false;
            SpVoice voice = new SpVoice();
            foreach (ISpeechObjectToken t in voice.GetVoices("", ""))
            {
                // VoiceCombo.Items.Add(t.GetAttribute("Name"));
                try
                {
                    if (t.GetAttribute("Name")=="NHMTTS Voice (Male)"||t.GetAttribute("Name")=="NHMTTS Voice (Female)")
                    {
                        tv = true;
                    }
                    
                }
                catch (Exception)
                {
                }
            }
            if (tv)
            {
                lbTinhTrang.Text = "Có hỗ trợ giọng đọc tiếng việt.";
            }
            else
            {
                lbTinhTrang.Text = "Không có giọng đọc tiếng việt.";
            }
            trackBarRate.Value = LDSong.Properties.Settings.Default.rate;
            trackBarVolume.Value = LDSong.Properties.Settings.Default.volume;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LDSong.Properties.Settings.Default.rate = trackBarRate.Value;
            LDSong.Properties.Settings.Default.volume = trackBarVolume.Value;
            LDSong.Properties.Settings.Default.Save();
            MessageBox.Show("Lưu cấu hình thành công!");
            this.Close();
        }
    }
}
