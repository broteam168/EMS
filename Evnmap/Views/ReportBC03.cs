using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using LDSong.Controlers;
using LDSong.Models;

namespace LDSong.Views
{
    public partial class ReportBC03 : DevExpress.XtraReports.UI.XtraReport
    {
        TT_PTDIEN_LRControler obj;
        private string dateB, dateE;
        public ReportBC03()
        {
            InitializeComponent();
        }
        public ReportBC03(string dvql, S_BAOCAO bc, string begin, string end, DateTime ngay, string dateB, string dateE)
        {
            this.dateB = dateB;
            this.dateE = dateE;
            InitializeComponent();
            obj = new TT_PTDIEN_LRControler();
            string[] b = begin.ToString().Split(' ');
            string[] e = end.ToString().Split(' ');
            lbBegin.Text = b[0];
            lbEnd.Text = e[0];
            lbTieuDe.Text = bc.TIEUDEBAOCAO;
            lbChucDanh.Text = bc.CHUCDANH;
            lbNguoiKy.Text = bc.NGUOIKY;
            lbNgaythangNam.Text = "Ninh Bình, ngày " + ngay.Day + " tháng " + ngay.Month + " năm " + ngay.Year;
            if (dvql != "PN")
            {
                xrLabel4.Text = "CÔNG TY TNHH MTV";
                xrLabel5.Text = "ĐIỆN LỰC NINH BÌNH";
                xrLabel6.Text = obj.TenDVi(dvql);
            }
        }

        private void idPTD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sumTime.Text= obj.getTram(int.Parse(idPTD.Text),dateB,dateE).ToString();
                count.Text = obj.cout03.ToString();
            }
            catch (Exception)
            {
                
            }
        }
    }
}
