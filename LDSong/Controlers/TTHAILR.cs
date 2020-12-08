using LDSong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class TTHAILR
    {
        private M_TTHAI_PTDIEN_LR obj;
        private LDSongDataContext db;
        public List<M_TTHAI_PTDIEN_LR> ListUpdate;
        public List<int> ListUpdate1;
        //public List<HISTORY_TTHAI_PTDIEN_LR> ListHistrory;
        public bool checkNguon = true;
        private bool nguon = false;
        public string tenNguon = "";
        public string lstCB;
        public TTHAILR() {
            try
            {
                db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
                ListUpdate = new List<M_TTHAI_PTDIEN_LR>();
                ListUpdate1 = new List<int>();
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
            //ListHistrory = new List<HISTORY_TTHAI_PTDIEN_LR>();
        }
        public bool checkClose(int idPTDIEN) {
            try
            {
                M_VITRI_V1 m= db.M_VITRI_V1s.Where(LR=>LR.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                if (m.LOAI_PTDIEN.Equals("DS") || m.LOAI_PTDIEN.Equals("SI") )
                {
                    if (m.LEFT_TRANGTHAI == true || m.RIGHT_TRANGTHAI == true)
                    {
                        return false;
                    }
                }
                if ( m.LOAI_PTDIEN.Equals("MC") )
                {
                    M_VITRI_V2 T = db.M_VITRI_V2s.Where(TT => TT.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                    if (T.TRANG_THAI==0)
                    {
                        if (m.LEFT_TRANGTHAI == true && m.RIGHT_TRANGTHAI == true)
                        {
                            return false;
                        } 
                    }
                }
                return true;
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
        public bool checkClose2Dau(int idPTDIEN)
        {
            try
            {
                M_VITRI_V1 m = db.M_VITRI_V1s.Where(LR => LR.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                if (m.LOAI_PTDIEN.Equals("DS") || m.LOAI_PTDIEN.Equals("SI") || m.LOAI_PTDIEN.Equals("MC"))
                {
                    if (m.LEFT_TRANGTHAI == true && m.RIGHT_TRANGTHAI == true)
                    {
                        return false;
                    }
                }
                return true;
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
        public void openCD(int idPTDIEN,int _root=0)
        {
            try
            {
                obj = new M_TTHAI_PTDIEN_LR();
                M_VITRI_V3 m = db.M_VITRI_V3s.Where(LR => LR.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                if (_root == 0 ) {
                    if (checkQH1Nhieu(idPTDIEN) && (m.LEFT_TRANGTHAI == true || m.RIGHT_TRANGTHAI == true)) // kiem tra quan he 1 nhieu, neu quan he nguyen Right => quan het it = true
                    {
                        setUpdate(idPTDIEN, m.LEFT_TRANGTHAI, false, 'L');
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
                                    if (T.TRANG_THAI == 1)
                                    {
                                        checkNguon = false;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                    else
                                    {
                                        setTTCDOpen(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                }

                            }
                            if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                            {
                            
                                if (T.TRANG_THAI != 0)
                                {
                                    openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                }
                                else
                                {
                                    setTTCDOpen(int.Parse(item.ID_PTDienCon.ToString()),idPTDIEN);
                                }
                            }
                            if (item.D_PTDIEN.LOAI_PTDIEN == "TT" || item.D_PTDIEN.LOAI_PTDIEN == "1S" || item.D_PTDIEN.LOAI_PTDIEN == "DZ")
                            {
                                if (T.TRANG_THAI != 0)
                                {
                                    setUpdate(int.Parse(item.ID_PTDienCon.ToString()), false, false, 'L');
                                }
                                else
                                {
                                    ListUpdate1.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                }
                            }
                        }
                    }
                    else // ca trai va phai deu co quan he
                    {
                        //checkChieuDongDienOpen(idPTDIEN); 
                        //if (nguon == true && (m.LEFT_TRANGTHAI == true || m.RIGHT_TRANGTHAI == true))
                        if (m.CHIEUDONGDIEN.Equals('L'))
                        {
                            setUpdate(idPTDIEN, m.LEFT_TRANGTHAI, false, 'L');
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
                                        if (T.TRANG_THAI == 1)
                                        {
                                            checkNguon = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (T.TRANG_THAI != 0)
                                        {
                                            openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                        else
                                        {
                                            setTTCDOpen(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                    }

                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                                {
                                
                                    if (T.TRANG_THAI != 0)
                                    {
                                        openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                    else
                                    {
                                        setTTCDOpen(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "TT" || item.D_PTDIEN.LOAI_PTDIEN == "1S" || item.D_PTDIEN.LOAI_PTDIEN == "DZ")
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        setUpdate(int.Parse(item.ID_PTDienCon.ToString()), false, false, 'L');
                                    }
                                    else
                                    {
                                        ListUpdate1.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                    }
                                }
                            }
                        }
                        //if (nguon == false && (m.LEFT_TRANGTHAI == true || m.RIGHT_TRANGTHAI == true))
                        if (m.CHIEUDONGDIEN.Equals('R'))
                        {
                            obj.ID_PTDIEN = idPTDIEN;
                            setUpdate(idPTDIEN, false, m.RIGHT_TRANGTHAI, 'R');
                            var d = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "L" select t;
                            foreach (var item in d)
                            {
                                //D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                M_VITRI_V2 T = db.M_VITRI_V2s.Where(TT => TT.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                if (item.D_PTDIEN.LOAI_PTDIEN == "CB")
                                {
                                    D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                                    if (int.Parse(pt.MA_CAPDA) <= int.Parse(item.D_PTDIEN.MA_CAPDA))
                                    {
                                        if (T.TRANG_THAI == 1)
                                        {
                                            checkNguon = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (T.TRANG_THAI != 0)
                                        {
                                            openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                        else
                                        {
                                            setTTCDOpen(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                    }

                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                    else
                                    {
                                        setTTCDOpen(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "TT" || item.D_PTDIEN.LOAI_PTDIEN == "1S" || item.D_PTDIEN.LOAI_PTDIEN == "DZ")
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        setUpdate(int.Parse(item.ID_PTDienCon.ToString()), false, false, 'L');
                                    }
                                    else
                                    {
                                        ListUpdate1.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                    }
                                }
                            }
                        }
                    }
                
                }// het if _root
                else
                {
                    var dd = from tt in db.D_QHE_PTDIEN_VITRIs where tt.ID_PTDienCha.Equals(idPTDIEN) && tt.ID_PTDienCon.Equals(_root) && tt.VITRI.Equals("L") select new{tt.ID};
                    if (dd.Count() != 0)
                    {
                        setUpdate(idPTDIEN,false,false,'N');
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
                                    if (T.TRANG_THAI == 1)
                                    {
                                        checkNguon = false;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                    else
                                    {
                                        setTTCDOpen(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                }
                                
                            }
                            if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                            {
                                if (T.TRANG_THAI != 0)
                                {
                                    openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                }
                                else
                                {
                                    setTTCDOpen(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                }
                            }
                            if (item.D_PTDIEN.LOAI_PTDIEN == "TT" || item.D_PTDIEN.LOAI_PTDIEN == "1S" || item.D_PTDIEN.LOAI_PTDIEN == "DZ")
                            {
                                if (T.TRANG_THAI!=0)
                                {
                                    setUpdate(int.Parse(item.ID_PTDienCon.ToString()),false,false,'L');
                                }
                                else
                                {
                                    ListUpdate1.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                }
                            }
                        }
                    }// het if child
                    else {
                        setUpdate(idPTDIEN,false,false,'N');
                        var d = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "L" select t;
                        if (d.Count()!=0)
                        {
                            foreach (var item in d)
                            {
                                //D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                M_VITRI_V2 T = db.M_VITRI_V2s.Where(TT => TT.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                if (item.D_PTDIEN.LOAI_PTDIEN == "CB")
                                {
                                    D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                                    if (int.Parse(pt.MA_CAPDA) <= int.Parse(item.D_PTDIEN.MA_CAPDA))
                                    {
                                        if (T.TRANG_THAI == 1)
                                        {
                                            checkNguon = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (T.TRANG_THAI != 0)
                                        {
                                            openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                        else
                                        {
                                            setTTCDOpen(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                    else
                                    {
                                        setTTCDOpen(int.Parse(item.ID_PTDienCon.ToString()),idPTDIEN);                                   
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "TT" || item.D_PTDIEN.LOAI_PTDIEN == "1S" || item.D_PTDIEN.LOAI_PTDIEN == "DZ")
                                {
                                    if (T.TRANG_THAI!=0)
                                    {
                                        setUpdate(int.Parse(item.ID_PTDienCon.ToString()),false,false,'L');
                                    }
                                    else
                                    {
                                        ListUpdate1.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                    }
                                }
                            }
                        }
                        else // chi co quan he ben phai
                        {
                            var d2 = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "R" select t;
                            foreach (var item in d2)
                            {
                                //D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                M_VITRI_V2 T = db.M_VITRI_V2s.Where(TT => TT.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                if (item.D_PTDIEN.LOAI_PTDIEN == "CB")
                                {
                                    D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                                    if (int.Parse(pt.MA_CAPDA) <= int.Parse(item.D_PTDIEN.MA_CAPDA))
                                    {
                                        if (T.TRANG_THAI == 1)
                                        {
                                            checkNguon = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (T.TRANG_THAI != 0)
                                        {
                                            openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                        else
                                        {
                                            setTTCDOpen(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        openCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                    else
                                    {
                                        setTTCDOpen(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "TT" || item.D_PTDIEN.LOAI_PTDIEN == "1S" || item.D_PTDIEN.LOAI_PTDIEN == "DZ")
                                {
                                    if (T.TRANG_THAI!=0)
                                    {
                                        setUpdate(int.Parse(item.ID_PTDienCon.ToString()),false,false,'L');
                                    }
                                    else
                                    {
                                        ListUpdate1.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                    }
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
        public void closeCD(int idPTDIEN,int _parent=0)
        {
            try
            {
                M_VITRI_V3 m = db.M_VITRI_V3s.Where(LR => LR.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                if (_parent==0)
                {
                    if (m.LEFT_TRANGTHAI == true || m.RIGHT_TRANGTHAI==true)
                    {
                        if (m.LEFT_TRANGTHAI==true)
                        {
                            setUpdate(idPTDIEN, true, true, 'L');
                        }
                        else
                        {
                            setUpdate(idPTDIEN, true, true, 'R');
                        }
                        var da = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "L" select t;
                        if (da.Count()==0)// kiem tra xem co phai nguon ko
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
                                        if (T.TRANG_THAI == 1)
                                        {
                                            checkNguon = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (T.TRANG_THAI != 0)
                                        {
                                            closeCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                        else
                                        {
                                            setTTCDClose(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        closeCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                    else
                                    {
                                        setTTCDClose(int.Parse(item.ID_PTDienCon.ToString()),idPTDIEN);
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "TT" || item.D_PTDIEN.LOAI_PTDIEN == "1S" || item.D_PTDIEN.LOAI_PTDIEN == "DZ")
                                {
                                
                                    if (T.TRANG_THAI != 0)
                                    {
                                        setUpdate(int.Parse(item.ID_PTDienCon.ToString()), true, true, 'L');
                                    }
                                    else
                                    {
                                        ListUpdate1.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                    }
                                
                                }
                            }
                        }
                        else// không phải nguồn check tiếp
                        {
                            //if (checkChieuDongDienClose(idPTDIEN))// check xem chieu dong dien ben trai?
                            if(m.CHIEUDONGDIEN.Equals('L'))
                            {
                                setUpdate(idPTDIEN, true, true, 'L');
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
                                            if (T.TRANG_THAI == 1)
                                            {
                                                checkNguon = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if (T.TRANG_THAI != 0)
                                            {
                                                closeCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                            }
                                            else
                                            {
                                                setTTCDClose(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                            }
                                        }
                                    }
                                    if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                                    {
                                        if (T.TRANG_THAI != 0)
                                        {
                                            closeCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                        else
                                        {
                                            setTTCDClose(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                    }
                                    if (item.D_PTDIEN.LOAI_PTDIEN == "TT" || item.D_PTDIEN.LOAI_PTDIEN == "1S" || item.D_PTDIEN.LOAI_PTDIEN == "DZ")
                                    {
                                        if (T.TRANG_THAI != 0)
                                        {
                                            setUpdate(int.Parse(item.ID_PTDienCon.ToString()), true, true, 'L');
                                        }
                                        else
                                        {
                                            ListUpdate1.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                        }
                                    }
                                }
                            }// het if
                            //else { // chieu dong dien ben phai?
                            if(m.CHIEUDONGDIEN.Equals('R')){
                                setUpdate(idPTDIEN,true,true,'R');
                                var d = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "L" select t;
                                foreach (var item in d)
                                {
                                    //D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                    M_VITRI_V2 T = db.M_VITRI_V2s.Where(TT => TT.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                    if (item.D_PTDIEN.LOAI_PTDIEN == "CB")
                                    {
                                        D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                                        if (int.Parse(pt.MA_CAPDA) <= int.Parse(item.D_PTDIEN.MA_CAPDA))
                                        {
                                            if (T.TRANG_THAI == 1)
                                            {
                                                checkNguon = false;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if (T.TRANG_THAI != 0)
                                            {
                                                closeCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                            }
                                            else
                                            {
                                                setTTCDClose(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                            }
                                        }
                                    }
                                    if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                                    {
                                        if (T.TRANG_THAI != 0)
                                        {
                                            closeCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                        else
                                        {
                                            setTTCDClose(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                    }
                                    if (item.D_PTDIEN.LOAI_PTDIEN == "TT" || item.D_PTDIEN.LOAI_PTDIEN == "1S" || item.D_PTDIEN.LOAI_PTDIEN == "DZ")
                                    {
                                        if (T.TRANG_THAI != 0)
                                        {
                                            setUpdate(int.Parse(item.ID_PTDienCon.ToString()), true, true, 'L');
                                        }
                                        else
                                        {
                                            //setUpdate(int.Parse(item.ID_PTDienCon.ToString()), true, false, true);
                                            ListUpdate1.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                        }
                                    }
                                }
                            }
                        }
                    }
                
                }// het parrent
                else
                {
                    var dL = from tt in db.D_QHE_PTDIEN_VITRIs where tt.ID_PTDienCha.Equals(idPTDIEN) && tt.ID_PTDienCon.Equals(_parent) && tt.VITRI.Equals("L") select new{tt.ID};
                    if (dL.Count() != 0)
                    {
                        setUpdate(idPTDIEN,true,true,'L');
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
                                    if (T.TRANG_THAI == 1)
                                    {
                                        checkNguon = false;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        closeCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                    else
                                    {
                                        setTTCDClose(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                }
                            }
                            if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                            {
                                if (T.TRANG_THAI != 0)
                                {
                                    closeCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);                                  
                                }
                                else
                                {
                                    setTTCDClose(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);                                   
                                }
                            }
                            if (item.D_PTDIEN.LOAI_PTDIEN == "TT" || item.D_PTDIEN.LOAI_PTDIEN == "1S" || item.D_PTDIEN.LOAI_PTDIEN == "DZ")
                            {
                                if (T.TRANG_THAI != 0)
                                {
                                    setUpdate(int.Parse(item.ID_PTDienCon.ToString()), true, true, 'L');
                                }
                                else
                                {
                                    ListUpdate1.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                }
                            }
                        }
                    }
                    else
                    {
                        var d = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "L" select t;
                        if (d.Count() != 0)
                        {
                            setUpdate(idPTDIEN, true, true, 'R');
                            foreach (var item in d)
                            {
                                //D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                M_VITRI_V2 T = db.M_VITRI_V2s.Where(TT => TT.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                if (item.D_PTDIEN.LOAI_PTDIEN == "CB")
                                {
                                    D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                                    if (int.Parse(pt.MA_CAPDA) <= int.Parse(item.D_PTDIEN.MA_CAPDA))
                                    {
                                        if (T.TRANG_THAI == 1)
                                        {
                                            checkNguon = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (T.TRANG_THAI != 0)
                                        {
                                            closeCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                        else
                                        {
                                            setTTCDClose(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        closeCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                    else
                                    {
                                        setTTCDClose(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "TT" || item.D_PTDIEN.LOAI_PTDIEN == "1S" || item.D_PTDIEN.LOAI_PTDIEN == "DZ")
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        setUpdate(int.Parse(item.ID_PTDienCon.ToString()), true, true, 'L');
                                    }
                                    else
                                    {
                                        //setUpdate(int.Parse(item.ID_PTDienCon.ToString()), true, false, true);
                                        ListUpdate1.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                    }
                                }
                            }
                        }
                        else
                        {
                            setUpdate(idPTDIEN, true, true, 'L');
                            var d2 = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "R" select t;
                            foreach (var item in d2)
                            {
                                //D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                M_VITRI_V2 T = db.M_VITRI_V2s.Where(TT => TT.ID_PTDIEN.Equals(item.ID_PTDienCon)).SingleOrDefault();
                                if (item.D_PTDIEN.LOAI_PTDIEN == "CB")
                                {
                                    D_PTDIEN pt = db.D_PTDIENs.Where(q => q.ID_PTDIEN.Equals(idPTDIEN)).SingleOrDefault();
                                    if (int.Parse(pt.MA_CAPDA) <= int.Parse(item.D_PTDIEN.MA_CAPDA))
                                    {
                                        if (T.TRANG_THAI == 1)
                                        {
                                            checkNguon = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (T.TRANG_THAI != 0)
                                        {
                                            closeCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                        else
                                        {
                                            setTTCDClose(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                        }
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                            closeCD(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);                                    
                                    }
                                    else
                                    {
                                        setTTCDClose(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);                                        
                                    }
                                }
                                if (item.D_PTDIEN.LOAI_PTDIEN == "TT" || item.D_PTDIEN.LOAI_PTDIEN == "1S" || item.D_PTDIEN.LOAI_PTDIEN == "DZ")
                                {
                                    if (T.TRANG_THAI != 0)
                                    {
                                        setUpdate(int.Parse(item.ID_PTDienCon.ToString()), true, true, 'L');
                                    }
                                    else
                                    {
                                        ListUpdate1.Add(int.Parse(item.ID_PTDienCon.ToString()));
                                    }
                                }
                            }
                        }

                    }
                }//het child close
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
        public void update(M_TTHAI_PTDIEN_LR _obj) {
            try
            {
                db.M_TTHAI_PTDIEN_LRs.InsertOnSubmit(_obj);
                db.SubmitChanges();
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
        public void update1(int _id,bool _tt)
        {
            try
            {
                var m = (from p in db.M_TTHAI_PTDIEN_LRs where p.ID_PTDIEN == _id orderby p.NGAY_CAP_NHAT descending select p).Skip(0).Take(1);
                foreach (var item in m)
                {
                    if (_tt)
                    {
                        item.LEFT_TRANGTHAI = true;
                    }
                    else
                    {
                        item.LEFT_TRANGTHAI = false;
                    }
                    db.SubmitChanges();
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
        public void updateEnd(M_TTHAI_PTDIEN_LR _obj)// update thoi gian ket thuc truoc khi insert vao M_TTHAI_PTDIEN_LR
        {
            try
            {
                var m=(from p in db.M_TTHAI_PTDIEN_LRs where p.ID_PTDIEN==_obj.ID_PTDIEN orderby p.NGAY_CAP_NHAT descending select p).Skip(0).Take(1);
                foreach (var item in m)
                {
                    item.THOIGIANKETTHUC = getDateServer();
                    db.SubmitChanges();
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
        public void updateEnd1(int _id)// update thoi gian ket thuc truoc khi insert M_TTHAI_PTDIEN
        {
            try
            {
                var m = (from p in db.M_TTHAI_PTDIENs where p.ID_PTDIEN == _id orderby p.THOI_DIEM descending select p).Skip(0).Take(1);
                foreach (var item in m)
                {
                    item.THOIGIANKETTHUC = getDateServer();
                    db.SubmitChanges();
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
        public DateTime getDateServer() {
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
        private void setUpdate(int _id,bool left,bool right,char chieudongdien) {
            obj = new M_TTHAI_PTDIEN_LR();
            obj.ID_PTDIEN = _id;
            obj.LEFT_TRANGTHAI = left;
            obj.RIGHT_TRANGTHAI = right;
            obj.CHIEUDONGDIEN = chieudongdien;
            obj.NGAY_CAP_NHAT = getDateServer();
            ListUpdate.Add(obj);
        }
        
        public M_TTHAI_PTDIEN_LR getTTHAILR(string idPTDIEN) {
            try
            {
                var d = (from lr in db.M_TTHAI_PTDIEN_LRs where lr.ID_PTDIEN.Equals(idPTDIEN) orderby lr.NGAY_CAP_NHAT descending select lr).Skip(0).Take(1);
                foreach (var item in d)
                {
                    return item;
                }
                return null;
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
        public bool checkChieuDongDienClose(int idPTDien) {
            try
            {
                var dc = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDien && t.VITRI == "L" select new { t.ID_PTDienCon };
                foreach (var item in dc)
                {
                    var dd = from t1 in db.M_VITRI_V1s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.LEFT_TRANGTHAI == true && t1.RIGHT_TRANGTHAI == true select new { t1.ID_PTDIEN };
                    if (dd.Count()!=0)
                    {
                        return true;
                    }
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
        public void checkChieuDongDienOpen(int idPTDIEN,int _parent=0) {
            try
            {
                if (_parent==0)
                {
                    var dc = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "L" select new { t.ID_PTDienCon };
                    foreach (var item in dc)
                    {
                        var dd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && t1.LOAI_PTDIEN == "CB" select new { t1.TRANG_THAI };
                        if (dd.Count() != 0)
                        {
                            nguon = true;
                            return;
                        }
                        var ddd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && (t1.LOAI_PTDIEN == "DS" || t1.LOAI_PTDIEN == "SI" || t1.LOAI_PTDIEN == "MC" || t1.LOAI_PTDIEN == "TG") select new { t1.TRANG_THAI };
                        if (ddd.Count() != 0)
                        {
                            checkChieuDongDienOpen(int.Parse(item.ID_PTDienCon.ToString()),idPTDIEN);
                        }
                    }
                }
                else
                {
                    var dL = from tt in db.D_QHE_PTDIEN_VITRIs where tt.ID_PTDienCha.Equals(idPTDIEN) && tt.ID_PTDienCon.Equals(_parent) && tt.VITRI.Equals("L") select new { tt.ID };
                    if (dL.Count()!=0)
                    {
                        var dc = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "R" select new { t.ID_PTDienCon };
                        foreach (var item in dc)
                        {
                            var dd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && t1.LOAI_PTDIEN == "CB" select new { t1.TRANG_THAI };
                            if (dd.Count() != 0)
                            {
                                nguon = true;
                                return;
                            }
                            var ddd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && (t1.LOAI_PTDIEN == "DS" || t1.LOAI_PTDIEN == "SI" || t1.LOAI_PTDIEN == "MC" || t1.LOAI_PTDIEN == "TG") select new { t1.TRANG_THAI };
                            if (ddd.Count() != 0)
                            {
                                checkChieuDongDienOpen(int.Parse(item.ID_PTDienCon.ToString()),idPTDIEN);
                            }
                        }
                    }
                    else
                    {
                        var dc = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "L" select new { t.ID_PTDienCon };
                        foreach (var item in dc)
                        {
                            var dd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && t1.LOAI_PTDIEN == "CB" select new { t1.TRANG_THAI };
                            if (dd.Count() != 0)
                            {
                                nguon = true;
                                return;
                            }
                            var ddd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && (t1.LOAI_PTDIEN == "DS" || t1.LOAI_PTDIEN == "SI" || t1.LOAI_PTDIEN == "MC" || t1.LOAI_PTDIEN == "TG") select new { t1.TRANG_THAI };
                            if (ddd.Count() != 0)
                            {
                                checkChieuDongDienOpen(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                            }
                        }
                    }
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
            }
        }
        public bool checkQH1Nhieu(int idPTDIEN) {
            try
            {
                var dc = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "L" select new { t.ID };
                if (dc.Count()==0)
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
        public bool checkCoTai(int idPTdien,string loaiTB) {
            if (loaiTB.Equals("DS"))
            {
                int h = db.M_VITRI_V1s.Where(p => p.ID_PTDIEN == idPTdien && p.LEFT_TRANGTHAI == false && p.RIGHT_TRANGTHAI == false).Count();
                if (h == 1)
                {
                    return true;
                }
                int d = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha == idPTdien && p.VITRI.Equals('L')).Count();
                if (d==0) 
                {
                    var qh = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha == idPTdien).ToList();
                    foreach (var item in qh)
                    {
                        if (item.D_PTDIEN.LOAI_PTDIEN.Equals("TT"))
                        {
                            int lr = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon && p.TRANG_THAI == 1).Count();
                            if (lr==1)
                            {
                                return false;
                            }
                        }
                        if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                        {
                            int ckOpen = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon && p.TRANG_THAI == 1).Count();
                            if (ckOpen==1)
                            {
                                if (checkCoTaiRight(int.Parse(item.ID_PTDienCon.ToString()))==false)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    var chieuDD = db.M_VITRI_V3s.Where(p => p.ID_PTDIEN == idPTdien && p.CHIEUDONGDIEN.Equals('L')).Count();
                    if (chieuDD==1)
                    {
                        var qh = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha == idPTdien && p.VITRI.Equals('R')).ToList();
                        foreach (var item in qh)
                        {
                            if (item.D_PTDIEN.LOAI_PTDIEN.Equals("TT"))
                            {
                                int lr = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon && p.TRANG_THAI == 1).Count();
                                if (lr==1)
                                {
                                    return false;
                                }
                            }
                            if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                            {
                                int ckOpen = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon && p.TRANG_THAI == 1).Count();
                                if (ckOpen==1)
                                {
                                    if (checkCoTaiRightLeft(int.Parse(item.ID_PTDienCon.ToString()),idPTdien)==false)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var qh = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha == idPTdien && p.VITRI.Equals('L')).ToList();
                        foreach (var item in qh)
                        {
                            if (item.D_PTDIEN.LOAI_PTDIEN.Equals("TT"))
                            {
                                int lr = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon && p.TRANG_THAI == 1).Count();
                                if (lr == 1)
                                {
                                    return false;
                                }
                            }
                            if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                            {
                                int ckOpen = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon && p.TRANG_THAI == 1).Count();
                                if (ckOpen == 1)
                                {
                                    if (checkCoTaiRightLeft(int.Parse(item.ID_PTDienCon.ToString()), idPTdien) == false)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                return true;
            }
        }
        public bool checkCoTaiRight(int idPTDien) {
            var qh = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha == idPTDien).ToList();
            foreach (var item in qh)
            {
                if (item.D_PTDIEN.LOAI_PTDIEN.Equals("TT"))
                {
                    int lr = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon && p.TRANG_THAI == 1).Count();
                    if (lr == 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool checkCoTaiRightLeft(int idPTDien, int _parent)
        {
            var dL = from tt in db.D_QHE_PTDIEN_VITRIs where tt.ID_PTDienCha.Equals(idPTDien) && tt.ID_PTDienCon.Equals(_parent) && tt.VITRI.Equals("L") select tt;
            if (dL.Count() != 0)
            {
                foreach (var item in dL)
                {
                    if (item.D_PTDIEN.LOAI_PTDIEN.Equals("TT"))
                    {
                        int lr = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon && p.TRANG_THAI == 1).Count();
                        if (lr == 1)
                        {
                            return false;
                        }
                    }
                    if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                    {
                        int ckOpen = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon && p.TRANG_THAI == 1).Count();
                        if (ckOpen == 1)
                        {
                            if (checkCoTaiRightLeft(int.Parse(item.ID_PTDienCon.ToString()), idPTDien) == false)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            else
            {
                var d = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDien && t.VITRI == "L" select t;
                if (d.Count() != 0)
                {
                    foreach (var item in d)
                    {
                        if (item.D_PTDIEN.LOAI_PTDIEN.Equals("TT"))
                        {
                            int lr = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon && p.TRANG_THAI == 1).Count();
                            if (lr == 1)
                            {
                                return false;
                            }
                        }
                        if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                        {
                            int ckOpen = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon && p.TRANG_THAI == 1).Count();
                            if (ckOpen == 1)
                            {
                                if (checkCoTaiRightLeft(int.Parse(item.ID_PTDienCon.ToString()), idPTDien) == false)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    var d1 = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDien && t.VITRI == "R" select t;
                    foreach (var item in d1)
                    {
                        if (d1.Count()!=0)
                        {
                            if (item.D_PTDIEN.LOAI_PTDIEN.Equals("TT"))
                            {
                                int lr = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon && p.TRANG_THAI == 1).Count();
                                if (lr == 1)
                                {
                                    return false;
                                }
                            }
                            if (item.D_PTDIEN.LOAI_PTDIEN == "DS" || item.D_PTDIEN.LOAI_PTDIEN == "SI" || item.D_PTDIEN.LOAI_PTDIEN == "MC" || item.D_PTDIEN.LOAI_PTDIEN == "TG")
                            {
                                int ckOpen = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon && p.TRANG_THAI == 1).Count();
                                if (ckOpen == 1)
                                {
                                    if (checkCoTaiRightLeft(int.Parse(item.ID_PTDienCon.ToString()), idPTDien) == false)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
        public bool checkCoTai1(int idPTDien) {
            var qh = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha == idPTDien && p.VITRI.Equals('R') && p.D_PTDIEN.LOAI_PTDIEN.Equals("TT")).ToList();
            if (qh.Count != 0)
            {
                foreach (var item in qh)
                {
                    int lr = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon && p.TRANG_THAI == 1).Count();
                    if (lr == 1)
                    {
                        return false;
                    }
                }
            }
            else // hoan toan khong co tba
            {
                var cd = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha == idPTDien && p.VITRI.Equals('R')).ToList();
                foreach (var item in cd)
                {
                    int tt = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon && p.TRANG_THAI == 1).Count();
                    if (tt != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void setTTCDOpen(int ID_PTDienCon, int idPTDIEN)
        {
            try
            {
                var dk = from k in db.D_QHE_PTDIEN_VITRIs where k.ID_PTDienCha == ID_PTDienCon && k.VITRI == "L" select new { k.ID };
                if (dk.Count() != 0)// kiem tra con dao co quan he 2 ca trai va phai ko?
                {
                    var dz = from kz in db.D_QHE_PTDIEN_VITRIs where kz.ID_PTDienCha == ID_PTDienCon && kz.ID_PTDienCon == idPTDIEN && kz.VITRI == "L" select new { kz.ID };
                    if (dz.Count() != 0)// con dao quan he ben trai voi phần tử cha
                    {
                        M_VITRI_V1 m1 = db.M_VITRI_V1s.Where(LR => LR.ID_PTDIEN.Equals(ID_PTDienCon)).SingleOrDefault();
                        if (m1.RIGHT_TRANGTHAI==true)
                        {
                            setUpdate(ID_PTDienCon, false, true, 'R');
                        }
                        else
                        {
                            setUpdate(ID_PTDienCon, false, false, 'N');
                        }
                    }
                    else // con dao quan he ben phai voi phan tu cha
                    {
                        M_VITRI_V1 m1 = db.M_VITRI_V1s.Where(LR => LR.ID_PTDIEN.Equals(ID_PTDienCon)).SingleOrDefault();
                        if (m1.LEFT_TRANGTHAI==true)
                        {
                            setUpdate(ID_PTDienCon, true, false, 'L');
                        }
                        else
                        {
                            setUpdate(ID_PTDienCon, false, false, 'N');
                        }
                    }
                }
                else // con dao chi co quan he ben phai
                {
                    M_VITRI_V1 m1 = db.M_VITRI_V1s.Where(LR => LR.ID_PTDIEN.Equals(ID_PTDienCon)).SingleOrDefault();
                    setUpdate(ID_PTDienCon, false, false, 'N');
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
        public void setTTCDClose(int ID_PTDienCon, int idPTDIEN)
        {
            try
            {
                M_VITRI_V1 m1 = db.M_VITRI_V1s.Where(LR => LR.ID_PTDIEN.Equals(ID_PTDienCon)).SingleOrDefault();
                //setHistory(m1.ID_PTDIEN, m1.LEFT_TRANGTHAI, m1.RIGHT_TRANGTHAI, m1.CHIEUDONGDIEN);
                var kt = from tt in db.D_QHE_PTDIEN_VITRIs where tt.ID_PTDienCha == ID_PTDienCon && tt.ID_PTDienCon == idPTDIEN && tt.VITRI == "L" select new { tt.ID };
                if (kt.Count() != 0)
                {
                    setUpdate(int.Parse(ID_PTDienCon.ToString()), true, m1.RIGHT_TRANGTHAI, 'L');
                }
                else
                {
                    setUpdate(int.Parse(ID_PTDienCon.ToString()), m1.LEFT_TRANGTHAI, true, 'R'); 
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
        public bool getCheck_Dong() {
            return bool.Parse(db.Bypasses.FirstOrDefault().Check_Dong.ToString());
        }
        public void XacDinhNguonCap(int idPTDIEN, int _parent = 0,char _Chieu='O')
        {
            try
            {
                if (_parent == 0)
                {
                    int DR = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha.Equals(idPTDIEN) && p.VITRI == "L").Count();
                    if (DR == 0) {
                        var Dr1 = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCon.Equals(idPTDIEN) ).ToList();
                        foreach (var item in Dr1)
                        {
                            if (item.D_PTDIEN.LOAI_PTDIEN.Equals("CB"))
                            {
                                lstCB=item.D_PTDIEN.TEN_PTDIEN;
                                return;
                            }
                        }
                        for (int i = 0; i < Dr1.Count; i++)
                        {
                            var ddd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == Dr1.ElementAt(i).ID_PTDienCha && t1.TRANG_THAI == 1 && (t1.LOAI_PTDIEN == "DS" || t1.LOAI_PTDIEN == "SI" || t1.LOAI_PTDIEN == "MC" || t1.LOAI_PTDIEN == "TG") select new { t1.TRANG_THAI };
                            if (ddd.Count() != 0)
                            {
                                XacDinhNguonCap(int.Parse(Dr1.ElementAt(i).ID_PTDienCha.ToString()), idPTDIEN);
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (_Chieu=='L')
                        {
                            var dc = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "L" select new { t.ID_PTDienCon };
                            foreach (var item in dc)
                            {
                                var dd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && t1.LOAI_PTDIEN == "CB" select new { t1.TRANG_THAI, t1.TEN_PTDIEN };
                                if (dd.Count() != 0)
                                {
                                    lstCB = dd.SingleOrDefault().TEN_PTDIEN;
                                    return;
                                }
                                var ddd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && (t1.LOAI_PTDIEN == "DS" || t1.LOAI_PTDIEN == "SI" || t1.LOAI_PTDIEN == "MC" || t1.LOAI_PTDIEN == "TG") select new { t1.TRANG_THAI };
                                if (ddd.Count() != 0)
                                {
                                    XacDinhNguonCap(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                }
                            }
                        }
                        else if (_Chieu == 'R')
                        {
                            var dc = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "R" select new { t.ID_PTDienCon };
                            foreach (var item in dc)
                            {
                                var dd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && t1.LOAI_PTDIEN == "CB" select new { t1.TRANG_THAI, t1.TEN_PTDIEN };
                                if (dd.Count() != 0)
                                {
                                    lstCB = dd.FirstOrDefault().TEN_PTDIEN;
                                    return;
                                }
                                var ddd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && (t1.LOAI_PTDIEN == "DS" || t1.LOAI_PTDIEN == "SI" || t1.LOAI_PTDIEN == "MC" || t1.LOAI_PTDIEN == "TG") select new { t1.TRANG_THAI };
                                if (ddd.Count() != 0)
                                {
                                    XacDinhNguonCap(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                }
                            }
                        }
                        else
                        {
                            var chieuDD = db.M_VITRI_V3s.Where(p => p.ID_PTDIEN == idPTDIEN && p.CHIEUDONGDIEN.Equals('L')).Count();
                            if (chieuDD == 1)
                            {
                                var dc = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "L" select new { t.ID_PTDienCon };
                                foreach (var item in dc)
                                {
                                    var dd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && t1.LOAI_PTDIEN == "CB" select new { t1.TRANG_THAI, t1.TEN_PTDIEN };
                                    if (dd.Count() != 0)
                                    {
                                        lstCB = dd.SingleOrDefault().TEN_PTDIEN;
                                        return;
                                    }
                                    var ddd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && (t1.LOAI_PTDIEN == "DS" || t1.LOAI_PTDIEN == "SI" || t1.LOAI_PTDIEN == "MC" || t1.LOAI_PTDIEN == "TG") select new { t1.TRANG_THAI };
                                    if (ddd.Count() != 0)
                                    {
                                        XacDinhNguonCap(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                }
                            }
                            else
                            {
                                var dc = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "R" select new { t.ID_PTDienCon };
                                foreach (var item in dc)
                                {
                                    var dd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && t1.LOAI_PTDIEN == "CB" select new { t1.TRANG_THAI, t1.TEN_PTDIEN };
                                    if (dd.Count() != 0)
                                    {
                                        lstCB = dd.FirstOrDefault().TEN_PTDIEN;
                                        return;
                                    }
                                    var ddd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && (t1.LOAI_PTDIEN == "DS" || t1.LOAI_PTDIEN == "SI" || t1.LOAI_PTDIEN == "MC" || t1.LOAI_PTDIEN == "TG") select new { t1.TRANG_THAI };
                                    if (ddd.Count() != 0)
                                    {
                                        XacDinhNguonCap(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                    }
                                }
                            }
                        }
                    }

                }
                else
                {
                    int DR = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha.Equals(idPTDIEN) && p.VITRI == "L").Count();
                    if (DR==0)
                    {
                        var Dr0 = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCon.Equals(idPTDIEN) && p.ID_PTDienCha.Equals(_parent)).Count();
                        if (Dr0==0)
                        {
                            var Dr1 = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCon.Equals(idPTDIEN)&&!p.ID_PTDienCha.Equals(_parent)).ToList();
                            foreach (var item in Dr1)
                            {
                                if (item.D_PTDIEN.LOAI_PTDIEN.Equals("CB"))
                                {
                                    lstCB=item.D_PTDIEN.TEN_PTDIEN;
                                    return;
                                }
                            }
                            for (int i = 0; i < Dr1.Count; i++)
                            {
                                var ddd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == Dr1.ElementAt(i).ID_PTDienCha && t1.TRANG_THAI == 1 && (t1.LOAI_PTDIEN == "DS" || t1.LOAI_PTDIEN == "SI" || t1.LOAI_PTDIEN == "MC" || t1.LOAI_PTDIEN == "TG") select new { t1.TRANG_THAI };
                                if (ddd.Count() != 0)
                                {
                                    XacDinhNguonCap(int.Parse(Dr1.ElementAt(i).ID_PTDienCha.ToString()), idPTDIEN);
                                    break;
                                }
                                
                            }
                        }
                    }
                    else
                    {
                        var dL = from tt in db.D_QHE_PTDIEN_VITRIs where tt.ID_PTDienCha.Equals(idPTDIEN) && tt.ID_PTDienCon.Equals(_parent) && tt.VITRI.Equals("L") select new { tt.ID };
                        if (dL.Count() != 0)
                        {
                            var dc = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "R" select new { t.ID_PTDienCon };
                            foreach (var item in dc)
                            {
                                var dd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && t1.LOAI_PTDIEN == "CB" select new { t1.TRANG_THAI, t1.TEN_PTDIEN };
                                if (dd.Count() != 0)
                                {
                                    lstCB=dd.FirstOrDefault().TEN_PTDIEN;
                                    return;
                                }
                                var ddd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && (t1.LOAI_PTDIEN == "DS" || t1.LOAI_PTDIEN == "SI" || t1.LOAI_PTDIEN == "MC" || t1.LOAI_PTDIEN == "TG") select new { t1.TRANG_THAI };
                                if (ddd.Count() != 0)
                                {
                                    XacDinhNguonCap(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                }
                            }
                        }
                        else
                        {
                            var dc = from t in db.D_QHE_PTDIEN_VITRIs where t.ID_PTDienCha == idPTDIEN && t.VITRI == "L" select new { t.ID_PTDienCon };
                            foreach (var item in dc)
                            {
                                var dd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && t1.LOAI_PTDIEN == "CB" select new { t1.TRANG_THAI, t1.TEN_PTDIEN };
                                if (dd.Count() != 0)
                                {
                                    lstCB=dd.FirstOrDefault().TEN_PTDIEN;
                                    return;
                                }
                                var ddd = from t1 in db.M_VITRI_V2s where t1.ID_PTDIEN == item.ID_PTDienCon && t1.TRANG_THAI == 1 && (t1.LOAI_PTDIEN == "DS" || t1.LOAI_PTDIEN == "SI" || t1.LOAI_PTDIEN == "MC" || t1.LOAI_PTDIEN == "TG") select new { t1.TRANG_THAI };
                                if (ddd.Count() != 0)
                                {
                                    XacDinhNguonCap(int.Parse(item.ID_PTDienCon.ToString()), idPTDIEN);
                                }
                            }
                        }
                    }
                }
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
    }
}
