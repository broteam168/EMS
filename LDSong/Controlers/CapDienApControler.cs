using LDSong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class CapDienApControler
    {
        private D_CAP_DAP obj;
        private LDSongDataContext db;

        public CapDienApControler()
        {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }

        public bool checkExists(string _Ma)
        {
            obj = db.D_CAP_DAPs.Where(p => p.MA_CAPDA.Equals(_Ma)).SingleOrDefault();
            if (obj != null) return true;
            else return false;
        }

        public void add(D_CAP_DAP _obj)
        {
            db.D_CAP_DAPs.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public void update(D_CAP_DAP _obj)
        {
            D_CAP_DAP tmp = db.D_CAP_DAPs.Where(p => p.MA_CAPDA.Equals(_obj.MA_CAPDA)).SingleOrDefault();
            if(tmp != null)
            {
                tmp.MA_PMIS = _obj.MA_PMIS;
                tmp.TEN_CAPDA = _obj.TEN_CAPDA;
                db.SubmitChanges();
            }
        }
        public List<D_CAP_DAP> list()
        {
            return db.D_CAP_DAPs.OrderBy(p => p.MA_CAPDA).ToList();
        }
        public void delete(string _Ma)
        {
            D_CAP_DAP tmp = db.D_CAP_DAPs.Where(p => p.MA_CAPDA.Equals(_Ma)).SingleOrDefault();
            if (tmp != null)
            {
                db.D_CAP_DAPs.DeleteOnSubmit(tmp);
                db.SubmitChanges();
            }
        }
        public bool checkExist(string _Ma)
        {
            int c = db.D_PTDIENs.Where(p => p.MA_CAPDA.Equals(_Ma)).Count();
            if (c > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
