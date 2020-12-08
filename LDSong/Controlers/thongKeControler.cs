using LDSong.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{

    class thongKeControler
    {
        private LDSongDataContext db;
        public List<int> ListCountClose, ListIdPTD;
        public thongKeControler() {
            try
            {
                db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                System.Windows.Forms.MessageBox.Show("Không thể kết nối được tới máy chủ. Bạn vui lòng kiểm tra lại kết nối và khởi động lại phần mềm.");
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Có lỗi xảy ra vui lòng kiểm tra lại. " + e.ToString());
            }
        }
        public List<D_DVI_QLY> listDVi(string dvql)
        {
            try
            {
                if (dvql != "PN")
                {
                    return db.D_DVI_QLies.Where(p => p.MA_DVIQLY.Equals(dvql)).ToList();
                }
                else
                {
                    return db.D_DVI_QLies.ToList();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                System.Windows.Forms.MessageBox.Show("Không thể kết nối được tới máy chủ. Bạn vui lòng kiểm tra lại kết nối và khởi động lại phần mềm.");
                throw;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Có lỗi xảy ra vui lòng kiểm tra lại. " + e.ToString());
                throw;
            }
        }
        public void getCountClose(string dvql,string timeBegin,string timeEnd)
        {
            try
            {
                ListIdPTD = new List<int>();
                ListCountClose = new List<int>();
                if (dvql!="PN")
                {
                    foreach (var line in db.M_TTHAI_PTDIEN_LRs.Where(m => m.D_PTDIEN.MA_DVQLY.Equals(dvql) && m.D_PTDIEN.LOAI_PTDIEN.Equals("TT") && !m.D_PTDIEN.MA_CAPDA.Equals("03") && !m.D_PTDIEN.MA_CAPDA.Equals("08") && m.RIGHT_TRANGTHAI == false && m.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && m.NGAY_CAP_NHAT <= DateTime.Parse(timeEnd)).GroupBy(m => m.ID_PTDIEN).Select(group => new { idPTD = group.Key, count = group.Count() }).OrderByDescending(x => x.count))
                    {
                        ListIdPTD.Add(line.idPTD);
                        ListCountClose.Add(line.count);
                    }
                }
                else
                {
                    foreach (var line in db.M_TTHAI_PTDIEN_LRs.Where(m => m.D_PTDIEN.LOAI_PTDIEN.Equals("TT") && !m.D_PTDIEN.MA_CAPDA.Equals("03") && !m.D_PTDIEN.MA_CAPDA.Equals("08") && m.RIGHT_TRANGTHAI == false && m.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && m.NGAY_CAP_NHAT <= DateTime.Parse(timeEnd)).GroupBy(m => m.ID_PTDIEN).Select(group => new { idPTD = group.Key, count = group.Count() }).OrderByDescending(x => x.count))
                    {
                        ListIdPTD.Add(line.idPTD);
                        ListCountClose.Add(line.count);
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                System.Windows.Forms.MessageBox.Show("Không thể kết nối được tới máy chủ. Bạn vui lòng kiểm tra lại kết nối và khởi động lại phần mềm.");
                throw;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Có lỗi xảy ra vui lòng kiểm tra lại. " + e.ToString());
                throw;
            }
        }
        public Dictionary<int, TimeSpan> getSumTime(List<int> idPTD)
        {
            try
            {
                var ds = new Dictionary<int, TimeSpan>();
                foreach (var item in idPTD)
                {
                    TimeSpan sum= default(TimeSpan),temp;
                    var d=db.M_TTHAI_PTDIEN_LRs.Where(m => m.ID_PTDIEN == item && m.THOIGIANKETTHUC != null && m.RIGHT_TRANGTHAI==false).ToList();
                    foreach (var c in d)
                    {
                        if (c.THOIGIANKETTHUC!=null)
                        {
                            temp = DateTime.Parse(c.THOIGIANKETTHUC.ToString()) - DateTime.Parse(c.NGAY_CAP_NHAT.ToString());
                            sum = sum + temp;
                        }
                    }
                    ds.Add(item, sum);
                }
                return ds;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                System.Windows.Forms.MessageBox.Show("Không thể kết nối được tới máy chủ. Bạn vui lòng kiểm tra lại kết nối và khởi động lại phần mềm.");
                throw;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Có lỗi xảy ra vui lòng kiểm tra lại. " + e.ToString());
                throw;
            }
        }
        public D_PTDIEN_New getPTDien(int id, int count, string _time="")
        {
            try
            {
                D_PTDIEN_New PTNew = new D_PTDIEN_New();
                var PT = from p in db.D_PTDIENs where p.ID_PTDIEN==id select new {p.ID_PTDIEN,p.TEN_PTDIEN,p.MA_DVQLY,p.D_CAP_DAP.TEN_CAPDA};
                PTNew.ID_PTDIEN=PT.FirstOrDefault().ID_PTDIEN;
                PTNew.TEN_PTDIEN=PT.FirstOrDefault().TEN_PTDIEN;
                PTNew.MA_DVQLY=PT.FirstOrDefault().MA_DVQLY;
                PTNew.MA_CAPDA=PT.FirstOrDefault().TEN_CAPDA;
                PTNew.count=count;
                PTNew.time = _time;
                return PTNew;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                System.Windows.Forms.MessageBox.Show("Không thể kết nối được tới máy chủ. Bạn vui lòng kiểm tra lại kết nối và khởi động lại phần mềm.");
                throw;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Có lỗi xảy ra vui lòng kiểm tra lại. " + e.ToString());
                throw;
            }
        }
    }
    public partial class D_PTDIEN_New 
    {
        private string _MA_DVQLY;

        private int _ID_PTDIEN;

        private string _TEN_PTDIEN;

        private string _MA_CAPDA;

        private string _TEN_CAPDA;

        private string _LOAI_PTDIEN;
        
        private int _count;
        private string _time;
        public string MA_DVQLY
        {
            get
            {
                return this._MA_DVQLY;
            }
            set
            {
                if ((this._MA_DVQLY != value))
                {
                    this._MA_DVQLY = value;
                }
            }
        }
        public int ID_PTDIEN
        {
            get
            {
                return this._ID_PTDIEN;
            }
            set
            {
                if ((this._ID_PTDIEN != value))
                {
                    this._ID_PTDIEN = value;
                }
            }
        }

        public string TEN_PTDIEN
        {
            get
            {
                return this._TEN_PTDIEN;
            }
            set
            {
                if ((this._TEN_PTDIEN != value))
                {
                    this._TEN_PTDIEN = value;
                }
            }
        }

        public string MA_CAPDA
        {
            get
            {
                return this._MA_CAPDA;
            }
            set
            {
                if ((this._MA_CAPDA != value))
                {
                    this._MA_CAPDA = value;
                }
            }
        }

        public string TEN_CAPDA
        {
            get
            {
                return this._TEN_CAPDA;
            }
            set
            {
                if ((this._TEN_CAPDA != value))
                {
                    this._TEN_CAPDA = value;
                }
            }
        }
        public string LOAI_PTDIEN
        {
            get
            {
                return this._LOAI_PTDIEN;
            }
            set
            {
                if ((this._LOAI_PTDIEN != value))
                {
                    this._LOAI_PTDIEN = value;
                }
            }
        }
        public int count
        {
            get
            {
                return this._count;
            }
            set
            {
                if ((this._count != value))
                {
                    this._count = value;
                }
            }
        }
        public string time
        {
            get
            {
                return this._time;
            }
            set
            {
                if ((this._time != value))
                {
                    this._time = value;
                }
            }
        }
    }
	
}
