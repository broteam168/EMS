using LDSong.Models;
using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class SoDo1SoiControler
    {
        private D_DVI_QLY obj;
        private LDSongDataContext db;
        private SqlGeometry geo;
        public List<string> ListsearchDZLine22, ListsearchDZLine35, ListsearchDZPoint0CDV, ListsearchDZPoint0CDH, ListsearchDZPoint1CDV, ListsearchDZPoint1CDH, ListsearchDZPoint1MCV, ListsearchDZPoint1MCH, ListsearchDZPoint0MCV, ListsearchDZPoint0MCH, ListsearchDZPoint1TGV, ListsearchDZPoint1TGH, ListsearchDZPoint0TGV, ListsearchDZPoint0TGH, ListsearchDZPoint1SIV, ListsearchDZPoint1SIH, ListsearchDZPoint0SIV, ListsearchDZPoint0SIH, ListsearchDZPoint1MCDZV, ListsearchDZPoint1MCDZH, ListsearchDZPoint0MCDZV, ListsearchDZPoint0MCDZH, ListWarning, ListSearchDZPoint0TBAV, ListSearchDZPoint1TBAV;
        public List<string> ListSearchNameTBA0V, ListSearchNameTBA0H, ListSearchNameTBA1V, ListSearchNameTBA1H, ListSearchNameCD0V, ListSearchNameCD0H, ListSearchNameCD1V, ListSearchNameCD1H, ListSearchNameDZ22, ListSearchNameDZ35, ListSearchNameMC0V, ListSearchNameMC0H, ListSearchNameMC1V, ListSearchNameMC1H, ListSearchNameTG0V, ListSearchNameTG0H, ListSearchNameTG1V, ListSearchNameTG1H, ListSearchNameSI0V, ListSearchNameSI0H, ListSearchNameSI1V, ListSearchNameSI1H, ListSearchNameMCDZ0V, ListSearchNameMCDZ0H, ListSearchNameMCDZ1V, ListSearchNameMCDZ1H;
        public List<int> ListSearchIDTBA0V, ListSearchIDTBA0H, ListSearchIDTBA1V, ListSearchIDTBA1H, ListSearchIDCD0V, ListSearchIDCD0H, ListSearchIDCD1V, ListSearchIDCD1H, ListSearchIDMC1V, ListSearchIDMC1H, ListSearchIDMC0V, ListSearchIDMC0H, ListSearchIDTG1V, ListSearchIDTG1H, ListSearchIDTG0V, ListSearchIDTG0H, ListSearchIDSI1V, ListSearchIDSI1H, ListSearchIDSI0V, ListSearchIDSI0H, ListSearchIDMCDZ1V, ListSearchIDMCDZ1H, ListSearchIDMCDZ0V, ListSearchIDMCDZ0H, ListIDDZ22, ListIDDZ35;
        public List<int> idQH;
        public List<string> listSearchtoado, listSearchten;
        public SoDo1SoiControler()
        {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }
        public bool checkWarning(int idPTDien)
        {
            var d = from vt in db.M_VITRI_V1s where vt.ID_PTDIEN==idPTDien && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" select new {  vt.ID_PTDIEN };
            if (d.Count()>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string vtCha(int idPTdien)
        {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                var d = from pt in data.M_VITRI_SD1S_V2s where pt.ID_PTDIEN==idPTdien select new { pt.VITRI };
                foreach (var item in d)
                {
                    if (item.VITRI != null)
                    {
                        geo.Read(new System.IO.BinaryReader(
                        new System.IO.MemoryStream(
                        item.VITRI.ToArray()
                        )));
                        return geo.ToString();
                    }
                }
                return null;
            }
        }
        public D_QHE_PTDIEN_VITRI XemQH(int idPTdien)
        {
            D_QHE_PTDIEN_VITRI qh = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCon == idPTdien&&p.D_PTDIEN.M_TTHAI_PTDIENs.OrderByDescending(c=>c.THOI_DIEM).FirstOrDefault().TRANG_THAI==1).FirstOrDefault();
            return qh;
        }
        public M_TTHAI_PTDIEN_LR getTTHAILR(int idPTDIEN)
        {
            try
            {
                var d = (from lr in db.M_TTHAI_PTDIEN_LRs where lr.ID_PTDIEN==idPTDIEN orderby lr.NGAY_CAP_NHAT descending select lr).Skip(0).Take(1);
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
        public string[] searchDiem(string id, string ten, string DVQLY, string dz22, string dz35)
        {
            SqlGeometry geo = new SqlGeometry();
            string toado;
            try
            {
                if (DVQLY == "PN")
                {
                    using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
                    {
                        var d = from pt in data.M_VITRI_SD1S_V2s where pt.ID_PTDIEN == int.Parse(id) && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S" select new { pt.VITRI, pt.TEN_PTDIEN };
                        listSearchten = new List<string>();
                        if (d.Count() != 0)
                        {
                            geo.Read(new System.IO.BinaryReader(
                            new System.IO.MemoryStream(
                            d.FirstOrDefault().VITRI.ToArray()
                            )));
                            toado = geo.ToString();
                            listSearchten.Add(d.FirstOrDefault().TEN_PTDIEN);
                            string[] xlline = toado.Split('(');
                            return xlline;
                        }


                    }
                }
                else
                {
                    using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
                    {
                        if (dz22 != "" && dz35 == "")
                        {
                            var d = from pt in data.M_VITRI_SD1S_V2s where pt.ID_PTDIEN == int.Parse(id) && pt.MA_DVQLY == DVQLY && pt.MA_CAPDA == dz22 && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S" select new { pt.VITRI, pt.TEN_PTDIEN };
                            listSearchten = new List<string>();
                            if (d.Count() != 0)
                            {

                                geo.Read(new System.IO.BinaryReader(
                               new System.IO.MemoryStream(
                               d.FirstOrDefault().VITRI.ToArray()
                               )));
                                toado = geo.ToString();
                                listSearchten.Add(d.FirstOrDefault().TEN_PTDIEN);
                                string[] xlline = toado.Split('(');
                                return xlline;
                            }
                        }
                        if (dz22 == "" && dz35 != "")
                        {
                            var d = from pt in data.M_VITRI_SD1S_V2s where pt.ID_PTDIEN == int.Parse(id) && pt.MA_DVQLY == DVQLY && pt.MA_CAPDA == dz35 && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S" select new { pt.VITRI, pt.TEN_PTDIEN };
                            listSearchten = new List<string>();
                            if (d.Count() != 0)
                            {

                                geo.Read(new System.IO.BinaryReader(
                               new System.IO.MemoryStream(
                               d.FirstOrDefault().VITRI.ToArray()
                               )));
                                toado = geo.ToString();
                                listSearchten.Add(d.FirstOrDefault().TEN_PTDIEN);
                                string[] xlline = toado.Split('(');
                                return xlline;
                            }
                        }
                        if (dz22 != "" && dz35 != "")
                        {
                            var d = from pt in data.M_VITRI_SD1S_V2s where pt.ID_PTDIEN == int.Parse(id) && pt.MA_DVQLY == DVQLY && pt.MA_CAPDA != "03" && pt.MA_CAPDA != "08" && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S" select new { pt.VITRI, pt.TEN_PTDIEN };
                            listSearchten = new List<string>();
                            if (d.Count() != 0)
                            {

                                geo.Read(new System.IO.BinaryReader(
                               new System.IO.MemoryStream(
                               d.FirstOrDefault().VITRI.ToArray()
                               )));
                                toado = geo.ToString();
                                listSearchten.Add(d.FirstOrDefault().TEN_PTDIEN);
                                string[] xlline = toado.Split('(');
                                return xlline;
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {

                try
                {
                    if (DVQLY == "PN")
                    {
                        using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
                        {
                            listSearchtoado = new List<string>();
                            listSearchten = new List<string>();
                            var d = from pt in data.M_VITRI_SD1S_V2s where pt.TEN_PTDIEN.Contains(ten) && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S" select new { pt.VITRI, pt.TEN_PTDIEN };
                            foreach (var item in d)
                            {
                                if (item.VITRI != null)
                                {
                                    geo.Read(new System.IO.BinaryReader(
                                    new System.IO.MemoryStream(
                                    item.VITRI.ToArray()
                                    )));
                                    listSearchtoado.Add(geo.ToString());
                                    listSearchten.Add(item.TEN_PTDIEN);
                                }
                            }
                            string[] xlline = listSearchtoado[0].Split('(');
                            System.Windows.Forms.MessageBox.Show("Hệ thống tìm được : " + listSearchtoado.Count + " kết quả" + "-" + "Hệ thống sẽ đưa bạn đến kết quả đầu tiên" + "-" + "Bạn nên đánh chính xác tên cần tìm");
                            return xlline;
                        }
                    }
                    else
                    {

                        using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
                        {
                            listSearchtoado = new List<string>();
                            listSearchten = new List<string>();
                            if (dz22 != "" && dz35 == "")
                            {
                                var d = from pt in data.M_VITRI_SD1S_V2s where pt.TEN_PTDIEN.Contains(ten) && pt.MA_DVQLY == DVQLY && pt.MA_CAPDA == dz22 && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S" select new { pt.VITRI, pt.TEN_PTDIEN };
                                foreach (var item in d)
                                {
                                    if (item.VITRI != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                        new System.IO.MemoryStream(
                                        item.VITRI.ToArray()
                                        )));
                                        listSearchtoado.Add(geo.ToString());
                                        listSearchten.Add(item.TEN_PTDIEN);
                                    }
                                }
                            }
                            if (dz22 == "" && dz35 != "")
                            {
                                var d = from pt in data.M_VITRI_SD1S_V2s where pt.TEN_PTDIEN.Contains(ten) && pt.MA_DVQLY == DVQLY && pt.MA_CAPDA == dz35 && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S" select new { pt.VITRI, pt.TEN_PTDIEN };
                                foreach (var item in d)
                                {
                                    if (item.VITRI != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                        new System.IO.MemoryStream(
                                        item.VITRI.ToArray()
                                        )));
                                        listSearchtoado.Add(geo.ToString());
                                        listSearchten.Add(item.TEN_PTDIEN);
                                    }
                                }
                            }
                            if (dz22 != "" && dz35 != "")
                            {
                                var d = from pt in data.M_VITRI_SD1S_V2s where pt.TEN_PTDIEN.Contains(ten) && pt.MA_DVQLY == DVQLY && pt.MA_CAPDA != "03" && pt.MA_CAPDA != "08" && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S" select new { pt.VITRI, pt.TEN_PTDIEN };
                                foreach (var item in d)
                                {
                                    if (item.VITRI != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                        new System.IO.MemoryStream(
                                        item.VITRI.ToArray()
                                        )));
                                        listSearchtoado.Add(geo.ToString());
                                        listSearchten.Add(item.TEN_PTDIEN);
                                    }
                                }
                            }
                            string[] xlline = listSearchtoado[0].Split('(');
                            System.Windows.Forms.MessageBox.Show("Hệ thống tìm được : " + listSearchtoado.Count + " kết quả" + "-" + "Hệ thống sẽ đưa bạn đến kết quả đầu tiên" + "-" + "Bạn nên đánh chính xác tên cần tìm");
                            return xlline;
                        }
                    }
                }
                catch (Exception)
                {

                    System.Windows.Forms.MessageBox.Show("Không tìm thấy kết quả nào");
                }
            }
            return null;
        }
        public void getWarning(string dvql, string capDa)
        {
            geo = new SqlGeometry();
            ListWarning = new List<string>();
            var d = from vt in db.M_VITRI_V1s where vt.MA_DVQLY == dvql && vt.MA_CAPDA == capDa && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "1S" select new { vt.TOA_DO };
            foreach (var item in d)
            {
                if (item.TOA_DO != null)
                {
                    geo.Read(new System.IO.BinaryReader(
                            new System.IO.MemoryStream(
                            item.TOA_DO.ToArray()
                            )));
                    ListWarning.Add(geo.ToString());
                }
            }
        }
        public void getAllDZ(string dvql, string macapda)
        {
            SqlGeometry geo = new SqlGeometry();
            ListSearchNameDZ22 = new List<string>();
            ListSearchNameDZ35 = new List<string>();
            ListsearchDZLine22 = new List<string>();
            ListIDDZ22 = new List<int>();
            ListsearchDZLine35 = new List<string>();
            ListIDDZ35 = new List<int>();
            var d = db.M_VITRI_V2s.Where(p => p.MA_DVQLY.Equals(dvql) && p.MA_CAPDA.Equals(macapda)).ToList();
            foreach (var item in d)
            {
                if (item.LOAI_PTDIEN == "1S")
                {
                    if (item.TOA_DO != null)
                    {
                        geo.Read(new System.IO.BinaryReader(
                                       new System.IO.MemoryStream(
                                       item.TOA_DO.ToArray()
                                       )));
                        if (geo.ToString().Contains("LINESTRING"))
                        {
                            if (item.MA_CAPDA == "05")
                            {
                                ListsearchDZLine22.Add(geo.ToString());
                                ListSearchNameDZ22.Add(item.TEN_PTDIEN);
                                ListIDDZ22.Add(item.ID_PTDIEN);
                            }
                            if (item.MA_CAPDA == "06")
                            {
                                ListsearchDZLine35.Add(geo.ToString());
                                ListSearchNameDZ35.Add(item.TEN_PTDIEN);
                                ListIDDZ35.Add(item.ID_PTDIEN);
                            }
                        }
                    }
                }
            }

        }
        public List<int> getAllSD1(string madv, string cap)
        {
            List<int> id = new List<int>();
            try
            {
               var a= db.M_VITRI_SD1S_Vs.Where(p => p.LOAI_PTDIEN != "TT"&&p.MA_DVQLY.Equals(madv)&&p.MA_CAPDA.Equals(cap)).ToList();
                foreach (var item in a)
                {
                    id.Add(int.Parse(item.ID_PTDIEN.ToString()));
                }
                return id;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Quá trình thực hiện lỗi! Bạn vui lòng thực hiện lại.");
                return null;
            }
        }
        public string todoPhanTu(int id)
        {
            try
            {
                SqlGeometry geo = new SqlGeometry();
                var d1 = db.M_VITRI_SD1S_Vs.Where(p => p.ID_PTDIEN == id).FirstOrDefault();
                geo.Read(new System.IO.BinaryReader(
                    new System.IO.MemoryStream(
                    d1.VITRI.ToArray()
                    )));
                if (geo.ToString().Contains("POINT"))
                {
                    return geo.ToString();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show("Quá trình thực hiện lỗi! Bạn vui lòng thực hiện lại."+e1);
                return null;
            }
        }
        public bool QHCC(int idPT)
        {
            var d2 = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha == idPT).Count();
            if (d2>=1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool nhieuQH(int idPT)
        {
            var d2 = db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha == idPT && p.D_PTDIEN.LOAI_PTDIEN!="TT").Count();
            if (d2>=1)
            {
                var d3= db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCon == idPT).Count();
                if (d3>=1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public List<string> xulyLine(List<string> allToado)
        {
            List<string> xulyLine = new List<string>();
            for (int i = 0; i < allToado.Count; i++)
            {
                string[] xlline = allToado[i].Split('(');
                xulyLine.Add(xlline[1].Replace(")", ""));

            }


            return xulyLine;
        }
        public List<string> toaDoQuanHe(int idCha)
        {
            try
            {
                SqlGeometry geo = new SqlGeometry();
                List<string> td = new List<string>();
                idQH = new List<int>();
                List<D_QHE_PTDIEN_VITRI> lst = listQH( idCha);
                var d1 = db.M_VITRI_SD1S_Vs.Where(p => p.ID_PTDIEN == idCha && p.LOAI_PTDIEN!="TT").FirstOrDefault();
                if (d1.VITRI != null)
                {
                    geo.Read(new System.IO.BinaryReader(
                    new System.IO.MemoryStream(
                    d1.VITRI.ToArray()
                    )));
                    if (geo.ToString().Contains("POINT"))
                    {
                        td.Add(geo.ToString());
                        idQH.Add(idCha);
                    }
                }
                foreach (var item in lst)
                {
                    var d = from vt in db.M_VITRI_SD1S_Vs where vt.ID_PTDIEN == item.ID_PTDienCon select new { vt.VITRI };
                    
                    if (d.FirstOrDefault() != null)
                    {
                        geo.Read(new System.IO.BinaryReader(
                        new System.IO.MemoryStream(
                        d.FirstOrDefault().VITRI.ToArray()
                        )));
                        if (geo.ToString().Contains("POINT"))
                        {
                            td.Add(geo.ToString());
                            idQH.Add(int.Parse(item.ID_PTDienCon.ToString()));
                        }
                    }
                }
                return td;
                
            }
            catch (Exception e) { 
            
                System.Windows.Forms.MessageBox.Show("Quá trình thực hiện lỗi! Bạn vui lòng thực hiện lại.");
                return null;
            }
        }
        public List<D_QHE_PTDIEN_VITRI> listQH(int idCha)
        {
            /*if (idCha == 0)
            {
                return db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCon == idCon && p.D_PTDIEN.LOAI_PTDIEN != "1S").ToList();
            }
            else
            {*/
                return db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha == idCha && p.D_PTDIEN.LOAI_PTDIEN != "DZ" && p.D_PTDIEN.LOAI_PTDIEN != "1S").ToList();
            //}
        }
        public List<D_DVI_QLY> listDonvi(string dvql)
        {
            try
            {
                if (dvql != "PN")
                {
                    return db.D_DVI_QLies.Where(p => p.MA_DVIQLY.Equals(dvql)).ToList();
                }
                else
                {
                    return db.D_DVI_QLies.ToList();
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
        public List<D_LOAI_TBI> listLoaiPT()
        {
            try
            {
                return db.D_LOAI_TBIs.Where(t => t.MA_LOAI == "TT" || t.MA_LOAI == "DS" || t.MA_LOAI == "SI" || t.MA_LOAI == "MC" || t.MA_LOAI == "CB" || t.MA_LOAI == "TG").ToList();
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
        public List<D_CAP_DAP> listCapDienAp()
        {
            try
            {
                return db.D_CAP_DAPs.Where(d => d.MA_CAPDA == "05" || d.MA_CAPDA == "06").ToList();
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
        public List<D_PTDIEN> listPTDien(string dvql,string capDA,string loai)
        {
            try
            {
                return db.D_PTDIENs.Where(p => p.MA_DVQLY.Equals(dvql) && p.MA_CAPDA.Equals(capDA) && p.LOAI_PTDIEN.Equals(loai)).OrderBy(p => p.ID_PTDIEN).ToList();
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
                return db.D_QHE_PTDIEN_VITRIs.Where(p => p.ID_PTDienCha.Equals(idPTDien)&&!p.D_PTDIEN.D_LOAI_TBI.MA_LOAI.Equals("DZ")).OrderBy(p => p.VITRI).ToList();
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
        public bool checkExist(string query)
        {
            SqlConnection con = new SqlConnection(LDSong.Properties.Settings.Default.connect);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            con.Close();
            if (da.Fill(dt) != 0)
            {
                return false;
            }
            else
            {
                return true;
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
        public List<string> xulyDiem(List<string> allToado)
        {
            List<string> xulyDiem = new List<string>();
            //List<string> xulyLine1 = new List<string>();
            for (int i = 0; i < allToado.Count; i++)
            {
                string[] xlline = allToado[i].Split('(');
                xulyDiem.Add(xlline[1].Replace(")", ""));
            }

            return xulyDiem;
        }
        public string xulyDiemTD(string allToado)
        {
            string xulyDiem = null;
            string[] xlline = allToado.Split('(');
            xulyDiem=xlline[1].Replace(")", "");
            return xulyDiem;
        }
        public DateTime getDateServer()
        {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                return data.GetServerDate();
            }
        }
        public void getAllTB(string dvql, string macapDa)
        {
            geo = new SqlGeometry();
            ListsearchDZPoint0CDV = new List<string>();
            ListsearchDZPoint0CDH = new List<string>();
            ListsearchDZPoint1CDH = new List<string>();
            ListsearchDZPoint1CDV = new List<string>();
            ListsearchDZPoint1MCV = new List<string>();
            ListsearchDZPoint1MCH = new List<string>();
            ListsearchDZPoint0MCV = new List<string>();
            ListsearchDZPoint0MCH = new List<string>();
            ListsearchDZPoint0TGH = new List<string>();
            ListsearchDZPoint0TGV = new List<string>();
            ListsearchDZPoint1TGV = new List<string>();
            ListsearchDZPoint1TGH = new List<string>();
            ListsearchDZPoint0SIV = new List<string>();
            ListsearchDZPoint0SIH = new List<string>();
            ListsearchDZPoint1SIV = new List<string>();
            ListsearchDZPoint1SIH = new List<string>();
            ListsearchDZPoint0MCDZV = new List<string>();
            ListsearchDZPoint0MCDZH = new List<string>();
            ListsearchDZPoint1MCDZV = new List<string>();
            ListsearchDZPoint1MCDZH = new List<string>();
            ListSearchDZPoint0TBAV = new List<string>();
            ListSearchDZPoint1TBAV = new List<string>();
            ListSearchNameTBA0V = new List<string>();
            ListSearchNameTBA0H = new List<string>();
            ListSearchNameTBA1V = new List<string>();
            ListSearchNameTBA1H = new List<string>();
            ListSearchNameCD0V = new List<string>();
            ListSearchNameCD0H = new List<string>();
            ListSearchNameCD1H = new List<string>();
            ListSearchNameCD1V = new List<string>();
            ListSearchNameMC0V = new List<string>();
            ListSearchNameMC0H = new List<string>();
            ListSearchNameMC1V = new List<string>();
            ListSearchNameMC1H = new List<string>();
            ListSearchNameTG0V = new List<string>();
            ListSearchNameTG0H = new List<string>();
            ListSearchNameTG1V = new List<string>();
            ListSearchNameTG1H = new List<string>();
            ListSearchNameSI0V = new List<string>();
            ListSearchNameSI0H = new List<string>();
            ListSearchNameSI1V = new List<string>();
            ListSearchNameSI1H = new List<string>();
            ListSearchNameMCDZ0V = new List<string>();
            ListSearchNameMCDZ0H = new List<string>();
            ListSearchNameMCDZ1V = new List<string>();
            ListSearchNameMCDZ1H = new List<string>();
            ListSearchIDTBA0V = new List<int>();
            ListSearchIDTBA0H = new List<int>();
            ListSearchIDTBA1V = new List<int>();
            ListSearchIDTBA1H = new List<int>();
            ListSearchIDCD0V = new List<int>();
            ListSearchIDCD0H = new List<int>();
            ListSearchIDCD1V = new List<int>();
            ListSearchIDCD1H = new List<int>();
            ListSearchIDMC0V = new List<int>();
            ListSearchIDMC0H = new List<int>();
            ListSearchIDMC1V = new List<int>();
            ListSearchIDMC1H = new List<int>();
            ListSearchIDTG0V = new List<int>();
            ListSearchIDTG0H = new List<int>();
            ListSearchIDTG1V = new List<int>();
            ListSearchIDTG1H = new List<int>();
            ListSearchIDSI0V = new List<int>();
            ListSearchIDSI0H = new List<int>();
            ListSearchIDSI1V = new List<int>();
            ListSearchIDSI1H = new List<int>();
            ListSearchIDMCDZ0V = new List<int>();
            ListSearchIDMCDZ0H = new List<int>();
            ListSearchIDMCDZ1V = new List<int>();
            ListSearchIDMCDZ1H = new List<int>();
            var d = db.M_VITRI_SD1S_V2s.Where(p => p.MA_DVQLY.Equals(dvql) && p.MA_CAPDA.Equals(macapDa)).ToList();
            foreach (var item in d)
            {
                if (item.VITRI != null)
                {
                    geo.Read(new System.IO.BinaryReader(
                                    new System.IO.MemoryStream(
                                    item.VITRI.ToArray()
                                    )));
                    if (geo.ToString().Contains("POINT"))
                    {
                        if (item.LOAI_PTDIEN == "DS")
                        {
                            if (item.TRANG_THAI == 0)
                            {
                                if (item.KIEU.Equals('V'))
                                {
                                    ListsearchDZPoint0CDV.Add(geo.ToString());
                                    ListSearchNameCD0V.Add(item.TEN_PTDIEN);
                                    ListSearchIDCD0V.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                                else
                                {
                                    ListsearchDZPoint0CDH.Add(geo.ToString());
                                    ListSearchNameCD0H.Add(item.TEN_PTDIEN);
                                    ListSearchIDCD0H.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                            }
                            else
                            {
                                if (item.KIEU.Equals('V'))
                                {
                                    ListsearchDZPoint1CDV.Add(geo.ToString());
                                    ListSearchNameCD1V.Add(item.TEN_PTDIEN);
                                    ListSearchIDCD1V.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                                else
                                {
                                    ListsearchDZPoint1CDH.Add(geo.ToString());
                                    ListSearchNameCD1H.Add(item.TEN_PTDIEN);
                                    ListSearchIDCD1H.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                            }
                        }
                        if (item.LOAI_PTDIEN == "CB")
                        {
                            if (item.TRANG_THAI == 0)
                            {
                                if (item.KIEU.Equals('V'))
                                {
                                    ListsearchDZPoint0MCV.Add(geo.ToString());
                                    ListSearchNameMC0V.Add(item.TEN_PTDIEN);
                                    ListSearchIDMC0V.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                                else
                                {
                                    ListsearchDZPoint0MCH.Add(geo.ToString());
                                    ListSearchNameMC0H.Add(item.TEN_PTDIEN);
                                    ListSearchIDMC0H.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                            }
                            else
                            {
                                if (item.KIEU.Equals('V'))
                                {
                                    ListsearchDZPoint1MCV.Add(geo.ToString());
                                    ListSearchNameMC1V.Add(item.TEN_PTDIEN);
                                    ListSearchIDMC1V.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                                else
                                {
                                    ListsearchDZPoint1MCH.Add(geo.ToString());
                                    ListSearchNameMC1H.Add(item.TEN_PTDIEN);
                                    ListSearchIDMC1H.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                            }
                        }
                        if (item.LOAI_PTDIEN == "TG")
                        {
                            if (item.TRANG_THAI == 0)
                            {
                                if (item.KIEU.Equals('V'))
                                {
                                    ListsearchDZPoint0TGV.Add(geo.ToString());
                                    ListSearchNameTG0V.Add(item.TEN_PTDIEN);
                                    ListSearchIDTG0V.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                                else
                                {
                                    ListsearchDZPoint0TGH.Add(geo.ToString());
                                    ListSearchNameTG0H.Add(item.TEN_PTDIEN);
                                    ListSearchIDTG0H.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                            }
                            else
                            {
                                if (item.KIEU.Equals('V'))
                                {
                                    ListsearchDZPoint1TGV.Add(geo.ToString());
                                    ListSearchNameTG1V.Add(item.TEN_PTDIEN);
                                    ListSearchIDTG1V.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                                else
                                {
                                    ListsearchDZPoint1TGH.Add(geo.ToString());
                                    ListSearchNameTG1H.Add(item.TEN_PTDIEN);
                                    ListSearchIDTG1H.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                            }
                        }
                        if (item.LOAI_PTDIEN == "SI")
                        {
                            if (item.TRANG_THAI == 0)
                            {
                                if (item.KIEU.Equals('V'))
                                {
                                    ListsearchDZPoint0SIV.Add(geo.ToString());
                                    ListSearchNameSI0V.Add(item.TEN_PTDIEN);
                                    ListSearchIDSI0V.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                                else
                                {
                                    ListsearchDZPoint0SIH.Add(geo.ToString());
                                    ListSearchNameSI0H.Add(item.TEN_PTDIEN);
                                    ListSearchIDSI0H.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                            }
                            else
                            {
                                if (item.KIEU.Equals('V'))
                                {
                                    ListsearchDZPoint1SIV.Add(geo.ToString());
                                    ListSearchNameSI1V.Add(item.TEN_PTDIEN);
                                    ListSearchIDSI1V.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                                else
                                {
                                    ListsearchDZPoint1SIH.Add(geo.ToString());
                                    ListSearchNameSI1H.Add(item.TEN_PTDIEN);
                                    ListSearchIDSI1H.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                            }
                        }
                        if (item.LOAI_PTDIEN == "MC")
                        {
                            if (item.TRANG_THAI == 0)
                            {
                                if (item.KIEU.Equals('V'))
                                {
                                    ListsearchDZPoint0MCDZV.Add(geo.ToString());
                                    ListSearchNameMCDZ0V.Add(item.TEN_PTDIEN);
                                    ListSearchIDMCDZ0V.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                                else
                                {
                                    ListsearchDZPoint0MCDZH.Add(geo.ToString());
                                    ListSearchNameMCDZ0H.Add(item.TEN_PTDIEN);
                                    ListSearchIDMCDZ0H.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                            }
                            else
                            {
                                if (item.KIEU.Equals('V'))
                                {
                                    ListsearchDZPoint1MCDZV.Add(geo.ToString());
                                    ListSearchNameMCDZ1V.Add(item.TEN_PTDIEN);
                                    ListSearchIDMCDZ1V.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                                else
                                {
                                    ListsearchDZPoint1MCDZH.Add(geo.ToString());
                                    ListSearchNameMCDZ1H.Add(item.TEN_PTDIEN);
                                    ListSearchIDMCDZ1H.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                }
                            }
                        }
                        if (item.LOAI_PTDIEN == "TT")
                        {
                            if (item.TRANG_THAI == 0)
                            {
                                ListSearchDZPoint0TBAV.Add(geo.ToString());
                                ListSearchNameTBA0V.Add(item.TEN_PTDIEN);
                                ListSearchIDTBA0V.Add(int.Parse(item.ID_PTDIEN.ToString()));
                                
                            }
                            else
                            {
                                ListSearchDZPoint1TBAV.Add(geo.ToString());
                                ListSearchNameTBA1V.Add(item.TEN_PTDIEN);
                                ListSearchIDTBA1V.Add(int.Parse(item.ID_PTDIEN.ToString()));
                            }
                        }
                    }
                }
            }

        }
    }
}
