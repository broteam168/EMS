using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LDSong.Controlers;
using System.Threading;
using DevExpress.XtraMap;
using LDSong.Models;
namespace LDSong.Views
{
    public partial class frmTrangthaiTram : Form
    {
        string id,userName,tb;
        List<string> list;
        private List<int> remove;
        private TTHAILR LR;
        private TTHAILR_VM LRVM;
        private bool VM,checkDong=false;
        public frmTrangthaiTram()
        {
            InitializeComponent();
        }
        public frmTrangthaiTram(string id,string userName,bool _VM=false)
        {
            InitializeComponent();
            this.VM = _VM;
            this.id = id;
            this.userName = userName;
            if (_VM==false)
            {
                LR= new TTHAILR();
                this.checkDong=LR.getCheck_Dong();
            }
            else
            {
                LRVM = new TTHAILR_VM();
            }
            initTram();
            
        }
        public void initTram() {
            toadoControler td = new toadoControler();
            
            string tenPTDIEN="";
            if (VM==false)
            {
                list = td.getthongtinDiem(id);
            }
            else
            {
                list = td.getthongtinDiem_VM(id);
            }
            tb = list.ElementAt(1).ToString();
            lbtentram.Text = list.ElementAt(5).ToString();
            td.getALLDuongDAY(list.ElementAt(8).ToString());
            List<string> name = td.listTenPTDien;
            for (int i = name.Count-1; i >=0 ; i--)
            {
                if (i != 0) {
                    tenPTDIEN = tenPTDIEN + name[i].ToString() + " - ";
                }
                else
                {
                    tenPTDIEN = tenPTDIEN + name[i].ToString()+".";
                }
            }
            labelDuongDay.Text = tenPTDIEN;
            if (list.ElementAt(1).ToString()=="DS")
            {
                labelName.Text = "Dao cách ly : ";
            }
            if (list.ElementAt(1).ToString() == "TT")
            {
                labelName.Text = "Trạm biến áp : ";
            }
            if (list.ElementAt(1).ToString() == "CB")
            {
                labelName.Text = "Máy cắt : ";
            }
            string th = list.ElementAt(7).ToString();
            if (th=="1")
	        {
                lbTrangThaiTram.Text = "Hiện tại trạng thái thiết bị đang đóng";
                lbTrangThaiTram.ForeColor = Color.Red;
                bttrangthaiON.Enabled = false;
                bttrangthaiOFF.Enabled = true;
	        }
            else
            {
                lbTrangThaiTram.Text = "Hiện tại trạng thái thiết bị trạm đang mở";
                lbTrangThaiTram.ForeColor = Color.Green;
                bttrangthaiON.Enabled = true;
                bttrangthaiOFF.Enabled = false;
            }
            
        }
        private List<int> kiemTraTrung(List<M_TTHAI_PTDIEN_LR> tt) {
            int n = tt.Count;
            remove = new List<int>();
            List<int> ds = new List<int>();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                    if (tt[i].ID_PTDIEN == tt[j].ID_PTDIEN)
                    {
                        ds.Add(i);
                        remove.Add(j);
                    }
            }
            return ds;
        }
        private List<int> kiemTraTrung_VM(List<M_TTHAI_PTDIEN_LR_VM> tt)
        {
            int n = tt.Count;
            remove = new List<int>();
            List<int> ds = new List<int>();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                    if (tt[i].ID_PTDIEN == tt[j].ID_PTDIEN)
                    {
                        ds.Add(i);
                        remove.Add(j);
                    }
            }
            return ds;
        }
        private void bttrangthaiON_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string str = "";
            if (tb == "DS" || tb == "SI")
            {
                str = "Bạn có chắc chắn muốn cập nhật trạng thái đóng dao?";
            }
            if (tb == "TT")
            {
                str = "Bạn có chắc chắn muốn cập nhật trạng thái đóng trạm?";
            }
            if (tb == "TG")
            {
                str = "Bạn có chắc chắn muốn cập nhật trạng thái đóng trạm TG?";
            }
            if (tb == "CB" || tb == "MC")
            {
                str = "Bạn có chắc chắn muốn cập nhật trạng thái đóng máy cắt?";
            }
            if (VM == false)
            {
                if (checkDong == false && !userName.Equals("administrator"))
                {
                    if (!tb.Equals("CB"))
                    {
                        if (LR.checkClose2Dau(int.Parse(list.ElementAt(0).ToString())))// - LR.checkClose(int.Parse(list.ElementAt(0).ToString())) && tb=="DS"
                        {
                            if (LR.checkCoTai(int.Parse(list.ElementAt(0).ToString()), list.ElementAt(1).ToString()) == false)  // LR.checkClose(int.Parse(list.ElementAt(0).ToString()))==false
                            {
                                MessageBox.Show("Phần tử thao tác đang có điện bạn không thể thao tác.");
                            }
                            else
                            {
                                closePTDien(str);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Thiết bị thao tác hiện tại 2 đầu đều có điện, bạn không thể thực hiện đóng thiết bị.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn không thể thao tác đóng nguồn.");
                    }
                }
                else
                {
                    if (LR.checkClose2Dau(int.Parse(list.ElementAt(0).ToString())))// - LR.checkClose(int.Parse(list.ElementAt(0).ToString())) && tb=="DS"
                    {
                        closePTDien(str);
                    }
                    else
                    {
                        MessageBox.Show("Thiết bị thao tác hiện tại 2 đầu đều có điện, bạn không thể thực hiện đóng thiết bị.");
                    }
                }
            }
            else // chay gia lap
            {
                if (LRVM.checkClose_VM(int.Parse(list.ElementAt(0).ToString())))// - LR.checkClose(int.Parse(list.ElementAt(0).ToString())) && tb=="DS"
                {
                    if (MessageboxMap.Show(str, "Tiếp tục", "Hủy bỏ") == true)
                    {
                        M_TTHAI_PTDIEN_LR_VM tbaOLD = LRVM.getTTHAILR(list.ElementAt(0).ToString());
                        if (tb == "DS" || tb == "CB" || tb == "MC" || tb == "SI" || tb == "TG")
                        {
                            if (tbaOLD.LEFT_TRANGTHAI == true || tbaOLD.RIGHT_TRANGTHAI == true)
                            {
                                LRVM.closeCD(int.Parse(list.ElementAt(0).ToString()));
                                if (LRVM.checkNguon == true)
                                {
                                    this.Cursor = Cursors.WaitCursor;
                                    List<M_TTHAI_PTDIEN_LR_VM> ListUpdate = LRVM.ListUpdate;
                                    List<int> ds = kiemTraTrung_VM(ListUpdate);
                                    if (ds.Count != 0)
                                    {
                                        for (int i = ds.Count - 1; i >= 0; i--)
                                        {
                                            ListUpdate.ElementAt(ds[i]).LEFT_TRANGTHAI = true;
                                            ListUpdate.ElementAt(ds[i]).RIGHT_TRANGTHAI = true;
                                        }
                                        remove.Sort();
                                        for (int i = remove.Count - 1; i >= 0; i--)
                                        {
                                            ListUpdate.RemoveAt(remove[i]);
                                        }
                                    }
                                    for (int i = 0; i < ListUpdate.Count; i++)
                                    {
                                        LRVM.updateEnd(ListUpdate[i]);
                                        LRVM.update(ListUpdate[i]);
                                    }
                                    List<int> Listupdate1 = LRVM.ListUpdate1;
                                    for (int i = 0; i < Listupdate1.Count; i++)
                                    {
                                        LRVM.update1(Listupdate1[i], true);
                                    }
                                    this.Cursor = Cursors.Default;
                                }
                                else
                                {
                                    MessageBox.Show("Thao tác này không ảnh hưởng đến các phần tử điện khác");
                                }
                            }

                        }
                        else
                        {
                            if (tbaOLD.LEFT_TRANGTHAI == true || tbaOLD.RIGHT_TRANGTHAI == true)
                            {
                                M_TTHAI_PTDIEN_LR_VM tba = new M_TTHAI_PTDIEN_LR_VM();
                                tba.ID_PTDIEN = int.Parse(list.ElementAt(0).ToString());
                                tba.LEFT_TRANGTHAI = tbaOLD.LEFT_TRANGTHAI;
                                tba.RIGHT_TRANGTHAI = tba.LEFT_TRANGTHAI;
                                tba.CHIEUDONGDIEN = true;
                                tba.NGAY_CAP_NHAT = LRVM.getDateServer();
                                LRVM.updateEnd(tba);
                                LRVM.update(tba);
                            }

                        }
                        toadoControler td = new toadoControler();
                        LRVM.updateEnd1(int.Parse(list.ElementAt(0).ToString()));
                        td.insertTrangthai_VM(list.ElementAt(0).ToString(), list.ElementAt(3).ToString(), "1", userName);
                        bttrangthaiOFF.Enabled = true;
                        bttrangthaiON.Enabled = false;
                        MessageBox.Show("Cập nhật trạng thái thành công");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Hai đầu dao đang có điện, bạn không thể thực hiện đóng dao.");
                }
            }
        }
        private void closePTDien(string str)
        {
            if (MessageboxMap.Show(str, "Tiếp tục", "Hủy bỏ") == true)
            {
                M_TTHAI_PTDIEN_LR tbaOLD = LR.getTTHAILR(list.ElementAt(0).ToString());
                if (tb == "DS" || tb == "CB" || tb == "MC" || tb == "SI" || tb == "TG")
                {
                    if (tbaOLD.LEFT_TRANGTHAI == true || tbaOLD.RIGHT_TRANGTHAI == true)
                    {
                        LR.closeCD(int.Parse(list.ElementAt(0).ToString()));
                        if (LR.checkNguon == true)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            List<M_TTHAI_PTDIEN_LR> ListUpdate = LR.ListUpdate;
                            List<int> ds = kiemTraTrung(ListUpdate);
                            if (ds.Count != 0)
                            {
                                for (int i = ds.Count - 1; i >= 0; i--)
                                {
                                    ListUpdate.ElementAt(ds[i]).LEFT_TRANGTHAI = true;
                                    ListUpdate.ElementAt(ds[i]).RIGHT_TRANGTHAI = true;
                                }
                                remove.Sort();
                                for (int i = remove.Count - 1; i >= 0; i--)
                                {
                                    ListUpdate.RemoveAt(remove[i]);
                                }
                            }
                            for (int i = 0; i < ListUpdate.Count; i++)
                            {
                                LR.updateEnd(ListUpdate[i]);
                                LR.update(ListUpdate[i]);
                            }
                            List<int> Listupdate1 = LR.ListUpdate1;
                            for (int i = 0; i < Listupdate1.Count; i++)
                            {
                                LR.update1(Listupdate1[i], true);
                            }
                            this.Cursor = Cursors.Default;
                        }
                        else
                        {
                            MessageBox.Show("Thao tác này không ảnh hưởng đến các phần tử điện khác");
                        }
                    }

                }
                else
                {
                    if (tbaOLD.LEFT_TRANGTHAI == true || tbaOLD.RIGHT_TRANGTHAI == true)
                    {
                        M_TTHAI_PTDIEN_LR tba = new M_TTHAI_PTDIEN_LR();
                        tba.ID_PTDIEN = int.Parse(list.ElementAt(0).ToString());
                        tba.LEFT_TRANGTHAI = tbaOLD.LEFT_TRANGTHAI;
                        tba.RIGHT_TRANGTHAI = tba.LEFT_TRANGTHAI;
                        tba.CHIEUDONGDIEN = 'L';
                        tba.NGAY_CAP_NHAT = LR.getDateServer();
                        LR.updateEnd(tba);
                        LR.update(tba);
                    }

                }
                toadoControler td = new toadoControler();
                LR.updateEnd1(int.Parse(list.ElementAt(0).ToString()));
                td.insertTrangthai(list.ElementAt(0).ToString(), list.ElementAt(3).ToString(), "1", userName);
                /*if ((tb == "DS" || tb == "MC" || tb == "SI") && (!list.ElementAt(9).ToString().Equals("") && !list.ElementAt(9).ToString().Equals(null)))
                {
                    td.insertTrangThaiTableCmis(list.ElementAt(0).ToString(), list.ElementAt(9).ToString(), true);
                }*/
                bttrangthaiOFF.Enabled = true;
                bttrangthaiON.Enabled = false;
                MessageBox.Show("Cập nhật trạng thái thành công");
                this.Close();
            }
            this.Cursor = Cursors.Default;
        }
        private void bttrangthaiOFF_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string str = "";
            if (tb == "DS" || tb == "SI")
            {
                str = "Bạn có chắc chắn muốn cập nhật trạng thái cắt dao?";
            }
            if (tb == "TT")
            {
                str = "Bạn có chắc chắn muốn cập nhật trạng thái cắt trạm?";
            }
            if (tb == "TG")
            {
                str = "Bạn có chắc chắn muốn cập nhật trạng thái cắt trạm TG?";
            }
            if (tb == "CB" || tb == "MC")
            {
                str = "Bạn có chắc chắn muốn cập nhật trạng thái cắt máy cắt?";
            }
            if (VM == false)
            {
                if (checkDong == false && !userName.Equals("administrator"))
                {
                    if (!tb.Equals("CB"))
                    {
                        if (LR.checkCoTai(int.Parse(list.ElementAt(0).ToString()), list.ElementAt(1).ToString()) == false) //LR.checkClose(int.Parse(list.ElementAt(0).ToString()))==false
                        {
                            MessageBox.Show("Thiết bị đang có điện không thể thao tác");
                        }
                        else
                        {
                            openPTDien(str);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn không thể thao tác mở nguồn.");
                    }
                }
                else
                {
                    openPTDien(str);
                }
            }
            else  // chay gia lap
            {
                if (MessageboxMap.Show(str, "Tiếp tục", "Hủy bỏ") == true)
                {
                    frmNguyenNhanMatDien nguyennhan = new frmNguyenNhanMatDien();
                    nguyennhan.ShowDialog();
                    string nn = nguyennhan.nguyenNhan.Trim();
                    if (nn.Length >= 10)
                    {
                        M_TTHAI_PTDIEN_LR_VM tbaOLD = LRVM.getTTHAILR(list.ElementAt(0).ToString());
                        if (tb == "DS" || tb == "CB" || tb == "MC" || tb == "SI" || tb == "TG")
                        {
                            if (tbaOLD.LEFT_TRANGTHAI == true || tbaOLD.RIGHT_TRANGTHAI == true)
                            {
                                LRVM.openCD(int.Parse(list.ElementAt(0).ToString()));
                                if (LRVM.checkNguon == true)
                                {
                                    this.Cursor = Cursors.WaitCursor;
                                    List<M_TTHAI_PTDIEN_LR_VM> ListUpdate = LRVM.ListUpdate;
                                    List<int> ds = kiemTraTrung_VM(ListUpdate);
                                    if (ds.Count != 0)
                                    {
                                        for (int i = ds.Count - 1; i >= 0; i--)
                                        {
                                            ListUpdate.ElementAt(ds[i]).LEFT_TRANGTHAI = false;
                                            ListUpdate.ElementAt(ds[i]).RIGHT_TRANGTHAI = false;
                                        }
                                        remove.Sort();
                                        for (int i = remove.Count - 1; i >= 0; i--)
                                        {
                                            ListUpdate.RemoveAt(remove[i]);
                                        }
                                    }
                                    for (int i = 0; i < ListUpdate.Count; i++)
                                    {
                                        ListUpdate[i].NGUYENNHAN = nn;
                                        LRVM.updateEnd(ListUpdate[i]);
                                        LRVM.update(ListUpdate[i]);
                                    }
                                    List<int> Listupdate1 = LRVM.ListUpdate1;
                                    for (int i = 0; i < Listupdate1.Count; i++)
                                    {
                                        LRVM.update1(Listupdate1[i], false);
                                    }
                                    this.Cursor = Cursors.Default;
                                }
                                else
                                {
                                    MessageBox.Show("Thao tác này không ảnh hưởng đến các phần tử điện khác");
                                }
                            }

                        }
                        else
                        {
                            if (tbaOLD.LEFT_TRANGTHAI == true || tbaOLD.RIGHT_TRANGTHAI == true)
                            {
                                M_TTHAI_PTDIEN_LR_VM tba = new M_TTHAI_PTDIEN_LR_VM();
                                tba.ID_PTDIEN = int.Parse(list.ElementAt(0).ToString());
                                tba.LEFT_TRANGTHAI = tbaOLD.LEFT_TRANGTHAI;
                                tba.RIGHT_TRANGTHAI = false;
                                tba.CHIEUDONGDIEN = true;
                                tba.NGAY_CAP_NHAT = LRVM.getDateServer();
                                tba.NGUYENNHAN = nn;
                                LRVM.updateEnd(tba);
                                LRVM.update(tba);
                            }
                        }
                        toadoControler td = new toadoControler();
                        LRVM.updateEnd1(int.Parse(list.ElementAt(0).ToString()));
                        td.insertTrangthai_VM(list.ElementAt(0).ToString(), list.ElementAt(3).ToString(), "0", userName);
                        bttrangthaiOFF.Enabled = false;
                        bttrangthaiON.Enabled = true;
                        MessageBox.Show("Cập nhật trạng thái thành công");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập nguyên nhân cắt điện. Bạn phải nhập ít nhất từ 10 ký tự trở lên.");
                    }

                }
            }
            this.Cursor = Cursors.Default;
        }
        private void openPTDien(string str) {
            if (MessageboxMap.Show(str, "Tiếp tục", "Hủy bỏ") == true)
            {
                frmNguyenNhanMatDien nguyennhan = new frmNguyenNhanMatDien();
                nguyennhan.ShowDialog();
                string nn = nguyennhan.nguyenNhan.Trim();
                if (nn.Length >= 10)
                {
                    M_TTHAI_PTDIEN_LR tbaOLD = LR.getTTHAILR(list.ElementAt(0).ToString());
                    if (tb == "DS" || tb == "CB" || tb == "MC" || tb == "SI" || tb == "TG")
                    {
                        if (tbaOLD.LEFT_TRANGTHAI == true || tbaOLD.RIGHT_TRANGTHAI == true)
                        {
                            LR.openCD(int.Parse(list.ElementAt(0).ToString()));
                            if (LR.checkNguon == true)
                            {
                                this.Cursor = Cursors.WaitCursor;
                                List<M_TTHAI_PTDIEN_LR> ListUpdate = LR.ListUpdate;
                                List<int> ds = kiemTraTrung(ListUpdate);
                                if (ds.Count != 0)
                                {
                                    for (int i = ds.Count - 1; i >= 0; i--)
                                    {
                                        ListUpdate.ElementAt(ds[i]).LEFT_TRANGTHAI = false;
                                        ListUpdate.ElementAt(ds[i]).RIGHT_TRANGTHAI = false;
                                    }
                                    remove.Sort();
                                    for (int i = remove.Count - 1; i >= 0; i--)
                                    {
                                        ListUpdate.RemoveAt(remove[i]);
                                    }
                                }
                                for (int i = 0; i < ListUpdate.Count; i++)
                                {
                                    ListUpdate[i].NGUYENNHAN = nn;
                                    LR.updateEnd(ListUpdate[i]);
                                    LR.update(ListUpdate[i]);
                                }
                                List<int> Listupdate1 = LR.ListUpdate1;
                                for (int i = 0; i < Listupdate1.Count; i++)
                                {
                                    LR.update1(Listupdate1[i], false);
                                }
                                this.Cursor = Cursors.Default;
                            }
                            else
                            {
                                MessageBox.Show("Thao tác này không ảnh hưởng đến các phần tử điện khác");
                            }
                        }

                    }
                    else
                    {
                        if (tbaOLD.LEFT_TRANGTHAI == true || tbaOLD.RIGHT_TRANGTHAI == true)
                        {
                            M_TTHAI_PTDIEN_LR tba = new M_TTHAI_PTDIEN_LR();
                            tba.ID_PTDIEN = int.Parse(list.ElementAt(0).ToString());
                            tba.LEFT_TRANGTHAI = tbaOLD.LEFT_TRANGTHAI;
                            tba.RIGHT_TRANGTHAI = false;
                            tba.CHIEUDONGDIEN = 'L';
                            tba.NGAY_CAP_NHAT = LR.getDateServer();
                            tba.NGUYENNHAN = nn;
                            LR.updateEnd(tba);
                            LR.update(tba);
                        }
                    }
                    toadoControler td = new toadoControler();
                    LR.updateEnd1(int.Parse(list.ElementAt(0).ToString()));
                    td.insertTrangthai(list.ElementAt(0).ToString(), list.ElementAt(3).ToString(), "0", userName);
                    /*if ((tb == "DS" || tb == "MC" || tb == "SI") && (!list.ElementAt(9).ToString().Equals("") && !list.ElementAt(9).ToString().Equals(null)))
                    {
                        td.insertTrangThaiTableCmis(list.ElementAt(0).ToString(), list.ElementAt(9).ToString(), false);
                    }*/
                    bttrangthaiOFF.Enabled = false;
                    bttrangthaiON.Enabled = true;
                    MessageBox.Show("Cập nhật trạng thái thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập nguyên nhân cắt điện. Bạn phải nhập ít nhất từ 10 ký tự trở lên.");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (VM == false)
            {
                this.Cursor = Cursors.WaitCursor;
                if (list.ElementAt(1).ToString() != "CB")
                {
                    if (LR.checkClose2Dau(int.Parse(list.ElementAt(0).ToString())) || list.ElementAt(7).ToString().Equals("1"))
                    {
                        label1.Visible = true;
                        label1.Text = "Đang xác định nguồn. Bạn vui lòng đợi ...";
                        button1.Visible = false;
                        LR.XacDinhNguonCap(int.Parse(id));
                        label1.Text = LR.lstCB;
                    }
                    else
                    {
                        label1.Visible = true;
                        label1.Text = "Đang xác định nguồn. Bạn vui lòng đợi ...";
                        button1.Visible = false;
                        LR.XacDinhNguonCap(int.Parse(id), 0, 'L');
                        label1.Text = LR.lstCB;
                        LR.XacDinhNguonCap(int.Parse(id), 0, 'R');
                        if (label1.Text.Equals(LR.lstCB))
                        {
                            label1.Text = label1.Text + " ** ";
                        }
                        else
                        {
                            label1.Text = label1.Text + " và " + LR.lstCB;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Đây là nguồn.");
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Hiện tại chưa hỗ trợ chức năng này cho phần giả lập");
            }
        }
    }
}
