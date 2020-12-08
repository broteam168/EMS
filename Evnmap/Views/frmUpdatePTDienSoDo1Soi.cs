using LDSong.Controlers;
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
    public partial class frmUpdatePTDienSoDo1Soi : Form
    {
        private int idPTDien;
        private string dvql,loai;
        private CreatePTDSoDo1SoiControler obj;
        private M_VITRI_SD1S_V2 objPTD;
        M_NOTE_V objNote;
        public static bool success = false;
        public frmUpdatePTDienSoDo1Soi()
        {
            InitializeComponent();
        }
        public frmUpdatePTDienSoDo1Soi(int idPTDien,string dvql,string loai)
        {
            InitializeComponent();
            success = false;
            this.idPTDien = idPTDien;
            this.dvql = dvql;
            this.loai = loai;
            obj = new CreatePTDSoDo1SoiControler();
            if (!loai.Equals("NT"))
            {
                initPTD();
            }
            else
            {
                radioDoc.Enabled = false;
                radioNgang.Enabled = false;
                labelControl1.Text = "Tên ghi chú:";
                initNote();
            }
        }
        public void initPTD(){
            objPTD = obj.getAllPTDien(idPTDien);
            textToado.Text = obj.toado;
            if (objPTD.KIEU.Equals('V'))
            {
                radioDoc.Checked = true;
            }
            else
            {
                radioNgang.Checked = true;
            }
            txtIDPTDien.Text = objPTD.ID_PTDIEN.ToString();
            txtTen.Text = objPTD.TEN_PTDIEN;
        }
        public void initNote()
        {
            objNote = obj.getAllNote(idPTDien);
            textToado.Text = obj.toado;
            txtIDPTDien.Text = objNote.SIZEFONT.ToString();
            txtTen.Text = objNote.NDGHICHU;
            txtIDPTDien.Enabled = true;
            txtTen.Enabled = true;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textToado.Enabled = true;
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            if (textToado.Text!="")
            {
                try
                {
                    if (!loai.Equals("NT")) // cap nhat phan tu dien
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
                        string query = "update  M_VITRI_SD1S set VITRI=geometry::STGeomFromText('" + t + "',0),KIEU='" + k + "'  where ID_PTDIEN=" + txtIDPTDien.Text;
                        obj.insertORupdateVitri(query);
                        MessageBox.Show("cập nhật phần tử điện thành công");
                        success = true;
                        this.Close();
                    }
                    else // cap nhat note
                    {
                        Console.WriteLine("vao day");
                        if (txtTen.Text!=""&&txtIDPTDien.Text!="")
                        {
                            Console.WriteLine("vao day1");
                            try
                            {
                                Console.WriteLine("vao day2");
                                int font = int.Parse(txtIDPTDien.Text.ToString()); Console.WriteLine("vao day3");
                                if (font>=1&&font<=20)
                                {
                                    string t = "POINT (" + textToado.Text + ")";
                                    string query = "update  M_NOTE set VITRI=geometry::STGeomFromText('" + t + "',0),NDGHICHU='" + txtTen.Text + "',SIZEFONT=" + font + "  where ID=" + objNote.ID;
                                    Console.WriteLine(query);
                                    obj.insertORupdateVitri(query);
                                    MessageBox.Show("cập nhật phần tử điện thành công");
                                    success = true;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Font chữ lớn hơn hoặc bằng 1 và nhỏ hơn hoăc bằng 20");
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Kích cỡ chữ phải là số nguyên");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Phần ghi chú không được để trống.");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể cập nhật được.Bạn vui lòng kiểm tra lại.");
                }
            }
            else
            {
                MessageBox.Show("Tọa độ không được để trống.");
            }
        }
    }
}
