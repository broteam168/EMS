using DevExpress.XtraMap;
using LDSong.Controlers;
using LDSong.Libs;
using LDSong.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDSong.Views
{
    public partial class frmCreatPTDien : Form
    {
        private CreatePTDienControler obj;
        private bool dz;
        private string userName, DVQuanLy;
        private List<string> lstDVQL;
        public frmCreatPTDien()
        {
            InitializeComponent();
        }
        public frmCreatPTDien(string toado,string userName,string dvql,bool _dz=false)
        {
            this.dz = _dz;
            InitializeComponent();
            textToado.Text = toado;
            this.userName = userName;
            this.DVQuanLy = dvql;
            obj = new CreatePTDienControler();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textToado.Enabled = true;
        }

        private void frmCreatPTDien_Load(object sender, EventArgs e)
        {
            cbLoaiphantu.Properties.NullText = "Vui lòng chọn loại phần tử";
            cbCapdienap.Properties.NullText = "Vui lòng chọn cấp điện áp";
            cbDonviquanly.Properties.NullText = "Vui lòng chọn đơn vị quản lý";
            cbCapdienap.Properties.DataSource = obj.listCapDienAp();
            cbLoaiphantu.Properties.DataSource = obj.listLoaiThietBi(dz);
            initComboboxDonvi();
        }
        public void initComboboxDonvi() {
            lstDVQL = new List<string>();
            
            foreach (var item in obj.listDonvi(DVQuanLy))
            {
                if (obj.listDonvi(DVQuanLy).Count == 1)
                {
                    cbDonviquanly.EditValue = item.TEN_DVIQLY;
                    lstDVQL.Add(item.MA_DVIQLY);
                }
                else
                {
                    if (!item.MA_DVIQLY.Equals("PN"))
                    {
                        cbDonviquanly.Properties.Items.Add(item.TEN_DVIQLY.ToString());
                        lstDVQL.Add(item.MA_DVIQLY);
                    }
                    
                }
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string t;
            int idPTDien=0,Err = 0;
            if (obj.checkMaPmiss(txtMaPmis.Text.Trim()))
            {
                if (textToado.Text != "" && txtTen.Text != "" && txtMaPmis.Text != "" && txtMaPmischa.Text != "")
                {
                    try
                    {
                        D_PTDIEN _obj = new D_PTDIEN();
                        _obj.TEN_PTDIEN = txtTen.Text;
                        _obj.MA_DVQLY = DVQuanLy;
                        _obj.MA_CAPDA = cbCapdienap.EditValue.ToString();
                        _obj.TEN_CAPDA = cbCapdienap.Text;
                        _obj.MA_CMIS = txtMaCmis.Text;
                        _obj.LOAI_PTDIEN = cbLoaiphantu.EditValue.ToString();
                        _obj.MA_PMIS = txtMaPmis.Text;
                        _obj.MA_PMISCHA = txtMaPmischa.Text;
                        _obj.NGAY_TAO = obj.getDateServer();
                        _obj.MA_SCADA = txtMaScada.Text;
                        _obj.NGUOI_TAO = userName; 
                        obj.addPTDien(_obj);
                        idPTDien = obj.getIDPTDien(txtTen.Text); 
                        if (cbLoaiphantu.EditValue.ToString().Equals("DZ"))
                        {
                            t = "LINESTRING (" + textToado.Text + ")";
                        }
                        else
                        {
                            t = "POINT (" + textToado.Text + ")";
                        } 
                        string query = "INSERT INTO M_VITRI VALUES ('"+DVQuanLy+"',"+idPTDien+",'','"+txtMaPmis.Text+"',geometry::STGeomFromText('"+t+"', 0));";
                        Err = 1;
                        obj.insertORupdateVitri(query); 
                        //_objV.MA_PMIS = txtMaPmis.Text;
                        /*if (cbLoaiphantu.EditValue.ToString().Equals("DZ"))
                        {
                            string t = "LINESTRING (" + textToado.Text + ")";
                            var binary = convertBinary(t);
                            _objV.TOA_DO = new System.Data.Linq.Binary(System.Text.Encoding.ASCII.GetBytes(t));
                        }
                        else
                        {
                            string t = "POINT (" + textToado.Text + ")";
                            _objV.TOA_DO = new System.Data.Linq.Binary(System.Text.Encoding.ASCII.GetBytes(t));
                        }
                        obj.addViTri(_objV);*/
                        M_TTHAI_PTDIEN _objTT = new M_TTHAI_PTDIEN();
                        _objTT.ID_PTDIEN = idPTDien;
                        _objTT.MA_DVQLY = DVQuanLy;
                        _objTT.TRANG_THAI = 1;
                        _objTT.THOI_DIEM = obj.getDateServer();
                        _objTT.UserName = userName;
                        obj.addTrangThai(_objTT);
                        M_TTHAI_PTDIEN_VM _objTTVM = new M_TTHAI_PTDIEN_VM();
                        _objTTVM.ID_PTDIEN = idPTDien;
                        _objTTVM.MA_DVQLY = DVQuanLy;
                        _objTTVM.TRANG_THAI = 1;
                        _objTTVM.THOI_DIEM = obj.getDateServer();
                        _objTTVM.UserName = userName;
                        obj.addTrangThai_VM(_objTTVM);
                        M_TTHAI_PTDIEN_LR _objLR = new M_TTHAI_PTDIEN_LR();
                        _objLR.ID_PTDIEN = idPTDien;
                        _objLR.LEFT_TRANGTHAI = true;
                        _objLR.RIGHT_TRANGTHAI = true;
                        _objLR.CHIEUDONGDIEN = 'L';
                        _objLR.NGAY_CAP_NHAT = obj.getDateServer();
                        obj.addTrangThai(_objLR);
                        M_TTHAI_PTDIEN_LR_VM _objLRVM = new M_TTHAI_PTDIEN_LR_VM();
                        _objLRVM.ID_PTDIEN = idPTDien;
                        _objLRVM.LEFT_TRANGTHAI = true;
                        _objLRVM.RIGHT_TRANGTHAI = true;
                        _objLRVM.CHIEUDONGDIEN = true;
                        _objLRVM.NGAY_CAP_NHAT = obj.getDateServer();
                        obj.addTrangThai_VM(_objLRVM);
                        MessageBox.Show("Tạo phần tử thành công.");
                        this.Close();
                    }
                    catch (Exception)
                    {
                        if (Err==1)
                        {
                            obj.deleteTT(idPTDien);
                            obj.deleteTTVM(idPTDien);
                            obj.deleteTTLR(idPTDien);
                            obj.deleteTTLRVM(idPTDien);
                            string query = "delete from M_VITRI where ID_PTDIEN=" + idPTDien;
                            obj.deleteVT(query);
                            obj.delete(idPTDien);
                        }
                        MessageBox.Show("Có lỗi xảy ra.Thao tác tạo phần tử chưa thực hiện được.Bạn vui lòng kiểm tra và thử lại.");
                    }
                }
                else {
                    MessageBox.Show("Tọa độ, tên phần tử,mã Pmis,mã Pmischa không được để trống");
                }
            }
            else
            {
                MessageBox.Show("Mã Pmiss đã tồn tại. Vui lòng nhập mã khác");
            }
        }
        public string convertBinary(string td) { 
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] buf = encoding.GetBytes(td);

            StringBuilder binaryStringBuilder = new StringBuilder();
            foreach (byte b in buf)
            {
                binaryStringBuilder.Append(Convert.ToString(b, 2));
            }
            return binaryStringBuilder.ToString();
            
        }
        private void cbDonviquanly_SelectedIndexChanged(object sender, EventArgs e)
        {
            DVQuanLy = lstDVQL.ElementAt(cbDonviquanly.SelectedIndex);
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime dt = obj.getDateServer();
            string rd = DVQuanLy + "_DZ_AUTO_"+dt.Day.ToString("00")+dt.Month.ToString("00")+dt.Year.ToString("00")+random();
            txtMaPmis.Text=rd;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                GeoPoint Ga = null, Gb = null;
                double k1 = 0, k2 = 0, khoangcach = 0;
                string[] td = textToado.Text.Split(',');
                if (td.Count() > 1)
                {
                    for (int i = 0; i < td.Count(); i++)
                    {
                        string[] td1 = td[i].Split(' ');
                        double x = double.Parse(td1[0]);
                        double y = double.Parse(td1[1]);
                        if (i == 0)
                        {
                            Ga = new GeoPoint(x, y);
                        }
                        if (i == 1)
                        {
                            Gb = new GeoPoint(x, y);
                            k1 = GeoMath.GetEquirectangularDistance(Ga, Gb);
                            Ga = Gb;
                        }
                        if (i != 0 && i != 1)
                        {
                            Gb = new GeoPoint(x, y);
                            k2 = GeoMath.GetEquirectangularDistance(Ga, Gb);
                            khoangcach = khoangcach + k2;
                            Ga = Gb;
                        }
                    }
                    khoangcach = k1 + khoangcach;
                    MessageBox.Show("Chiều dài khoảng cách là " + string.Format("{0:0.##}", khoangcach * 1000) + " mét (" + string.Format("{0:0.##}", khoangcach) + " km)");
                    
                }
                else
                {
                    MessageBox.Show("Bạn mới chọn 1 điểm, không thể tính được khoảng cách. Vui lòng chọn ít nhất 2 điểm trở lên");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra bạn vui lòng kiểm tra lại.Không thể tính khoảng cách.");
            }
        }

        private string random()
        {
            int Numrd, Numrd1, Numrd2, Numrd3, Numrd4, Numrd5;
            string Numrd_str, Numrd_str1, Numrd_str2, Numrd_str3, Numrd_str4, Numrd_str5;
            Random rd = new Random();
            Numrd = rd.Next(1, 99);
            Numrd_str = rd.Next(1, 100).ToString("00");
            Numrd1 = rd.Next(1, 99);
            Numrd_str1 = rd.Next(1, 100).ToString("00");
            Numrd2 = rd.Next(1, 99);
            Numrd_str2 = rd.Next(1, 100).ToString("00");
            Numrd3 = rd.Next(1, 99);
            Numrd_str3 = rd.Next(1, 100).ToString("00");
            Numrd4 = rd.Next(1, 99);
            Numrd_str4 = rd.Next(1, 100).ToString("00");
            Numrd5 = rd.Next(1, 99);
            Numrd_str5 = rd.Next(1, 100).ToString("00");
            string TextRdT, TextRdH;
            TextRdH = Convert.ToString((char)rd.Next(65, 90));
            TextRdT = Convert.ToString((char)rd.Next(97, 122));
            return TextRdH + TextRdT + Numrd_str + Numrd_str1 + Numrd_str2 + Numrd_str3 + Numrd_str4 + Numrd_str5;
        }
    }
}
