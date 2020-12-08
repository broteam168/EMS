using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace LDSong.Views
{
    public partial class ReportMatdien : DevExpress.XtraReports.UI.XtraReport
    {
        int i = 1;
        private DateTime TimeBegin, TimeEnd;
        private TimeSpan sumTime,sunTimeAll;
        private string[] tamBegin, tamEnd,tamEnd1,tamBegin1;
        public ReportMatdien()
        {
            InitializeComponent();
        }

        public ReportMatdien(string begin,string end,string sumTime)
        {
            InitializeComponent();
            string[] b = begin.ToString().Split(' ');
            string[] e = end.ToString().Split(' ');
            lbBegin.Text = b[0];
            lbEnd.Text = e[0];
            lbSumTimeAll.Text = sumTime;
        }

        private void TextChangeTimeBegin(object sender, EventArgs e)
        {
            try
            {
                if (lbTimeBegin.Text != "" && lbTimeEnd.Text != "")
                {
                    tamBegin = lbTimeBegin.Text.Split(' ');
                    tamBegin1 = tamBegin[0].Split('/');
                    string ss = tamBegin1[2] + "-" + tamBegin1[1] + "-" + tamBegin1[0] + " " + tamBegin[1];
                    TimeBegin = DateTime.Parse(ss); 
                    sumTime = TimeEnd - TimeBegin;
                    lbSumTime.Text = sumTime.ToString() ;
                }
                else
                {
                    lbSumTime.Text = "Không xác định";
                }
            }
            catch (Exception)
            {
                lbSumTime.Text = "Không xác định";
            }
        }

        private void TextChangeTimeEnd(object sender, EventArgs e)
        {
            try
            {
                if (lbTimeBegin.Text != "" && lbTimeEnd.Text != "")
                {
                    tamEnd = lbTimeEnd.Text.Split(' ');
                    tamEnd1 = tamEnd[0].Split('/');
                    string ss = tamEnd1[2] + "-" + tamEnd1[1] + "-" + tamEnd1[0] + " " + tamEnd[1];
                    TimeEnd = DateTime.Parse(ss); 
                    sumTime = TimeEnd - TimeBegin;
                    lbSumTime.Text = sumTime.ToString();
                }
                else
                {
                    lbSumTime.Text = "Không xác định";
                }
            }
            catch (Exception)
            {
                lbSumTime.Text = "Không xác định";
            }
        }

        private void TextChangeHide(object sender, EventArgs e)
        {
            stt.Text = i.ToString();
            i++;
            if (lbSumTime.Text != "Không xác định")
            {
                sunTimeAll = TimeSpan.Parse(lbSumTime.Text) + sunTimeAll;
            }
            lbSumTimeAll.Text = sunTimeAll.ToString();
        }

        

    }
}
