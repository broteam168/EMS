using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using LDSong.Controlers;
using LDSong.Models;
using LDSong.Libs;

namespace LDSong.Views
{
    public partial class frmDMDonVi : DevExpress.XtraEditors.XtraForm
    {
        private static int _MenuId = 9;
        private string _Action = "";
        private DVQLControler clsObj;
        private D_DVI_QLY obj;

        public frmDMDonVi()
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
            txtDiaChi.Enabled = _isEdit;
            txtDienThoai.Enabled = _isEdit;
            textToaDo.Enabled = _isEdit;

            dgrCtlDonVi.Enabled = !_isEdit;
        }

        private void frmDMDonVi_Load(object sender, EventArgs e)
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
                obj = new D_DVI_QLY();
                clsObj = new DVQLControler();
                changeStatus(false);

                loadDataToGrid();
            }
            catch { }
        }

        private void loadDataToGrid()
        {
            dgrCtlDonVi.DataSource = clsObj.list();
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            _Action = "ADD";
            changeStatus(true);
            txtMaDV.Focus();
            txtMaDV.Text = "";
            txtTenDV.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            _Action = "EDIT";
            changeStatus(true);
            txtMaDV.Enabled = false;
            txtTenDV.Focus();
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            string _msg = "";

            if (txtMaDV.Text!=""&&textToaDo.Text.Trim()!=""&&txtTenDV.Text.Trim()!="")
            {
                obj.MA_DVIQLY = txtMaDV.Text.Trim();
                obj.TEN_DVIQLY = txtTenDV.Text.Trim();
                obj.DIA_CHI = txtDiaChi.Text.Trim();
                obj.DIEN_THOAI = txtDienThoai.Text.Trim();
                obj.TOA_DO = textToaDo.Text.Trim();
                if (_Action == "ADD")
                {
                    if (clsObj.checkExists(txtMaDV.Text))
                    {
                        MessageBox.Show("Mã đơn vị đã tồn tại !", "Lỗi");
                        txtMaDV.Focus();
                        return;
                    }                
                
                    clsObj.add(obj);
                    _msg = "Thêm mới đơn vị thành công !";
                }
                else if (_Action == "EDIT")
                {
                    clsObj.update(obj);
                    _msg = "Cập nhật thông tin đơn vị thành công !";
                }

                _Action = "";
                MessageBox.Show(_msg, "Thông báo");
                changeStatus(false);
                loadDataToGrid();
            }
            else
            {
                MessageBox.Show("Mã đơn vị,tên đơn vị, tọa độ không được để trống");
            }
        }

        private void cmdHuy_Click(object sender, EventArgs e)
        {
            changeStatus(false);
        }

       

        private void dgrDonVi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (dgrDonVi.GetFocusedRowCellValue("MA_DVIQLY") != null)
                {
                    obj.MA_DVIQLY = dgrDonVi.GetFocusedRowCellValue("MA_DVIQLY").ToString();
                    txtMaDV.Text = obj.MA_DVIQLY;
                    txtTenDV.Text = dgrDonVi.GetFocusedRowCellValue("TEN_DVIQLY").ToString();
                    textToaDo.Text = dgrDonVi.GetFocusedRowCellValue("TOA_DO").ToString();
                    cmdSua.Enabled = true;
                    cmdXoa.Enabled = true;
                    txtDiaChi.Text = dgrDonVi.GetFocusedRowCellValue("DIA_CHI").ToString();
                    txtDienThoai.Text = dgrDonVi.GetFocusedRowCellValue("DIEN_THOAI").ToString();
                    
                    
                }
            }
            catch {  }
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (obj.MA_DVIQLY.Equals("PN"))
                {
                    MessageBox.Show("Không thể xóa đơn vị này.");
                }
                else
                {
                    if (MessageBox.Show("Chắc chắn bạn muốn xóa thông tin đơn vị không ?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (clsObj.checkExist(obj.MA_DVIQLY))
                        {
                            clsObj.delete(obj.MA_DVIQLY);
                            loadDataToGrid();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa vì đơn vị này đã được liên kết");
                        }
                    }
                }
            }
            catch { }
        }

    }
}