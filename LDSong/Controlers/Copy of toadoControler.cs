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
        public List<string> lineString;
        public List<string> point;
        public List<int> ListPTDIEN0, ListPTDxuly0, ListCD0;
        public List<int> ListPTDIEN1, ListPTDxuly1, ListCD1;
        public List<string> ListNameTBA0, ListNameTBA1, ListNameCD0, ListNameCD1;
        public List<string> ListsearchDZLine22, ListsearchDZLine35, ListsearchDZPoint0TT, ListsearchDZPoint1TT, ListsearchDZPoint0CD, ListsearchDZPoint1CD;
        public List<string> ListSearchNameTBA0, ListSearchNameTBA1, ListSearchNameCD0, ListSearchNameCD1;
        public List<int> ListSearchIDTBA0, ListSearchIDTBA1, ListSearchIDCD0, ListSearchIDCD1;
        public List<string> listSearchtoado;
        public List<string> listSearchten;
        public List<string> listMaPmis;
        public List<string> getAllTBA0(string CAPDA, string DVQLY, string loaiTB, int trangthai)
        {
            Binary toado;
            SqlGeometry geo = new SqlGeometry();
            List<string> listtoado = new List<string>();
            ListPTDIEN0 = new List<int>();
            ListNameTBA0 = new List<string>();
            using (LDSongDataContext dataVitri = new LDSongDataContext())
            {
                List<Binary> list = new List<Binary>();
                if (CAPDA == "")
                {
                    if (DVQLY == "")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN,vt.TEN_PTDIEN };
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
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN,vt.TEN_PTDIEN };
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
                    if (DVQLY == "")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA  && vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN,vt.TEN_PTDIEN };
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
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA  && vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN,vt.TEN_PTDIEN };
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
            Binary toado;
            SqlGeometry geo = new SqlGeometry();
            List<string> listtoado = new List<string>();
            ListPTDIEN1 = new List<int>();
            ListNameTBA1 = new List<string>();
            using (LDSongDataContext dataVitri = new LDSongDataContext())
            {
                List<Binary> list = new List<Binary>();
                if (CAPDA == "")
                {
                    if (DVQLY == "")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN ,vt.TEN_PTDIEN};
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
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN,vt.TEN_PTDIEN };
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
                    if (DVQLY == "")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA  && vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN,vt.TEN_PTDIEN};
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
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA && vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN,vt.TEN_PTDIEN };
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
        public List<string> getAllCD0(string CAPDA, string DVQLY, string loaiTB, int trangthai)
        {
            Binary toado;
            SqlGeometry geo = new SqlGeometry();
            List<string> listtoado = new List<string>();
            ListCD0 = new List<int>();
            ListNameCD0 = new List<string>();
            using (LDSongDataContext dataVitri = new LDSongDataContext())
            {
                List<Binary> list = new List<Binary>();
                if (CAPDA == "" )
                {
                    if (DVQLY == "")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN,vt.TEN_PTDIEN };
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
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN,vt.TEN_PTDIEN };
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
                    if (DVQLY == "")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA  && vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN,vt.TEN_PTDIEN };
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
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA && vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN,vt.TEN_PTDIEN };
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
            Binary toado;
            SqlGeometry geo = new SqlGeometry();
            List<string> listtoado = new List<string>();
            ListCD1 = new List<int>();
            ListNameCD1 = new List<string>();
            using (LDSongDataContext dataVitri = new LDSongDataContext())
            {
                List<Binary> list = new List<Binary>();
                if (CAPDA == "" )
                {
                    if (DVQLY == "")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN,vt.TEN_PTDIEN };
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
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN,vt.TEN_PTDIEN };
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
                    if (DVQLY == "")
                    {
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA  && vt.TRANG_THAI == trangthai && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN,vt.TEN_PTDIEN };
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
                        var d = from vt in dataVitri.M_VITRI_V2s where vt.MA_CAPDA == CAPDA  && vt.TRANG_THAI == trangthai && vt.MA_DVQLY == DVQLY && vt.LOAI_PTDIEN == loaiTB select new { vt.TOA_DO, vt.ID_PTDIEN,vt.TEN_PTDIEN };
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
            if (DVQLY == "")
            {
                using (LDSongDataContext dataLine10 = new LDSongDataContext())
                {
                    var d = from vt in dataLine10.M_VITRI_Vs where vt.MA_CAPDA == CAPDA select new { vt.TOA_DO };
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
                using (LDSongDataContext dataLine10 = new LDSongDataContext())
                {
                    var d = from vt in dataLine10.M_VITRI_Vs where vt.MA_CAPDA == CAPDA && vt.MA_DVQLY == DVQLY select new { vt.TOA_DO };
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
        public List<string> getthongtinDiem(string id)
        {
            List<string> inforTram = new List<string>();
            using (LDSongDataContext data = new LDSongDataContext())
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
                return inforTram;

            }
        }
        public string[] searchDiem(string id, string ten, string DVQLY)
        {
            SqlGeometry geo = new SqlGeometry();
            string toado;
            try
            {
                if (DVQLY == "")
                {
                    using (LDSongDataContext data = new LDSongDataContext())
                    {
                        var d = from pt in data.M_VITRI_V2s where pt.ID_PTDIEN == int.Parse(id) select new { pt.TOA_DO,pt.TEN_PTDIEN };
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
                    using (LDSongDataContext data = new LDSongDataContext())
                    {
                        var d = from pt in data.M_VITRI_V2s where pt.ID_PTDIEN == int.Parse(id) && pt.MA_DVQLY == DVQLY select new { pt.TOA_DO, pt.TEN_PTDIEN };
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
            catch (Exception)
            {

                try
                {
                    if (DVQLY == "")
                    {
                        using (LDSongDataContext data = new LDSongDataContext())
                        {
                            listSearchtoado = new List<string>();
                            listSearchten = new List<string>();
                            var d = from pt in data.M_VITRI_V2s where pt.TEN_PTDIEN.Contains(ten) select new { pt.TOA_DO, pt.TEN_PTDIEN };
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
                        using (LDSongDataContext data = new LDSongDataContext())
                        {
                            listSearchtoado = new List<string>();
                            listSearchten = new List<string>();
                            var d = from pt in data.M_VITRI_V2s where pt.TEN_PTDIEN.Contains(ten) && pt.MA_DVQLY == DVQLY select new { pt.TOA_DO, pt.TEN_PTDIEN };
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
                }
                catch (Exception)
                {

                    System.Windows.Forms.MessageBox.Show("Không tìm thấy kết quả nào");
                }
            }
            return null;
        }
        public void updateTrangthai(string id, string ql, string trangthai)
        {
            using (LDSongDataContext data = new LDSongDataContext())
            {
                M_TTHAI_PTDIEN TTHai = data.M_TTHAI_PTDIENs.Single(o => o.ID_PTDIEN == int.Parse(id) && o.MA_DVQLY == ql);
                TTHai.ID_PTDIEN = int.Parse(id);
                TTHai.TRANG_THAI = int.Parse(trangthai);
                TTHai.THOI_DIEM = DateTime.Now;
                data.SubmitChanges();
                System.Windows.Forms.MessageBox.Show("Cập nhật trạng thái thành công");
            }
        }
        public void insertTrangthai(string id, string ql, string trangthai,string userName)
        {
            using (LDSongDataContext data = new LDSongDataContext())
            {
                M_TTHAI_PTDIEN TTHai = new M_TTHAI_PTDIEN();
                TTHai.ID_PTDIEN = int.Parse(id);
                TTHai.MA_DVQLY = ql;
                TTHai.TRANG_THAI = int.Parse(trangthai);
                TTHai.THOI_DIEM = DateTime.Now;
                TTHai.UserName = userName ;
                data.M_TTHAI_PTDIENs.InsertOnSubmit(TTHai);
                data.SubmitChanges();
                System.Windows.Forms.MessageBox.Show("Cập nhật trạng thái thành công");
            }
        }
        public List<D_DVI_QLY> loadComboDonvi(string donvi)
        {
            using (LDSongDataContext data = new LDSongDataContext())
            {
                if (donvi=="PN")
                {
                    var d = from dv in data.D_DVI_QLies select dv;
                    return d.ToList();
                }
                else
                {
                    var d = from dv in data.D_DVI_QLies where dv.MA_DVIQLY==donvi select dv;
                    return d.ToList();
                }
            }
        }
        public void searcDuongday(string searchDay) {
            SqlGeometry geo = new SqlGeometry();
            ListsearchDZLine22 = new List<string>();
            ListsearchDZLine35 = new List<string>();
            ListsearchDZPoint0CD = new List<string>();
            ListsearchDZPoint1CD = new List<string>();
            ListsearchDZPoint0TT = new List<string>();
            ListsearchDZPoint1TT = new List<string>();
            ListSearchNameTBA0 = new List<string>();
            ListSearchNameTBA1 = new List<string>();
            ListSearchNameCD0 = new List<string>();
            ListSearchNameCD1 = new List<string>();
            ListSearchIDTBA0 = new List<int>();
            ListSearchIDTBA1 = new List<int>();
            ListSearchIDCD0 = new List<int>();
            ListSearchIDCD1 = new List<int>();
            using (LDSongDataContext data = new LDSongDataContext())
            {
                string[] xl = searchDay.Split(',');
                for (int i = 0; i < xl.Count()-1; i++)
                {
                    var d = from vt in data.M_VITRI_V2s where vt.MA_PMISCHA == xl[i]  select vt;
                    //var d1 = from vt in data.M_VITRI_V2s where vt.MA_PMIS == xl[i] select vt;
                    foreach (var item in d)
                    {
                        Console.WriteLine("ten" + item.ID_PTDIEN);
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
                                        if (item.TRANG_THAI==1)
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
                                        if (item.TRANG_THAI == 1)
                                        {
                                            ListsearchDZPoint1CD.Add(geo.ToString());
                                            ListSearchNameCD1.Add(item.TEN_PTDIEN);
                                            ListSearchIDCD1.Add(item.ID_PTDIEN);
                                        }
                                    }

                                }
                                if (geo.ToString().Contains("LINESTRING"))
                                {
                                    if (item.MA_CAPDA=="05")
                                    {
                                        ListsearchDZLine22.Add(geo.ToString());
                                    }
                                    if (item.MA_CAPDA == "06")
                                    {
                                        ListsearchDZLine35.Add(geo.ToString());
                                    }
                                }
                                
                            }
                    }
                }
            }
        }

        // code tree day khong dung den
        /*public List<M_VITRI_V2> loadTreeDuongday(string parent, int checkcha)
        {
            using (LDSongDataContext data = new LDSongDataContext())
            {
                if (checkcha==0)
                {
                    var d = from v in data.M_VITRI_V2s where v.MA_PMIS == parent select v;
                    return d.ToList();
                }
                else
                {
                    var d = from v in data.M_VITRI_V2s where v.MA_PMISCHA == parent select v;
                    return d.ToList();
                }
            }
        }
        public List<M_VITRI_V2> loadTreeDuongday1(string parent)
        {
            using (LDSongDataContext data = new LDSongDataContext())
            {
                var d = from v in data.M_VITRI_V2s where v.MA_PMISCHA == parent select v;
                return d.ToList();
            }
        }
        public List<string> getPMISCHA(string DVQL)
        {
            List<string> listPmischa = new List<string>();
            using (LDSongDataContext data = new LDSongDataContext())
            {
                //List<M_VITRI_V> listvitri = new List<M_VITRI_V>();
                //var result = listvitri.Where(p => p.MA_CAPDA != "08" && p.MA_CAPDA != "03").GroupBy(p => p.MA_PMISCHA).Select(p => p.First());
                //return result.ToList();
                if (DVQL=="PN")
                {
                    var d = from v in data.D_PTDIENs where v.MA_CAPDA != "08" && v.MA_CAPDA != "03" group v by v.MA_PMIS into v orderby v.Key select v.FirstOrDefault();
                    foreach (var item in d)
                    {
                        listPmischa.Add(item.MA_PMIS);
                    }
                    return listPmischa;
                }
                else
                {
                    //var d = from v in data.D_PTDIENs where v.MA_CAPDA != "08" && v.MA_CAPDA != "03" && v.MA_DVQLY == DVQL group v by v.MA_PMIS into v orderby v.Key select v.FirstOrDefault();
                    var d = from v in data.D_PTDIENs where v.MA_CAPDA != "08" && v.MA_CAPDA != "03" && v.MA_PMISCHA == DVQL  select v;
                    foreach (var item in d)
                    {
                        listPmischa.Add(item.MA_PMIS); 
                    }
                    return listPmischa;
                }
                
            }
        }*/
        public List<string> getPMISCHA(string DVQL)
        {
            listMaPmis = new List<string>();
            List<string> tenPTDIEN = new List<string>();
            using (LDSongDataContext data = new LDSongDataContext())
            {
                    var d = from v in data.D_PTDIENs where v.MA_CAPDA != "08" && v.MA_CAPDA != "03" && v.MA_PMISCHA == DVQL select v;
                    foreach (var item in d)
                    {
                        tenPTDIEN.Add(item.TEN_PTDIEN);
                        listMaPmis.Add(item.MA_PMIS);
                        /*Console.WriteLine(item.MA_PMIS);
                        var d1 = (from v1 in data.D_PTDIENs where v1.MA_PMISCHA == item.MA_PMIS && v1.LOAI_PTDIEN=="DZ" select new { v1.TEN_PTDIEN}).Distinct();
                        foreach (var item1 in d1)
                        {
                            tenPTDIEN.Add(item1.TEN_PTDIEN);
                        }*/
                    }
                    return tenPTDIEN;
                

            }
        }
    }
}
