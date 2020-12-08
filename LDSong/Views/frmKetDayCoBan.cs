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
    public partial class frmKetDayCoBan : Form
    {
        private CD_KDCBcontroler obj;
        private string dvql;
        private int idPTDienR, idPTDienL;
        public frmKetDayCoBan(string dvql)
        {
            this.dvql = dvql;
            InitializeComponent();
            obj = new CD_KDCBcontroler();
            gridDSDao.DataSource = obj.listCD(dvql);
            if (DanhSachDao.DataRowCount!=0)
            {
                DanhSachDao.FocusedRowHandle = 1;
            }
            gridConDaoALL.DataSource = obj.listCDAll(dvql);
            if (DanhSachDaoALL.DataRowCount != 0)
            {
                DanhSachDaoALL.FocusedRowHandle = 1;
            }
        }

        private void DanhSachDaoALL_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                idPTDienR = int.Parse(DanhSachDaoALL.GetFocusedRowCellValue("ID_PTDIEN").ToString());
            }
            catch (Exception)
            {
                
            }
        }

        private void btThemDao_Click(object sender, EventArgs e)
        {
            if (obj.chechexist(idPTDienR))
            {
                M_TTHAI_CD_KDCB _obj = new M_TTHAI_CD_KDCB();
                _obj.ID_PTDIEN=idPTDienR;
                obj.add(_obj);
                gridDSDao.DataSource = obj.listCD(dvql);
                if (DanhSachDao.DataRowCount != 0)
                {
                    DanhSachDao.FocusedRowHandle = 1;
                }
            }
            else
            {
                MessageBox.Show("Phần tử này đã có, không thể thêm.");
            }
        }

        private void DanhSachDao_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                idPTDienL = int.Parse(DanhSachDao.GetFocusedRowCellValue("ID_PTDIEN").ToString());
            }
            catch (Exception)
            {
                
            }
        }

        private void btGoBoDao_Click(object sender, EventArgs e)
        {
            obj.delete(idPTDienL);
            gridDSDao.DataSource = obj.listCD(dvql);
            if (DanhSachDao.DataRowCount != 0)
            {
                DanhSachDao.FocusedRowHandle = 1;
            }
        }
    }
}
