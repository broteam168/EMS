using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
using LDSong.Models;
using System.Collections.Generic;
using LDSong.Controlers;

namespace LDSong.Views
{
    public partial class Report08_ieee : DevExpress.XtraReports.UI.XtraReport
    {
        List<IEEE1366> lst;
        int i = 0, count;
        
        public Report08_ieee()
        {
            InitializeComponent();
        }
        public Report08_ieee(List<IEEE1366> lst, S_BAOCAO bc, DateTime ngay,string dvql,string result)
        {
            InitializeComponent();
            TT_PTDIEN_LRControler obj = new TT_PTDIEN_LRControler();
            lbTieuDe.Text = bc.TIEUDEBAOCAO;
            lbChucDanh.Text = bc.CHUCDANH;
            lbNguoiKy.Text = bc.NGUOIKY;
            if (dvql != "PN")
            {
                xrLabel4.Text = "CÔNG TY TNHH MTV";
                xrLabel5.Text = "ĐIỆN LỰC NINH BÌNH";
                xrLabel6.Text = obj.TenDVi(dvql);
            }
            lbNgaythangNam.Text = "Ninh Bình, ngày " + ngay.Day + " tháng " + ngay.Month + " năm " + ngay.Year;
            if (result.ToString().Equals("NaN"))
            {
                lbTmed.Text = "0" + " phút";
            }
            else
            {
                lbTmed.Text = result + " phút";
            }
            lbTmed.Text = result+" phút";
            this.lst = lst;
            count = lst.Count;
            
        }
        private void xrLabel1_TextChanged(object sender, EventArgs e)
        {
            if (i < count)
            {
                xrTableCell10.Text = lst.ElementAt(i).day.ToString("dd/MM/yyyy");
                xrTableCell11.Text = lst.ElementAt(i).ci.ToString();
                xrTableCell13.Text = lst.ElementAt(i).cmi.ToString();
                xrTableCell14.Text = lst.ElementAt(i).cs.ToString();
                xrTableCell15.Text = lst.ElementAt(i).saifi.ToString("0.000000");
                xrTableCell16.Text = lst.ElementAt(i).caidi.ToString("0.0");
                xrTableCell17.Text = lst.ElementAt(i).asai.ToString("0.000000");
                xrTableCell18.Text = lst.ElementAt(i).saidi.ToString("0.000000");
                xrTableCell12.Text = lst.ElementAt(i).ln.ToString("0.000000");
                i++;
            }
        }
    }
}
