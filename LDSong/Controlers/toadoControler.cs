using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.SqlServer.Types;
using LDSong.Models;
using System.Data.Linq;

namespace LDSong.Controlers
{
    class toadoControler
    {
        //public List<string> lineString;
        //public List<string> point;
        public List<int> ListPTDIEN0, ListCD0;//, ListPTDxuly0
        public List<int> ListPTDIEN1, ListCD1;//,ListPTDxuly1
        public List<string> ListNameTBA0, ListNameTBA1, ListNameCD0, ListNameCD1;
        public List<string> ListsearchDZLine22, ListsearchDZLine35, ListsearchDZPoint0TT, ListsearchDZPoint1TT, ListsearchDZPoint0CD, ListsearchDZPoint1CD, ListsearchDZPoint1MC, ListsearchDZPoint0MC, ListsearchDZPoint1TG, ListsearchDZPoint0TG, ListsearchDZPoint1SI, ListsearchDZPoint0SI, ListsearchDZPoint1MCDZ, ListsearchDZPoint0MCDZ, listtoadoN, ListNameN, ListColorBGN;//ListWarning,
        public List<string> ListSearchNameTBA0, ListSearchNameTBA1, ListSearchNameCD0, ListSearchNameCD1, ListSearchNameDZ22, ListSearchNameDZ35, ListSearchNameMC0, ListSearchNameMC1, ListSearchNameTG0, ListSearchNameTG1, ListSearchNameSI0, ListSearchNameSI1, ListSearchNameMCDZ0, ListSearchNameMCDZ1;
        public List<int> ListSearchIDTBA0, ListSearchIDTBA1, ListSearchIDCD0, ListSearchIDCD1, ListSearchIDMC1, ListSearchIDMC0, ListSearchIDTG1, ListSearchIDTG0, ListSearchIDSI1, ListSearchIDSI0, ListSearchIDMCDZ1, ListSearchIDMCDZ0, ListIDDZ22, ListIDDZ35, ListIDN;
        public List<string> listSearchtoado,listLS0,listLS1;
        public List<string> listSearchten;
        public List<string> listMaPmis, listTenPTDien;
        private SqlGeometry geo;
        public toadoControler()
        {
            listTenPTDien = new List<string>();
        }
        public List<D_CAP_DAP> listCap()
        {
            using (LDSongDataContext db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                return db.D_CAP_DAPs.ToList();
            }
        }
        public List<string> getAllTBA0(string CAPDA, string DVQLY, string loaiTB, int trangthai)
        {
            //Binary toado;
            SqlGeometry geo = new SqlGeometry();
            List<string> listtoado = new List<string>();
            ListPTDIEN0 = new List<int>();
            ListNameTBA0 = new List<string>();
            using (LDSongDataContext dataVitri = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                //List<Binary> list = new List<Binary>();
                if (CAPDA == "")
                {
                    if (DVQLY == "PN")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));

                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListPTDIEN0.Add(item.ID_PTDIEN);
                                    ListNameTBA0.Add(item.TEN_PTDIEN);
                                }

                            }
                        }
                    }
                    else
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListPTDIEN0.Add(item.ID_PTDIEN);
                                    ListNameTBA0.Add(item.TEN_PTDIEN);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (DVQLY == "PN")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA && vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListPTDIEN0.Add(item.ID_PTDIEN);
                                    ListNameTBA0.Add(item.TEN_PTDIEN);
                                }
                            }
                        }
                    }
                    else
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA && vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListPTDIEN0.Add(item.ID_PTDIEN);
                                    ListNameTBA0.Add(item.TEN_PTDIEN);
                                }
                            }
                        }
                    }
                }
                return listtoado;
            }


        }
        public List<string> getAllTBA1(string CAPDA, string DVQLY, string loaiTB, int trangthai)
        {
            //Binary toado;
            SqlGeometry geo = new SqlGeometry();
            List<string> listtoado = new List<string>();
            ListPTDIEN1 = new List<int>();
            ListNameTBA1 = new List<string>();
            using (LDSongDataContext dataVitri = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                List<Binary> list = new List<Binary>();
                if (CAPDA == "")
                {
                    if (DVQLY == "PN")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListPTDIEN1.Add(item.ID_PTDIEN);
                                    ListNameTBA1.Add(item.TEN_PTDIEN);
                                }
                            }
                        }
                    }
                    else
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListPTDIEN1.Add(item.ID_PTDIEN);
                                    ListNameTBA1.Add(item.TEN_PTDIEN);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (DVQLY == "PN")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA && vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListPTDIEN1.Add(item.ID_PTDIEN);
                                    ListNameTBA1.Add(item.TEN_PTDIEN);
                                }
                            }
                        }
                    }
                    else
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA && vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListPTDIEN1.Add(item.ID_PTDIEN);
                                    ListNameTBA1.Add(item.TEN_PTDIEN);
                                }
                            }
                        }
                    }
                }

                return listtoado;
            }

        }
        public void getNotice(string DVQLY, string loaiTB)
        { 
            SqlGeometry geo = new SqlGeometry();
            listtoadoN = new List<string>();
            ListIDN = new List<int>();
            ListNameN = new List<string>();
            ListColorBGN = new List<string>();
            using (LDSongDataContext dataVitri = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                if (DVQLY == "PN")
                {
                    var d = from vt in dataVitri.M_VITRI_V2s where  vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN,vt.MA_CMIS };
                    foreach (var item in d)
                    {
                        if (item.TOA_DO != null)
                        {
                            geo.Read(new System.IO.BinaryReader(
                            new System.IO.MemoryStream(
                            item.TOA_DO.ToArray()
                            )));
                            if (geo.ToString().Contains("LINESTRING"))
                            {
                                listtoadoN.Add(geo.ToString());
                                ListIDN.Add(item.ID_PTDIEN);
                                ListNameN.Add(item.TEN_PTDIEN);
                                ListColorBGN.Add(item.MA_CMIS);
                            }
                        }
                    }
                }
                else
                {
                    var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN ,vt.MA_CMIS};
                    foreach (var item in d)
                    {
                        if (item.TOA_DO != null)
                        {
                            geo.Read(new System.IO.BinaryReader(
                            new System.IO.MemoryStream(
                            item.TOA_DO.ToArray()
                            )));
                            if (geo.ToString().Contains("LINESTRING"))
                            {
                                listtoadoN.Add(geo.ToString());
                                ListIDN.Add(item.ID_PTDIEN);
                                ListNameN.Add(item.TEN_PTDIEN);
                                ListColorBGN.Add(item.MA_CMIS);
                            }
                        }
                    }
                }
            }
        }
        public List<string> getAllCD0(string CAPDA, string DVQLY, string loaiTB, int trangthai)
        {
            //Binary toado;
            SqlGeometry geo = new SqlGeometry();
            List<string> listtoado = new List<string>();
            ListCD0 = new List<int>();
            ListNameCD0 = new List<string>();
            using (LDSongDataContext dataVitri = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                List<Binary> list = new List<Binary>();
                if (CAPDA == "")
                {
                    if (DVQLY == "PN")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));

                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListCD0.Add(item.ID_PTDIEN);
                                    ListNameCD0.Add(item.TEN_PTDIEN);
                                }

                            }
                        }
                    }
                    else
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListCD0.Add(item.ID_PTDIEN);
                                    ListNameCD0.Add(item.TEN_PTDIEN);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (DVQLY == "PN")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA && vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListCD0.Add(item.ID_PTDIEN);
                                    ListNameCD0.Add(item.TEN_PTDIEN);
                                }
                            }
                        }
                    }
                    else
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA && vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListCD0.Add(item.ID_PTDIEN);
                                    ListNameCD0.Add(item.TEN_PTDIEN);
                                }
                            }
                        }
                    }
                }


                return listtoado;
            }


        }
        public List<string> getAllCD1(string CAPDA, string DVQLY, string loaiTB, int trangthai)
        {
            //Binary toado;
            SqlGeometry geo = new SqlGeometry();
            List<string> listtoado = new List<string>();
            ListCD1 = new List<int>();
            ListNameCD1 = new List<string>();
            using (LDSongDataContext dataVitri = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                List<Binary> list = new List<Binary>();
                if (CAPDA == "")
                {
                    if (DVQLY == "PN")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));

                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListCD1.Add(item.ID_PTDIEN);
                                    ListNameCD1.Add(item.TEN_PTDIEN);
                                }

                            }
                        }
                    }
                    else
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListCD1.Add(item.ID_PTDIEN);
                                    ListNameCD1.Add(item.TEN_PTDIEN);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (DVQLY == "PN")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA && vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListCD1.Add(item.ID_PTDIEN);
                                    ListNameCD1.Add(item.TEN_PTDIEN);
                                }
                            }
                        }
                    }
                    else
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA && vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN, vt.TEN_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    listtoado.Add(geo.ToString());
                                    ListCD1.Add(item.ID_PTDIEN);
                                    ListNameCD1.Add(item.TEN_PTDIEN);
                                }
                            }
                        }
                    }
                }


                return listtoado;
            }


        }
        public List<string> getLine(string CAPDA, string DVQLY)
        {

            SqlGeometry geo = new SqlGeometry();
            List<string> listtoado = new List<string>();
            if (DVQLY == "PN")
            {
                using (LDSongDataContext dataLine10 = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
                {
                    var d = from vt in dataLine10.M_VITRI_V2s where vt.MA_CAPDA == CAPDA select new { vt.TOA_DO };
                    List<Binary> list = new List<Binary>();
                    foreach (var item in d)
                    {
                        if (item.TOA_DO != null)
                        {
                            geo.Read(new System.IO.BinaryReader(
                            new System.IO.MemoryStream(
                            item.TOA_DO.ToArray()
                            )));
                            if (geo.ToString().Contains("LINESTRING"))
                            {
                                listtoado.Add(geo.ToString());
                            }
                        }
                    }
                }
                return listtoado;
            }
            else
            {
                using (LDSongDataContext dataLine10 = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
                {
                    var d = from vt in dataLine10.M_VITRI_V2s where vt.MA_CAPDA == CAPDA && vt.MA_DVQLY == DVQLY select new { vt.TOA_DO };
                    List<Binary> list = new List<Binary>();
                    foreach (var item in d)
                    {
                        if (item.TOA_DO != null)
                        {
                            geo.Read(new System.IO.BinaryReader(
                            new System.IO.MemoryStream(
                            item.TOA_DO.ToArray()
                            )));
                            if (geo.ToString().Contains("LINESTRING"))
                            {
                                listtoado.Add(geo.ToString());
                            }
                        }
                    }
                }
                return listtoado;
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
        public List<string> xulyDiem(string allToado)
        {
            List<string> xulyDiem = new List<string>();
            string[] xlline = allToado.ToString().Split('(');
            xulyDiem.Add(xlline[1].Replace(")", ""));
            return xulyDiem;
        }
        public string getToadoCD(int idPTDien) { 
            try{
                using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
                {
                    var td = data.M_VITRI_V2s.Where(p => p.ID_PTDIEN == idPTDien).SingleOrDefault();
                    SqlGeometry geo = new SqlGeometry();
                    geo.Read(new System.IO.BinaryReader(
                                                    new System.IO.MemoryStream(
                                                    td.TOA_DO.ToArray()
                                                    )));
                    return geo.ToString();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                System.Windows.Forms.MessageBox.Show("Không thể kết nối được tới máy chủ. Bạn vui lòng kiểm tra lại kết nối và khởi động lại phần mềm.");
                return null;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Có lỗi xảy ra vui lòng kiểm tra lại. " + e.ToString());
                return null;
            }
        }
        public List<string> getthongtinDiem(string id)
        {
            List<string> inforTram = new List<string>();
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                var d = from pt in data.M_VITRI_V2s where pt.ID_PTDIEN == int.Parse(id) select pt;
                inforTram.Add(d.FirstOrDefault().ID_PTDIEN.ToString());
                inforTram.Add(d.FirstOrDefault().LOAI_PTDIEN.ToString());
                inforTram.Add(d.FirstOrDefault().MA_CAPDA.ToString());
                inforTram.Add(d.FirstOrDefault().MA_DVQLY.ToString());
                inforTram.Add(d.FirstOrDefault().MA_PMIS.ToString());
                //inforTram.Add(d.FirstOrDefault().MA_PTDIEN.ToString());
                inforTram.Add(d.FirstOrDefault().TEN_PTDIEN.ToString());
                inforTram.Add(d.FirstOrDefault().TOA_DO.ToString());
                inforTram.Add(d.FirstOrDefault().TRANG_THAI.ToString());
                inforTram.Add(d.FirstOrDefault().MA_PMISCHA.ToString());
                try
                {
                    inforTram.Add(d.FirstOrDefault().MA_CMIS.ToString());
                }
                catch (Exception)
                {
                    inforTram.Add("");
                }
                return inforTram;

            }
        }
        public List<string> getthongtinDiem_VM(string id)
        {
            List<string> inforTram = new List<string>();
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                var d = from pt in data.M_VITRI_V2_VMs where pt.ID_PTDIEN == int.Parse(id) select pt;
                inforTram.Add(d.FirstOrDefault().ID_PTDIEN.ToString());
                inforTram.Add(d.FirstOrDefault().LOAI_PTDIEN.ToString());
                inforTram.Add(d.FirstOrDefault().MA_CAPDA.ToString());
                inforTram.Add(d.FirstOrDefault().MA_DVQLY.ToString());
                inforTram.Add(d.FirstOrDefault().MA_PMIS.ToString());
                //inforTram.Add(d.FirstOrDefault().MA_PTDIEN.ToString());
                inforTram.Add(d.FirstOrDefault().TEN_PTDIEN.ToString());
                inforTram.Add(d.FirstOrDefault().TOA_DO.ToString());
                inforTram.Add(d.FirstOrDefault().TRANG_THAI.ToString());
                inforTram.Add(d.FirstOrDefault().MA_PMISCHA.ToString());
                try
                {
                    inforTram.Add(d.FirstOrDefault().MA_CMIS.ToString());
                }
                catch (Exception)
                {
                    inforTram.Add("");
                }
                return inforTram;

            }
        }
        public void getALLDuongDAY(string maPmisCha)
        {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                try
                {
                    var d = from pt in data.D_PTDIENs where pt.MA_PMIS == maPmisCha select new { pt.TEN_PTDIEN, pt.MA_PMISCHA };
                    listTenPTDien.Add(d.First().TEN_PTDIEN);
                    getALLDuongDAY(d.First().MA_PMISCHA);
                }
                catch (Exception)
                {

                }
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
                        var d = from pt in data.M_VITRI_V2s where pt.ID_PTDIEN == int.Parse(id) && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT"  && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S" select new { pt.TOA_DO, pt.TEN_PTDIEN };
                        listSearchten = new List<string>();
                        if (d.Count() != 0)
                        {
                            geo.Read(new System.IO.BinaryReader(
                            new System.IO.MemoryStream(
                            d.FirstOrDefault().TOA_DO.ToArray()
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
                            var d = from pt in data.M_VITRI_V2s where pt.ID_PTDIEN == int.Parse(id) && pt.MA_DVQLY == DVQLY && pt.MA_CAPDA == dz22 && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S"  select new { pt.TOA_DO, pt.TEN_PTDIEN };
                            listSearchten = new List<string>();
                            if (d.Count() != 0)
                            {

                                geo.Read(new System.IO.BinaryReader(
                               new System.IO.MemoryStream(
                               d.FirstOrDefault().TOA_DO.ToArray()
                               )));
                                toado = geo.ToString();
                                listSearchten.Add(d.FirstOrDefault().TEN_PTDIEN);
                                string[] xlline = toado.Split('(');
                                return xlline;
                            }
                        }
                        if (dz22 == "" && dz35 != "")
                        {
                            var d = from pt in data.M_VITRI_V2s where pt.ID_PTDIEN == int.Parse(id) && pt.MA_DVQLY == DVQLY && pt.MA_CAPDA == dz35 && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S" select new { pt.TOA_DO, pt.TEN_PTDIEN };
                            listSearchten = new List<string>();
                            if (d.Count() != 0)
                            {

                                geo.Read(new System.IO.BinaryReader(
                               new System.IO.MemoryStream(
                               d.FirstOrDefault().TOA_DO.ToArray()
                               )));
                                toado = geo.ToString();
                                listSearchten.Add(d.FirstOrDefault().TEN_PTDIEN);
                                string[] xlline = toado.Split('(');
                                return xlline;
                            }
                        }
                        if (dz22 != "" && dz35 != "")
                        {
                            var d = from pt in data.M_VITRI_V2s where pt.ID_PTDIEN == int.Parse(id) && pt.MA_DVQLY == DVQLY && pt.MA_CAPDA != "03" && pt.MA_CAPDA != "08" && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S" select new { pt.TOA_DO, pt.TEN_PTDIEN };
                            listSearchten = new List<string>();
                            if (d.Count() != 0)
                            {

                                geo.Read(new System.IO.BinaryReader(
                               new System.IO.MemoryStream(
                               d.FirstOrDefault().TOA_DO.ToArray()
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
                            var d = from pt in data.M_VITRI_V2s where pt.TEN_PTDIEN.Contains(ten) && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S" select new { pt.TOA_DO, pt.TEN_PTDIEN };
                            foreach (var item in d)
                            {
                                if (item.TOA_DO != null)
                                {
                                    geo.Read(new System.IO.BinaryReader(
                                    new System.IO.MemoryStream(
                                    item.TOA_DO.ToArray()
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
                                var d = from pt in data.M_VITRI_V2s where pt.TEN_PTDIEN.Contains(ten) && pt.MA_DVQLY == DVQLY && pt.MA_CAPDA == dz22 && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S" select new { pt.TOA_DO, pt.TEN_PTDIEN };
                                foreach (var item in d)
                                {
                                    if (item.TOA_DO != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                        new System.IO.MemoryStream(
                                        item.TOA_DO.ToArray()
                                        )));
                                        listSearchtoado.Add(geo.ToString());
                                        listSearchten.Add(item.TEN_PTDIEN);
                                    }
                                }
                            }
                            if (dz22 == "" && dz35 != "")
                            {
                                var d = from pt in data.M_VITRI_V2s where pt.TEN_PTDIEN.Contains(ten) && pt.MA_DVQLY == DVQLY && pt.MA_CAPDA == dz35 && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S" select new { pt.TOA_DO, pt.TEN_PTDIEN };
                                foreach (var item in d)
                                {
                                    if (item.TOA_DO != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                        new System.IO.MemoryStream(
                                        item.TOA_DO.ToArray()
                                        )));
                                        listSearchtoado.Add(geo.ToString());
                                        listSearchten.Add(item.TEN_PTDIEN);
                                    }
                                }
                            }
                            if (dz22 != "" && dz35 != "")
                            {
                                var d = from pt in data.M_VITRI_V2s where pt.TEN_PTDIEN.Contains(ten) && pt.MA_DVQLY == DVQLY && pt.MA_CAPDA != "03" && pt.MA_CAPDA != "08" && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" && pt.LOAI_PTDIEN != "VS" && pt.LOAI_PTDIEN != "1S" select new { pt.TOA_DO, pt.TEN_PTDIEN };
                                foreach (var item in d)
                                {
                                    if (item.TOA_DO != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                        new System.IO.MemoryStream(
                                        item.TOA_DO.ToArray()
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
        public System.Windows.Forms.AutoCompleteStringCollection supportSearch(string ten, string DVQLY)
        {
            System.Windows.Forms.AutoCompleteStringCollection lst = new System.Windows.Forms.AutoCompleteStringCollection();
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                var d = from pt in data.M_VITRI_V2s where pt.TEN_PTDIEN.Contains(ten) && pt.MA_DVQLY == DVQLY && pt.MA_CAPDA != "03" && pt.MA_CAPDA != "08" && pt.LOAI_PTDIEN != "DZ" && pt.LOAI_PTDIEN != "LT" select new { pt.TEN_PTDIEN };
                foreach (var item in d)
                {
                    lst.Add(item.TEN_PTDIEN);
                }
                return lst;
            }
        }
        public void updateTrangthai(string id, string ql, string trangthai)
        {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                M_TTHAI_PTDIEN TTHai = data.M_TTHAI_PTDIENs.Single(o => o.ID_PTDIEN == int.Parse(id) && o.MA_DVQLY == ql);
                TTHai.ID_PTDIEN = int.Parse(id);
                TTHai.TRANG_THAI = int.Parse(trangthai);
                TTHai.THOI_DIEM = getDateServer();
                data.SubmitChanges();
                System.Windows.Forms.MessageBox.Show("Cập nhật trạng thái thành công");
            }
        }
        public void insertTrangthai(string id, string ql, string trangthai, string userName)
        {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                M_TTHAI_PTDIEN TTHai = new M_TTHAI_PTDIEN();
                TTHai.ID_PTDIEN = int.Parse(id);
                TTHai.MA_DVQLY = ql;
                TTHai.TRANG_THAI = int.Parse(trangthai);
                TTHai.THOI_DIEM = getDateServer();
                TTHai.UserName = userName;
                data.M_TTHAI_PTDIENs.InsertOnSubmit(TTHai);
                data.SubmitChanges();
            }
        }
        public void insertTrangthai_VM(string id, string ql, string trangthai, string userName)
        {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                M_TTHAI_PTDIEN_VM TTHai = new M_TTHAI_PTDIEN_VM();
                TTHai.ID_PTDIEN = int.Parse(id);
                TTHai.MA_DVQLY = ql;
                TTHai.TRANG_THAI = int.Parse(trangthai);
                TTHai.THOI_DIEM = getDateServer();
                TTHai.UserName = userName;
                data.M_TTHAI_PTDIEN_VMs.InsertOnSubmit(TTHai);
                data.SubmitChanges();
            }
        }
        public void insertTrangThaiTableCmis(string id, string tagName, bool trangthai)
        {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                M_TTHAI_PTDIEN_CMI TThai = new M_TTHAI_PTDIEN_CMI();
                TThai.ID_PTDIEN = int.Parse(id);
                TThai.TagName = tagName;
                TThai.Value = trangthai;
                TThai.TimeStamp = getDateServer();
                data.M_TTHAI_PTDIEN_CMIs.InsertOnSubmit(TThai);
                data.SubmitChanges();
            }
        }
        public DateTime getDateServer()
        {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                return data.GetServerDate();
            }
        }
        public List<D_DVI_QLY> loadComboDonvi(string donvi)
        {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                if (donvi == "PN")
                {
                    var d = from dv in data.D_DVI_QLies select dv;
                    return d.ToList();
                }
                else
                {
                    var d = from dv in data.D_DVI_QLies where dv.MA_DVIQLY == donvi select dv;
                    return d.ToList();
                }
            }
        }
        public string getToaDo(string madv) {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                return data.D_DVI_QLies.Where(p => p.MA_DVIQLY.Equals(madv)).FirstOrDefault().TOA_DO;
            }
        }
        public void searcDuongday(string searchDay, string dvql, int all)
        {
            geo = new SqlGeometry();
            ListsearchDZLine22 = new List<string>();
            ListIDDZ22 = new List<int>();
            ListsearchDZLine35 = new List<string>();
            ListIDDZ35 = new List<int>();
            ListsearchDZPoint0CD = new List<string>();
            ListsearchDZPoint1CD = new List<string>();
            ListsearchDZPoint0TT = new List<string>();
            ListsearchDZPoint1TT = new List<string>();
            ListsearchDZPoint1MC = new List<string>();
            ListsearchDZPoint0MC = new List<string>();
            ListsearchDZPoint0TG = new List<string>();
            ListsearchDZPoint1TG = new List<string>();
            ListsearchDZPoint0SI = new List<string>();
            ListsearchDZPoint1SI = new List<string>();
            ListsearchDZPoint0MCDZ = new List<string>();
            ListsearchDZPoint1MCDZ = new List<string>();
            ListSearchNameTBA0 = new List<string>();
            ListSearchNameTBA1 = new List<string>();
            ListSearchNameCD0 = new List<string>();
            ListSearchNameCD1 = new List<string>();
            ListSearchNameMC0 = new List<string>();
            ListSearchNameMC1 = new List<string>();
            ListSearchNameTG0 = new List<string>();
            ListSearchNameTG1 = new List<string>();
            ListSearchNameSI0 = new List<string>();
            ListSearchNameSI1 = new List<string>();
            ListSearchNameMCDZ0 = new List<string>();
            ListSearchNameMCDZ1 = new List<string>();
            ListSearchIDTBA0 = new List<int>();
            ListSearchIDTBA1 = new List<int>();
            ListSearchIDCD0 = new List<int>();
            ListSearchIDCD1 = new List<int>();
            ListSearchIDMC0 = new List<int>();
            ListSearchIDMC1 = new List<int>();
            ListSearchIDTG0 = new List<int>();
            ListSearchIDTG1 = new List<int>();
            ListSearchIDSI0 = new List<int>();
            ListSearchIDSI1 = new List<int>();
            ListSearchIDMCDZ0 = new List<int>();
            ListSearchIDMCDZ1 = new List<int>();
            ListSearchNameDZ22 = new List<string>();
            ListSearchNameDZ35 = new List<string>();
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                if (all == 0)
                {
                    string[] xl = searchDay.Split(',');
                    for (int i = 0; i < xl.Count() - 1; i++)
                    {
                        var d = from vt in data.M_VITRI_V2s where vt.MA_PMIS == xl[i] select vt;
                        //var d1 = from vt in data.M_VITRI_V2s where vt.MA_PMIS == xl[i] select vt;
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {

                                    if (item.LOAI_PTDIEN == "TT")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0TT.Add(geo.ToString());
                                            ListSearchNameTBA0.Add(item.TEN_PTDIEN);
                                            ListSearchIDTBA0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1TT.Add(geo.ToString());
                                            ListSearchNameTBA1.Add(item.TEN_PTDIEN);
                                            ListSearchIDTBA1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "DS")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0CD.Add(geo.ToString());
                                            ListSearchNameCD0.Add(item.TEN_PTDIEN);
                                            ListSearchIDCD0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1CD.Add(geo.ToString());
                                            ListSearchNameCD1.Add(item.TEN_PTDIEN);
                                            ListSearchIDCD1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "CB")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0MC.Add(geo.ToString());
                                            ListSearchNameMC0.Add(item.TEN_PTDIEN);
                                            ListSearchIDMC0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1MC.Add(geo.ToString());
                                            ListSearchNameMC1.Add(item.TEN_PTDIEN);
                                            ListSearchIDMC1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "TG")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0TG.Add(geo.ToString());
                                            ListSearchNameTG0.Add(item.TEN_PTDIEN);
                                            ListSearchIDTG0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1TG.Add(geo.ToString());
                                            ListSearchNameTG1.Add(item.TEN_PTDIEN);
                                            ListSearchIDTG1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "SI")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0SI.Add(geo.ToString());
                                            ListSearchNameSI0.Add(item.TEN_PTDIEN);
                                            ListSearchIDSI0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1SI.Add(geo.ToString());
                                            ListSearchNameSI1.Add(item.TEN_PTDIEN);
                                            ListSearchIDSI1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "MC")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0MCDZ.Add(geo.ToString());
                                            ListSearchNameMCDZ0.Add(item.TEN_PTDIEN);
                                            ListSearchIDMCDZ0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1MCDZ.Add(geo.ToString());
                                            ListSearchNameMCDZ1.Add(item.TEN_PTDIEN);
                                            ListSearchIDMCDZ1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                }
                                else
                                {
                                    if (item.LOAI_PTDIEN=="DZ")
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
                            getSub(item.MA_PMIS);
                        }
                    }
                }
                else
                {
                    if (dvql != "PN")
                    {
                        //var d = from vt in data.M_VITRI_V2s where vt.MA_DVQLY == dvql && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" select vt;
                        List<M_VITRI_V2> d = null;
                        if (all == 1)
                        {
                            d = data.M_VITRI_V2s.Where(vt => vt.MA_DVQLY == dvql && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08").ToList();
                        }
                        if (all == 2)
                        {
                            d = data.M_VITRI_V2s.Where(vt => vt.MA_DVQLY == dvql && vt.MA_CAPDA == "05" && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08").ToList();
                        }
                        if (all == 3)
                        {
                            d = data.M_VITRI_V2s.Where(vt => vt.MA_DVQLY == dvql && vt.MA_CAPDA == "06" && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08").ToList();
                        }
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    if (item.LOAI_PTDIEN == "TT")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0TT.Add(geo.ToString());
                                            ListSearchNameTBA0.Add(item.TEN_PTDIEN);
                                            ListSearchIDTBA0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1TT.Add(geo.ToString());
                                            ListSearchNameTBA1.Add(item.TEN_PTDIEN);
                                            ListSearchIDTBA1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "DS")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0CD.Add(geo.ToString());
                                            ListSearchNameCD0.Add(item.TEN_PTDIEN);
                                            ListSearchIDCD0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1CD.Add(geo.ToString());
                                            ListSearchNameCD1.Add(item.TEN_PTDIEN);
                                            ListSearchIDCD1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "CB")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0MC.Add(geo.ToString());
                                            ListSearchNameMC0.Add(item.TEN_PTDIEN);
                                            ListSearchIDMC0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1MC.Add(geo.ToString());
                                            ListSearchNameMC1.Add(item.TEN_PTDIEN);
                                            ListSearchIDMC1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "TG")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0TG.Add(geo.ToString());
                                            ListSearchNameTG0.Add(item.TEN_PTDIEN);
                                            ListSearchIDTG0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1TG.Add(geo.ToString());
                                            ListSearchNameTG1.Add(item.TEN_PTDIEN);
                                            ListSearchIDTG1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "SI")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0SI.Add(geo.ToString());
                                            ListSearchNameSI0.Add(item.TEN_PTDIEN);
                                            ListSearchIDSI0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1SI.Add(geo.ToString());
                                            ListSearchNameSI1.Add(item.TEN_PTDIEN);
                                            ListSearchIDSI1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "MC")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0MCDZ.Add(geo.ToString());
                                            ListSearchNameMCDZ0.Add(item.TEN_PTDIEN);
                                            ListSearchIDMCDZ0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1MCDZ.Add(geo.ToString());
                                            ListSearchNameMCDZ1.Add(item.TEN_PTDIEN);
                                            ListSearchIDMCDZ1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                }
                                else
                                {
                                    if (item.LOAI_PTDIEN=="DZ")
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
                    else
                    {
                        //var d = from vt in data.M_VITRI_V2s where vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" select vt;
                        List<M_VITRI_V2> d = null;
                        if (all == 1)
                        {
                            d = data.M_VITRI_V2s.Where(vt => vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08").ToList();
                        }
                        if (all == 2)
                        {
                            d = data.M_VITRI_V2s.Where(vt => vt.MA_CAPDA == "05" && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08").ToList();
                        }
                        if (all == 3)
                        {
                            d = data.M_VITRI_V2s.Where(vt => vt.MA_CAPDA == "06" && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08").ToList();
                        }
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {

                                    if (item.LOAI_PTDIEN == "TT")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0TT.Add(geo.ToString());
                                            ListSearchNameTBA0.Add(item.TEN_PTDIEN);
                                            ListSearchIDTBA0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1TT.Add(geo.ToString());
                                            ListSearchNameTBA1.Add(item.TEN_PTDIEN);
                                            ListSearchIDTBA1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "DS")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0CD.Add(geo.ToString());
                                            ListSearchNameCD0.Add(item.TEN_PTDIEN);
                                            ListSearchIDCD0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1CD.Add(geo.ToString());
                                            ListSearchNameCD1.Add(item.TEN_PTDIEN);
                                            ListSearchIDCD1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "CB")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0MC.Add(geo.ToString());
                                            ListSearchNameMC0.Add(item.TEN_PTDIEN);
                                            ListSearchIDMC0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1MC.Add(geo.ToString());
                                            ListSearchNameMC1.Add(item.TEN_PTDIEN);
                                            ListSearchIDMC1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "TG")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0TG.Add(geo.ToString());
                                            ListSearchNameTG0.Add(item.TEN_PTDIEN);
                                            ListSearchIDTG0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1TG.Add(geo.ToString());
                                            ListSearchNameTG1.Add(item.TEN_PTDIEN);
                                            ListSearchIDTG1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "SI")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0SI.Add(geo.ToString());
                                            ListSearchNameSI0.Add(item.TEN_PTDIEN);
                                            ListSearchIDSI0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1SI.Add(geo.ToString());
                                            ListSearchNameSI1.Add(item.TEN_PTDIEN);
                                            ListSearchIDSI1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "MC")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0MCDZ.Add(geo.ToString());
                                            ListSearchNameMCDZ0.Add(item.TEN_PTDIEN);
                                            ListSearchIDMCDZ0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1MCDZ.Add(geo.ToString());
                                            ListSearchNameMCDZ1.Add(item.TEN_PTDIEN);
                                            ListSearchIDMCDZ1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                }
                                else
                                {
                                    if (item.LOAI_PTDIEN=="DZ")
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

                }
            }
        }
        public void searcDuongday_LS(string searchDay, string dvql, int all,DateTime timeBegin,DateTime timeEnd)
        {
            geo = new SqlGeometry();
            listLS0 = new List<string>();
            listLS1 = new List<string>();
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                if (all == 0)
                {
                    string[] xl = searchDay.Split(',');
                    for (int i = 0; i < xl.Count() - 1; i++)
                    {
                        var d = from vt in data.M_VITRI_V5_ALL_TTs where vt.MA_PMIS == xl[i] && vt.THOI_DIEM>=timeBegin && vt.THOI_DIEM<=timeEnd orderby vt.THOI_DIEM descending select vt;
                        //var d1 = from vt in data.M_VITRI_V2s where vt.MA_PMIS == xl[i] select vt;
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    if (item.TRANG_THAI == 0)
                                    {
                                        listLS0.Add(geo.ToString());
                                    }
                                    else
                                    {
                                        listLS1.Add(geo.ToString());
                                    }
                                        
                                }
                            }
                            getSub(item.MA_PMIS);
                        }
                    }
                }
                else
                {
                    if (dvql != "PN")
                    {
                        //var d = from vt in data.M_VITRI_V2s where vt.MA_DVQLY == dvql && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" select vt;
                        List<M_VITRI_V5_ALL_TT> d = null;
                        if (all == 1)
                        {
                            d = data.M_VITRI_V5_ALL_TTs.Where(vt => vt.MA_DVQLY == dvql && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.THOI_DIEM >= timeBegin && vt.THOI_DIEM <= timeEnd).Distinct().OrderByDescending(vt => vt.ID_PTDIEN).ToList();
                        }
                        if (all == 2)
                        {
                            d = data.M_VITRI_V5_ALL_TTs.Where(vt => vt.MA_DVQLY == dvql && vt.MA_CAPDA == "05" && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.THOI_DIEM >= timeBegin && vt.THOI_DIEM <= timeEnd).Distinct().OrderByDescending(vt => vt.ID_PTDIEN).ToList();
                        }
                        if (all == 3)
                        {
                            d = data.M_VITRI_V5_ALL_TTs.Where(vt => vt.MA_DVQLY == dvql && vt.MA_CAPDA == "06" && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.THOI_DIEM >= timeBegin && vt.THOI_DIEM <= timeEnd).Distinct().OrderByDescending(vt => vt.ID_PTDIEN).ToList(); ;
                        }
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    if (item.TRANG_THAI == 0)
                                    {
                                        listLS0.Add(geo.ToString());
                                    }
                                    else
                                    {
                                        listLS1.Add(geo.ToString());
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //var d = from vt in data.M_VITRI_V2s where vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" select vt;
                        List<M_VITRI_V5_ALL_TT> d = null;
                        if (all == 1)
                        {
                            d = data.M_VITRI_V5_ALL_TTs.Where(vt => vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.THOI_DIEM >= timeBegin && vt.THOI_DIEM <= timeEnd).Distinct().OrderByDescending(vt => vt.ID_PTDIEN).ToList(); ;
                        }
                        if (all == 2)
                        {
                            d = data.M_VITRI_V5_ALL_TTs.Where(vt => vt.MA_CAPDA == "05" && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.THOI_DIEM >= timeBegin && vt.THOI_DIEM <= timeEnd).Distinct().OrderByDescending(vt => vt.ID_PTDIEN).ToList(); ;
                        }
                        if (all == 3)
                        {
                            d = data.M_VITRI_V5_ALL_TTs.Where(vt => vt.MA_CAPDA == "06" && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.THOI_DIEM >= timeBegin && vt.THOI_DIEM <= timeEnd).Distinct().OrderByDescending(vt => vt.ID_PTDIEN).ToList(); ;
                        }
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    if (item.TRANG_THAI == 0)
                                    {
                                        listLS0.Add(geo.ToString());
                                    }
                                    else
                                    {
                                        listLS1.Add(geo.ToString());
                                    }

                                }
                                
                            }
                        }
                    }

                }
            }
        }
        public void searcDuongday_VM(string searchDay, string dvql, int all)
        {
            geo = new SqlGeometry();
            ListsearchDZLine22 = new List<string>();
            ListIDDZ22 = new List<int>();
            ListsearchDZLine35 = new List<string>();
            ListIDDZ35 = new List<int>();
            ListsearchDZPoint0CD = new List<string>();
            ListsearchDZPoint1CD = new List<string>();
            ListsearchDZPoint0TT = new List<string>();
            ListsearchDZPoint1TT = new List<string>();
            ListsearchDZPoint1MC = new List<string>();
            ListsearchDZPoint0MC = new List<string>();
            ListsearchDZPoint0TG = new List<string>();
            ListsearchDZPoint1TG = new List<string>();
            ListsearchDZPoint0SI = new List<string>();
            ListsearchDZPoint1SI = new List<string>();
            ListsearchDZPoint0MCDZ = new List<string>();
            ListsearchDZPoint1MCDZ = new List<string>();
            ListSearchNameTBA0 = new List<string>();
            ListSearchNameTBA1 = new List<string>();
            ListSearchNameCD0 = new List<string>();
            ListSearchNameCD1 = new List<string>();
            ListSearchNameMC0 = new List<string>();
            ListSearchNameMC1 = new List<string>();
            ListSearchNameTG0 = new List<string>();
            ListSearchNameTG1 = new List<string>();
            ListSearchNameSI0 = new List<string>();
            ListSearchNameSI1 = new List<string>();
            ListSearchNameMCDZ0 = new List<string>();
            ListSearchNameMCDZ1 = new List<string>();
            ListSearchIDTBA0 = new List<int>();
            ListSearchIDTBA1 = new List<int>();
            ListSearchIDCD0 = new List<int>();
            ListSearchIDCD1 = new List<int>();
            ListSearchIDMC0 = new List<int>();
            ListSearchIDMC1 = new List<int>();
            ListSearchIDTG0 = new List<int>();
            ListSearchIDTG1 = new List<int>();
            ListSearchIDSI0 = new List<int>();
            ListSearchIDSI1 = new List<int>();
            ListSearchIDMCDZ0 = new List<int>();
            ListSearchIDMCDZ1 = new List<int>();
            ListSearchNameDZ22 = new List<string>();
            ListSearchNameDZ35 = new List<string>();
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                if (all == 0)
                {
                    string[] xl = searchDay.Split(',');
                    for (int i = 0; i < xl.Count() - 1; i++)
                    {
                        var d = from vt in data.M_VITRI_V2_VMs where vt.MA_PMIS == xl[i] select vt;
                        //var d1 = from vt in data.M_VITRI_V2s where vt.MA_PMIS == xl[i] select vt;
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {

                                    if (item.LOAI_PTDIEN == "TT")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0TT.Add(geo.ToString());
                                            ListSearchNameTBA0.Add(item.TEN_PTDIEN);
                                            ListSearchIDTBA0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1TT.Add(geo.ToString());
                                            ListSearchNameTBA1.Add(item.TEN_PTDIEN);
                                            ListSearchIDTBA1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "DS")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0CD.Add(geo.ToString());
                                            ListSearchNameCD0.Add(item.TEN_PTDIEN);
                                            ListSearchIDCD0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1CD.Add(geo.ToString());
                                            ListSearchNameCD1.Add(item.TEN_PTDIEN);
                                            ListSearchIDCD1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "CB")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0MC.Add(geo.ToString());
                                            ListSearchNameMC0.Add(item.TEN_PTDIEN);
                                            ListSearchIDMC0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1MC.Add(geo.ToString());
                                            ListSearchNameMC1.Add(item.TEN_PTDIEN);
                                            ListSearchIDMC1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "TG")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0TG.Add(geo.ToString());
                                            ListSearchNameTG0.Add(item.TEN_PTDIEN);
                                            ListSearchIDTG0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1TG.Add(geo.ToString());
                                            ListSearchNameTG1.Add(item.TEN_PTDIEN);
                                            ListSearchIDTG1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "SI")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0SI.Add(geo.ToString());
                                            ListSearchNameSI0.Add(item.TEN_PTDIEN);
                                            ListSearchIDSI0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1SI.Add(geo.ToString());
                                            ListSearchNameSI1.Add(item.TEN_PTDIEN);
                                            ListSearchIDSI1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "MC")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0MCDZ.Add(geo.ToString());
                                            ListSearchNameMCDZ0.Add(item.TEN_PTDIEN);
                                            ListSearchIDMCDZ0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1MCDZ.Add(geo.ToString());
                                            ListSearchNameMCDZ1.Add(item.TEN_PTDIEN);
                                            ListSearchIDMCDZ1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                }
                                else
                                {
                                    if (item.LOAI_PTDIEN=="DZ")
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
                            getSub(item.MA_PMIS);
                        }
                    }
                }
                else
                {
                    if (dvql != "PN")
                    {
                        //var d = from vt in data.M_VITRI_V2s where vt.MA_DVQLY == dvql && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" select vt;
                        List<M_VITRI_V2_VM> d = null;
                        if (all == 1)
                        {
                            d = data.M_VITRI_V2_VMs.Where(vt => vt.MA_DVQLY == dvql && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08").ToList();
                        }
                        if (all == 2)
                        {
                            d = data.M_VITRI_V2_VMs.Where(vt => vt.MA_DVQLY == dvql && vt.MA_CAPDA == "05" && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08").ToList();
                        }
                        if (all == 3)
                        {
                            d = data.M_VITRI_V2_VMs.Where(vt => vt.MA_DVQLY == dvql && vt.MA_CAPDA == "06" && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08").ToList();
                        }
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {
                                    if (item.LOAI_PTDIEN == "TT")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0TT.Add(geo.ToString());
                                            ListSearchNameTBA0.Add(item.TEN_PTDIEN);
                                            ListSearchIDTBA0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1TT.Add(geo.ToString());
                                            ListSearchNameTBA1.Add(item.TEN_PTDIEN);
                                            ListSearchIDTBA1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "DS")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0CD.Add(geo.ToString());
                                            ListSearchNameCD0.Add(item.TEN_PTDIEN);
                                            ListSearchIDCD0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1CD.Add(geo.ToString());
                                            ListSearchNameCD1.Add(item.TEN_PTDIEN);
                                            ListSearchIDCD1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "CB")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0MC.Add(geo.ToString());
                                            ListSearchNameMC0.Add(item.TEN_PTDIEN);
                                            ListSearchIDMC0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1MC.Add(geo.ToString());
                                            ListSearchNameMC1.Add(item.TEN_PTDIEN);
                                            ListSearchIDMC1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "TG")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0TG.Add(geo.ToString());
                                            ListSearchNameTG0.Add(item.TEN_PTDIEN);
                                            ListSearchIDTG0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1TG.Add(geo.ToString());
                                            ListSearchNameTG1.Add(item.TEN_PTDIEN);
                                            ListSearchIDTG1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "SI")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0SI.Add(geo.ToString());
                                            ListSearchNameSI0.Add(item.TEN_PTDIEN);
                                            ListSearchIDSI0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1SI.Add(geo.ToString());
                                            ListSearchNameSI1.Add(item.TEN_PTDIEN);
                                            ListSearchIDSI1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "MC")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0MCDZ.Add(geo.ToString());
                                            ListSearchNameMCDZ0.Add(item.TEN_PTDIEN);
                                            ListSearchIDMCDZ0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1MCDZ.Add(geo.ToString());
                                            ListSearchNameMCDZ1.Add(item.TEN_PTDIEN);
                                            ListSearchIDMCDZ1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                }
                                else
                                {
                                    if (item.LOAI_PTDIEN=="DZ")
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
                    else
                    {
                        var d = from vt in data.M_VITRI_V2_VMs where vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" select vt;
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null)
                            {
                                geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                                if (geo.ToString().Contains("POINT"))
                                {

                                    if (item.LOAI_PTDIEN == "TT")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0TT.Add(geo.ToString());
                                            ListSearchNameTBA0.Add(item.TEN_PTDIEN);
                                            ListSearchIDTBA0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1TT.Add(geo.ToString());
                                            ListSearchNameTBA1.Add(item.TEN_PTDIEN);
                                            ListSearchIDTBA1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "DS")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0CD.Add(geo.ToString());
                                            ListSearchNameCD0.Add(item.TEN_PTDIEN);
                                            ListSearchIDCD0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1CD.Add(geo.ToString());
                                            ListSearchNameCD1.Add(item.TEN_PTDIEN);
                                            ListSearchIDCD1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "CB")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0MC.Add(geo.ToString());
                                            ListSearchNameMC0.Add(item.TEN_PTDIEN);
                                            ListSearchIDMC0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1MC.Add(geo.ToString());
                                            ListSearchNameMC1.Add(item.TEN_PTDIEN);
                                            ListSearchIDMC1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "TG")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0TG.Add(geo.ToString());
                                            ListSearchNameTG0.Add(item.TEN_PTDIEN);
                                            ListSearchIDTG0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1TG.Add(geo.ToString());
                                            ListSearchNameTG1.Add(item.TEN_PTDIEN);
                                            ListSearchIDTG1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "SI")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0SI.Add(geo.ToString());
                                            ListSearchNameSI0.Add(item.TEN_PTDIEN);
                                            ListSearchIDSI0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1SI.Add(geo.ToString());
                                            ListSearchNameSI1.Add(item.TEN_PTDIEN);
                                            ListSearchIDSI1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                    if (item.LOAI_PTDIEN == "MC")
                                    {
                                        if (item.TRANG_THAI == 0)
                                        {
                                            ListsearchDZPoint0MCDZ.Add(geo.ToString());
                                            ListSearchNameMCDZ0.Add(item.TEN_PTDIEN);
                                            ListSearchIDMCDZ0.Add(item.ID_PTDIEN);
                                        }
                                        else
                                        {
                                            ListsearchDZPoint1MCDZ.Add(geo.ToString());
                                            ListSearchNameMCDZ1.Add(item.TEN_PTDIEN);
                                            ListSearchIDMCDZ1.Add(item.ID_PTDIEN);
                                        }
                                    }
                                }
                                else
                                {
                                    if (item.LOAI_PTDIEN=="DZ")
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

                }
            }
        }
        public void getSub(string _MaCha)
        {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                var d = from vt in data.M_VITRI_V2s where vt.MA_PMISCHA == _MaCha select vt;
                foreach (var item in d)
                {
                    if (item.TOA_DO != null)
                    {
                        geo.Read(new System.IO.BinaryReader(
                        new System.IO.MemoryStream(
                        item.TOA_DO.ToArray()
                        )));
                        if (geo.ToString().Contains("POINT"))
                        {

                            if (item.LOAI_PTDIEN == "TT")
                            {
                                if (item.TRANG_THAI == 0)
                                {
                                    ListsearchDZPoint0TT.Add(geo.ToString());
                                    ListSearchNameTBA0.Add(item.TEN_PTDIEN);
                                    ListSearchIDTBA0.Add(item.ID_PTDIEN);
                                }
                                else
                                {
                                    ListsearchDZPoint1TT.Add(geo.ToString());
                                    ListSearchNameTBA1.Add(item.TEN_PTDIEN);
                                    ListSearchIDTBA1.Add(item.ID_PTDIEN);
                                }
                            }
                            if (item.LOAI_PTDIEN == "DS")
                            {
                                if (item.TRANG_THAI == 0)
                                {
                                    ListsearchDZPoint0CD.Add(geo.ToString());
                                    ListSearchNameCD0.Add(item.TEN_PTDIEN);
                                    ListSearchIDCD0.Add(item.ID_PTDIEN);
                                }
                                else
                                {
                                    ListsearchDZPoint1CD.Add(geo.ToString());
                                    ListSearchNameCD1.Add(item.TEN_PTDIEN);
                                    ListSearchIDCD1.Add(item.ID_PTDIEN);
                                }
                            }
                            if (item.LOAI_PTDIEN == "CB")
                            {
                                if (item.TRANG_THAI == 0)
                                {
                                    ListsearchDZPoint0MC.Add(geo.ToString());
                                    ListSearchNameMC0.Add(item.TEN_PTDIEN);
                                    ListSearchIDMC0.Add(item.ID_PTDIEN);
                                }
                                else
                                {
                                    ListsearchDZPoint1MC.Add(geo.ToString());
                                    ListSearchNameMC1.Add(item.TEN_PTDIEN);
                                    ListSearchIDMC1.Add(item.ID_PTDIEN);
                                }
                            }
                            if (item.LOAI_PTDIEN == "TG")
                            {
                                if (item.TRANG_THAI == 0)
                                {
                                    ListsearchDZPoint0TG.Add(geo.ToString());
                                    ListSearchNameTG0.Add(item.TEN_PTDIEN);
                                    ListSearchIDTG0.Add(item.ID_PTDIEN);
                                }
                                else
                                {
                                    ListsearchDZPoint1TG.Add(geo.ToString());
                                    ListSearchNameTG1.Add(item.TEN_PTDIEN);
                                    ListSearchIDTG1.Add(item.ID_PTDIEN);
                                }
                            }
                            if (item.LOAI_PTDIEN == "SI")
                            {
                                if (item.TRANG_THAI == 0)
                                {
                                    ListsearchDZPoint0SI.Add(geo.ToString());
                                    ListSearchNameSI0.Add(item.TEN_PTDIEN);
                                    ListSearchIDSI0.Add(item.ID_PTDIEN);
                                }
                                else
                                {
                                    ListsearchDZPoint1SI.Add(geo.ToString());
                                    ListSearchNameSI1.Add(item.TEN_PTDIEN);
                                    ListSearchIDSI1.Add(item.ID_PTDIEN);
                                }
                            }
                            if (item.LOAI_PTDIEN == "MC")
                            {
                                if (item.TRANG_THAI == 0)
                                {
                                    ListsearchDZPoint0MCDZ.Add(geo.ToString());
                                    ListSearchNameMCDZ0.Add(item.TEN_PTDIEN);
                                    ListSearchIDMCDZ0.Add(item.ID_PTDIEN);
                                }
                                else
                                {
                                    ListsearchDZPoint1MCDZ.Add(geo.ToString());
                                    ListSearchNameMCDZ1.Add(item.TEN_PTDIEN);
                                    ListSearchIDMCDZ1.Add(item.ID_PTDIEN);
                                }
                            }
                        }
                        else
                        {
                            if (item.LOAI_PTDIEN=="DZ")
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
                    getSub(item.MA_PMIS);
                }

            }
        }
        public void addRemoveList(string loaiTB, int i)
        {
            if (loaiTB == "TT0")
            {
                ListsearchDZPoint1TT.Add(ListsearchDZPoint0TT.ElementAt(i));
                ListSearchNameTBA1.Add(ListSearchNameTBA0.ElementAt(i));
                ListSearchIDTBA1.Add(ListSearchIDTBA0.ElementAt(i));
                ListsearchDZPoint0TT.RemoveAt(i);
                ListSearchNameTBA0.RemoveAt(i);
                ListSearchIDTBA0.RemoveAt(i);
            }
            if (loaiTB == "TT1")
            {
                ListsearchDZPoint0TT.Add(ListsearchDZPoint1TT.ElementAt(i));
                ListSearchNameTBA0.Add(ListSearchNameTBA1.ElementAt(i));
                ListSearchIDTBA0.Add(ListSearchIDTBA1.ElementAt(i));
                ListsearchDZPoint1TT.RemoveAt(i);
                ListSearchNameTBA1.RemoveAt(i);
                ListSearchIDTBA1.RemoveAt(i);
            }
            if (loaiTB == "DS0")
            {
                ListsearchDZPoint1CD.Add(ListsearchDZPoint0CD.ElementAt(i));
                ListSearchNameCD1.Add(ListSearchNameCD0.ElementAt(i));
                ListSearchIDCD1.Add(ListSearchIDCD0.ElementAt(i));
                ListsearchDZPoint0CD.RemoveAt(i);
                ListSearchNameCD0.RemoveAt(i);
                ListSearchIDCD0.RemoveAt(i);
            }
            if (loaiTB == "DS1")
            {
                ListsearchDZPoint0CD.Add(ListsearchDZPoint1CD.ElementAt(i));
                ListSearchNameCD0.Add(ListSearchNameCD1.ElementAt(i));
                ListSearchIDCD0.Add(ListSearchIDCD1.ElementAt(i));
                ListsearchDZPoint1CD.RemoveAt(i);
                ListSearchNameCD1.RemoveAt(i);
                ListSearchIDCD1.RemoveAt(i);
            }
            if (loaiTB == "CB0")
            {
                ListsearchDZPoint1MC.Add(ListsearchDZPoint0MC.ElementAt(i));
                ListSearchNameMC1.Add(ListSearchNameMC0.ElementAt(i));
                ListSearchIDMC1.Add(ListSearchIDMC0.ElementAt(i));
                ListsearchDZPoint0MC.RemoveAt(i);
                ListSearchNameMC0.RemoveAt(i);
                ListSearchIDMC0.RemoveAt(i);
            }
            if (loaiTB == "CB1")
            {
                ListsearchDZPoint0MC.Add(ListsearchDZPoint1MC.ElementAt(i));
                ListSearchNameMC0.Add(ListSearchNameMC1.ElementAt(i));
                ListSearchIDMC0.Add(ListSearchIDMC1.ElementAt(i));
                ListsearchDZPoint1MC.RemoveAt(i);
                ListSearchNameMC1.RemoveAt(i);
                ListSearchIDMC1.RemoveAt(i);
            }
            if (loaiTB == "TG0")
            {
                ListsearchDZPoint1TG.Add(ListsearchDZPoint0TG.ElementAt(i));
                ListSearchNameTG1.Add(ListSearchNameTG0.ElementAt(i));
                ListSearchIDTG1.Add(ListSearchIDTG0.ElementAt(i));
                ListsearchDZPoint0TG.RemoveAt(i);
                ListSearchNameTG0.RemoveAt(i);
                ListSearchIDTG0.RemoveAt(i);
            }
            if (loaiTB == "TG1")
            {
                ListsearchDZPoint0TG.Add(ListsearchDZPoint1TG.ElementAt(i));
                ListSearchNameTG0.Add(ListSearchNameTG1.ElementAt(i));
                ListSearchIDTG0.Add(ListSearchIDTG1.ElementAt(i));
                ListsearchDZPoint1TG.RemoveAt(i);
                ListSearchNameTG1.RemoveAt(i);
                ListSearchIDTG1.RemoveAt(i);
            }
            if (loaiTB == "SI0")
            {
                ListsearchDZPoint1SI.Add(ListsearchDZPoint0SI.ElementAt(i));
                ListSearchNameSI1.Add(ListSearchNameSI0.ElementAt(i));
                ListSearchIDSI1.Add(ListSearchIDSI0.ElementAt(i));
                ListsearchDZPoint0SI.RemoveAt(i);
                ListSearchNameSI0.RemoveAt(i);
                ListSearchIDSI0.RemoveAt(i);
            }
            if (loaiTB == "SI1")
            {
                ListsearchDZPoint0SI.Add(ListsearchDZPoint1SI.ElementAt(i));
                ListSearchNameSI0.Add(ListSearchNameSI1.ElementAt(i));
                ListSearchIDSI0.Add(ListSearchIDSI1.ElementAt(i));
                ListsearchDZPoint1SI.RemoveAt(i);
                ListSearchNameSI1.RemoveAt(i);
                ListSearchIDSI1.RemoveAt(i);
            }
            if (loaiTB == "MCDZ0")
            {
                ListsearchDZPoint1MCDZ.Add(ListsearchDZPoint0MCDZ.ElementAt(i));
                ListSearchNameMCDZ1.Add(ListSearchNameMCDZ0.ElementAt(i));
                ListSearchIDMCDZ1.Add(ListSearchIDMCDZ0.ElementAt(i));
                ListsearchDZPoint0MCDZ.RemoveAt(i);
                ListSearchNameMCDZ0.RemoveAt(i);
                ListSearchIDMCDZ0.RemoveAt(i);
            }
            if (loaiTB == "MCDZ1")
            {
                ListsearchDZPoint0MCDZ.Add(ListsearchDZPoint1MCDZ.ElementAt(i));
                ListSearchNameMCDZ0.Add(ListSearchNameMCDZ1.ElementAt(i));
                ListSearchIDMCDZ0.Add(ListSearchIDMCDZ1.ElementAt(i));
                ListsearchDZPoint1MCDZ.RemoveAt(i);
                ListSearchNameMCDZ1.RemoveAt(i);
                ListSearchIDMCDZ1.RemoveAt(i);
            }
        }

        public List<string> getPMISCHA(string DVQL, string dz22, string dz35)
        {
            listMaPmis = new List<string>();
            List<string> tenPTDIEN = new List<string>();
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                if (dz22 != "" && dz35 == "")
                {
                    var d = from v in data.D_PTDIENs where v.MA_CAPDA == dz22 && v.MA_PMISCHA.Equals(DVQL) select v;
                    foreach (var item in d)
                    {
                        tenPTDIEN.Add(item.TEN_PTDIEN);
                        listMaPmis.Add(item.MA_PMIS);
                    }
                }
                if (dz22 == "" && dz35 != "")
                {
                    var d = from v in data.D_PTDIENs where v.MA_CAPDA == dz35 && v.MA_PMISCHA.Equals(DVQL) select v;
                    foreach (var item in d)
                    {
                        tenPTDIEN.Add(item.TEN_PTDIEN);
                        listMaPmis.Add(item.MA_PMIS);
                    }
                }
                if (dz22 != "" && dz35 != "")
                {
                    var d = from v in data.D_PTDIENs where v.MA_CAPDA != "08" && v.MA_CAPDA != "03" && v.MA_PMISCHA.Equals(DVQL) select v;
                    foreach (var item in d)
                    {
                        tenPTDIEN.Add(item.TEN_PTDIEN);
                        listMaPmis.Add(item.MA_PMIS);
                    }
                }
                return tenPTDIEN;


            }
        }
        public List<M_VITRI_V1> getListTramMatDien(string dvql)
        {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                if (dvql != "PN")
                {
                    return data.M_VITRI_V1s.Where(p => p.MA_DVQLY.Equals(dvql) && p.LOAI_PTDIEN.Equals("TT") && !p.MA_CAPDA.Equals("03") && !p.MA_CAPDA.Equals("08") && (p.LEFT_TRANGTHAI == false || p.RIGHT_TRANGTHAI == false)).ToList();
                }
                else
                {
                    return data.M_VITRI_V1s.Where(p => p.LOAI_PTDIEN.Equals("TT") && !p.MA_CAPDA.Equals("03") && !p.MA_CAPDA.Equals("08") && (p.LEFT_TRANGTHAI == false || p.RIGHT_TRANGTHAI == false)).ToList();
                }
            }
        }
        
        public M_TTHAI_PTDIEN_LR getThongTinTram(int id)
        {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                var m = (from p in data.M_TTHAI_PTDIEN_LRs where p.ID_PTDIEN == id orderby p.NGAY_CAP_NHAT descending select p).Skip(0).Take(1);
                return m.FirstOrDefault();
            }
        }
        public string getMaTram(int id) {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                return data.D_PTDIENs.Where(p => p.ID_PTDIEN == id).FirstOrDefault().MA_CMIS;
            }
        }
        public K_THONGSO_V getThongSoTT(string maTram) {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                return data.K_THONGSO_Vs.Where(p => p.MA_TRAM.Equals(maTram)).SingleOrDefault();
            }
        }
        public K_THONGSO_CB_V getThongSoCB(string maTram) {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                return data.K_THONGSO_CB_Vs.Where(p => p.TagName.Equals(maTram)).SingleOrDefault();
            }
        }
        
        
    }
}
