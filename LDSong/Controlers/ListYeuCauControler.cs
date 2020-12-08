using LDSong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class ListYeuCauControler
    {
        private LDSongDataContext db;
        public ListYeuCauControler()
        {
            try
            {
                db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
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
        public List<D_DVI_QLY> listdvql(string dvql) {
            if (dvql!="PN")
            {
                return db.D_DVI_QLies.Where(d=> d.MA_DVIQLY.Equals(dvql)).ToList();
            }
            else
	        {
                return db.D_DVI_QLies.ToList();
	        }
        }
        public List<K_YEU_CAU> listYeuCau(int tinhTrang,string dvql,string begin,string end) {
            if (tinhTrang==0)
            {
                if (dvql!="PN")
	            {
                    return db.K_YEU_CAUs.Where(k => k.MA_DVIQLY.Equals(dvql) && k.NGAY_TAO >= DateTime.Parse(begin) && k.NGAY_TAO <= DateTime.Parse(end)).ToList();
	            }
                else
	            {
                    return db.K_YEU_CAUs.Where(k=> k.NGAY_TAO >= DateTime.Parse(begin) && k.NGAY_TAO <= DateTime.Parse(end)).ToList();
	            }
            }
            else if (tinhTrang==1)
            {
                if (dvql!="PN")
                {
                    return db.K_YEU_CAUs.Where(k => k.MA_DVIQLY.Equals(dvql) && k.NGAY_TAO >= DateTime.Parse(begin) && k.NGAY_TAO <= DateTime.Parse(end) && (k.TINH_TRANG.Equals("Chưa xử lý") || k.TINH_TRANG == null)).ToList();
                }
                else
                {
                    return db.K_YEU_CAUs.Where(k => k.TINH_TRANG.Equals("Chưa xử lý") && k.NGAY_TAO >= DateTime.Parse(begin) && k.NGAY_TAO <= DateTime.Parse(end)).ToList();
                }
            }
            else if (tinhTrang==2)
            {
                if (dvql!="PN")
                {
                    return db.K_YEU_CAUs.Where(k => k.MA_DVIQLY.Equals(dvql) && k.TINH_TRANG.Equals("Đang xử lý") && k.NGAY_TAO >= DateTime.Parse(begin) && k.NGAY_TAO <= DateTime.Parse(end)).ToList();
                }
                else
                {
                    return db.K_YEU_CAUs.Where(k => k.TINH_TRANG.Equals("Đang xử lý") && k.NGAY_TAO >= DateTime.Parse(begin) && k.NGAY_TAO <= DateTime.Parse(end)).ToList();
                }
            }
            else
            {
                if (dvql != "PN")
                {
                    return db.K_YEU_CAUs.Where(k => k.MA_DVIQLY.Equals(dvql) && k.TINH_TRANG.Equals("Đã xử lý xong") && k.NGAY_TAO >= DateTime.Parse(begin) && k.NGAY_TAO <= DateTime.Parse(end)).ToList();
                }
                else
                {
                    return db.K_YEU_CAUs.Where(k => k.TINH_TRANG.Equals("Đã xử lý xong") && k.NGAY_TAO >= DateTime.Parse(begin) && k.NGAY_TAO <= DateTime.Parse(end)).ToList();
                }
            }
        }
    }
}
