using LDSong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class ThongSoTBAControler
    {
        private LDSongDataContext db;
        public ThongSoTBAControler()
        {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }
        public void add(D_ChiTiet_TBA _obj)
        {
            db.D_ChiTiet_TBAs.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public void update(D_ChiTiet_TBA _obj)
        {
            D_ChiTiet_TBA tmp = db.D_ChiTiet_TBAs.Where(p => p.ID_PTDIEN.Equals(_obj.ID_PTDIEN)).SingleOrDefault();
            if (tmp != null)
            {
                tmp.fHz = _obj.fHz;
                tmp.I0 = _obj.I0;
                tmp.Idm1 = _obj.Idm1;
                tmp.Idm2 = _obj.Idm2;
                tmp.Note = _obj.Note;
                tmp.P0 = _obj.P0;
                tmp.Sdm = _obj.Sdm;
                tmp.Trong_Luong_Dau = _obj.Trong_Luong_Dau;
                tmp.Trong_Luong_TBA = _obj.Trong_Luong_TBA;
                tmp.Udm1 = _obj.Udm1;
                tmp.Udm2 = _obj.Udm2;
                tmp.UN = _obj.UN;
                db.SubmitChanges();
            }
        }
        public D_ChiTiet_TBA DetailTBA(int idPTDien)
        {
            return db.D_ChiTiet_TBAs.Where(p=>p.ID_PTDIEN== idPTDien).SingleOrDefault();
        }
    }
}
