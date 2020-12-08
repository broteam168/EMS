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
    public partial class frmListYeuCau : DevExpress.XtraEditors.XtraForm
    {
        private string dvql;
        private ListYeuCauControler obj;
        public frmListYeuCau(string dvql)
        {
            this.dvql = dvql;
            InitializeComponent();
            obj = new ListYeuCauControler();
            cbTinhTrang.SelectedIndex = 0;
            initDVQL(dvql);
        }
        public void initDVQL(string dvql) {
            cbDvql.Properties.DataSource = obj.listdvql(dvql);
            cbDvql.Properties.NullText = "Vui lòng chọn đơn vị quản lý.";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateBegin.Text != "" && dateEnd.Text != "")
                {
                    DateTime begin, end;
                    begin = dateBegin.DateTime;
                    end = dateEnd.DateTime;
                    string[] b = begin.ToString().Split(' ');
                    string[] c = end.ToString().Split(' ');
                    gridListYC.DataSource = obj.listYeuCau(cbTinhTrang.SelectedIndex, cbDvql.EditValue.ToString(), b[0] + " 00:00:01", c[0] + " 23:59:59");
                }
                else
                {
                    MessageBox.Show("Bạn không được để trống thời gian bắt đầu và thời gian kết thúc.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra! Bạn vui lòng kiểm tra lại thao tác.");
            }
        }
        
    }
}
