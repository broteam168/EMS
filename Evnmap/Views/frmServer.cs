using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

using LDSong.Libs;
using System.Data.SqlClient;

namespace LDSong.Views
{
    public partial class frmServer : DevExpress.XtraEditors.XtraForm
    {
        //private DataTable tbl;
        private string con;
        private SqlConnection conSQL;
        private bool con1 = false;
        public frmServer()
        {
            InitializeComponent();
            try
            {
                string s = LDSong.Properties.Settings.Default.connect;
                string[] s1 = s.Split(';');
                for (int i = 0; i < s1.Length; i++)
                {
                    string[] s2 = s1[i].Split('=');
                    if (i==0)
                    {
		                txtServer.Text = s2[1];
                    }
                    if (i==1)
                    {
                        txtDB.Text = s2[1];
                    }
                    if (i == 2)
                    {
                        txtUser.Text = s2[1];
                    }
                    if (i == 3)
                    {
                        txtPass.Text = s2[1];
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            if (con1==true)
            {
                LDSong.Properties.Settings.Default.connect = con;
                LDSong.Properties.Settings.Default.Save();
                MessageBox.Show("Ghi cấu hình thành công!", "Thông báo");
                Application.Restart();
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra kêt nối trước khi ghi cấu hình","Thông báo!");
            }
            /*tbl = new DataTable();    
            tbl.TableName = "SERVER";
            tbl.Columns.Add("SRV", typeof(string));
            tbl.Columns.Add("DB", typeof(string));
            tbl.Columns.Add("USER", typeof(string));
            tbl.Columns.Add("PASS", typeof(string));
            DataRow dr = tbl.NewRow();
            dr["SRV"] = clsFunction.Encrypt(txtServer.Text);
            dr["DB"] = clsFunction.Encrypt(txtDB.Text);
            dr["USER"] = clsFunction.Encrypt(txtUser.Text);
            dr["PASS"] = clsFunction.Encrypt(txtPass.Text);
            tbl.Rows.Add(dr);
            tbl.AcceptChanges();

            DataSet ds = new DataSet();
            ds.DataSetName = "CONFIG";
            ds.Tables.Add(tbl);
            ds.WriteXml(Directory.GetCurrentDirectory() + @"\Config\CONFIG.xml");
            MessageBox.Show( "Ghi dữ liệu thành công, khởi động lại chương trình","Thông báo");
            Application.Exit();*/
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            /*try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\Config\CONFIG.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(Directory.GetCurrentDirectory() + @"\Config\CONFIG.xml");
                    tbl = ds.Tables[0];
                    DataRow dr = tbl.Rows[0];
                    txtServer.Text = clsFunction.Decrypt(dr["SRV"].ToString());
                    txtDB.Text = clsFunction.Decrypt(dr["DB"].ToString());
                    txtUser.Text = clsFunction.Decrypt(dr["USER"].ToString());
                    txtPass.Text = clsFunction.Decrypt(dr["PASS"].ToString());
                }
            }
            catch { }*/
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btcheckConnection_Click(object sender, EventArgs e)
        {
            
             checkConnection(txtServer.Text,txtDB.Text,txtUser.Text,txtPass.Text);
            
        }
        private void checkConnection(string server, string data, string user, string pass) {
            con = "Data Source=" + server + ";Initial Catalog=" + data + ";User ID=" + user + ";Password=" + pass + ";";
            conSQL = new SqlConnection(con);
            try
            {
                conSQL.Open();
                MessageBox.Show("Kết nối thành công!", "Thông báo");
                con1 = true;
            }
            catch (Exception)
            {
                con1 = false;
                MessageBox.Show("Kết nối thất bại!", "Thông báo");
            }
            finally
            {
                conSQL.Close();
            }
        }
    }
}