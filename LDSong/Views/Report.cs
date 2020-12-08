using LDSong.Controlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using LDSong.Models;
namespace LDSong.Views
{
    public partial class Report : DevExpress.XtraEditors.XtraForm
    {
        private TT_PTDIEN_LRControler obj;
        private string dvql;
        private List<M_TTHAI_PTDIEN_LR> m;
        private bool CDV=false, CBC=false;
        public Report()
        {
            InitializeComponent();
            
            obj = new TT_PTDIEN_LRControler();
            CDV = false; CBC = false;
            labelControl4.Visible = false;
            cbLo.Visible = false;
        }
        public Report(string dvql,string loai)
        {
            this.dvql = dvql;
            InitializeComponent();
            obj = new TT_PTDIEN_LRControler();
            imageSlider1.SlideNext();
            if (loai.Equals("0"))
            {
                btDSDaoKDCB.Enabled = true;
            }
        }

        private void loadform(object sender, EventArgs e)
        {
            cbDvi.Properties.DataSource = obj.listDVi(dvql);
            cbDvi.Properties.NullText = "Vui lòng chọn đơn vị";
            cbBaoCao.Properties.DataSource = obj.listBCao();
            cbBaoCao.Properties.NullText = "Vui lòng chọn loại báo cáo";
            cbLo.Properties.NullText = "Vui lòng chọn lộ";
            dateBegin.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            dateBegin.Properties.Mask.EditMask = "dd-MM-yyyy";
            dateBegin.Properties.Mask.UseMaskAsDisplayFormat = true;
            dateBegin.Properties.CharacterCasing = CharacterCasing.Upper;
            dateEnd.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            dateEnd.Properties.Mask.EditMask = "dd-MM-yyyy";
            dateEnd.Properties.Mask.UseMaskAsDisplayFormat = true;
            dateEnd.Properties.CharacterCasing = CharacterCasing.Upper;
            cbDvi.Properties.NullText = "Vui lòng chọn đơn vị quản lý";
            cbYeuCauKH.Properties.DataSource = obj.listLoaiYeuCau();
            cbYeuCauKH.Properties.NullText = "Vui lòng chọn loại yêu cầu";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            /*if (dateBegin.Text != "" && dateEnd.Text!="")
            {
                DateTime begin, end;
                begin = dateBegin.DateTime;
                end = dateEnd.DateTime;
                string[] b = begin.ToString().Split(' ');
                string[] c = end.ToString().Split(' ');
                try
                {
                    
                    m = obj.getOFF(cbDvi.EditValue.ToString(), b[0]+" 00:00:01", c[0]+" 23:59:59");
                    List<D_PTDIEN> d = obj.getOFFBC03(cbDvi.EditValue.ToString(), b[0] + " 00:00:01", c[0] + " 23:59:59");
                    Console.WriteLine(d[0].ID_PTDIEN);
                    for (int i = 0; i < d[0].M_TTHAI_PTDIEN_LRs.Count; i++)
                    {
                        Console.WriteLine(d[0].M_TTHAI_PTDIEN_LRs[i].LEFT_TRANGTHAI);
                        Console.WriteLine(d[0].M_TTHAI_PTDIEN_LRs[i].RIGHT_TRANGTHAI);
                    }
                    gridListTramMD.DataSource = d;
                }
                catch (Exception)
                {
                    MessageBox.Show("Có lỗi xảy ra! Bạn vui lòng kiểm tra lại.");
                }
            }
            else
            {
                MessageBox.Show("Bạn không được để trống thời gian bắt đầu và thời gian kết thúc.");
            }*/
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string cbdv = "";
                int loaiBC = 0;
                try
                {
                    loaiBC = int.Parse(cbBaoCao.EditValue.ToString());
                }
                catch (Exception)
                {

                    MessageBox.Show("Bạn vui lòng chọn loại báo cáo.");
                }
                try
                {
                    cbdv = cbDvi.EditValue.ToString();
                }
                catch (Exception)
                {
                        
                    MessageBox.Show("Bạn vui lòng chọn đơn vị.");
                }
                S_BAOCAO bc = obj.getLoaiBCao(loaiBC);
                //ReportMatdien rp = new ReportMatdien(dateBegin.Text, dateEnd.Text,sumS);
                if (loaiBC==4)
                {
                    if (dateBegin.Text != "" && dateEnd.Text != "")
                    {
                        DateTime begin, end;
                        begin = dateBegin.DateTime;
                        end = dateEnd.DateTime;
                        string[] b = begin.ToString().Split(' ');
                        string[] c = end.ToString().Split(' ');
                        this.Cursor = Cursors.WaitCursor;
                        m = obj.getOFF(cbdv, b[0] + " 00:00:01", c[0] + " 23:59:59");
                        this.Cursor = Cursors.Default;
                        if (m.Count!=0)
                        {
                            ReportBC04 rp = new ReportBC04(cbdv, bc, dateBegin.Text, dateEnd.Text, obj.getDateServer());
                            rp.DataSource = m;
                            rp.ShowPreviewDialog();
                        }
                        else
                        {
                            MessageBox.Show("Chúng tôi Rất tiếc!Không có dữ liệu để tổng hợp báo cáo.");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Bạn không được để trống thời gian bắt đầu và thời gian kết thúc.");
                    }
                }
                if (loaiBC==3)
                {
                    if (dateBegin.Text != "" && dateEnd.Text != "")
                    {
                        DateTime begin, end;
                        begin = dateBegin.DateTime;
                        end = dateEnd.DateTime;
                        string[] b = begin.ToString().Split(' ');
                        string[] c = end.ToString().Split(' ');
                        this.Cursor = Cursors.WaitCursor;
                        List<D_PTDIEN> d = obj.getOFFBC03(cbdv, b[0] + " 00:00:01", c[0] + " 23:59:59");
                        this.Cursor = Cursors.Default;
                        if (d.Count != 0)
                        {
                            ReportBC03 rp = new ReportBC03(cbdv, bc, dateBegin.Text, dateEnd.Text, obj.getDateServer(), b[0] + " 00:00:01", c[0] + " 23:59:59");
                            rp.DataSource = d;
                            rp.ShowPreviewDialog();
                        }
                        else
                        {
                            MessageBox.Show("Chúng tôi Rất tiếc!Không có dữ liệu để tổng hợp báo cáo.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn không được để trống thời gian bắt đầu và thời gian kết thúc.");
                    }
                        
                }
                if (loaiBC==5)
                {
                    if (dateBegin.Text != "" && dateEnd.Text != "")
                    {
                        DateTime begin, end;
                        begin = dateBegin.DateTime;
                        end = dateEnd.DateTime;
                        string[] b = begin.ToString().Split(' ');
                        string[] c = end.ToString().Split(' ');
                        this.Cursor = Cursors.WaitCursor;
                        List<D_DVI_QLY> d = obj.getDVQL05(cbdv);
                        this.Cursor = Cursors.Default;
                        if (d.Count != 0)
                        {
                            ReportBC05 rp = new ReportBC05(cbdv, bc, dateBegin.Text, dateEnd.Text, obj.getDateServer(), b[0] + " 00:00:01", c[0] + " 23:59:59");
                            rp.DataSource = d;
                            rp.ShowPreviewDialog();
                        }
                        else
                        {
                            MessageBox.Show("Chúng tôi Rất tiếc!Không có dữ liệu để tổng hợp báo cáo.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn không được để trống thời gian bắt đầu và thời gian kết thúc.");
                    }
                        
                }
                if (loaiBC == 6)
                {
                    if (dateBegin.Text != "" && dateEnd.Text != "")
                    {
                        DateTime begin, end;
                        begin = dateBegin.DateTime;
                        end = dateEnd.DateTime;
                        string[] b = begin.ToString().Split(' ');
                        string[] c = end.ToString().Split(' ');
                        this.Cursor = Cursors.WaitCursor;
                        List<M_TTHAI_CD_KDCB> d = obj.getListDao06(cbdv);
                        this.Cursor = Cursors.Default;
                        if (d.Count != 0)
                        {
                            ReportBC06 rp = new ReportBC06(cbdv, bc, dateBegin.Text, dateEnd.Text, obj.getDateServer(), b[0] + " 00:00:01", c[0] + " 23:59:59");
                            rp.DataSource = d;
                            rp.ShowPreviewDialog();
                        }
                        else
                        {
                            MessageBox.Show("Chúng tôi Rất tiếc!Không có dữ liệu để tổng hợp báo cáo.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn không được để trống thời gian bắt đầu và thời gian kết thúc.");
                    }

                }
                if (loaiBC==1)
                {
                    this.Cursor = Cursors.WaitCursor;
                    List<D_PTDIEN> d = obj.getOFF01(cbdv);
                    this.Cursor = Cursors.Default;
                    if (d.Count!=0)
                    {
                        ReportBC01 rp = new ReportBC01(cbdv, bc, obj.getDateServer());
                        rp.DataSource = d;
                        rp.ShowPreviewDialog();
                    }
                    else
                    {
                        MessageBox.Show("Chúng tôi Rất tiếc!Không có dữ liệu để tổng hợp báo cáo.");
                    }
                }
                if (loaiBC==2)
                {
                    string maPmis="";
                    try
                    {
                        maPmis = cbLo.EditValue.ToString();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bạn vui lòng chọn lộ.");
                    }
                    this.Cursor = Cursors.WaitCursor;
                    obj.getALLDuongDay02(maPmis,true);
                    List<D_PTDIEN> d = obj.list02;
                    this.Cursor = Cursors.Default;
                    if (d.Count!=0)
                    {
                        ReportBC02 rp = new ReportBC02(cbdv, bc, obj.getDateServer(), cbLo.Properties.GetDisplayText(cbLo.EditValue), obj.getNameCapDa(cbLo.EditValue.ToString()));
                        rp.DataSource = d;
                        rp.ShowPreviewDialog();
                    }
                    else
                    {
                        MessageBox.Show("Chúng tôi Rất tiếc!Không có dữ liệu để tổng hợp báo cáo.");
                    }
                }
                if (loaiBC==7)
                {
                    if (dateBegin.Text != "" && dateEnd.Text != "")
                    {
                        string maYeuCau = "";
                        try
                        {
                            maYeuCau = cbYeuCauKH.EditValue.ToString();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Bạn vui lòng chọn loại yêu cầu.");
                        }
                        DateTime begin, end;
                        begin = dateBegin.DateTime;
                        end = dateEnd.DateTime;
                        string[] b = begin.ToString().Split(' ');
                        string[] c = end.ToString().Split(' ');
                        this.Cursor = Cursors.WaitCursor;
                        List<K_YEU_CAU> d = obj.listKHYeuCau(cbdv, maYeuCau, b[0] + " 00:00:01", c[0] + " 23:59:59");
                        this.Cursor = Cursors.Default;
                        if (d.Count != 0)
                        {
                            ReportBC07 rp = new ReportBC07(cbdv, bc, dateBegin.Text, dateEnd.Text, obj.getDateServer(), b[0] + " 00:00:01", c[0] + " 23:59:59");
                            rp.DataSource = d;
                            rp.ShowPreviewDialog();
                        }
                        else
                        {
                            MessageBox.Show("Chúng tôi Rất tiếc!Không có dữ liệu để tổng hợp báo cáo.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn không được để trống thời gian bắt đầu và thời gian kết thúc.");
                    }
                }
            if (loaiBC == 8)
            {
                if (dateBegin.Text != "" && dateEnd.Text != "")
                {
                    DateTime begin, end;
                    begin = dateBegin.DateTime;
                    end = dateEnd.DateTime;
                    string[] b = begin.ToString().Split(' ');
                    string[] c = end.ToString().Split(' ');
                    this.Cursor = Cursors.WaitCursor;
                    m = obj.getOFF1(cbdv, b[0] + " 00:00:01", c[0] + " 23:59:59");

                    if (m.Count!=0)
                    {
                        List<IEEE1366> lstIe = new List<IEEE1366>();
                        TimeSpan sumTime = DateTime.Parse(c[0] + " 23:59:59") - DateTime.Parse(b[0] + " 00:00:01");
                        foreach (var item in m)
                        {

                            DateTime ngayB;
                            DateTime ngayK;
                            if (item.NGAY_CAP_NHAT < DateTime.Parse(b[0] + " 00:00:01"))
                            {
                                ngayB = DateTime.Parse(b[0] + " 00:00:01");
                            }
                            else
                            {
                                ngayB = item.NGAY_CAP_NHAT.Value;
                            }
                            if (item.THOIGIANKETTHUC.Equals("") || !item.THOIGIANKETTHUC.HasValue)//item.THOIGIANKETTHUCsValue.Ha
                            {
                                ngayK = DateTime.Parse(c[0] + " 23:59:59");
                            }
                            else
                            {
                                if (item.THOIGIANKETTHUC > DateTime.Parse(c[0] + " 23:59:59"))
                                {
                                    ngayK = DateTime.Parse(c[0] + " 23:59:59");
                                }
                                else
                                {
                                    ngayK = item.THOIGIANKETTHUC.Value;
                                }
                            }
                            string cmis = item.D_PTDIEN.MA_CMIS;
                            int count = obj.getCountKH(cmis);
                            List<DateTime> lstDate = new List<DateTime>();
                            List<int> lstPhut = new List<int>();
                            List<int> lstKh = new List<int>();
                            if (ngayB.Date == ngayK.Date)
                            {
                                lstDate.Add(ngayB.Date);
                                TimeSpan temp = getDateBE(ngayK.ToString()) - getDateBE(ngayB.ToString());
                                lstPhut.Add(temp.Days * 24 * 60 + temp.Hours * 60 + temp.Minutes + temp.Seconds / 30);
                                lstKh.Add(count);
                            }
                            else
                            {
                                if (ngayK != DateTime.Parse(c[0] + " 23:59:59"))
                                {
                                    TimeSpan sn = getDateBE(ngayK.Date.ToString()) - getDateBE(ngayB.Date.ToString());
                                    for (int i = 0; i <= sn.Days; i++)
                                    {
                                        lstDate.Add(ngayB.AddDays(i).Date);
                                        lstKh.Add(count);
                                        if (i == 0)
                                        {
                                                if (ngayB== DateTime.Parse(b[0] + " 00:00:01"))
                                                {
                                                    lstPhut.Add(1440);
                                                }
                                                else
                                                {
                                                    lstPhut.Add((24 - ngayB.TimeOfDay.Hours) * 60 + (60 - ngayB.TimeOfDay.Minutes) + (60 - ngayB.Second) / 30);
                                                }
                                        }
                                        else
                                        {
                                            if (i == sn.Days)
                                            {
                                                lstPhut.Add(ngayK.TimeOfDay.Hours * 60 + ngayK.TimeOfDay.Minutes + ngayK.Second / 30);
                                            }
                                            else
                                            {
                                                lstPhut.Add(1440);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    TimeSpan sn = DateTime.Parse(c[0] + " 23:59:59").Date - ngayB.Date;
                                    for (int i = 0; i <= sn.Days; i++)
                                    {
                                        lstDate.Add(ngayB.AddDays(i).Date);
                                        lstKh.Add(count);
                                        if (i == 0)
                                        {
                                                if (ngayB == DateTime.Parse(b[0] + " 00:00:01"))
                                                {
                                                    lstPhut.Add(1440);
                                                }
                                                else
                                                {
                                                    lstPhut.Add((24 - ngayB.TimeOfDay.Hours) * 60 + (60 - ngayB.TimeOfDay.Minutes) + (60 - ngayB.Second) / 30);
                                                }
                                            }
                                        else
                                        {
                                            if (i == sn.Days)
                                            {
                                                lstPhut.Add(ngayK.TimeOfDay.Hours * 60 + ngayK.TimeOfDay.Minutes + ngayK.Second / 30);
                                            }
                                            else
                                            {
                                                lstPhut.Add(1440);
                                            }
                                        }
                                    }
                                }
                            }
                            for (int i = 0; i < lstDate.Count; i++)
                            {
                                IEEE1366 objIe = new IEEE1366();
                                objIe.day = lstDate.ElementAt(i);
                                objIe.ci = lstKh.ElementAt(i);// kh bi gian doan
                                objIe.cmi = objIe.ci * lstPhut.ElementAt(i); //phut cua kh bi gian doan
                                objIe.cs = obj.sumKh(cbdv);//tong so kh
                                objIe.caidi = objIe.cmi / (float)objIe.ci;// chi tieu thoi gian ngung cap dien trung binh cua khach hang
                                objIe.saifi = objIe.ci / (float)objIe.cs;//chi tieu tan suat ngung cap dien cua he thong
                                objIe.asai = (24 * 60 * objIe.cs - objIe.cmi) / ((float)24 * 60 * objIe.cs);
                                objIe.saidi = objIe.cmi / (float)objIe.cs;// chi tieu thoi gian ngung cap dien trung binh cua he thong
                                objIe.ln = Math.Round(Math.Log(objIe.saidi), 4);
                                int index = lstIe.FindIndex(x => x.day == lstDate.ElementAt(i));
                                if (index != -1)
                                {
                                    lstIe.ElementAt(index).ci = lstIe.ElementAt(index).ci + objIe.ci;
                                    lstIe.ElementAt(index).cmi = lstIe.ElementAt(index).cmi + objIe.cmi;
                                    lstIe.ElementAt(index).caidi = lstIe.ElementAt(index).cmi / (float)lstIe.ElementAt(index).ci;
                                    lstIe.ElementAt(index).saifi = lstIe.ElementAt(index).ci / (float)objIe.cs;
                                    lstIe.ElementAt(index).asai = (24 * 60 * objIe.cs - lstIe.ElementAt(index).cmi) / ((float)24 * 60 * objIe.cs);
                                    lstIe.ElementAt(index).saidi = lstIe.ElementAt(index).cmi / (float)objIe.cs;
                                    lstIe.ElementAt(index).ln = Math.Round(Math.Log(lstIe.ElementAt(index).saidi), 4);
                                }
                                else
                                {

                                    lstIe.Add(objIe);
                                }

                            }

                        }
                        var result = lstIe.Select(ie => (double)ie.ln);
                        double tm = tinhTMED(result);
                        this.Cursor = Cursors.Default;
                        Report08_ieee rp = new Report08_ieee(lstIe, bc, obj.getDateServer(), cbdv, tm.ToString());
                        rp.DataSource = lstIe;
                        rp.ShowPreviewDialog();
                    }
                    else
                    {
                        MessageBox.Show("Chúng tôi Rất tiếc!Không có dữ liệu để tổng hợp báo cáo.");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn không được để trống thời gian bắt đầu và thời gian kết thúc.");
                }
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra! Bạn vui lòng kiểm tra lại.");
            }
            this.Cursor = Cursors.Default;
        }
        private double tinhTMED(IEnumerable<double> values)
        {
            double Tmed = 0;

            if (values.Any())
            {
                // tinh gia tri trung binhf    
                double avg = values.Average();

                // Thuc hien tong cua gia tri trung binh_2_2.      
                double sum = values.Sum(d => Math.Pow(d - avg, 2));

                // Do lech chuan.      
                double standardDeviation = Math.Sqrt((sum) / (values.Count() - 1));

                Tmed = Math.Pow(2.72, (avg+2.5*standardDeviation));
            }

            return Math.Round(Tmed,2);
        }
        public DateTime getDateBE(string dt)
        {
            string[] tam, tam1;
            tam = dt.Split(' ');
            tam1 = tam[0].Split('/');
            string ss = tam1[2] + "-" + tam1[1] + "-" + tam1[0] + " " + tam[1];
            return DateTime.Parse(ss);
        }
        private void setVisbleCal(bool tt) {
            lbbegin.Enabled = tt;
            lbEnd.Enabled = tt;
            dateBegin.Enabled = tt;
            dateEnd.Enabled = tt;
            lbLoaiYeuCau.Visible = false;
            cbYeuCauKH.Visible = false;
        }
        private void slide(object sender, EventArgs e)
        {
            imageSlider1.SlideNext();
        }

        private void cbDvi_EditValueChanged(object sender, EventArgs e)
        {
            CDV = true;
            if (CBC==true)
            {
                cbLo.Properties.DataSource = null;
                labelControl4.Enabled = true;
                cbLo.Enabled = true;
                this.Cursor = Cursors.WaitCursor;
                cbLo.Properties.DataSource = obj.getOFF01(cbDvi.EditValue.ToString());
                this.Cursor = Cursors.Default;
            }
        }

        private void cbBaoCao_EditValueChanged(object sender, EventArgs e)
        {
            try 
	        {
                string i = cbBaoCao.EditValue.ToString();
		        if (i.Equals("2"))
                {
                    CBC = true;
                    if (CDV==true)
                    {
                        cbLo.Properties.DataSource = null;
                        labelControl4.Enabled = true;
                        cbLo.Enabled = true;
                        this.Cursor = Cursors.WaitCursor;
                        cbLo.Properties.DataSource = obj.getOFF01(cbDvi.EditValue.ToString());
                        this.Cursor = Cursors.Default;
                    }
                }
                else
                {
                    CBC = false;
                    labelControl4.Enabled = false;
                    cbLo.Enabled = false;
                }


                if (i.Equals("1"))
                {
                    setVisbleCal(false);
                    imageSlider1.CurrentImageIndex = 5;
                    timerAnimation.Enabled=false;
                }
                else
                {
                    if (i.Equals("2"))
                    {
                        setVisbleCal(false);
                        imageSlider1.CurrentImageIndex = 6;
                        timerAnimation.Enabled=false;
                    }
                    else
                    {
                        if (i.Equals("3"))
                        {
                            setVisbleCal(true);
                            imageSlider1.CurrentImageIndex = 7;
                            timerAnimation.Enabled=false;
                        }
                        else
                        {
                            if (i.Equals("4"))
                            {
                                setVisbleCal(true);
                                imageSlider1.CurrentImageIndex = 8;
                                timerAnimation.Enabled=false;
                            }
                            else
                            {
                                if (i.Equals("5"))
                                {
                                    setVisbleCal(true);
                                    imageSlider1.CurrentImageIndex = 9;
                                    timerAnimation.Enabled=false;
                                }
                                else
                                {
                                    if (i.Equals("6"))
                                    {
                                        setVisbleCal(true);
                                        imageSlider1.CurrentImageIndex = 10;
                                        timerAnimation.Enabled = false;
                                    }
                                    else
                                    {
                                        if (i.Equals("7"))
                                        {
                                            setVisbleCal(true);
                                            imageSlider1.CurrentImageIndex = 11;
                                            timerAnimation.Enabled = false;
                                            lbLoaiYeuCau.Visible = true;
                                            cbYeuCauKH.Visible = true;
                                        }
                                        else
                                        {
                                            setVisbleCal(true);
                                            imageSlider1.CurrentImageIndex = 12;
                                            timerAnimation.Enabled = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
	        }
	        catch (Exception)
	        {
                CBC = false;
                labelControl4.Enabled = false;
                cbLo.Enabled = false;
	        }
            
                
        }
        private void btDSDaoKDCB_Click(object sender, EventArgs e)
        {
            frmKetDayCoBan frm = new frmKetDayCoBan(dvql);
            frm.ShowDialog();
        }
    }
}
