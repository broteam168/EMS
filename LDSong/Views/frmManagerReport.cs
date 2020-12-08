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
    public partial class frmManagerReport : DevExpress.XtraEditors.XtraForm
    {
        ManageReport obj;
        private string dvql;
        public frmManagerReport(string dvql)
        {
            this.dvql = dvql;
            InitializeComponent();
            obj = new ManageReport();
            gridBaoCao.DataSource = obj.getList();
        }

        private void BaoCao_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            textTen.Text = BaoCao.GetFocusedRowCellValue("TENBAOCAO").ToString();
            textTieuDe.Text = BaoCao.GetFocusedRowCellValue("TIEUDEBAOCAO").ToString();
            textChucDanh.Text = BaoCao.GetFocusedRowCellValue("CHUCDANH").ToString();
            textNguoiKy.Text = BaoCao.GetFocusedRowCellValue("NGUOIKY").ToString();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (textTen.Text.Trim() != null && textTieuDe.Text.Trim() != null && textNguoiKy.Text.Trim() != null && textChucDanh.Text.Trim() != null)
            {
                S_BAOCAO _obj = new S_BAOCAO();
                _obj.ID = int.Parse(BaoCao.GetFocusedRowCellValue("ID").ToString());
                _obj.TENBAOCAO = textTen.Text;
                _obj.TIEUDEBAOCAO = textTieuDe.Text;
                _obj.CHUCDANH = textChucDanh.Text;
                _obj.NGUOIKY = textNguoiKy.Text;
                obj.update(_obj);
                MessageBox.Show("Cập nhật thành công.");
            }
            else
            {
                MessageBox.Show("Các trường không được để trống.");
            }
        }

    }
}
