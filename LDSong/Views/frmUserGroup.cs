using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;

using LDSong.Models;
using LDSong.Controlers;
using LDSong.Libs;

namespace LDSong.Views
{
    public partial class frmUserGroup : DevExpress.XtraEditors.XtraForm
    {
        private static int _MenuId = 12;
        private  S_GROUP obj;
        private GroupControler clsObj;
        private  int _Id;
        private  string[] mnItems;
        private  string _Action = "";
        private bool t, s, x;
        public frmUserGroup()
        {
            InitializeComponent();
        }

        private void frmUserGroup_Load(object sender, EventArgs e)
        {
            clsObj = new GroupControler();

            dgrCtlNhom.DataSource = clsObj.list();
            createMenu(trPhanQuyen);
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
            changeControlState(true);
            dgrNhom.FocusedRowHandle = 1;
            
        }        

        private void dgrNhom_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                _Id = int.Parse(dgrNhom.GetFocusedRowCellValue("GroupId").ToString());
                txtGroupName.Text = dgrNhom.GetFocusedRowCellValue("GroupName").ToString();
                //txtDesc.Text = dgrNhom.GetFocusedRowCellValue("Description").ToString();
                mnItems = dgrNhom.GetFocusedRowCellValue("Permission").ToString().Split(',');
                cbLoai.SelectedIndex = int.Parse(dgrNhom.GetFocusedRowCellValue("GroupDesc").ToString());
                setCheckedMenu(trPhanQuyen.Nodes);
            }
            catch { }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                changeState(trPhanQuyen.Nodes);
            }
            catch { }
        }

        private void changeState(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                node.CheckState = chkAll.CheckState;
                changeState(node.Nodes);
            }
        }

        private void invertState(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                node.CheckState = (node.CheckState == CheckState.Checked) ? CheckState.Unchecked : CheckState.Checked;
                invertState(node.Nodes);
            }
        }

        private void chkInvert_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                invertState(trPhanQuyen.Nodes);
            }
            catch { }
        }

        private void trPhanQuyen_AfterCheckNode(object sender, NodeEventArgs e)
        {
            try
            {
                if (e.Node.CheckState == CheckState.Checked)
                {
                    e.Node.CheckAll();
                }
                else
                {
                    e.Node.UncheckAll();
                }
            }
            catch { }
        }

        private void lMoRong_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            try
            {
                trPhanQuyen.ExpandAll();
            }
            catch { }
        }

        private void lThuGon_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            try
            {
                trPhanQuyen.CollapseAll();
            }
            catch { }
        }
        
        private void cmdGhi_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa nhập tên nhóm !");
                txtGroupName.Focus();
            }
            else{
                obj = new S_GROUP();
                obj.GroupName = txtGroupName.Text.Trim();
                obj.GroupDesc = cbLoai.SelectedIndex.ToString(); 
                obj.Permission = getCheckedMenu(trPhanQuyen.Nodes); 
                obj.GroupId = _Id;
                if (_Action == "ADD")
                {
                    clsObj.add(obj);
                }
                else
                {                    
                    clsObj.update(obj);
                }
                MessageBox.Show("Cập nhật dữ liệu thành công !");
                dgrCtlNhom.DataSource = clsObj.list();
                changeControlState(true);
            }
        }

        private void setCheckedMenu(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                if (mnItems.Contains(node.GetValue("MenuId").ToString())) node.CheckState = CheckState.Checked;
                else node.CheckState = CheckState.Unchecked;
                setCheckedMenu(node.Nodes); 
            }
        }

        private string getCheckedMenu(TreeListNodes nodes)
        {
            string str = "";
            foreach (TreeListNode node in nodes)
            {
                if (node.CheckState == CheckState.Checked) str = str + String.Format("{0},", node.GetValue("MenuId"));
                str += getCheckedMenu(node.Nodes);
            }
            return str;
        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            _Action = "ADD";
            changeControlState(false);
            txtGroupName.Text = "";
            //txtDesc.Text = "";
            chkAll.CheckState = CheckState.Unchecked;
        }

        private void cmdSua_Click(object sender, EventArgs e)
        {
            _Action = "EDIT";
            changeControlState(false);
        }

        private void changeControlState(Boolean _State)
        {
            if (_State)
            {
                if (t)
                {
                    cmdThem.Enabled = _State;
                }
                if (s)
                {
                    cmdSua.Enabled = _State;
                }
                if (x)
                {
                    cmdXoa.Enabled = _State;
                }
            }
            else
            {
                cmdThem.Enabled = _State;
                cmdSua.Enabled = _State;
                cmdXoa.Enabled = _State;
            }
            
            
            cmdGhi.Enabled = !_State;
            cmdHuy.Enabled = !_State;
            txtGroupName.Enabled = !_State;
            cbLoai.Enabled = !_State;
            trPhanQuyen.Enabled = !_State;
            //trPhanQuyen.Enabled = !_State;
            //trPhanQuyen.OptionsView.ShowCheckBoxes = !_State;

            dgrCtlNhom.Enabled = _State;
        }

        private void cmdHuy_Click(object sender, EventArgs e)
        {
            changeControlState(true);
        }

        private void trPhanQuyen_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                e.Node.Checked = !e.Node.Checked;
            }
            catch { }
        }

        private void createMenu(TreeList tr)
        {
            tr.BeginUnboundLoad();
            TreeListNode root = null;
            createNode(tr, root);
            tr.EndUnboundLoad();
        }

        private void createNode(TreeList tr, TreeListNode node, int _Parent = 0)
        {
            List<S_MENU> lst = clsObj.listMenu(_Parent); 
            foreach (S_MENU item in lst)
            {
                TreeListNode tmp = tr.AppendNode(new object[] { item.MenuId, item.MenuName}, node);
                createNode(tr, tmp, item.MenuId); 
            } 
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhóm?", "xác thực", MessageBoxButtons.YesNo);
            if (result==DialogResult.Yes)
            {
                clsObj.delete(int.Parse(dgrNhom.GetFocusedRowCellValue("GroupId").ToString()));
                MessageBox.Show("Xóa thành công");
                dgrCtlNhom.DataSource = clsObj.list();
                changeControlState(true);
            }
        }
    }
}