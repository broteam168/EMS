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

namespace LDSong.Views
{
    public partial class frmCreatePTDSoDo1Soi : Form
    {
        private string dvql,maCapda;
        private CreatePTDSoDo1SoiControler obj;
        public static bool success = false;
        private bool note = false;
        public frmCreatePTDSoDo1Soi()
        {
            InitializeComponent();
        }
        public frmCreatePTDSoDo1Soi(string toado,string dvql,string maCapda)
        {
            obj = new CreatePTDSoDo1SoiControler();
            success = false;
            InitializeComponent();
            textToado.Text = toado;
            this.dvql = dvql;
            this.maCapda = maCapda;
        }
        private void initTable() {
            gridPTDien.DataSource = obj.getListPTDien(dvql);
            if (gridPTDien.DataSource!=null)
            {
                PTDien.FocusedRowHandle = 0;
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textToado.Enabled = true;
        }

        private void PTDien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtIDPTDien.Text = PTDien.GetFocusedRowCellValue("ID_PTDIEN").ToString();
                txtTen.Text = PTDien.GetFocusedRowCellValue("TEN_PTDIEN").ToString();
            }
            catch (Exception)
            {
                
            }
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            if (note==false)// gan phan tu dien
            {
                string q = "select * from M_VITRI_SD1S where ID_PTDIEN="+txtIDPTDien.Text;
                if (txtIDPTDien.Text!=""&&txtTen.Text!="")
                {
                    if (obj.checkExist(q))
                    {
                        try
                        {
                            char k;
                            if (radioDoc.Checked == true)
                            {
                                k = 'V';
                            }
                            else
                            {
                                k = 'H';
                            }
                            string t = "POINT (" + textToado.Text + ")";
                            string query = "INSERT INTO M_VITRI_SD1S VALUES (" + txtIDPTDien.Text + ",geometry::STGeomFromText('" + t + "', 0),'" + k + "');";
                            obj.insertORupdateVitri(query);
                            MessageBox.Show("Thêm phần tử mới thành công");
                            success = true;
                            this.Close();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Không thể thêm phần tử điện, bạn vui lòng kiểm tra lại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phần tử điện này đã có,bạn không thể thêm.");
                    }
                }
                else
                {
                    MessageBox.Show("Tên phần tử điện chưa có.");
                }
            }
            else // tao ghi chu
            {
                if (txtTen.Text!=""&&txtIDPTDien.Text!="")
                {
                    try
                    {
                        try
                        {
                            int font = int.Parse(txtIDPTDien.Text);
                            if (font>=1&&font<=20)
                            {
                                string t = "POINT (" + textToado.Text + ")";
                                string query = "INSERT INTO M_NOTE VALUES ('" + txtTen.Text + "',geometry::STGeomFromText('" + t + "', 0)," + font + ",'"+dvql+"','"+maCapda+"');";
                                obj.insertORupdateVitri(query);
                                MessageBox.Show("Thêm phần tử mới thành công");
                                success = true;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Kích cỡ font chữ không nhỏ hơn 1 và không lớn hơn 20");
                            }
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Kích cỡ font phải là số nguyên");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không thể thêm phần tử điện, bạn vui lòng kiểm tra lại");
                    }
                }
                else
                {
                    MessageBox.Show("Phần tên ghi chú không được để trống");
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            note = false;
            radioDoc.Enabled = true;
            radioNgang.Enabled = true;
            txtIDPTDien.Enabled = false;
            txtTen.Enabled = false;
            txtTen.Text = "";
            labelControl1.Text = "Phần tử điện :";
            initTable();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            note = true;
            radioDoc.Enabled = false;
            radioNgang.Enabled = false;
            txtIDPTDien.Enabled = true;
            txtTen.Enabled = true;
            txtIDPTDien.Text = "8";
            txtTen.Text = "";
            txtIDPTDien.Text = "";
            labelControl1.Text = "Tên ghi chú :";
            
        }
    }
}
