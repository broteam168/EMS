using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDSong.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.SqlServer.Types;

namespace LDSong.Controlers
{
    
    class CreatePTDSoDo1SoiControler
    {
        LDSongDataContext data;
        public string toado;
        public CreatePTDSoDo1SoiControler()
        {
            try
                {
                    data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    System.Windows.Forms.MessageBox.Show("Không thể kết nối được tới máy chủ. Bạn vui lòng kiểm tra lại kết nối và khởi động lại phần mềm.");
                    throw;
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Có lỗi xảy ra vui lòng kiểm tra lại. " + e.ToString());
                    throw;
                }
        }
        public List<D_PTDIEN> getListPTDien(string dvql) {
            if (!dvql.Equals("PN"))
            {
                return data.D_PTDIENs.Where(p => !p.LOAI_PTDIEN.Equals("DZ") && !p.LOAI_PTDIEN.Equals("VS") && !p.LOAI_PTDIEN.Equals("1S") && !p.LOAI_PTDIEN.Equals("TT") && p.MA_DVQLY.Equals(dvql)).ToList();
            }
            else
            {
                return data.D_PTDIENs.Where(p => !p.LOAI_PTDIEN.Equals("DZ") && !p.LOAI_PTDIEN.Equals("VS") && !p.LOAI_PTDIEN.Equals("1S") && !p.LOAI_PTDIEN.Equals("TT")).ToList();
            }
        }
        public void insertORupdateVitri(string query)
        {
            SqlConnection con = new SqlConnection(LDSong.Properties.Settings.Default.connect);
            con.Open();
            SqlCommand sqlcmd = new SqlCommand(query, con);
            sqlcmd.ExecuteNonQuery();
            con.Close();
        }
        public bool checkExist(string query)
        {
            SqlConnection con = new SqlConnection(LDSong.Properties.Settings.Default.connect);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            con.Close();
            if (da.Fill(dt)!=0)
            {
                return false;
            }
            else
	        {
                return true;
	        }
        }
        public void insertORupdateVitri_DZ(string query)
        {
            SqlConnection con = new SqlConnection(LDSong.Properties.Settings.Default.connect);
            con.Open();
            SqlCommand sqlcmd = new SqlCommand(query, con);
            sqlcmd.ExecuteNonQuery();
            con.Close();
        }
        public List<D_DVI_QLY> getListDVQL(string dvql) {
            if (!dvql.Equals("PN"))
            {
                return data.D_DVI_QLies.Where(p => p.MA_DVIQLY.Equals(dvql)).ToList();
            }
            else
            {
                return data.D_DVI_QLies.Where(p => !p.MA_DVIQLY.Equals("PN")).ToList();
            }
        }
        public DateTime getDateServer() {
            return data.GetServerDate();
        }
        public void addPTDien(D_PTDIEN _obj)
        {
            data.D_PTDIENs.InsertOnSubmit(_obj);
            data.SubmitChanges();
        }
        public void updatePTDien(D_PTDIEN _obj)
        {
            D_PTDIEN tmp = data.D_PTDIENs.Where(p => p.ID_PTDIEN.Equals(_obj.ID_PTDIEN)).SingleOrDefault();
            if (tmp != null)
            {
                tmp.TEN_PTDIEN = _obj.TEN_PTDIEN;
                tmp.D_CAP_DAP = data.D_CAP_DAPs.Single(p => p.MA_CAPDA == _obj.MA_CAPDA);
                tmp.TEN_CAPDA = _obj.TEN_CAPDA;
                tmp.D_LOAI_TBI = data.D_LOAI_TBIs.Single(p => p.MA_LOAI == _obj.LOAI_PTDIEN);
                tmp.MA_CMIS = _obj.MA_CMIS;
                tmp.D_DVI_QLY = data.D_DVI_QLies.Single(p => p.MA_DVIQLY == _obj.MA_DVQLY);
                tmp.MA_PMIS = _obj.MA_PMIS;
                tmp.MA_PMISCHA = _obj.MA_PMISCHA;
                tmp.MA_SCADA = _obj.MA_SCADA;
                tmp.NGAY_SUA = _obj.NGAY_SUA;
                data.SubmitChanges();
            }
        }
        public int getIDPTDien(string tenPTDien)
        {
            var d = (from p in data.D_PTDIENs where p.TEN_PTDIEN.Equals(tenPTDien) orderby p.ID_PTDIEN descending select p).Skip(0).Take(1);
            return d.FirstOrDefault().ID_PTDIEN;
        }
        public void addTrangThai(M_TTHAI_PTDIEN _obj)
        {
            data.M_TTHAI_PTDIENs.InsertOnSubmit(_obj);
            data.SubmitChanges();
        }
        public void addTrangThai(M_TTHAI_PTDIEN_LR _obj)
        {
            data.M_TTHAI_PTDIEN_LRs.InsertOnSubmit(_obj);
            data.SubmitChanges();
        }
        public M_VITRI_SD1S_V2 getAllPTDien(int id)
        {
            SqlGeometry geo = new SqlGeometry();
            M_VITRI_SD1S_V2 m = data.M_VITRI_SD1S_V2s.Where(p => p.ID_PTDIEN == id).FirstOrDefault();
            if (m.VITRI != null)
            {
                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                m.VITRI.ToArray()
                                )));
                toado = xulyChuoi(geo.ToString());
            }
            return m;
        }
        public M_NOTE_V getAllNote(int id)
        {
            SqlGeometry geo = new SqlGeometry();
            M_NOTE_V m = data.M_NOTE_Vs.Where(p => p.ID == id).FirstOrDefault();
            if (m.VITRI != null)
            {
                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                m.VITRI.ToArray()
                                )));
                toado = xulyChuoi(geo.ToString());
            }
            return m;
        }
        public M_VITRI_V2 getAllPTDienDZ(int id)
        {
            SqlGeometry geo = new SqlGeometry();
            M_VITRI_V2 m = data.M_VITRI_V2s.Where(p => p.ID_PTDIEN == id).FirstOrDefault();
            if (m.TOA_DO != null)
            {
                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                m.TOA_DO.ToArray()
                                )));
                toado = xulyChuoi(geo.ToString());
            }
            return m;
        }
        public string xulyChuoi(string s)
        {
            string[] xlline = s.Split('(');
            return xlline[1].Replace(")", "");
        }
        public bool checkQH(int idPTD)
        {
            int c = data.D_QHE_PTDIEN_VITRIs.Where(d => d.ID_PTDienCha == idPTD).Count();
            int e = data.D_QHE_PTDIEN_VITRIs.Where(d => d.ID_PTDienCon == idPTD).Count();
            if (c != 0 && e != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public D_PTDIEN getthongtinDiem(int id)
        {

            return data.D_PTDIENs.Where(p => p.ID_PTDIEN.Equals(id)).SingleOrDefault();

        }
        public void addHisStoryDelete(HISTORY_DELETE_DPTIDEN _objDelete)
        {
            data.HISTORY_DELETE_DPTIDENs.InsertOnSubmit(_objDelete);
            data.SubmitChanges();
        }
        public void delete(string _Ma)
        {
            D_PTDIEN tmp = data.D_PTDIENs.Where(p => p.ID_PTDIEN.Equals(_Ma)).SingleOrDefault();
            if (tmp != null)
            {
                data.D_PTDIENs.DeleteOnSubmit(tmp);
                data.SubmitChanges();
            }
        }
        public void deleteTT(int idPTD)
        {
            List<M_TTHAI_PTDIEN> tmp = data.M_TTHAI_PTDIENs.Where(p => p.ID_PTDIEN.Equals(idPTD)).ToList();
            if (tmp.Count != 0)
            {
                foreach (var item in tmp)
                {
                    data.M_TTHAI_PTDIENs.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
            }
        }
        public void deleteTTLR(int idPTD)
        {
            List<M_TTHAI_PTDIEN_LR> tmp = data.M_TTHAI_PTDIEN_LRs.Where(p => p.ID_PTDIEN.Equals(idPTD)).ToList();
            if (tmp.Count != 0)
            {
                foreach (var item in tmp)
                {
                    data.M_TTHAI_PTDIEN_LRs.DeleteOnSubmit(item);
                    data.SubmitChanges();
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
        public void deleteQH(int idcon) {
            var tmp = data.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCon == idcon).ToList();
            if (tmp.Count != 0)
            {
                foreach (var item in tmp)
                {
                    data.D_QHE_PTDIEN_VITRIs.DeleteOnSubmit(item);
                    data.SubmitChanges();
                }
            }
        }
    }
}
