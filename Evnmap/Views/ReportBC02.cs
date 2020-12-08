using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using LDSong.Models;
using LDSong.Controlers;

namespace LDSong.Views
{
    public partial class ReportBC02 : DevExpress.XtraReports.UI.XtraReport
    {
        TT_PTDIEN_LRControler obj;
        public ReportBC02()
        {
            InitializeComponent();
        }
        public ReportBC02(string dvql, S_BAOCAO bc, DateTime ngay,string TenLo,string duongDay)
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
            lbTenLo.Text = TenLo;
            lbCapDienAp.Text = duongDay;
        }

        private void xrTableCell6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                countKH.Text = obj.countKH02(maCmis.Text).ToString();
                lbCongsuat.Text = obj.congsuat(maCmis.Text);
            }
            catch (Exception)
            {
                
            }
        }
    }
}
