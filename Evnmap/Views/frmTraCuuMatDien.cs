using DevExpress.XtraEditors;
using LDSong.Controlers;
using LDSong.Libs;
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
    public partial class frmTraCuuMatDien : DevExpress.XtraEditors.XtraForm
    {
        private static int _MenuId = 38;
        private TraCuuMatDienTram obj;
        private string dvql;
        private int idPTDien;
        public frmTraCuuMatDien()
        {
            InitializeComponent();
            obj = new TraCuuMatDienTram();
            
        }
        public frmTraCuuMatDien(string dvql)
        {
            this.dvql = dvql;
            InitializeComponent();
            obj = new TraCuuMatDienTram();

        }
        

        private void frmTraCuuMatDien_Load(object sender, EventArgs e)
        {
            LDSFunction Fn = new LDSFunction();
            List<string> menus = Fn.getMenuByUser("cmd", _MenuId);

            foreach (string item in menus)
            {
                SimpleButton ctl = this.Controls.Find(item, true).FirstOrDefault() as SimpleButton;
                ctl.Enabled = true;
            }
            dateBegin.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            dateBegin.Properties.Mask.EditMask = "dd/MM/yyyy";
            dateBegin.Properties.Mask.UseMaskAsDisplayFormat = true;
            dateBegin.Properties.CharacterCasing = CharacterCasing.Upper;
            dateEnd.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            dateEnd.Properties.Mask.EditMask = "dd/MM/yyyy";
            dateEnd.Properties.Mask.UseMaskAsDisplayFormat = true;
            dateEnd.Properties.CharacterCasing = CharacterCasing.Upper;
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                gridControlPT.DataSource = null;
                int id = int.Parse(textBoxID.Text.Trim()); 
                gridControlPT.DataSource = obj.getListTram(id, dvql);
                if (PTDien.DataRowCount != 0)
                {
                    PTDien.FocusedRowHandle = 1;
                }
                else
                {
                    MessageBox.Show("Không tìm được trạm nào theo điều kiện bạn nhập.");
                }
            }
            catch (Exception)
            {
                if (textMatram.Text.Trim()!="")
                {
                    gridControlPT.DataSource = obj.getListTram1(textMatram.Text.Trim(), dvql);
                    if (PTDien.DataRowCount != 0)
                    {
                        PTDien.FocusedRowHandle = 1;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm được trạm nào theo điều kiện bạn nhập.");
                    }
                }
                else
                {
                    if (textBoxTenTram.Text.Trim()!="")
                    {
                        gridControlPT.DataSource = obj.getListTram(textBoxTenTram.Text.Trim(), dvql);
                        if (PTDien.DataRowCount != 0)
                        {
                            PTDien.FocusedRowHandle = 1;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm được trạm nào theo điều kiện bạn nhập.");
                        }
                    }
                    else
                    {
                        if (textBoxID.Text.Trim()!="")
                        {
                            MessageBox.Show("ID trạm phải là số.Bạn vui lòng kiểm tra lại.");
                        }
                        else
                        {
                            MessageBox.Show("Bạn vui lòng nhập ID trạm hoặc mã trạm hoặc tên trạm để hệ thống có thể tìm kiếm.");
                        }
                    }
                }
            }
        }
        
        private void PTDien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btBaocao.Enabled = false;
            try
            {
                DateTime begin, end;
                begin = dateBegin.DateTime;
                end = dateEnd.DateTime;
                idPTDien = int.Parse(PTDien.GetFocusedRowCellValue("ID_PTDIEN").ToString());
                if (begin.Equals(DateTime.Parse("1/1/0001 12:00:00 AM")) && end.Equals(DateTime.Parse("1/1/0001 12:00:00 AM")))
                {
                    if (checkBox1.Checked)
                    {
                        gridTrangthaiDongcat.DataSource = obj.getListTTOC(idPTDien);
                    }
                    else
                    {
                        gridControlTrangThai.DataSource = obj.getListTTLR(idPTDien);
                    }
                    if (TrangThaiLR.DataRowCount!=0&&checkBox1.Checked==false)
                    {
                        btBaocao.Enabled = true;
                    }
                }
                else
                {
                    if (checkBox1.Checked)
                    {
                        gridTrangthaiDongcat.DataSource = obj.getListTTLR(idPTDien, begin, end);
                    }
                    else
                    {
                        gridControlTrangThai.DataSource = obj.getListTTLR(idPTDien, begin, end);
                    }

                    if (TrangThaiLR.DataRowCount != 0 && checkBox1.Checked == false)
                    {
                        btBaocao.Enabled = true;
                    }
                }
                
            }
            catch (Exception)
            {
                
            }
        }

        private void btBaocao_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime begin, end, TimeBegin, TimeEnd;
                TimeSpan t, sumTime = default(TimeSpan);
                begin = dateBegin.DateTime; 
                end = dateEnd.DateTime;
                List<M_TTHAI_PTDIEN_LR> m;
                if (begin.Equals(DateTime.Parse("1/1/0001 12:00:00 AM")) && end.Equals(DateTime.Parse("1/1/0001 12:00:00 AM")))
                {
                    m = obj.getListTTLR(idPTDien);
                    for (int i = 0; i < m.Count; i++)
                    {
                        if (m[i].THOIGIANKETTHUC != null)
                        {
                            TimeBegin = DateTime.Parse(m[i].NGAY_CAP_NHAT.ToString());
                            TimeEnd = DateTime.Parse(m[i].THOIGIANKETTHUC.ToString());
                            t = TimeEnd - TimeBegin;
                            sumTime =  t+sumTime;
                        }
                    }
                    
                }
                else
                {
                    m = obj.getListTTLR(idPTDien, begin, end);
                    for (int i = 0; i < m.Count; i++)
                    {
                        if (m[i].THOIGIANKETTHUC != null)
                        {
                            TimeBegin = DateTime.Parse(m[i].NGAY_CAP_NHAT.ToString());
                            TimeEnd = DateTime.Parse(m[i].THOIGIANKETTHUC.ToString());
                            t = TimeEnd - TimeBegin;
                            sumTime = sumTime + t;
                        }
                    }
                }
                string sumS = sumTime.Days.ToString("00") + ":" + sumTime.Hours.ToString("00") + ":" + sumTime.Minutes.ToString("00") + ":" + sumTime.Seconds.ToString("00");
                ReportMatDienTram rp = new ReportMatDienTram(dateBegin.Text, dateEnd.Text,sumS);
                rp.DataSource = m;
                rp.ShowPreviewDialog();
            }
            catch (Exception)
            {

            }
        }

        private void textBoxTenTram_TextChanged(object sender, EventArgs e)
        {
            if (PTDien.RowCount!=0)
            {
                if (textBoxTenTram.TextLength==0)
                {
                    gridControlPT.DataSource = null;
                }
            }
        }

        private void textMatram_TextChanged(object sender, EventArgs e)
        {
            if (PTDien.RowCount != 0)
            {
                if (textMatram.TextLength == 0)
                {
                    gridControlPT.DataSource = null;
                }
            }
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            if (PTDien.RowCount != 0)
            {
                if (textBoxID.TextLength == 0)
                {
                    gridControlPT.DataSource = null;
                }
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                gridControlTrangThai.Visible = false;
                gridTrangthaiDongcat.Visible = true;
            }
            else
            {
                gridControlTrangThai.Visible = true;
                gridTrangthaiDongcat.Visible = false;
            }
        }
    }
}
