using DevExpress.XtraEditors;
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
    public partial class frmLoaiYeuCau : DevExpress.XtraEditors.XtraForm
    {
        private static int _MenuId = 10;
        private string _Action = "";
        private LoaiyeucauControler clsObj;
        private D_LOAI_YCAU obj;
        public frmLoaiYeuCau()
        {
            InitializeComponent();
        }
        private void changeStatus(Boolean _isEdit)
        {

            cmdThem.Enabled = !_isEdit;
            cmdSua.Enabled = !_isEdit;
            cmdXoa.Enabled = !_isEdit;

            cmdGhi.Enabled = _isEdit;
            cmdHuy.Enabled = _isEdit;

            txtMaDV.Enabled = _isEdit;
            txtTenDV.Enabled = _isEdit;

            dgrCtlDonVi.Enabled = !_isEdit;
        }

        private void loadForm(object sender, EventArgs e)
        {
            LDSFunction Fn = new LDSFunction();
            List<string> menus = Fn.getMenuByUser("cmd", _MenuId);
            foreach (string item in menus)
            {

                SimpleButton ctl = this.Controls.Find(item, true).FirstOrDefault() as SimpleButton;
                ctl.Enabled = true;
            }
            try
            {
                obj = new D_LOAI_YCAU();
                clsObj = new LoaiyeucauControler();
                changeStatus(false);

                loadDataToGrid();
            }
            catch { }
        }
        private void loadDataToGrid()
        {
            dgrCtlDonVi.DataSource = clsObj.list();
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            string _msg = "";

            obj.MA_LOAI = txtMaDV.Text.Trim();
            obj.TEN_LOAI = txtTenDV.Text.Trim();
            if (_Action == "ADD")
            {
                if (clsObj.checkExists(txtMaDV.Text))
                {
                    MessageBox.Show("Mã yêu cầu đã tồn tại !", "Lỗi");
                    txtMaDV.Focus();
                    return;
                }

                clsObj.add(obj);
                _msg = "Thêm mới loại yêu cầu thành công !";
            }
            else if (_Action == "EDIT")
            {
                clsObj.update(obj);
                _msg = "Cập nhật thông tin loại yêu cầu thành công !";
            }

            _Action = "";
            MessageBox.Show(_msg, "Thông báo");
            changeStatus(false);
            loadDataToGrid();
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            _Action = "ADD";
            changeStatus(true);
            txtMaDV.Focus();
            txtMaDV.Text = "";
            txtTenDV.Text = "";
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            _Action = "EDIT";
            changeStatus(true);
            txtMaDV.Enabled = false;
            txtTenDV.Focus();
        }

        private void cmdHuy_Click(object sender, EventArgs e)
        {
            changeStatus(false);
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Chắc chắn bạn muốn xóa thông tin loại yêu cầu không ?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    clsObj.delete(obj.MA_LOAI);
                    loadDataToGrid();
                }
            }
            catch { }
        }

        private void chosseRow(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (dgrDonVi.GetFocusedRowCellValue("MA_LOAI") != null)
                {
                    obj.MA_LOAI = dgrDonVi.GetFocusedRowCellValue("MA_LOAI").ToString();
                    txtMaDV.Text = obj.MA_LOAI;
                    txtTenDV.Text = dgrDonVi.GetFocusedRowCellValue("TEN_LOAI").ToString();
                    cmdSua.Enabled = true;
                    cmdXoa.Enabled = true;
                }
            }
            catch { }
        }
    }
}
