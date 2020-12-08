using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using LDSong.Models;

namespace LDSong.Controlers
{
    class KHangControler
    {
        private LDSongDataContext DB;
        public List<string> listTenPTDien;
        public KHangControler()
        {
            try
            {
                DB = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
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

        public List<K_KHACH_HANG> timKhachHang(string filter)
        {
            try
            {
                var p = Expression.Parameter(typeof(K_KHACH_HANG), "x");
                var e = (Expression)DynamicExpressionParser.ParseLambda(new[] { p }, null, filter);

                var typedExpression = (Expression<Func<K_KHACH_HANG, bool>>)e;

                var res = DB.K_KHACH_HANGs.Where(typedExpression).ToList();
                return res;

                
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

        public List<K_DIEM_DO> timDiemDo( string _MaKH)
        {
            try
            {
                //return DB.K_DIEM_DOs.Where(p => p.MA_DVIQLY.Contains(_DVQL) && p.MA_KHANG.Equals(_MaKH)).ToList();
                return DB.K_DIEM_DOs.Where(p =>  p.MA_KHANG.Equals(_MaKH)).ToList();
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
        public List<D_LOAI_YCAU> listYeucau() {
            try
            {
                return DB.D_LOAI_YCAUs.ToList();
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
        public void addKHYEUCAU(K_YEU_CAU _obj) {
            try
            {
                DB.K_YEU_CAUs.InsertOnSubmit(_obj);
                DB.SubmitChanges();
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
        public List<K_YEU_CAU> lichSuYeuCau(string maKH) {
            try
            {
                using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
                {
                    return data.K_YEU_CAUs.Where(k => k.MA_KHANG.Equals(maKH)).ToList();
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
        public M_VITRI_V1 trangThai(string maScada){
            try
            {
                using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
                {
                    return data.M_VITRI_V1s.Where(t => t.MA_CMIS.Equals(maScada)).SingleOrDefault();
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
        public M_VITRI_V2 trangThai2(string maScada)
        {
            try
            {
                using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
                {
                    return data.M_VITRI_V2s.Where(t => t.MA_CMIS.Equals(maScada)).SingleOrDefault();
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
        public D_PTDIEN getMaPmisCha(string maCmis) {
            try
            {
                return DB.D_PTDIENs.Where(p => p.MA_CMIS.Equals(maCmis)).SingleOrDefault();
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
        public void getALLDuongDAY(string maPmisCha,int _parent=0)
        {
            try
            {
                if (_parent==0)
                {
                    listTenPTDien = new List<string>();
                }
                using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
                {
                    try
                    {
                        var d = from pt in data.D_PTDIENs where pt.MA_PMIS == maPmisCha select new { pt.TEN_PTDIEN, pt.MA_PMISCHA };
                        listTenPTDien.Add(d.First().TEN_PTDIEN);
                        getALLDuongDAY(d.First().MA_PMISCHA,1);
                    }
                    catch (Exception)
                    {

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
        public DateTime getDateServer()
        {
            try
            {
                return DB.GetServerDate();
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
}
