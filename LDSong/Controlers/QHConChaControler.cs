using LDSong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class QHConChaControler
    {
        private LDSongDataContext db;

        public QHConChaControler()
        {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }
        public List<D_QHE_PTDIEN_VITRI> listQH(int idCon) {
            return db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCon == idCon).ToList();
        }
        public List<QuanHeModel> listConCha(int idCon)
        {
            List<D_QHE_PTDIEN_VITRI> lst = listQH(idCon);
            List<QuanHeModel> lstConCha = new List<QuanHeModel>();
            foreach (var item in lst)
            {
                QuanHeModel cc = new QuanHeModel();
                cc.ID = item.ID;
                cc.ID_PTDienCha = item.ID_PTDienCha;
                cc.VITRI = item.VITRI;
                var d = db.D_PTDIENs.Where(p => p.ID_PTDIEN == item.ID_PTDienCha).FirstOrDefault();
                cc.TEN_LOAI = d.D_LOAI_TBI.TEN_LOAI;
                cc.TEN_PTDIEN = d.TEN_PTDIEN;
                lstConCha.Add(cc);
            }
            return lstConCha;
        }
        public string tenPTD(int idCon) {
            return db.D_PTDIENs.Where(p => p.ID_PTDIEN == idCon).FirstOrDefault().TEN_PTDIEN;
        }
    }
}
