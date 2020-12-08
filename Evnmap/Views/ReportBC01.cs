using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using LDSong.Models;
using LDSong.Controlers;

namespace LDSong.Views
{
    public partial class ReportBC01 : DevExpress.XtraReports.UI.XtraReport
    {
        TT_PTDIEN_LRControler obj;
        public ReportBC01()
        {
            InitializeComponent();
        }
        public ReportBC01(string dvql, S_BAOCAO bc, DateTime ngay)
        {
            InitializeComponent();
            obj = new TT_PTDIEN_LRControler();
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
                obj.getTram01(int.Parse(idPTD.Text));
                 count.Text = obj.count01.ToString();
                 KhachHang.Text = obj.KH01.ToString();
            }
            catch (Exception)
            {
                
            }
        }
    }
}
