using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LDSong.Models;

namespace LDSong.Controlers
{
    public class DVQLControler
    {
        private D_DVI_QLY obj;
        private LDSongDataContext db;

        public DVQLControler() {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }

        public bool checkExists(string _Ma)
        {
            obj = db.D_DVI_QLies.Where(p => p.MA_DVIQLY.Equals(_Ma)).SingleOrDefault();
            if (obj != null) return true;
            else return false;
        }

        public void add(D_DVI_QLY _obj) {
            db.D_DVI_QLies.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public void update(D_DVI_QLY _obj)
        {
            D_DVI_QLY tmp = db.D_DVI_QLies.Where(p => p.MA_DVIQLY.Equals(_obj.MA_DVIQLY)).SingleOrDefault();
            if(tmp != null)
            {
                tmp.TEN_DVIQLY = _obj.TEN_DVIQLY;
                tmp.DIA_CHI = _obj.DIA_CHI;
                tmp.DIEN_THOAI = _obj.DIEN_THOAI;
                tmp.TOA_DO = _obj.TOA_DO;
                db.SubmitChanges();
            }
        }
        public List<D_DVI_QLY> list()
        {
            return db.D_DVI_QLies.OrderBy(p => p.MA_DVIQLY).ToList();
        }
        public void delete(string _Ma)
        {
            D_DVI_QLY tmp = db.D_DVI_QLies.Where(p => p.MA_DVIQLY.Equals(_Ma)).SingleOrDefault();
            if (tmp != null)
            {
                db.D_DVI_QLies.DeleteOnSubmit(tmp);
                db.SubmitChanges();
            }
        }
        public bool checkExist(string _Ma)
        {
            int c = db.D_PTDIENs.Where(p => p.MA_DVQLY.Equals(_Ma)).Count();
            if (c>0)
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
