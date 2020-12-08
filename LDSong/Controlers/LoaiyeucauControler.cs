using LDSong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class LoaiyeucauControler
    {
        private D_LOAI_YCAU obj;
        private LDSongDataContext db;

        public LoaiyeucauControler()
        {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }

        public bool checkExists(string _Ma)
        {
            obj = db.D_LOAI_YCAUs.Where(p => p.MA_LOAI.Equals(_Ma)).SingleOrDefault();
            if (obj != null) return true;
            else return false;
        }

        public void add(D_LOAI_YCAU _obj)
        {
            db.D_LOAI_YCAUs.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public void update(D_LOAI_YCAU _obj)
        {
            D_LOAI_YCAU tmp = db.D_LOAI_YCAUs.Where(p => p.MA_LOAI.Equals(_obj.MA_LOAI)).SingleOrDefault();
            if(tmp != null)
            {
                tmp.TEN_LOAI = _obj.TEN_LOAI;
                db.SubmitChanges();
            }
        }
        public List<D_LOAI_YCAU> list()
        {
            return db.D_LOAI_YCAUs.OrderBy(p => p.MA_LOAI).ToList();
        }
        public void delete(string _Ma)
        {
            Console.WriteLine("aa "+ _Ma);
            D_LOAI_YCAU tmp = db.D_LOAI_YCAUs.Where(p => p.MA_LOAI.Equals(_Ma)).SingleOrDefault();
            if (tmp != null)
            {
                db.D_LOAI_YCAUs.DeleteOnSubmit(tmp);
                db.SubmitChanges();
            }
        }
    }
}
