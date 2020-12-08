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
    public partial class frmCapdienap :   DevExpress.XtraEditors.XtraForm
    {
        private static int _MenuId = 8;
        private string _Action = "";
        private CapDienApControler clsObj;
        private D_CAP_DAP obj;
        private bool t, s, x;
        public frmCapdienap()
        {
            InitializeComponent();
        }
        private void changeStatus(Boolean _isEdit)
        {
            if (_isEdit)
            {
                if (t)
                {
                    cmdThem.Enabled = _isEdit;
                }
                if (s)
                {
                    cmdSua.Enabled = _isEdit;
                }
                if (x)
                {
                    cmdXoa.Enabled = _isEdit;
                }
            }
            else
            {
                cmdThem.Enabled = !_isEdit;
                cmdSua.Enabled = !_isEdit;
                cmdXoa.Enabled = !_isEdit;
            }

            

            cmdGhi.Enabled = _isEdit;
            cmdHuy.Enabled = _isEdit;

            txtMaDV.Enabled = _isEdit;
            txtTenDV.Enabled = _isEdit;
            txtDiaChi.Enabled = _isEdit;

            dgrCtlDonVi.Enabled = !_isEdit;
        }

        private void frmLoad(object sender, EventArgs e)
        {
            LDSFunction Fn = new LDSFunction();
            List<string> menus = Fn.getMenuByUser("cmd", _MenuId);
            foreach (string item in menus)
            {

                SimpleButton ctl = this.Controls.Find(item, true).FirstOrDefault() as SimpleButton;
                ctl.Enabled = true;
            }
            t = cmdThem.Enabled;
            s = cmdSua.Enabled;
            x = cmdXoa.Enabled;
            try
            {
                obj = new D_CAP_DAP();
                clsObj = new CapDienApControler();
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

            obj.MA_CAPDA = txtMaDV.Text.Trim();
            obj.MA_PMIS = txtTenDV.Text.Trim();
            obj.TEN_CAPDA = txtDiaChi.Text.Trim();
            if (_Action == "ADD")
            {
                if (clsObj.checkExists(txtMaDV.Text))
                {
                    MessageBox.Show("Mã CAPDA đã tồn tại !", "Lỗi");
                    txtMaDV.Focus();
                    return;
                }

                clsObj.add(obj);
                _msg = "Thêm mới cấp điện áp thành công !";
            }
            else if (_Action == "EDIT")
            {
                clsObj.update(obj);
                _msg = "Cập nhật thông tin cấp điện áp thành công !";
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
            txtDiaChi.Text = "";
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
                if (MessageBox.Show("Chắc chắn bạn muốn xóa thông tin cấp điện áp không ?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (clsObj.checkExist(obj.MA_CAPDA))
                    {
                        clsObj.delete(obj.MA_CAPDA);
                        loadDataToGrid();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa vì cấp điện áp này đã được liên kết");
                    }
                        
                }
            }
            catch { }
        }

        private void ChosseRow(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (dgrDonVi.GetFocusedRowCellValue("MA_CAPDA") != null)
                {
                    obj.MA_CAPDA = dgrDonVi.GetFocusedRowCellValue("MA_CAPDA").ToString();
                    txtMaDV.Text = obj.MA_CAPDA;
                    txtTenDV.Text = dgrDonVi.GetFocusedRowCellValue("MA_PMIS").ToString();
                    txtDiaChi.Text = dgrDonVi.GetFocusedRowCellValue("TEN_CAPDA").ToString();
                    cmdSua.Enabled = true;
                    cmdXoa.Enabled = true;
                }
            }
            catch { }
        }
    }
}
