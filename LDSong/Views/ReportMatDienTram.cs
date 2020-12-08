using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace LDSong.Views
{
    public partial class ReportMatDienTram : DevExpress.XtraReports.UI.XtraReport
    {
        private int i=1;
        private TimeSpan sumTime;
        private string[] tam, tam1;
        public ReportMatDienTram()
        {
            InitializeComponent();
        }
        public ReportMatDienTram(string begin, string end,string sum)
        {
            string lbB=begin, lbE=end;
            InitializeComponent();
            if (begin=="")
            {
                lbB = "15/10/2016";
            }
            if (end=="")
            {
                lbE = DateTime.Now.ToString("dd/MM/yyyy");
            }
            lbBegin.Text = lbB;
            lbEnd.Text = lbE;
            lbSumTimeAll.Text = sum;
        }
        

        private void xrLabel2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lbTimeEnd_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void xrLabel12_TextChanged(object sender, EventArgs e)
        {
            stt.Text = i.ToString();
            i++;
            try
            {
                if ((lbTimeBegin.Text != "" && lbTimeEnd.Text != "") || (lbTimeBegin.Text != null && lbTimeEnd.Text != null))
                {
                    Console.WriteLine(xrLabel12.Text);
                    Console.WriteLine(lbTimeEnd.Text);
                    Console.WriteLine(lbTimeBegin.Text);
                    sumTime = getDateBE(lbTimeEnd.Text) - getDateBE(lbTimeBegin.Text);
                    //lbSumTime.Text = sumTime.ToString();
                }
                else
                {
                    //lbSumTime.Text = "Chưa xác định";
                }
            }
            catch (Exception)
            {

                //lbSumTime.Text = "Chưa xác định";
            }
            /*if (lbSumTime.Text != "Không xác định" && lbSumTime.Text != "lbSumTime")
            {
                sunTimeAll = TimeSpan.Parse(lbSumTime.Text) + sunTimeAll;
                test = test + lbSumTime.Text;
                Console.WriteLine(test);
            }
            lbSumTimeAll.Text = sunTimeAll.ToString();*/
        }
        public DateTime getDateBE(string dt)
        {
            tam = dt.Split(' ');
            tam1 = tam[0].Split('/');
            string ss = tam1[2] + "-" + tam1[1] + "-" + tam1[0] + " " + tam[1];
            return DateTime.Parse(ss);
        }
    }
}
