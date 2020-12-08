using LDSong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class QHPTDiencontroler
    {
        private D_QHE_PTDIEN obj;
        private LDSongDataContext db;
        public List<int> ListUpdate;
        public QHPTDiencontroler()
        {
            try
            {
                db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
                ListUpdate = new List<int>();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                System.Windows.Forms.MessageBox.Show("Không thể kết nối được tới máy chủ. Bạn vui lòng kiểm tra lại kết nối và khởi động lại phần mềm.");
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Có lỗi xảy ra vui lòng kiểm tra lại. " + e.ToString());
            }
        }
        public void add(D_QHE_PTDIEN _obj)
        {
            try
            {
                db.D_QHE_PTDIENs.InsertOnSubmit(_obj);
                db.SubmitChanges();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                System.Windows.Forms.MessageBox.Show("Không thể kết nối được tới máy chủ. Bạn vui lòng kiểm tra lại kết nối và khởi động lại phần mềm.");
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Có lỗi xảy ra vui lòng kiểm tra lại. " + e.ToString());
            }
        }
        
        public List<D_QHE_PTDIEN> search(string str)
        {
            try
            {
                return db.D_QHE_PTDIENs.Where(ptd => ptd.ID_PTDIEN==int.Parse(str)).ToList();
            }
            catch (Exception)
            {
                return null;
                //return db.D_PTDIENs.Where(ptd => ptd.TEN_PTDIEN.Contains(str) || ptd.MA_CAPDA.Contains(str) || ptd.MA_CMIS.Contains(str) || ptd.MA_PMISCHA.Contains(str)).ToList();
            }
        }
        public List<D_QHE_PTDIEN> list()
        {
             //var d = from qh in db.D_QHE_PTDIENs join pt in db.D_PTDIENs on qh.ID_PTDIEN equals pt.ID_PTDIEN select new { qh.ID_PTDIEN,qh.ID_PTCHA,qh.ID_QHE,qh.NGAY_HLUC,pt.TEN_PTDIEN};
            
            return db.D_QHE_PTDIENs.OrderBy(p => p.ID_PTDIEN).ToList();
        }
        public void delete(string _Ma)
        {
            D_QHE_PTDIEN tmp = db.D_QHE_PTDIENs.Where(p => p.ID_PTDIEN.Equals(_Ma)).SingleOrDefault();
            if (tmp != null)
            {
                db.D_QHE_PTDIENs.DeleteOnSubmit(tmp);
                db.SubmitChanges();
            }
        }
        public List<string> getDVQL() {
            List<string> str = new List<string>();
            var d = from ql in db.D_DVI_QLies select ql;
            foreach (var item in d)
            {
                str.Add(item.MA_DVIQLY);
            }
            return str;
        }
        public List<D_PTDIEN> getCha(string dvql) {
            List<int> lst = new List<int>();
            if (dvql=="PN")
            {
                var d = from pt in db.D_PTDIENs  select pt;
                return d.ToList();
            }
            else
            {
                var d = from pt in db.D_PTDIENs where pt.MA_PMISCHA == dvql select pt;
                return d.ToList();
            }
        }
        public List<D_QHE_PTDIEN> listTree(int _Parent,string dvql)
        {
            var d = from qh in db.D_QHE_PTDIENs where qh.ID_PTCHA == _Parent && qh.D_PTDIEN.MA_DVQLY==dvql group qh by qh.ID_PTDIEN into pt orderby pt.Key select pt.FirstOrDefault();
            return d.ToList();
        }
        public List<D_CAY_TON_THAT> listCayTT(int _Parent, string dvql)
        {
            var d = from qh in db.D_CAY_TON_THATs where qh.ID_PTCHA == _Parent && qh.D_PTDIEN.MA_DVQLY == dvql group qh by qh.ID_PTDIEN into pt orderby pt.Key select pt.FirstOrDefault();
            return d.ToList();
        }
        public List<D_QHE_PTDIEN> getNode(int idPTDien) {
            var d = from qh in db.D_QHE_PTDIENs where qh.ID_PTDIEN ==idPTDien group qh by qh.NGAY_HLUC into pt orderby pt.Key select pt.FirstOrDefault();
            return d.ToList();
        }
        public List<D_LOAI_TBI> listLoaiTB() {
            return db.D_LOAI_TBIs.ToList();
        }
        public List<D_CAP_DAP> listDienap() {
            return db.D_CAP_DAPs.ToList();
        }
        public List<D_DVI_QLY> listDVQL(string dvql) {
            if (dvql=="PN")
            {
                return db.D_DVI_QLies.ToList();
            }
            else
            {
                return db.D_DVI_QLies.Where(p => p.MA_DVIQLY.Equals(dvql)).ToList();
            }
        }
        public void addRoot(D_QHE_PTDIEN _obj)
        {
            db.D_QHE_PTDIENs.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public void addCayTT(D_CAY_TON_THAT _obj)
        {
            db.D_CAY_TON_THATs.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public void updateRoot(D_QHE_PTDIEN _obj)
        {
            obj = db.D_QHE_PTDIENs.Where(p => p.ID_QHE.Equals(_obj.ID_QHE)).FirstOrDefault();
            if (obj!=null)
            {
                obj.ID_QHE = _obj.ID_QHE;
                obj.D_PTDIEN = db.D_PTDIENs.Single(p => p.ID_PTDIEN == _obj.ID_PTDIEN); 
                obj.NGAY_HLUC = _obj.NGAY_HLUC;
                obj.NGAY_SUA = _obj.NGAY_SUA;
                obj.NGUOI_SUA = _obj.NGUOI_SUA;
                db.SubmitChanges();
            }
            
        }
        public void delete(int idqh) {
            obj = db.D_QHE_PTDIENs.Where(qh => qh.ID_QHE.Equals(idqh)).FirstOrDefault();
            if (obj != null)
            {
                db.D_QHE_PTDIENs.DeleteOnSubmit(obj);
                db.SubmitChanges();
            }  
        }
        public string getListIdDelete(int idPTDien) {
            string str = "";
            var d = from qh in db.D_QHE_PTDIENs where qh.ID_PTCHA == idPTDien select qh;
            foreach (var item in d)
            {
                str = str + String.Format("{0},", item.ID_QHE);
                str+=getListIdDelete(item.ID_PTDIEN);
            }
            return str;
        }

        public List<D_PTDIEN> listPTDienChildren(string idptdien, string dvql, string capda)
        {
            var d = from pt in db.D_PTDIENs where   pt.MA_DVQLY == dvql && pt.MA_CAPDA == capda select pt;
            return d.ToList();
        }
        public bool checkExist(int idPTDIEN) {
            try
            {
                var d = from pt in db.D_QHE_PTDIENs where pt.ID_PTDIEN==idPTDIEN select pt;
                if (d.Count()==0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
        public List<D_QHE_PTDIEN_VITRI> listLR(int idPTDien)
        {
            try
            {
                return db.D_QHE_PTDIEN_VITRIs.Where(p=>p.ID_PTDienCha.Equals(idPTDien)).OrderBy(p => p.ID_PTDienCha).ToList();
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
        public void addLR(D_QHE_PTDIEN_VITRI _obj)
        {
            try
            {
                db.D_QHE_PTDIEN_VITRIs.InsertOnSubmit(_obj);
                db.SubmitChanges();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                System.Windows.Forms.MessageBox.Show("Không thể kết nối được tới máy chủ. Bạn vui lòng kiểm tra lại kết nối và khởi động lại phần mềm.");
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Có lỗi xảy ra vui lòng kiểm tra lại. " + e.ToString());
            }
        }
        public bool checkQH(int cha, int con) {
            var d = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha == cha && p.ID_PTDienCon == con).Count();
            if (d>=1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void deleteLR(int idLR)
        {
            try
            {
                D_QHE_PTDIEN_VITRI tmp = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID.Equals(idLR)).SingleOrDefault();
                db.D_QHE_PTDIEN_VITRIs.DeleteOnSubmit(tmp);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Quá trình xóa sảy ra lỗi! Bạn vui lòng thực hiện lại.");
            }
            
        }
        public void deleteAllLR(List<D_QHE_PTDIEN_VITRI> lstQH)
        {
            try
            {
                db.D_QHE_PTDIEN_VITRIs.DeleteAllOnSubmit(lstQH);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Quá trình xóa sảy ra lỗi! Bạn vui lòng thực hiện lại.");
            }

        }
        public DateTime getDateServer()
        {
            try
            {
                return db.GetServerDate();
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
        public List<int> getRootTT(string dvql) {
            List<int> lstCB = new List<int>();
            var d = from pt in db.D_PTDIENs where pt.LOAI_PTDIEN.Equals("CB") && pt.MA_DVQLY.Equals(dvql) select new { pt.ID_PTDIEN };
            foreach (var item in d)
            {
                lstCB.Add(item.ID_PTDIEN);
            }
            return lstCB;
        }
        public bool checkQH1Nhieu(int idPTDIEN)
        {
            try
            {
                var dc = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "L" select new { t.ID };
                if (dc.Count() == 0)
                {
                    return true;
                }
                return false;
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
        public void openCD(int idPTDIEN, int _root = 0)
        {
            try
            {
                //obj = new M_TTHAI_PTDIEN_LR();
                M_VITRI_V3 m = db.M_VITRI_V3s.Where(LR => LR.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                if (_root == 0)
                {
                    if (checkQH1Nhieu(idPTDIEN) && (m.LEFT_TRANGTHAI == true || m.RIGHT_TRANGTHAI == true)) // kiem tra quan he 1 nhieu, neu quan he nguyen Right => quan het it = true
                    {
                        var d = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "R" select t;
                        foreach (var item in d)
                        {
                            //D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                            M_VITRI_V2 T = db.M_VITRI_V2s.Where(TT => TT.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                            if (item.D_PTDIEN.LOAI_PTDIEN == "CB")
                            {
                                D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                                if (int.Parse(pt.MA_CAPDA) <= int.Parse(item.D_PTDIEN.MA_CAPDA))
                                {
                                    /*if (T.TRANG_THAI == 1)
                                    {
                                        checkNguon = false;
                                        return;
                                    }*/
                                }
                                else
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                }

                            }
                            if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                            {
                                if (T.TRANG_THAI != 0)
                                {
                                    openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                }
                            }
                            if (item.D_PTDIEN.LOAI_PTDIEN == "TT" )
                            {
                                
                                ListUpdate.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                
                            }
                        }
                    }
                    else // ca trai va phai deu co quan he
                    {
                        if (m.CHIEUDONGDIEN.Equals('L'))
                        {
                            var d = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "R" select t;
                            foreach (var item in d)
                            {
                                M_VITRI_V2 T = db.M_VITRI_V2s.Where(TT => TT.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                if (item.D_PTDIEN.LOAI_PTDIEN == "CB")
                                {
                                    D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                                    if (int.Parse(pt.MA_CAPDA) <= int.Parse(item.D_PTDIEN.MA_CAPDA))
                                    {
                                        /*if (T.TRANG_THAI == 1)
                                        {
                                            checkNguon = false;
                                            return;
                                        }*/
                                    }
                                    else
                                    {
                                        if (T.TRANG_THAI != 0)
                                        {
                                            openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                    }

                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "TT" )
                                {
                                    ListUpdate.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                }
                            }
                        }
                        if (m.CHIEUDONGDIEN.Equals('R'))
                        {
                            obj.ID_PTDIEN = idPTDIEN;
                            var d = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "L" select t;
                            foreach (var item in d)
                            {
                                M_VITRI_V2 T = db.M_VITRI_V2s.Where(TT => TT.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                if (item.D_PTDIEN.LOAI_PTDIEN == "CB")
                                {
                                    D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                                    if (int.Parse(pt.MA_CAPDA) <= int.Parse(item.D_PTDIEN.MA_CAPDA))
                                    {
                                        /*if (T.TRANG_THAI == 1)
                                        {
                                            checkNguon = false;
                                            return;
                                        }*/
                                    }
                                    else
                                    {
                                        if (T.TRANG_THAI != 0)
                                        {
                                            openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                    }

                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "TT" )
                                {
                                    ListUpdate.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                }
                            }
                        }
                    }

                }// het if _root
                else
                {
                    var dd = from tt in db.D_QHE_PTDIEN_VITRIs where tt.ID_PTDienCha.Equals(idPTDIEN) && tt.ID_PTDienCon.Equals(_root) && tt.VITRI.Equals("L") select new { tt.ID };
                    if (dd.Count() != 0)
                    {
                        var d = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "R" select t;
                        foreach (var item in d)
                        {
                            M_VITRI_V2 T = db.M_VITRI_V2s.Where(TT => TT.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                            if (item.D_PTDIEN.LOAI_PTDIEN == "CB")
                            {
                                D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                                if (int.Parse(pt.MA_CAPDA) <= int.Parse(item.D_PTDIEN.MA_CAPDA))
                                {
                                    
                                }
                                else
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                }

                            }
                            if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                            {
                                if (T.TRANG_THAI != 0)
                                {
                                    openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                }
                            }
                            if (item.D_PTDIEN.LOAI_PTDIEN == "TT")
                            {
                                ListUpdate.Add(int.Parse(item.ID_PTDienCon.ToString()));
                            }
                        }
                    }// het if child
                    else
                    {
                        var d = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "L" select t;
                        if (d.Count() != 0)
                        {
                            foreach (var item in d)
                            {
                                M_VITRI_V2 T = db.M_VITRI_V2s.Where(TT => TT.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                if (item.D_PTDIEN.LOAI_PTDIEN == "CB")
                                {
                                    D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                                    if (int.Parse(pt.MA_CAPDA) <= int.Parse(item.D_PTDIEN.MA_CAPDA))
                                    {
                                       
                                    }
                                    else
                                    {
                                        if (T.TRANG_THAI != 0)
                                        {
                                            openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "TT" )
                                {
                                    ListUpdate.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                }
                            }
                        }
                        else // chi co quan he ben phai
                        {
                            var d2 = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "R" select t;
                            foreach (var item in d2)
                            {
                                M_VITRI_V2 T = db.M_VITRI_V2s.Where(TT => TT.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                if (item.D_PTDIEN.LOAI_PTDIEN == "CB")
                                {
                                    D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                                    if (int.Parse(pt.MA_CAPDA) <= int.Parse(item.D_PTDIEN.MA_CAPDA))
                                    {
                                    }
                                    else
                                    {
                                        if (T.TRANG_THAI != 0)
                                        {
                                            openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "TT" )
                                {
                                        ListUpdate.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                }
                            }
                        }
                    }// het else child
                }
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
    }
}
