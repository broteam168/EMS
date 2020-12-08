using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using LDSong.Controlers;
using LDSong.Models;

namespace LDSong.Views
{
    public partial class ReportBC05 : DevExpress.XtraReports.UI.XtraReport
    {
        TT_PTDIEN_LRControler obj;
        private string dateB, dateE;
        public ReportBC05()
        {
            InitializeComponent();
        }
        public ReportBC05(string dvql, S_BAOCAO bc, string begin, string end, DateTime ngay,string dateB,string dateE)
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

        private void MaDVQL_TextChanged(object sender, EventArgs e)
        {
            float a = 0;
            sumTime.Text= obj.getOFF05(MaDVQL.Text, dateB, dateE).ToString();
            count.Text = obj.count05.ToString() ;
            khachHang.Text = obj.getID05(MaDVQL.Text, dateB, dateE).ToString();
            try
            {
                a = int.Parse(sumTime.Text) / int.Parse(khachHang.Text);
            }
            catch (Exception)
            {
               
            }
            avg.Text = a.ToString();
        }

    }
}
