using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
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
    public partial class frmCayTonThat :  DevExpress.XtraEditors.XtraForm
    {
        private QHPTDiencontroler clsObj;
        private List<string> lstDv;
        private string DVQuanLy, dvql, userName, idPTDien, maCapDa, idQH;

        public frmCayTonThat()
        {
            InitializeComponent();
        }
        public frmCayTonThat(string DVQuanLy, string userName)
        {
            this.DVQuanLy = DVQuanLy;
            this.userName = userName;
            InitializeComponent();
        }
        private void frmCayTonThat_Load(object sender, EventArgs e)
        {
            clsObj = new QHPTDiencontroler();
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

        private void cbDvql_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdAddchild.Enabled = true;
            DVQuanLy = lstDv.ElementAt(cbDvql.SelectedIndex);
            createMenu(treeListQHPTDIEN);
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
            List<D_CAY_TON_THAT> lst = clsObj.listCayTT(_Parent, DVQuanLy);
            foreach (D_CAY_TON_THAT item in lst)
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

        private void cmdAddchild_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            List<int> lstCB = clsObj.getRootTT(DVQuanLy);
            DateTime date = clsObj.getDateServer();
            foreach (var item in lstCB)
            {
                QHPTDiencontroler cls1 = new QHPTDiencontroler();
                D_CAY_TON_THAT objTTR = new D_CAY_TON_THAT();
                objTTR.ID_PTDIEN = item;
                objTTR.ID_PTCHA = 0;
                objTTR.NGAY_LAY_CAY = date;
                cls1.addCayTT(objTTR);
                cls1.openCD(item);
                foreach (var it in cls1.ListUpdate)
                {
                    D_CAY_TON_THAT objTTC = new D_CAY_TON_THAT();
                    objTTC.ID_PTDIEN = it;
                    objTTC.ID_PTCHA = item;
                    objTTC.NGAY_LAY_CAY = date;
                    cls1.addCayTT(objTTC);
                }
            }
            createMenu(treeListQHPTDIEN);
            MessageBox.Show("Cập nhật cây tổn thất thành công!");
            this.Cursor = Cursors.Default;
        }

        
    }
    public class AssignImageTreeLisOperation : TreeListOperation
    {
        public override void Execute(TreeListNode n)
        {
            if (n != null)
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
                                if (n.GetValue("LOAI_PTDIEN").ToString() == "DS" || n.GetValue("LOAI_PTDIEN").ToString() == "SI" || n.GetValue("LOAI_PTDIEN").ToString() == "MC")
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
    }
}
