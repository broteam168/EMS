using LDSong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class CD_KDCBcontroler
    {
        private LDSongDataContext db;
        public CD_KDCBcontroler() {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }
        public List<M_TTHAI_CD_KDCB> listCD(string dvql) {
            if (!dvql.Equals("PN"))
            {
                return db.M_TTHAI_CD_KDCBs.Where(p=>p.D_PTDIEN.MA_DVQLY.Equals("dvql")).ToList();
            }
            else
            {
                return db.M_TTHAI_CD_KDCBs.OrderBy(p=>p.D_PTDIEN.MA_DVQLY).ToList();
            }
        }
        public void add(M_TTHAI_CD_KDCB _obj) {
            db.M_TTHAI_CD_KDCBs.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public bool chechexist(int idPTDien) {
            var d=db.M_TTHAI_CD_KDCBs.Where(p => p.ID_PTDIEN == idPTDien).Count();
            if (d!=0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void delete(int idPTDien)
        {
            var tmp = db.M_TTHAI_CD_KDCBs.Where(p => p.ID_PTDIEN == idPTDien).SingleOrDefault();
            if (tmp!=null)
            {
                db.M_TTHAI_CD_KDCBs.DeleteOnSubmit(tmp);
                db.SubmitChanges();
            }
        }
        public List<D_PTDIEN> listCDAll(string dvql) {
            if (!dvql.Equals("PN"))
            {
                return db.D_PTDIENs.Where(p => p.MA_DVQLY.Equals(dvql) && !p.MA_CAPDA.Equals("03") && !p.MA_CAPDA.Equals("08") && p.LOAI_PTDIEN.Equals("DS")).ToList();
            }
            else
            {
                return db.D_PTDIENs.Where(p => !p.MA_CAPDA.Equals("03") && !p.MA_CAPDA.Equals("08") && p.LOAI_PTDIEN.Equals("DS")).ToList();
            }
        }
    }
}
