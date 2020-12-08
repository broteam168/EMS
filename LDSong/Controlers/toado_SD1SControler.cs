using LDSong.Models;
using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class toado_SD1SControler
    {
        //public List<int> ListPTDIEN0, ListCD0;//, ListPTDxuly0
       // public List<int> ListPTDIEN1, ListCD1;//,ListPTDxuly1
        //public List<string> ListNameTBA0, ListNameTBA1, ListNameCD0, ListNameCD1;
        public List<int> ListNoteFont,ListNoteID;
        public List<string> ListNotePoint,ListNoteTen;
        public List<string> ListsearchDZLine22, ListsearchDZLine35, ListsearchDZPoint0CDV, ListsearchDZPoint0CDH, ListsearchDZPoint1CDV, ListsearchDZPoint1CDH, ListsearchDZPoint1MCV, ListsearchDZPoint1MCH, ListsearchDZPoint0MCV, ListsearchDZPoint0MCH, ListsearchDZPoint1TGV, ListsearchDZPoint1TGH, ListsearchDZPoint0TGV, ListsearchDZPoint0TGH, ListsearchDZPoint1SIV, ListsearchDZPoint1SIH, ListsearchDZPoint0SIV, ListsearchDZPoint0SIH, ListsearchDZPoint1MCDZV, ListsearchDZPoint1MCDZH, ListsearchDZPoint0MCDZV, ListsearchDZPoint0MCDZH, ListWarning;
        public List<string> ListSearchNameTBA0V, ListSearchNameTBA0H, ListSearchNameTBA1V, ListSearchNameTBA1H, ListSearchNameCD0V, ListSearchNameCD0H, ListSearchNameCD1V, ListSearchNameCD1H, ListSearchNameDZ22, ListSearchNameDZ35, ListSearchNameMC0V, ListSearchNameMC0H, ListSearchNameMC1V, ListSearchNameMC1H, ListSearchNameTG0V, ListSearchNameTG0H, ListSearchNameTG1V, ListSearchNameTG1H, ListSearchNameSI0V, ListSearchNameSI0H, ListSearchNameSI1V, ListSearchNameSI1H, ListSearchNameMCDZ0V, ListSearchNameMCDZ0H, ListSearchNameMCDZ1V, ListSearchNameMCDZ1H;
        public List<int> ListSearchIDTBA0V, ListSearchIDTBA0H, ListSearchIDTBA1V, ListSearchIDTBA1H, ListSearchIDCD0V, ListSearchIDCD0H, ListSearchIDCD1V, ListSearchIDCD1H, ListSearchIDMC1V, ListSearchIDMC1H, ListSearchIDMC0V, ListSearchIDMC0H, ListSearchIDTG1V, ListSearchIDTG1H, ListSearchIDTG0V, ListSearchIDTG0H, ListSearchIDSI1V, ListSearchIDSI1H, ListSearchIDSI0V, ListSearchIDSI0H, ListSearchIDMCDZ1V, ListSearchIDMCDZ1H, ListSearchIDMCDZ0V, ListSearchIDMCDZ0H, ListIDDZ22, ListIDDZ35;
        LDSongDataContext data;
        private SqlGeometry geo;
        public toado_SD1SControler() {
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
        public void getAllTB(string dvql,string macapDa) {
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
            var d = data.M_VITRI_SD1S_V2s.Where(p => p.MA_DVQLY.Equals(dvql) && p.MA_CAPDA.Equals(macapDa)).ToList();
            foreach (var item in d)
            {
                if (item.VITRI != null) {
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
                    }
                }
            }
            
        }
        public void getAllDZ(string dvql,string macapda) {
            SqlGeometry geo = new SqlGeometry();
            ListSearchNameDZ22 = new List<string>();
            ListSearchNameDZ35 = new List<string>();
            ListsearchDZLine22 = new List<string>();
            ListIDDZ22 = new List<int>();
            ListsearchDZLine35 = new List<string>();
            ListIDDZ35 = new List<int>();
            var d = data.M_VITRI_V2s.Where(p => p.MA_DVQLY.Equals(dvql) && p.MA_CAPDA.Equals(macapda)).ToList();
            foreach (var item in d)
            {
                if (item.LOAI_PTDIEN=="1S")
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
        public void getWarning(string dvql, string capDa) {
            geo = new SqlGeometry();
            ListWarning = new List<string>();
            var d = from vt in data.M_VITRI_V1s where vt.MA_DVQLY == dvql && vt.MA_CAPDA == capDa && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "1S" select new { vt.TOA_DO };
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
        public void getNote(string dvql, string capDa)
        {
            geo = new SqlGeometry();
            ListNoteFont = new List<int>();
            ListNoteID = new List<int>();
            ListNotePoint = new List<string>();
            ListNoteTen = new List<string>();
            var d = data.M_NOTE_Vs.Where(p=>p.MA_DVQL.Equals(dvql) && p.MA_CAPDA.Equals(capDa));
            foreach (var item in d)
            {
                if (item.VITRI != null)
                {
                    geo.Read(new System.IO.BinaryReader(
                            new System.IO.MemoryStream(
                            item.VITRI.ToArray()
                            )));
                    ListNotePoint.Add(geo.ToString());
                    ListNoteID.Add(item.ID);
                    ListNoteTen.Add(item.NDGHICHU);
                    ListNoteFont.Add(int.Parse(item.SIZEFONT.ToString()));
                }
            }
        }
        public List<D_DVI_QLY> listDVQL(string dvql) {
            if (!dvql.Equals("PN"))
            {
                return data.D_DVI_QLies.Where(p => p.MA_DVIQLY.Equals(dvql)).ToList();
            }
            else
            {
                return data.D_DVI_QLies.Where(p => !p.MA_DVIQLY.Equals(dvql)).ToList();
            }
        }
    }

}
