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
    public partial class frmInforQuanHe : Form
    {
        private QHConChaControler clsObj;
        private int idLR;
        public frmInforQuanHe()
        {
            InitializeComponent();
        }
        public frmInforQuanHe(int idCon)
        {
            InitializeComponent();
            lbIDNut.Text = idCon.ToString() ;
            clsObj = new QHConChaControler();
            lbTenCon.Text = clsObj.tenPTD(idCon);
            gridQuanHe.DataSource = clsObj.listConCha(idCon);
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa quan hệ này?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                toadoControler1 obj1 = new toadoControler1();
                obj1.deleteLR(idLR);
                MessageBox.Show("Xóa thành công!");
                gridQuanHe.DataSource = null;
                gridQuanHe.DataSource = clsObj.listConCha(int.Parse(lbIDNut.Text));
            }
        }

        private void quanHe_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                idLR = int.Parse(quanHe.GetFocusedRowCellValue("ID").ToString());
            }
            catch (Exception)
            {

            }
        }

        private void quanHe_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            MenuDelete.Show(gridQuanHe, gridQuanHe.PointToClient(Cursor.Position));
        }
    }
}
