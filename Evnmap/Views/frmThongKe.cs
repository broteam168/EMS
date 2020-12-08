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
    public partial class frmThongKe : DevExpress.XtraEditors.XtraForm
    {
        thongKeControler obj;
        List<int> count;
        List<TimeSpan> sumTime;
        private string DVQuanLy;
        public frmThongKe(string DVQuanLy)
        {
            this.DVQuanLy = DVQuanLy;
            InitializeComponent();
            obj = new thongKeControler();
            cbDvi.Properties.DataSource = obj.listDVi(DVQuanLy);
            cbDvi.Properties.NullText = "Vui lòng chọn đơn vị";
        }
        public List<int> getMaxCount(int _top) {
            count = new List<int>();
            List<int> MaxCount = new List<int>();
            DateTime begin, end;
            begin = dateBegin.DateTime;
            end = dateEnd.DateTime;
            string[] b = begin.ToString().Split(' ');
            string[] c = end.ToString().Split(' ');
            try
            {
                obj.getCountClose(cbDvi.EditValue.ToString(), b[0]+" 00:00:01", c[0]+" 23:59:59");
            }
            catch (Exception)
            {

                MessageBox.Show("Bạn vui lòng chọn đơn vị");
            }
            try
            {
                List<int> listId = obj.ListIdPTD;
                List<int> ListCountClose = obj.ListCountClose;
                int index = 0;
                for (int t = 0; t < _top; t++)
                {
                    List<int> find = findC(ListCountClose,index);
                    index = index + find.Count;
                    for (int i = 0; i < find.Count; i++)
                    {
                        MaxCount.Add(listId[index+i]);
                        count.Add(ListCountClose[index+i]);
                    }
                }
                return MaxCount;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<int> findC(List<int> list, int index = 0)
        {
            if (index < list.Count)
            {
                List<int> find = list.FindAll(delegate(int item)
                {
                    return item == list[index];
                });
                return find;
            }
            return null;
        }
        public List<int> getMaxTime(int _top=1)
        {
            sumTime = new List<TimeSpan>();
            List<int> MaxTime = new List<int>();
            List<int> ListIdPTD = new List<int>();
            List<TimeSpan> ListSumTime = new List<TimeSpan>();
            Dictionary<int, TimeSpan> ds = obj.getSumTime(obj.ListIdPTD);// phai goi ham getMaxCount() truoc
            var items = from dic in ds orderby dic.Value descending select dic;
            foreach (KeyValuePair<int, TimeSpan> pair in items)
            {
                ListIdPTD.Add(pair.Key);
                ListSumTime.Add(pair.Value);
            }
            int index = 0;
            try
            {
                for (int t = 0; t < _top; t++)
                {
                    List<TimeSpan> find = findS(ListSumTime,index);
                    index = index + find.Count;
                    for (int i = 0; i < find.Count; i++)
                    {
                        MaxTime.Add(ListIdPTD[index+i]);
                        sumTime.Add(ListSumTime[index + i]);
                    }
                }
            }
            catch (Exception)
            {
                
            }
            
            
            return MaxTime;
        }
        public List<TimeSpan> findS(List<TimeSpan> list,int index=0) {
            if (index<list.Count)
            {
                List<TimeSpan> find = list.FindAll(delegate(TimeSpan item)
                {
                    return item == list[index];
                });
                return find;
            }
            return null;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dateBegin.Text != "" && dateEnd.Text != "")
            {
                List<int> id=null;
                try
                {
                    int Top = int.Parse(textTop.Text);
                    id = getMaxCount(Top);
                    try
                    {
                        if (id.Count != 0)
                        {
                            List<D_PTDIEN_New> listD = new List<D_PTDIEN_New>();
                            for (int i = 0; i < id.Count; i++)
                            {
                                listD.Add(obj.getPTDien(id[i], count[i]));
                            }
                            gridThongKe.DataSource = listD;
                            ThongKe.Columns["count"].Visible = true;
                            ThongKe.Columns["count"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                            ThongKe.Columns["time"].Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Chúng tôi Rất tiếc!Không có dữ liệu để tổng hợp báo cáo.");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Chúng tôi Rất tiếc!Không có dữ liệu để tổng hợp báo cáo.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ô \"Top\" Bạn phải nhập là số.");
                }
            }
            else
            {
                MessageBox.Show("Bạn không được để trống thời gian bắt đầu và thời gian kết thúc.");
            }
            
        }

        private void btTime_Click(object sender, EventArgs e)
        {
            if (dateBegin.Text != "" && dateEnd.Text != "")
            {
                try
                {
                    int Top = int.Parse(textTop.Text);
                    getMaxCount(Top);
                    string s;
                    List<int> id = getMaxTime(Top);
                    try
                    {
                        if (id.Count != 0)
                        {
                            List<D_PTDIEN_New> listD = new List<D_PTDIEN_New>();
                            for (int i = 0; i < id.Count; i++)
                            {
                                s = sumTime[i].Days.ToString("00") + ":" + sumTime[i].Hours.ToString("00") + ":" + sumTime[i].Minutes.ToString("00") + ":" + sumTime[i].Seconds.ToString("00");
                                listD.Add(obj.getPTDien(id[i], 0, s));
                            }
                            gridThongKe.DataSource = listD;
                            ThongKe.Columns["time"].Visible = true;
                            ThongKe.Columns["time"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                            ThongKe.Columns["count"].Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Chúng tôi Rất tiếc!Không có dữ liệu để tổng hợp báo cáo.");
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Chúng tôi Rất tiếc!Không có dữ liệu để tổng hợp báo cáo.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ô \"Top\" Bạn phải nhập là số.");
                }
                
            }
            else
            {
                MessageBox.Show("Bạn không được để trống thời gian bắt đầu và thời gian kết thúc.");
            }
            
        }
    }
}
