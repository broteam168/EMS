using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using LDSong.Models;
using LDSong.Controlers;

namespace LDSong.Views
{
    public partial class ReportBC07 : DevExpress.XtraReports.UI.XtraReport
    {
        TT_PTDIEN_LRControler obj;
        public ReportBC07()
        {
            InitializeComponent();
        }
        public ReportBC07(string dvql, S_BAOCAO bc, string begin, string end, DateTime ngay, string dateB, string dateE)
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
            lbNgaythangNam.Text = "Ninh Bình, ngày " + ngay.Day + " tháng " + ngay.Month + " năm " + ngay.Year;
            if (dvql != "PN")
            {
                xrLabel4.Text = "CÔNG TY TNHH MTV";
                xrLabel5.Text = "ĐIỆN LỰC NINH BÌNH";
                xrLabel6.Text = obj.TenDVi(dvql);
            }
        }
    }
}
