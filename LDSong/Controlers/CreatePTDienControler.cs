using LDSong.Models;
using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class CreatePTDienControler
    {
        private LDSongDataContext db;
        public string toado;
        public CreatePTDienControler()
        {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }
        public List<D_CAP_DAP> listCapDienAp() {
            return db.D_CAP_DAPs.Where(d => d.MA_CAPDA == "05" || d.MA_CAPDA == "06").ToList();
        }
        public List<D_LOAI_TBI> listLoaiThietBi(bool _dz=false) {
            if (_dz==false)
            {
                return db.D_LOAI_TBIs.Where(t => t.MA_LOAI == "TT" || t.MA_LOAI == "DS" || t.MA_LOAI == "SI" || t.MA_LOAI == "MC" || t.MA_LOAI == "CB" || t.MA_LOAI=="TG").ToList();
            }
            else
            {
                return db.D_LOAI_TBIs.Where(t => t.MA_LOAI == "DZ").ToList();
            }
        }
        public List<D_DVI_QLY> listDonvi(string dvql)
        {
            if (dvql!="PN")
            {
                return db.D_DVI_QLies.Where(p=>p.MA_DVIQLY.Equals(dvql)).ToList();
            }
            else
            {
                return db.D_DVI_QLies.ToList();
            }
        }
        public void addPTDien(D_PTDIEN _obj)
        {
            db.D_PTDIENs.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public void addImage(D_Image _obj)
        {
            db.D_Images.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public void addViTri(M_VITRI_V _obj)
        {
            db.M_VITRI_Vs.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public void insertORupdateVitri(string query) {
            SqlConnection con = new SqlConnection(LDSong.Properties.Settings.Default.connect);
            con.Open(); 
            SqlCommand sqlcmd = new SqlCommand(query, con); 
            sqlcmd.ExecuteNonQuery(); 
            con.Close();
        }
        public bool checkMaPmiss(string ma)
        {
            int c = db.D_PTDIENs.Where(p => p.MA_PMIS.Equals(ma)).Count(); 
            if (c>=1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool checkDVQL(string madv)
        {
            int c = db.D_DVI_QLies.Where(p => p.MA_DVIQLY.Equals(madv)).Count();
            if (c>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkMaCapda(string macap)
        {
            int c = db.D_CAP_DAPs.Where(p => p.MA_CAPDA.Equals(macap)).Count();
            if (c >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkTenCapda(string tencap)
        {
            int c = db.D_CAP_DAPs.Where(p => p.TEN_CAPDA.Equals(tencap)).Count();
            if (c >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkLoaiPTDien(string loai)
        {
            int c = db.D_LOAI_TBIs.Where(p => p.MA_LOAI.Equals(loai)).Count();
            if (c >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void addTrangThai(M_TTHAI_PTDIEN _obj)
        {
            db.M_TTHAI_PTDIENs.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public void addTrangThai_VM(M_TTHAI_PTDIEN_VM _obj)
        {
            db.M_TTHAI_PTDIEN_VMs.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public void addTrangThai(M_TTHAI_PTDIEN_LR _obj)
        {
            db.M_TTHAI_PTDIEN_LRs.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public void addTrangThai_VM(M_TTHAI_PTDIEN_LR_VM _obj)
        {
            db.M_TTHAI_PTDIEN_LR_VMs.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public DateTime getDateServer()
        {
            return db.GetServerDate();
        }
        public int getIDPTDien(string tenPTDien) {
            var d = (from p in db.D_PTDIENs where p.TEN_PTDIEN.Equals(tenPTDien) orderby p.ID_PTDIEN descending select p).Skip(0).Take(1);
            return d.FirstOrDefault().ID_PTDIEN;
        }
        public M_VITRI_V2 getAllPTDien(int id)
        {
            SqlGeometry geo = new SqlGeometry();
            M_VITRI_V2 m = db.M_VITRI_V2s.Where(p=>p.ID_PTDIEN==id).FirstOrDefault();
            if (m.TOA_DO!=null)
            {
                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                m.TOA_DO.ToArray()
                                )));
                toado = xulyChuoi(geo.ToString());
            }
            return m;
        }
        public string xulyChuoi(string s) {
            string[] xlline = s.Split('(');
            return xlline[1].Replace(")", "");
        }
        public void updatePTDien(D_PTDIEN _obj) {
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
        public void delete(int _Ma)
        {
            D_PTDIEN tmp = db.D_PTDIENs.Where(p => p.ID_PTDIEN.Equals(_Ma)).SingleOrDefault();
            if (tmp != null)
            {
                db.D_PTDIENs.DeleteOnSubmit(tmp);
                db.SubmitChanges();
            }
        }
    }
}
