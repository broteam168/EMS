using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using LDSong.Models;
using LDSong.Controlers;

namespace LDSong.Views
{
    public partial class ReportBC04 : DevExpress.XtraReports.UI.XtraReport
    {
        int i = 1;
        TT_PTDIEN_LRControler obj;
        private TimeSpan sumTime;
        private string[] tam, tam1;
        public ReportBC04()
        {
            InitializeComponent();
        }
        public ReportBC04(string dvql, S_BAOCAO bc, string begin, string end, DateTime ngay)
        {
            InitializeComponent();
            obj = new TT_PTDIEN_LRControler();
            string[] b = begin.ToString().Split(' ');
            string[] e = end.ToString().Split(' ');
            lbBegin.Text = b[0];
            lbEnd.Text = e[0];
            lbTieuDe.Text = bc.TIEUDEBAOCAO;
            lbChucDanh.Text = bc.CHUCDANH;
            lbNguoiKy.Text = bc.NGUOIKY;
            lbNgaythangNam.Text = "Ninh Bình, ngày "+ngay.Day+" tháng "+ngay.Month+" năm "+ngay.Year ;
            if (dvql!="PN")
            {
                xrLabel4.Text = "CÔNG TY TNHH MTV";
                xrLabel5.Text = "ĐIỆN LỰC NINH BÌNH";
                xrLabel6.Text = obj.TenDVi(dvql);
            }
        }

        private void xrLabelIDAuto_TextChanged(object sender, EventArgs e)
        {
            stt.Text = i.ToString();
            i++;
            try
            {
                if (lbTimeBegin.Text != "" && lbTimeEnd.Text != "")
                {
                    sumTime = getDateBE(lbTimeEnd.Text) - getDateBE(lbTimeBegin.Text);
                    int phut =sumTime.Days * 24 * 60 + sumTime.Hours * 60 + sumTime.Minutes + sumTime.Seconds / 60;//sumTime.TotalMinutes
                    lbSumTime.Text = phut.ToString();
                }
                else
                {
                    lbSumTime.Text = "Chưa xác định";
                }
            }
            catch (Exception)
            {

                //lbSumTime.Text = "Chưa xác định";
            }
        }
        public DateTime getDateBE(string dt) {
            tam = dt.Split(' ');
            tam1 = tam[0].Split('/');
            string ss = tam1[2] + "-" + tam1[1] + "-" + tam1[0] + " " + tam[1];
            return DateTime.Parse(ss);
        }

        private void lbTimeEnd_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
