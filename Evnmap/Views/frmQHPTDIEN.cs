using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LDSong.Libs;
using LDSong.Models;
using LDSong.Controlers;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraEditors;

namespace LDSong.Views
{
    public partial class frmQHPTDIEN : DevExpress.XtraEditors.XtraForm
    {
        private static int _MenuId = 19;
        private QHPTDiencontroler clsObj;
        private D_QHE_PTDIEN obj;
        private D_QHE_PTDIEN_VITRI objLR;
        private int idLR;
        private string DVQuanLy, dvql, userName, idPTDien, maCapDa, idQH;
        private string _Action = "";
        private List<string> lstDv;
        public frmQHPTDIEN()
        {
            InitializeComponent();
        }
        public frmQHPTDIEN(string DVQuanLy, string userName)
        {
            this.DVQuanLy = DVQuanLy;
            this.userName = userName;
            InitializeComponent();
            labelNgay.Text = "";
            labelNode.Text = "";
            labelLoaiphantu.Text = "";

        }
        private void initQHPTDIEN(object sender, EventArgs e)
        {
            clsObj = new QHPTDiencontroler();
            LDSFunction Fn = new LDSFunction();
            List<string> menus = Fn.getMenuByUser("cmd", _MenuId);
            foreach (string item in menus)
            {
                SimpleButton ctl = this.Controls.Find(item, true).FirstOrDefault() as SimpleButton;
                ctl.Enabled = true;
            }
            initComboboxDonvi();
            this.Cursor = Cursors.WaitCursor;
            createMenu(treeListQHPTDIEN);
            this.Cursor = Cursors.Default;
        }
        public void initComboboxDonvi()
        {
            lstDv = new List<string>();
            foreach (var d in clsObj.listDVQL(DVQuanLy))
            {
                if (clsObj.listDVQL(DVQuanLy).Count == 1)
                {
                    cbDvql.EditValue = d.TEN_DVIQLY.ToString();

                }
                else
                {
                    cbDvql.Properties.Items.Add(d.TEN_DVIQLY.ToString());
                    lstDv.Add(d.MA_DVIQLY);
                    cbDvql.SelectedIndex = 0;
                }
            }
        }
        private void changeControlState(Boolean _State)
        {
            cmdThem.Enabled = _State;
            cmdAddchild.Enabled = _State;
            cmdSua.Enabled = _State;
            cmdXoa.Enabled = _State;
            //treeListQHPTDIEN.Enabled = _State;

            cmdGhi.Enabled = !_State;
            cmdHuy.Enabled = !_State;
            treeRoot.Enabled = !_State;
            //chkAll.Enabled = !_State;
            //chkInvert.Enabled = !_State;
            //trPhanQuyen.Enabled = !_State;
            //trPhanQuyen.OptionsView.ShowCheckBoxes = !_State;


        }
        private void createMenu(TreeList tr)
        {
            tr.Nodes.Clear();
            this.Cursor = Cursors.WaitCursor;
            tr.BeginUnboundLoad();
            TreeListNode root = null;
            createNode(tr, root, 0);
            if (tr != null)
            {
                tr.StateImageList = imageCollection1;
                tr.NodesIterator.DoOperation(new AssignImageTreeLisOperation());
            }
            tr.EndUnboundLoad();
            this.Cursor = Cursors.Default;
        }
        private void createNode(TreeList tr, TreeListNode node, int _Parent)
        {
            List<D_QHE_PTDIEN> lst = clsObj.listTree(_Parent,DVQuanLy);
            foreach (D_QHE_PTDIEN item in lst)
            {
                try
                {
                    if (_Parent == 0)
                    {
                        TreeListNode tmp = tr.AppendNode(new object[] { item.D_PTDIEN.TEN_PTDIEN + " _***_ " + item.D_PTDIEN.D_CAP_DAP.TEN_CAPDA, item.ID_PTDIEN, item.D_PTDIEN.D_CAP_DAP.MA_CAPDA, item.D_PTDIEN.MA_DVQLY, item.D_PTDIEN.LOAI_PTDIEN, item.ID_QHE }, node);
                        createNode(tr, tmp, item.ID_PTDIEN);
                    }
                    else
                    {
                        TreeListNode tmp = tr.AppendNode(new object[] { item.D_PTDIEN.TEN_PTDIEN, item.ID_PTDIEN, item.D_PTDIEN.D_CAP_DAP.MA_CAPDA, item.D_PTDIEN.MA_DVQLY, item.D_PTDIEN.LOAI_PTDIEN, item.ID_QHE }, node);
                        createNode(tr, tmp, item.ID_PTDIEN);
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void getNode(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                idPTDien = e.Node.GetValue("ID_PTDIEN").ToString();
                maCapDa = e.Node.GetValue("MA_CAPDA").ToString();
                dvql = e.Node.GetValue("MA_DVIQLY").ToString();
                idQH = e.Node.GetValue("ID_QHE").ToString();
                List<D_QHE_PTDIEN> lst = clsObj.getNode(int.Parse(e.Node.GetValue("ID_PTDIEN").ToString()));
                foreach (var item in lst)
                {
                    labelNgay.Text = item.NGAY_HLUC.ToString();
                    labelNode.Text = item.D_PTDIEN.TEN_PTDIEN.ToString();
                    labelLoaiphantu.Text = item.D_PTDIEN.D_LOAI_TBI.TEN_LOAI;
                }
                tbQHLR.OptionsView.ShowGroupPanel = false;
                QHLR.DataSource = clsObj.listLR(int.Parse(idPTDien));
            }
            catch (Exception)
            {


            }

        }

        private void cmdThem_Click(object sender, EventArgs e)
        {
            _Action = "addRoot";
            labelNode.Text = "Gốc";
            loadListTree0();
            changeControlState(false);
        }
        private void loadListTree0()
        {
            try
            {
                treeRoot.Nodes.Clear();
                List<D_PTDIEN> lst = clsObj.getCha(DVQuanLy);
                foreach (D_PTDIEN item in lst)
                {
                    TreeListNode tmp = treeRoot.AppendNode(new object[] { item.ID_PTDIEN, item.TEN_PTDIEN, item.D_LOAI_TBI.TEN_LOAI, item.D_CAP_DAP.TEN_CAPDA, item.D_LOAI_TBI.TEN_LOAI,item.MA_PMISCHA }, null);
                }
            }
            catch (Exception)
            {
                
            }
        }
        private string checkNode(TreeListNodes nodes)
        {
            string str = "";
            foreach (TreeListNode node in nodes)
            {
                if (node.CheckState == CheckState.Checked)
                {
                    str = str + String.Format("{0},", node.GetValue("ID_PTDIEN"));
                }
                str += checkNode(node.Nodes);
            }
            return str;
        }
        private string checkNodeGetName(TreeListNodes nodes)
        {
            string str = "";
            foreach (TreeListNode node in nodes)
            {
                if (node.CheckState == CheckState.Checked)
                {
                    str = str + String.Format("{0},", node.GetValue("TEN_PTDIEN"));
                }
                str += checkNode(node.Nodes);
            }
            return str;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbDvql_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DVQuanLy = lstDv.ElementAt(cbDvql.SelectedIndex);
            createMenu(treeListQHPTDIEN);
            if (_Action == "addRoot")
            {
                loadListTree0();
            }
        }

        private void cmdGhi_Click(object sender, EventArgs e)
        {
            string msg = "Tạo phần tử  thành công.";
            if (_Action == "addRoot")
            {
                string[] xl = checkNode(treeRoot.Nodes).Split(',');
                string[] tenPT = checkNodeGetName(treeRoot.Nodes).Split(',');
                for (int i = 0; i < xl.Count() - 1; i++)
                {

                    obj = new D_QHE_PTDIEN();
                    obj.NGAY_HLUC = DateTime.Now;
                    obj.NGAY_TAO = DateTime.Now;
                    obj.ID_PTDIEN = int.Parse(xl[i]);
                    obj.ID_PTCHA = 0;
                    obj.NGUOI_TAO = userName;
                    if (clsObj.checkExist(int.Parse(xl[i])))
                    {
                        clsObj.addRoot(obj);

                    }
                    else
                    {
                        if (MessageBox.Show("Phần từ \"" + xl[i] + ":" + tenPT[i] + "\" bạn chọn đã tồn tại trên hệ thống.Bạn hãy kiểm tra phần tử này trên cây phần tử điện. Bạn vẫn muốn thêm phần tử này vào cây?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            clsObj.addRoot(obj);
                            treeListQHPTDIEN.Nodes.Clear();
                            createMenu(treeListQHPTDIEN);
                        }
                        else
                        {
                            msg = "Tạo phần tử \"" + xl[i] + ":" + tenPT[i] + "\" không thành công.";
                        }

                    }
                }
                MessageBox.Show(msg);
            }
            if (_Action == "addChildren")
            {
                string[] xl = checkNode(treeRoot.Nodes).Split(',');
                string[] tenPT = checkNodeGetName(treeRoot.Nodes).Split(',');
                for (int i = 0; i < xl.Count() - 1; i++)
                {
                    obj = new D_QHE_PTDIEN();
                    obj.NGAY_HLUC = DateTime.Now;
                    obj.NGAY_TAO = DateTime.Now;
                    obj.ID_PTDIEN = int.Parse(xl[i]);
                    obj.ID_PTCHA = int.Parse(idPTDien);
                    obj.NGUOI_TAO = userName;
                    if (clsObj.checkExist(int.Parse(xl[i])))
                    {

                        clsObj.addRoot(obj);

                    }
                    else
                    {
                        if (MessageBox.Show("Phần từ \"" + xl[i] + ":" + tenPT[i] + "\" bạn chọn đã tồn tại trên hệ thống. Bạn hãy kiểm tra phần tử này trên cây phần tử điện. Bạn vẫn muốn thêm phần tử này vào cây?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            clsObj.addRoot(obj);
                            treeListQHPTDIEN.Nodes.Clear();
                            createMenu(treeListQHPTDIEN);
                        }
                        else
                        {
                            msg = "Tạo phần tử \"" + xl[i] + ":" + tenPT[i] + "\" không thành công.";
                        }
                    }
                }
                MessageBox.Show(msg);
            }
            if (_Action == "Edit")
            {
                string[] xl = checkNode(treeRoot.Nodes).Split(',');
                if (xl.Count() > 2)
                {
                    MessageBox.Show("Bạn vui lòng chọn 1 phần tử");
                }
                else
                {
                    obj = new D_QHE_PTDIEN();
                    obj.ID_QHE = int.Parse(idQH);
                    obj.ID_PTDIEN = int.Parse(xl[0]);
                    obj.NGAY_HLUC = DateTime.Now;
                    obj.NGAY_SUA = DateTime.Now;
                    obj.NGUOI_SUA = userName;
                    clsObj.updateRoot(obj);
                    MessageBox.Show("Cập nhật nút thành công!");
                }
            }
            treeListQHPTDIEN.Nodes.Clear();
            createMenu(treeListQHPTDIEN);
            changeControlState(true);
            _Action = "";
        }

        private void cmdHuy_Click(object sender, EventArgs e)
        {
            changeControlState(true);
            _Action = "";
        }

        private void cmdAddchild_Click(object sender, EventArgs e)
        {
            _Action = "addChildren";
            treeRoot.Nodes.Clear();
            loadTreeRoot();
            changeControlState(false);
        }
        private void loadTreeRoot()
        {
            List<D_PTDIEN> lst = clsObj.listPTDienChildren(idPTDien, dvql, maCapDa);
            foreach (D_PTDIEN item in lst)
            {
                TreeListNode tmp = treeRoot.AppendNode(new object[] { item.ID_PTDIEN, item.TEN_PTDIEN, item.D_LOAI_TBI.TEN_LOAI, item.D_CAP_DAP.TEN_CAPDA, item.D_LOAI_TBI.TEN_LOAI,item.MA_PMISCHA }, null);
            }
            
        }
        private void cmdSua_Click(object sender, EventArgs e)
        {
            _Action = "Edit";
            treeRoot.Nodes.Clear();
            loadTreeRoot();
            changeControlState(false);
        }

        private void cmdXoa_Click(object sender, EventArgs e)
        {
            string msg = "";
            string ListIDqh = clsObj.getListIdDelete(int.Parse(idPTDien));
            string[] xl = ListIDqh.Split(',');
            int del = xl.Count() - 1;
            if (del == 0)
            {
                msg = "Bạn có chắc chắn muốn xóa phần tử này?";
            }
            else
            {
                msg = "Phần tử bạn muốn xóa có chứa " + del + " phần tử con. Nếu bạn xóa toàn bộ phần tử con cũng bị xóa. Bạn chắc chắn muốn xóa";
            }
            if (MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                for (int i = 0; i < xl.Count() - 1; i++)
                {
                    clsObj.delete(int.Parse(xl[i]));
                }
                clsObj.delete(int.Parse(idQH));
                treeListQHPTDIEN.Nodes.Clear();
                createMenu(treeListQHPTDIEN);
                MessageBox.Show("Xóa thành công!");
            }
        }
        private void changeState(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                //node.CheckState = chkAll.CheckState;
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
        private void unCheck(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                node.CheckState = CheckState.Unchecked;
                unCheck(node.Nodes);
            }
        }
        private void checkallTree(object sender, EventArgs e)
        {
            changeState(treeRoot.Nodes);
        }

        private void reverse(object sender, EventArgs e)
        {
            invertState(treeRoot.Nodes);
        }

        private void btQHTrai_Click(object sender, EventArgs e)
        {
            bool c = true;
            string[] xl = checkNode(treeRoot.Nodes).Split(',');
            string[] tenPT = checkNodeGetName(treeRoot.Nodes).Split(',');
            for (int i = 0; i < xl.Count() - 1; i++)
            {

                objLR = new D_QHE_PTDIEN_VITRI();
                objLR.ID_PTDienCha = int.Parse(idPTDien);
                objLR.ID_PTDienCon = int.Parse(xl[i]);
                objLR.TENPTDienCon = tenPT[i];
                objLR.VITRI = "L";
                objLR.NGAYCAPNHAT = clsObj.getDateServer();
                objLR.USERNAME = userName;
                if (clsObj.checkQH(int.Parse(objLR.ID_PTDienCha.ToString()), int.Parse(objLR.ID_PTDienCon.ToString())))
                {
                    clsObj.addLR(objLR);
                }
                else
                {
                    c = false;
                    MessageBox.Show("Phần tử điện " + objLR.ID_PTDienCon + " đã có. Không thể thêm.");
                }
            }
            if (c)
            {
                MessageBox.Show("Thêm quan hệ thành công!");
            }
            QHLR.DataSource = clsObj.listLR(int.Parse(idPTDien));
            unCheck(treeRoot.Nodes);
        }
        private void btQHPhai_Click(object sender, EventArgs e)
        {
            bool c=true;
            string[] xl = checkNode(treeRoot.Nodes).Split(',');
            string[] tenPT = checkNodeGetName(treeRoot.Nodes).Split(',');
            for (int i = 0; i < xl.Count() - 1; i++)
            {

                objLR = new D_QHE_PTDIEN_VITRI();
                objLR.ID_PTDienCha = int.Parse(idPTDien);
                objLR.ID_PTDienCon = int.Parse(xl[i]);
                objLR.TENPTDienCon = tenPT[i];
                objLR.VITRI = "R";
                objLR.NGAYCAPNHAT = clsObj.getDateServer();
                objLR.USERNAME = userName;
                if (clsObj.checkQH(int.Parse(objLR.ID_PTDienCha.ToString()), int.Parse(objLR.ID_PTDienCon.ToString())))
                {
                    clsObj.addLR(objLR);
                }
                else
                {
                    c = false;
                    MessageBox.Show("Phần tử điện " + objLR.ID_PTDienCon + " đã có. Không thể thêm.");
                }
            }
            if (c)
            {
                MessageBox.Show("Thêm quan hệ thành công!");
            }
            QHLR.DataSource = clsObj.listLR(int.Parse(idPTDien));
            unCheck(treeRoot.Nodes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa quan hệ này?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                clsObj.deleteLR(idLR);
                MessageBox.Show("Xóa thành công!");
                QHLR.DataSource = clsObj.listLR(int.Parse(idPTDien));
            }
        }

        private void getQHLR(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                idLR = int.Parse(tbQHLR.GetFocusedRowCellValue("ID").ToString());
            }
            catch (Exception)
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả quan hệ ?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                clsObj.deleteAllLR(clsObj.listLR(int.Parse(idPTDien)));
                MessageBox.Show("Xóa thành công!");
                QHLR.DataSource = clsObj.listLR(int.Parse(idPTDien));
            }
        }
    }
    /*public class AssignImageTreeLisOperation : TreeListOperation
    {
        public override void Execute(TreeListNode n)
        {
            if (n!= null)
            {
                if (n.GetValue("LOAI_PTDIEN").ToString() == "LT")
                {
                    n.StateImageIndex = 0;
                }
                else
                {
                    if (n.GetValue("LOAI_PTDIEN").ToString() == "DZ")
                    {
                        n.StateImageIndex = 4;
                    }
                    else
                    {
                        if (n.GetValue("LOAI_PTDIEN").ToString() == "TT")
                        {
                            n.StateImageIndex = 2;
                        }
                        else
                        {
                            if (n.GetValue("LOAI_PTDIEN").ToString() == "TC")
                            {
                                n.StateImageIndex = 2;
                            }
                            else
                            {
                                if (n.GetValue("LOAI_PTDIEN").ToString() == "DS" || n.GetValue("LOAI_PTDIEN").ToString() == "SI" || n.GetValue("LOAI_PTDIEN").ToString() == "MC" )
                                {
                                    n.StateImageIndex = 5;
                                }
                                if (n.GetValue("LOAI_PTDIEN").ToString() == "CB")
                                {
                                    n.StateImageIndex = 0;
                                }
                            }
                        }
                    }
                }
            }
        }
    }*/

       
}
