using DevExpress.XtraMap;
using LDSong.Controlers;
using LDSong.Libs;
using LDSong.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDSong.Views
{
    public partial class frmUpdateAllPTDien : Form
    {
        private CreatePTDienControler obj;
        private int id;
        public static bool tt=false;
        private string userName, DVQuanLy,maPmis;
        private List<string> lstDVQL;
        public frmUpdateAllPTDien()
        {
            tt = false;
            InitializeComponent();
        }
        public frmUpdateAllPTDien(int id, string userName, string dvql, bool _dz = false)
        {
            tt = false;
            InitializeComponent();
            this.userName = userName;
            this.DVQuanLy = dvql;
            this.id = id;
            obj = new CreatePTDienControler();
            cbLoaiphantu.Properties.NullText = "Vui lòng chọn loại phần tử";
            cbCapdienap.Properties.NullText = "Vui lòng chọn cấp điện áp";
            cbDonviquanly.Properties.NullText = "Vui lòng chọn đơn vị quản lý";
            cbCapdienap.Properties.DataSource = obj.listCapDienAp();
            cbLoaiphantu.Properties.DataSource = obj.listLoaiThietBi(_dz);
            initComboboxDonvi();
            M_VITRI_V2 m= obj.getAllPTDien(id);
            textToado.Text = obj.toado;
            txtTen.Text = m.TEN_PTDIEN;
            txtMaCmis.Text = m.MA_CMIS;
            txtMaPmis.Text = m.MA_PMIS;
            maPmis = m.MA_PMIS;
            txtMaPmischa.Text = m.MA_PMISCHA;
            txtMaScada.Text = m.MA_SCADA;
            cbCapdienap.EditValue = m.MA_CAPDA;
            cbLoaiphantu.EditValue = m.LOAI_PTDIEN;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textToado.Enabled = true;
        }
        public void initComboboxDonvi()
        {
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
                        string[] td1 = td[i].Trim().Split(' ');
                        double x = double.Parse(td1[0].Trim());
                        double y = double.Parse(td1[1].Trim());
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ofdMain.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (ofdMain.ShowDialog() != DialogResult.Cancel)
            {
                CreateAttachment(ofdMain.FileName);
            }
        }
        private void CreateAttachment(string strFile)
        {
            try
            {
                FileStream objFileStream = new FileStream(strFile, FileMode.Open, FileAccess.Read);
                int intLength = Convert.ToInt32(objFileStream.Length);
                byte[] objData;
                objData = new byte[intLength];
                string[] strPath = strFile.Split(Convert.ToChar(@"\"));

                objFileStream.Read(objData, 0, intLength);
                objFileStream.Close();

                D_Image oImage = new D_Image();
                oImage.ID_PTDIEN = id;
                oImage.Image = objData;
                oImage.Ngay_up = obj.getDateServer();
                oImage.Nguoi_up = userName;
                obj.addImage(oImage);
                MessageBox.Show("Thêm ảnh thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra không thể tải file.Bạn vui lòng kiểm tra lại. " + ex);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbLoaiphantu.EditValue.ToString().Equals("TT"))
                {

                }
                else
                {
                    MessageBox.Show("Chỉ hỗ trợ cập nhật thông số cho trạm biến áp.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể thêm,bạn vui lòng kiểm tra lại.");
            }
        }

        private void cbDonviquanly_SelectedIndexChanged(object sender, EventArgs e)
        {
            DVQuanLy = lstDVQL.ElementAt(cbDonviquanly.SelectedIndex);
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string t;
            if (textToado.Text != "" && txtTen.Text != "" && txtMaPmis.Text != "" && txtMaPmischa.Text != "")
            {
                try
                {
                    if (maPmis.Equals(txtMaPmis.Text.Trim()))
                    {
                        D_PTDIEN _obj = new D_PTDIEN();
                        _obj.ID_PTDIEN = id;
                        _obj.TEN_PTDIEN = txtTen.Text;
                        _obj.MA_DVQLY = DVQuanLy;
                        _obj.MA_CAPDA = cbCapdienap.EditValue.ToString();
                        _obj.TEN_CAPDA = cbCapdienap.Text;
                        _obj.MA_CMIS = txtMaCmis.Text;
                        _obj.LOAI_PTDIEN = cbLoaiphantu.EditValue.ToString();
                        _obj.MA_PMIS = txtMaPmis.Text;
                        _obj.MA_PMISCHA = txtMaPmischa.Text;
                        _obj.NGAY_SUA = obj.getDateServer();
                        _obj.NGUOI_SUA = userName;
                        _obj.MA_SCADA = txtMaScada.Text;
                        obj.updatePTDien(_obj);
                        // 
                        if (cbLoaiphantu.EditValue.ToString().Equals("DZ"))
                        {
                            t = "LINESTRING (" + textToado.Text + ")";
                        }
                        else
                        {
                            t = "POINT (" + textToado.Text + ")";
                        }
                        string query = "update M_VITRI set MA_DVQLY='" + DVQuanLy + "',MA_PMIS='" + txtMaPmis.Text + "',TOA_DO =geometry::STGeomFromText('" + t + "',0) where ID_PTDIEN=" + id;
                        obj.insertORupdateVitri(query);
                        tt = true;
                        MessageBox.Show("Cập nhật thông tin phần tử điện thành công");
                        this.Close();
                    }
                    else
                    {
                        if (obj.checkMaPmiss(txtMaPmis.Text.Trim()))
                        {
                            D_PTDIEN _obj = new D_PTDIEN();
                            _obj.ID_PTDIEN = id;
                            _obj.TEN_PTDIEN = txtTen.Text;
                            _obj.MA_DVQLY = DVQuanLy;
                            _obj.MA_CAPDA = cbCapdienap.EditValue.ToString();
                            _obj.TEN_CAPDA = cbCapdienap.Text;
                            _obj.MA_CMIS = txtMaCmis.Text;
                            _obj.LOAI_PTDIEN = cbLoaiphantu.EditValue.ToString();
                            _obj.MA_PMIS = txtMaPmis.Text;
                            _obj.MA_PMISCHA = txtMaPmischa.Text;
                            _obj.NGAY_SUA = obj.getDateServer();
                            _obj.NGUOI_SUA = userName;
                            _obj.MA_SCADA = txtMaScada.Text;
                            obj.updatePTDien(_obj);
                            // 
                            if (cbLoaiphantu.EditValue.ToString().Equals("DZ"))
                            {
                                t = "LINESTRING (" + textToado.Text + ")";
                            }
                            else
                            {
                                t = "POINT (" + textToado.Text + ")";
                            }
                            string query = "update M_VITRI set MA_DVQLY='" + DVQuanLy + "',MA_PMIS='" + txtMaPmis.Text + "',TOA_DO =geometry::STGeomFromText('" + t + "',0) where ID_PTDIEN=" + id;
                            obj.insertORupdateVitri(query);
                            tt = true;
                            MessageBox.Show("Cập nhật thông tin phần tử điện thành công");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Mã Pmis đã tồn tại. Bạn vui lòng nhập mã Pmis khác.");
                        }
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Có lỗi xảy ra.Thao tác tạo phần tử chưa thực hiện được.Bạn vui lòng kiểm tra và thử lại.");
                }
            }
            else
            {
                MessageBox.Show("Tọa độ, tên phần tử,mã Pmis,mã Pmischa không được để trống");
            }
        }
    }
}
