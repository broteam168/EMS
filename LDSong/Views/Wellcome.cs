using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LDSong.Controlers;
using LDSong.Models;
using LDSong.Libs;

namespace LDSong.Views
{
    public partial class Wellcome : DevExpress.XtraEditors.XtraForm
    {
        private string userName;
        private double Vr = 2.1;
        public Wellcome(string userName)
        {
            this.userName = userName;
            InitializeComponent();
            timerLogin.Enabled = true;
            timerLogin.Interval = 300;
        }

        private void actionTime(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;            
                HISTRORY_LOGINcontroler objHS = new HISTRORY_LOGINcontroler();
                HISTORY_LOGIN _objHS = new HISTORY_LOGIN();
                _objHS.USERNAME = userName;
                _objHS.THOIGIAN_DANGNHAP = objHS.getDateServer();
                //_objHS.IP_CONNETION = objHS.LocalIPAddress().ToString() + "-" + objHS.getIPaddressInter() + "-" + "Cpu:" + GetidComputer.cpuId() + "-" + "Hard drive :" + GetidComputer.diskId() + "-"+"Network card : "+ GetidComputer.macId()+"-"+SystemInfor.getOperatingSystemInfo()+"-"+SystemInfor.getProcessorInfo()+"-"+"Value : "+GetidComputer.Value();
                _objHS.IP_CONNETION = objHS.LocalIPAddress().ToString() + "-" + "Hard drive :" + GetidComputer.diskId() + "-" + SystemInfor.getOperatingSystemInfo();
                objHS.insertLogin(_objHS);
                this.Cursor = Cursors.Default;
                timerLogin.Enabled = false;
                double vr =objHS.getVerSion();
                if (Vr<vr)
                {
                    string ms = "Phiên bản phần mềm hiện tại bạn đang dùng là: " + Vr.ToString("0.0") + " - Đã có phiên bản " + vr.ToString("0.0") + " mới hơn. Bạn vui lòng liên hệ với người quản trị để được nâng cấp.";
                    MessageBox.Show(ms, "Thông báo");
                }
                if (LDSong.Properties.Settings.Default.rdPerson)
                {
                    if (objHS.countPer()<=2)
                    {
                        Key key = new Key();
                        string k = key.getID().Trim();
                        if (objHS.checkExist(k))
                        {

                        }
                        else
                        {
                            objHS.insert(k);
                        }
                    }
                    else
                    {
                        LDSong.Properties.Settings.Default.Key = "";
                        LDSong.Properties.Settings.Default.Save();
                        MessageBox.Show("Bạn cần đăng ký để tiếp tục sử dụng");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        
    }
}
