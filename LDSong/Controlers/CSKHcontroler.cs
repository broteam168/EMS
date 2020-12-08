using LDSong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class CSKHcontroler
    {
        private K_YEU_CAU obj;
        private LDSongDataContext db;
        public CSKHcontroler()
        {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }
        public K_YEU_CAU getYeuCau(int id) {
            return db.K_YEU_CAUs.Where(k => k.ID_YCAU == id).SingleOrDefault();
        }
        public void updateYeuCau(K_YEU_CAU _obj,string userName) {
            K_YEU_CAU kh = db.K_YEU_CAUs.Where(k => k.ID_YCAU == _obj.ID_YCAU).SingleOrDefault();
            if (kh!=null)
            {
                kh.NGUOI_XU_LY = _obj.NGUOI_XU_LY;
                kh.TINH_TRANG = _obj.TINH_TRANG;
                kh.NGUOI_CAP_NHAT = userName;
                db.SubmitChanges();
            }
        }

    }
}
