using LDSong.Models;
using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class toadoControler1
    {
        LDSongDataContext data;
        public toadoControler1() {
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
        public List<M_VITRI_V> getListTramMatDien(string dvql)
        {
            try
            {
                if (dvql != "PN")
                {
                    return data.M_VITRI_Vs.Where(p => p.MA_DVQLY.Equals(dvql) && p.LOAI_PTDIEN.Equals("TT")  && !p.MA_CAPDA.Equals("03") && !p.MA_CAPDA.Equals("08") && (p.LEFT_TRANGTHAI == false || p.RIGHT_TRANGTHAI == false)).OrderByDescending(p=>p.NGAY_CAP_NHAT).ToList();
                }
                else
                {
                    return data.M_VITRI_Vs.Where(p => p.LOAI_PTDIEN.Equals("TT") && !p.MA_CAPDA.Equals("03") && !p.MA_CAPDA.Equals("08") && (p.LEFT_TRANGTHAI == false || p.RIGHT_TRANGTHAI == false)).OrderByDescending(p => p.NGAY_CAP_NHAT).ToList();
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
        public List<M_VITRI_V_VM> getListTramMatDien_VM(string dvql)
        {
            try
            {
                if (dvql != "PN")
                {
                    return data.M_VITRI_V_VMs.Where(p => p.MA_DVQLY.Equals(dvql) && p.LOAI_PTDIEN.Equals("TT") && !p.MA_CAPDA.Equals("03") && !p.MA_CAPDA.Equals("08") && (p.LEFT_TRANGTHAI == false || p.RIGHT_TRANGTHAI == false)).OrderByDescending(p => p.NGAY_CAP_NHAT).ToList();
                }
                else
                {
                    return data.M_VITRI_V_VMs.Where(p => p.LOAI_PTDIEN.Equals("TT") && !p.MA_CAPDA.Equals("03") && !p.MA_CAPDA.Equals("08") && (p.LEFT_TRANGTHAI == false || p.RIGHT_TRANGTHAI == false)).OrderByDescending(p => p.NGAY_CAP_NHAT).ToList();
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
        public List<M_TTHAI_PTDIEN_LR> getThongTinTram(int id)
        {
            try
            {
                var m = (from p in data.M_TTHAI_PTDIEN_LRs where p.ID_PTDIEN == id orderby p.NGAY_CAP_NHAT descending select p).Skip(0).Take(1);
                return m.ToList();
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
        public int getCountKH(string matram) {
            try
            {
                return data.K_DIEM_DOs.Where(d => d.MA_TRAM.Equals(matram)).Count();
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
        public List<M_VITRI_V0> listCDOpen(string dvql)
        {
            try
            {
                if (!dvql.Equals("PN"))
                {
                    return data.M_VITRI_V0s.Where(p => p.MA_DVQLY.Equals(dvql) && (p.LOAI_PTDIEN.Equals("DS") || p.LOAI_PTDIEN.Equals("MC") || p.LOAI_PTDIEN.Equals("SI")) && !p.TEN_PTDIEN.Contains("tách lèo") && !p.MA_CAPDA.Equals("03") && !p.MA_CAPDA.Equals("08") && p.TRANG_THAI == 0).OrderByDescending(p=>p.MA_CAPDA).ToList();
                }
                else
                {
                    return data.M_VITRI_V0s.Where(p => (p.LOAI_PTDIEN.Equals("DS") || p.LOAI_PTDIEN.Equals("MC") || p.LOAI_PTDIEN.Equals("SI")) && !p.TEN_PTDIEN.Contains("tách lèo") && !p.MA_CAPDA.Equals("03") && !p.MA_CAPDA.Equals("08") && p.TRANG_THAI == 0).OrderByDescending(p => p.MA_CAPDA).ToList();
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
        public List<M_VITRI_V2> listAllCD(string dvql) {
            try
            {
                if (!dvql.Equals("PN"))
                {
                    return data.M_VITRI_V2s.Where(p => p.MA_DVQLY.Equals(dvql) && (p.LOAI_PTDIEN.Equals("DS") || p.LOAI_PTDIEN.Equals("MC") || p.LOAI_PTDIEN.Equals("SI")) && !p.TEN_PTDIEN.Contains("tách lèo")).OrderByDescending(p => p.MA_CAPDA).ToList();
                }
                else
                {
                    return data.M_VITRI_V2s.Where(p => (p.LOAI_PTDIEN.Equals("DS") || p.LOAI_PTDIEN.Equals("MC") || p.LOAI_PTDIEN.Equals("SI")) && !p.TEN_PTDIEN.Contains("tách lèo") ).OrderByDescending(p => p.MA_CAPDA).ToList();
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
        public List<M_VITRI_V0_VM> listCDOpen_VM(string dvql)
        {
            try
            {
                if (!dvql.Equals("PN"))
                {
                    return data.M_VITRI_V0_VMs.Where(p => p.MA_DVQLY.Equals(dvql) && (p.LOAI_PTDIEN.Equals("DS") || p.LOAI_PTDIEN.Equals("MC") || p.LOAI_PTDIEN.Equals("SI")) && !p.TEN_PTDIEN.Contains("tách lèo") && !p.MA_CAPDA.Equals("03") && !p.MA_CAPDA.Equals("08") && p.TRANG_THAI == 0).OrderByDescending(p => p.MA_CAPDA).ToList();
                }
                else
                {
                    return data.M_VITRI_V0_VMs.Where(p => (p.LOAI_PTDIEN.Equals("DS") || p.LOAI_PTDIEN.Equals("MC") || p.LOAI_PTDIEN.Equals("SI")) && !p.TEN_PTDIEN.Contains("tách lèo") && !p.MA_CAPDA.Equals("03") && !p.MA_CAPDA.Equals("08") && p.TRANG_THAI == 0).OrderByDescending(p => p.MA_CAPDA).ToList();
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
        public Dictionary<string, int> getCountMatDienHienTaiTrongNgay(string _dvql)
        {
            try
            {
                int count = 0;
                Dictionary<string, int> present = new Dictionary<string, int>();
                List<D_DVI_QLY> dvql;
                if (!_dvql.Equals("PN"))
                {
                    dvql = data.D_DVI_QLies.Where(p => p.MA_DVIQLY.Equals(_dvql)).ToList();
                }
                else
                {
                    dvql = data.D_DVI_QLies.Where(p => !p.MA_DVIQLY.Equals("PN") && !p.MA_DVIQLY.Equals("PNX110")).ToList();
                }
                foreach (var item in dvql)
                {
                    try
                    {
                        count = data.M_VITRI_Vs.Where(p => p.MA_DVQLY.Equals(item.MA_DVIQLY) &&p.LOAI_PTDIEN.Equals("TT") && !p.MA_CAPDA.Equals("03") && !p.MA_CAPDA.Equals("08")&& p.NGAY_CAP_NHAT>=DateTime.Parse(getDateServer()) && (p.LEFT_TRANGTHAI == false || p.RIGHT_TRANGTHAI == false)).OrderByDescending(p => p.NGAY_CAP_NHAT).Count();
                    }
                    catch (Exception)
                    {
                        count = 0;
                    }
                    //int count1 = data.M_TTHAI_PTDIEN_LRs.Where(p =>p.D_PTDIEN.MA_DVQLY.Equals(item.MA_DVIQLY) && p.D_PTDIEN.LOAI_PTDIEN.Equals("TT") && !p.D_PTDIEN.MA_CAPDA.Equals("03") && !p.D_PTDIEN.MA_CAPDA.Equals("03") && p.NGAY_CAP_NHAT >= data.GetServerDate() && (p.LEFT_TRANGTHAI == false || p.RIGHT_TRANGTHAI == false)).Count();
                    present.Add(item.MA_DVIQLY, count);
                }
                return present;
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
        public Dictionary<string, int> getCountMatDienTrongNgay(string _dvql)
        {
            try
            {
                int count = 0;
                Dictionary<string, int> inDay = new Dictionary<string, int>();
                List<D_DVI_QLY> dvql;
                if (!_dvql.Equals("PN"))
                {
                    dvql = data.D_DVI_QLies.Where(p => p.MA_DVIQLY.Equals(_dvql)).ToList();
                }
                else
                {
                    dvql = data.D_DVI_QLies.Where(p => !p.MA_DVIQLY.Equals("PN") && !p.MA_DVIQLY.Equals("PNX110")).ToList();
                }
                foreach (var item in dvql)
                {
                    try
                    {
                        count = data.M_TTHAI_PTDIEN_LRs.Where(p => p.D_PTDIEN.MA_DVQLY.Equals(item.MA_DVIQLY) && p.D_PTDIEN.LOAI_PTDIEN.Equals("TT") && !p.D_PTDIEN.MA_CAPDA.Equals("03") && !p.D_PTDIEN.MA_CAPDA.Equals("03") && p.NGAY_CAP_NHAT >= DateTime.Parse(getDateServer()) && (p.LEFT_TRANGTHAI == false || p.RIGHT_TRANGTHAI == false)).Count();
                    
                    }
                    catch (Exception)
                    {
                        count = 0;
                    }
                    inDay.Add(item.MA_DVIQLY, count);
                }
                return inDay;
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
        public string getDateServer() {
            try
            {
                string[] date = data.GetServerDate().ToString().Split(' ');
                return date[0];
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
                return data.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha.Equals(idPTDien)).OrderBy(p => p.ID_PTDienCha).ToList();
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
        public List<D_QHE_PTDIEN_VITRI> listLRCon(int idPTDien)
        {
            try
            {
                return data.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCon.Equals(idPTDien)).ToList();
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
        public bool checkQH(int cha, int con)
        {
            var d = data.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha == cha && p.ID_PTDienCon == con).Count();
            if (d >= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void addLR(D_QHE_PTDIEN_VITRI _obj)
        {
            try
            {
                data.D_QHE_PTDIEN_VITRIs.InsertOnSubmit(_obj);
                data.SubmitChanges();
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
        public void deleteLR(int idLR)
        {
            try
            {
                D_QHE_PTDIEN_VITRI tmp = data.D_QHE_PTDIEN_VITRIs.Where(p => p.ID.Equals(idLR)).SingleOrDefault();
                data.D_QHE_PTDIEN_VITRIs.DeleteOnSubmit(tmp);
                data.SubmitChanges();
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
                data.D_QHE_PTDIEN_VITRIs.DeleteAllOnSubmit(lstQH);
                data.SubmitChanges();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Quá trình xóa sảy ra lỗi! Bạn vui lòng thực hiện lại.");
            }

        }
        public List<D_QHE_PTDIEN_VITRI> saoChepQH(int id) {
            return data.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCon == id).ToList();
        }
        public void danQH(List<D_QHE_PTDIEN_VITRI> lst) {
            foreach (var item in lst)
            {
                if (checkQH(int.Parse(item.ID_PTDienCha.ToString()),int.Parse(item.ID_PTDienCon.ToString())))
                {
                    addLR(item);
                }
            }
        }
        public List<D_QHE_PTDIEN_VITRI> listQH(int idCon=0,int idCha=0)
        {
            if (idCha==0)
            {
                return data.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCon == idCon && p.D_PTDIEN.LOAI_PTDIEN != "1S").ToList();
            }
            else
            {
                return data.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha == idCha && p.D_PTDIEN.LOAI_PTDIEN!="DZ"&&p.D_PTDIEN.LOAI_PTDIEN!="1S").ToList();
            }
        }
        public List<string> toaDoQuanHe(int idCon, int idCha)
        {
            try
            {
                using (LDSongDataContext db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
                {
                    SqlGeometry geo = new SqlGeometry();
                    List<string> td = new List<string>();
                    List<D_QHE_PTDIEN_VITRI> lst = listQH(idCon,idCha);
                    M_VITRI_V2 d1;
                    if (idCha==0)
                    {
                        d1 = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == idCon).FirstOrDefault();
                    }
                    else
                    {
                        d1 = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == idCha).FirstOrDefault();
                    }
                    if (d1.TOA_DO != null)
                    {
                        geo.Read(new System.IO.BinaryReader(
                        new System.IO.MemoryStream(
                        d1.TOA_DO.ToArray()
                        )));
                        if (geo.ToString().Contains("POINT"))
                        {
                            td.Add(geo.ToString());
                        }
                        else
                        {
                            td.Add(ThayTheLine(geo.ToString()));
                        }
                    }
                    foreach (var item in lst)
                    {
                        M_VITRI_V2 d;
                        if (idCha == 0)
                        {
                            d = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCha).FirstOrDefault();
                        }
                        else
                        {
                            d = db.M_VITRI_V2s.Where(p => p.ID_PTDIEN == item.ID_PTDienCon).FirstOrDefault();
                        }
                        if (d.TOA_DO != null)
                        {
                            geo.Read(new System.IO.BinaryReader(
                            new System.IO.MemoryStream(
                            d.TOA_DO.ToArray()
                            )));
                            if (geo.ToString().Contains("POINT"))
                            {
                                td.Add(geo.ToString());
                            }
                            else
                            {
                                td.Add(ThayTheLine(geo.ToString()));
                            }
                        }
                    }
                    return td;
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Quá trình xóa sảy ra lỗi! Bạn vui lòng thực hiện lại.");
                return null;
            }
        }
        public string ThayTheLine(string allToado)
        {
            
            string xl= allToado.Replace("LINESTRING", "POINT");
            string[] xl1 = xl.Split(',');
            return xl1[0] + xl1[2];
            
        }
    }
}
