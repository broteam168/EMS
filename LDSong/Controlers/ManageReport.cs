using LDSong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class ManageReport
    {
        private LDSongDataContext db;
        public ManageReport() {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }
        public List<S_BAOCAO> getList() {
            return db.S_BAOCAOs.ToList();
        }
        public void update(S_BAOCAO obj) {
            S_BAOCAO bc= db.S_BAOCAOs.Where(b => b.ID == obj.ID).SingleOrDefault();
            if (bc!=null)
            {
                bc.TENBAOCAO = obj.TENBAOCAO;
                bc.TIEUDEBAOCAO = obj.TIEUDEBAOCAO;
                bc.CHUCDANH = obj.CHUCDANH;
                bc.NGUOIKY = obj.NGUOIKY;
                db.SubmitChanges();
            }
        }
    }
}
