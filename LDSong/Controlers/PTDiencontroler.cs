using LDSong.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class PTDiencontroler
    {
        //private D_PTDIEN obj;
        private LDSongDataContext db;

        public PTDiencontroler()
        {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }
        public void add(D_PTDIEN _obj)
        {
            db.D_PTDIENs.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public void update(D_PTDIEN _obj)
        {
            D_PTDIEN tmp = db.D_PTDIENs.Where(p => p.ID_PTDIEN.Equals(_obj.ID_PTDIEN)).SingleOrDefault();
            if (tmp != null)
            {
                tmp.TEN_PTDIEN = _obj.TEN_PTDIEN;
                tmp.D_CAP_DAP = db.D_CAP_DAPs.Single(p => p.MA_CAPDA == _obj.MA_CAPDA);
                tmp.TEN_CAPDA = _obj.TEN_CAPDA;
                tmp.D_LOAI_TBI = db.D_LOAI_TBIs.Single(p => p.MA_LOAI == _obj.LOAI_PTDIEN);

                tmp.MA_CMIS = _obj.MA_CMIS; 
                tmp.D_DVI_QLY = db.D_DVI_QLies.Single(p => p.MA_DVIQLY == _obj.MA_DVQLY);
                tmp.MA_PMIS = _obj.MA_PMIS;
                tmp.MA_PMISCHA = _obj.MA_PMISCHA;
                tmp.MA_SCADA = _obj.MA_SCADA;
                tmp.NGAY_SUA = _obj.NGAY_SUA;
                db.SubmitChanges();
            }
        }
        public List<D_PTDIEN> search(string str,string dvql)
        {
            //var d = from ptd in db.D_PTDIENs where ptd.ID_PTDIEN==int.Parse(str) || ptd.TEN_PTDIEN.Contains(str) || ptd.MA_CAPDA.Contains(str) || ptd.MA_CMIS.Contains(str) || ptd.MA_PMISCHA.Contains(str) select ptd;
            if (dvql!="PN")
            {
                try
                {
                    return db.D_PTDIENs.Where(ptd => ptd.ID_PTDIEN == int.Parse(str) && ptd.MA_DVQLY.Equals(dvql)).ToList();
                }
                catch (Exception)
                {
                    return db.D_PTDIENs.Where(ptd => ptd.MA_DVQLY.Equals(dvql) && (ptd.TEN_PTDIEN.Contains(str) || ptd.MA_CAPDA.Contains(str) || ptd.MA_CMIS.Contains(str) || ptd.MA_PMISCHA.Contains(str))).ToList();
                }
            }
            else
            {
                try
                {
                    return db.D_PTDIENs.Where(ptd => ptd.ID_PTDIEN == int.Parse(str)).ToList();
                }
                catch (Exception)
                {
                    return db.D_PTDIENs.Where(ptd => ptd.TEN_PTDIEN.Contains(str) || ptd.MA_CAPDA.Contains(str) || ptd.MA_CMIS.Contains(str) || ptd.MA_PMISCHA.Contains(str)).ToList();
                }
            }
        }
        public List<D_PTDIEN> list(string dvql)
        {
            if (dvql!="PN")
            {
                return db.D_PTDIENs.Where(p=>p.MA_DVQLY.Equals(dvql)).OrderBy(pt => pt.ID_PTDIEN).ToList();
            }
            else
            {
                return db.D_PTDIENs.OrderBy(pt => pt.ID_PTDIEN).ToList();
            }
        }
        public void delete(int _Ma)
        {
            D_PTDIEN tmp = db.D_PTDIENs.Where(p => p.ID_PTDIEN.Equals(_Ma)).SingleOrDefault();
            if (tmp != null)
            {
                db.D_PTDIENs.DeleteOnSubmit(tmp);
                db.SubmitChanges();
            }
        }
        public List<M_TTHAI_PTDIEN> listTT(int id) {
            return db.M_TTHAI_PTDIENs.Where(p => p.ID_PTDIEN == id).ToList();
        }
        public List<M_TTHAI_PTDIEN_LR> listTTLR(int id)
        {
            return db.M_TTHAI_PTDIEN_LRs.Where(p => p.ID_PTDIEN == id).ToList();
        }
        public void deleteTT(int idPTD)
        {
            List<M_TTHAI_PTDIEN> tmp = db.M_TTHAI_PTDIENs.Where(p => p.ID_PTDIEN.Equals(idPTD)).ToList();
            if (tmp.Count != 0)
            {
                foreach (var item in tmp)
                {
                    db.M_TTHAI_PTDIENs.DeleteOnSubmit(item);
                    db.SubmitChanges();
                }
            }
        }
        public void deleteTTVM(int idPTD)
        {
            List<M_TTHAI_PTDIEN_VM> tmp = db.M_TTHAI_PTDIEN_VMs.Where(p => p.ID_PTDIEN.Equals(idPTD)).ToList();
            if (tmp.Count != 0)
            {
                foreach (var item in tmp)
                {
                    db.M_TTHAI_PTDIEN_VMs.DeleteOnSubmit(item);
                    db.SubmitChanges();
                }
            }
        }
        public void deleteTTLR(int idPTD)
        {
            List<M_TTHAI_PTDIEN_LR> tmp = db.M_TTHAI_PTDIEN_LRs.Where(p => p.ID_PTDIEN.Equals(idPTD)).ToList();
            if (tmp.Count != 0)
            {
                foreach (var item in tmp)
                {
                    db.M_TTHAI_PTDIEN_LRs.DeleteOnSubmit(item);
                    db.SubmitChanges();
                }
            }
        }
        public void deleteTTLRVM(int idPTD)
        {
            List<M_TTHAI_PTDIEN_LR_VM> tmp = db.M_TTHAI_PTDIEN_LR_VMs.Where(p => p.ID_PTDIEN.Equals(idPTD)).ToList();
            if (tmp.Count != 0)
            {
                foreach (var item in tmp)
                {
                    db.M_TTHAI_PTDIEN_LR_VMs.DeleteOnSubmit(item);
                    db.SubmitChanges();
                }
            }
        }
        public void deleteVT(string query)
        {
            SqlConnection con = new SqlConnection(LDSong.Properties.Settings.Default.connect);
            con.Open(); 
            SqlCommand sqlcmd = new SqlCommand(query, con);
            sqlcmd.ExecuteNonQuery(); 
            con.Close();
        }
        
        public void deleteNodeTree(int idIPTD) {
            var tmp = db.D_QHE_PTDIENs.Where(p => p.ID_PTDIEN == idIPTD).ToList();
            if (tmp.Count!=0)
            {
                foreach (var item in tmp)
                {
                    db.D_QHE_PTDIENs.DeleteOnSubmit(item);
                    db.SubmitChanges();
                }
            }
            var tmp1 = db.D_QHE_PTDIENs.Where(p => p.ID_PTCHA == idIPTD).ToList();
            if (tmp1.Count!=0)
            {
                foreach (var item1 in tmp1)
                {
                    db.D_QHE_PTDIENs.DeleteOnSubmit(item1); 
                    db.SubmitChanges();
                }
            }
        }
        public bool checkQH(int idPTD) {
           int c= db.D_QHE_PTDIEN_VITRIs.Where(d => d.ID_PTDienCha == idPTD).Count();
           int e = db.D_QHE_PTDIEN_VITRIs.Where(d => d.ID_PTDienCon == idPTD).Count();
           if (c>=1)
           {
               return false;
           }
           else
           {
               if (e>=1)
               {
                   return false;
               }
               else
               {
                   return true;
               }
           }
        }
        public void deleteQH(int idcon)
        {
            var tmp = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCon == idcon).ToList();
            if (tmp.Count != 0)
            {
                foreach (var item in tmp)
                {
                    db.D_QHE_PTDIEN_VITRIs.DeleteOnSubmit(item);
                    db.SubmitChanges();
                }
            }
        }
        public List<D_DVI_QLY> listDVQLY(string dvql) {
            if (dvql!="PN")
            {
                return db.D_DVI_QLies.Where(p=>p.MA_DVIQLY.Equals(dvql)).ToList();
            }
            else
            {
                return db.D_DVI_QLies.ToList();
            }
        }
        public List<D_LOAI_TBI> listTB() {
            return db.D_LOAI_TBIs.ToList();
        }
        public DateTime getDateServer()
        {
            return db.GetServerDate();
        }
        public D_PTDIEN getthongtinDiem(int id)
        {
            
            return db.D_PTDIENs.Where(p => p.ID_PTDIEN.Equals(id)).SingleOrDefault();
            
        }
        public void addHisStoryDelete(HISTORY_DELETE_DPTIDEN _objDelete) {
            db.HISTORY_DELETE_DPTIDENs.InsertOnSubmit(_objDelete);
            db.SubmitChanges();
        }
        public void addHisStoryDeleteTT(HISTORY_TTHAI_PTDIEN _objDelete)
        {
            db.HISTORY_TTHAI_PTDIENs.InsertOnSubmit(_objDelete);
            db.SubmitChanges();
        }
        public void addHisStoryDeleteTTLR(HISTORY_TTHAI_PTDIEN_LR _objDelete)
        {
            db.HISTORY_TTHAI_PTDIEN_LRs.InsertOnSubmit(_objDelete);
            db.SubmitChanges();
        }
    }
}
