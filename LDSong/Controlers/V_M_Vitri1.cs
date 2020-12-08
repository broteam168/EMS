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
    class V_M_Vitri1
    {
        public List<string> ListWarning, ListWarningDZ;
        private SqlGeometry geo;
        public V_M_Vitri1() {
        }
        public void getWarning(string searchDay,string dvql,int all) {
            geo = new SqlGeometry();
            ListWarning = new List<string>();
            using (LDSongDataContext dataVitri = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                if (all==0)
                {
                    string[] xl = searchDay.Split(',');
                    for (int i = 0; i < xl.Count() - 1; i++)
                    {
                        var d = from vt in dataVitri.M_VITRI_V1s where vt.MA_PMIS == xl[i]  select new { vt.TOA_DO, vt.MA_PMIS, vt.RIGHT_TRANGTHAI, vt.LEFT_TRANGTHAI,vt.LOAI_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null && item.RIGHT_TRANGTHAI == false && item.LEFT_TRANGTHAI == false && item.LOAI_PTDIEN != "DZ" && item.LOAI_PTDIEN != "1S")
                            {
                                geo.Read(new System.IO.BinaryReader(
                                        new System.IO.MemoryStream(
                                        item.TOA_DO.ToArray()
                                        )));
                                ListWarning.Add(geo.ToString()); 
                            }
                            getSub(item.MA_PMIS);
                        }
                    }
                }
                else
                {
                    if (dvql!="PN")
                    {
                        if (all==1)
                        {
                            var d = from vt in dataVitri.M_VITRI_V1s where vt.MA_DVQLY == dvql && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                        else
                        {
                            if (all==2)
                            {
                                var d = from vt in dataVitri.M_VITRI_V1s where vt.MA_DVQLY == dvql && vt.MA_CAPDA == "05" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                            else
                            {
                                var d = from vt in dataVitri.M_VITRI_V1s where vt.MA_DVQLY == dvql && vt.MA_CAPDA == "06" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                        }
                    }
                    else
                    {
                        if (all == 1)
                        {
                            var d = from vt in dataVitri.M_VITRI_V1s where vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                        else
                        {
                            if (all ==2)
                            {
                                var d = from vt in dataVitri.M_VITRI_V1s where vt.MA_CAPDA == "05" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                            else
                            {
                                var d = from vt in dataVitri.M_VITRI_V1s where vt.MA_CAPDA == "06" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                        }
                    }
                }
            }
        }
        public void getWarning_LS(string searchDay, string dvql, int all,string timeBegin,string timeEnd)
        {
            geo = new SqlGeometry();
            ListWarning = new List<string>();
            using (LDSongDataContext dataVitri = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                if (all == 0)
                {
                    string[] xl = searchDay.Split(',');
                    for (int i = 0; i < xl.Count() - 1; i++)
                    {
                        var d = from vt in dataVitri.M_VITRI_V5_Alls where vt.MA_PMIS == xl[i] && vt.NGAY_CAP_NHAT>=DateTime.Parse(timeBegin)&&vt.THOIGIANKETTHUC <= DateTime.Parse(timeEnd) select new { vt.TOA_DO, vt.MA_PMIS, vt.RIGHT_TRANGTHAI, vt.LEFT_TRANGTHAI, vt.LOAI_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null && item.RIGHT_TRANGTHAI == false && item.LEFT_TRANGTHAI == false && item.LOAI_PTDIEN != "DZ" && item.LOAI_PTDIEN != "1S")
                            {
                                geo.Read(new System.IO.BinaryReader(
                                        new System.IO.MemoryStream(
                                        item.TOA_DO.ToArray()
                                        )));
                                ListWarning.Add(geo.ToString());
                            }
                            getSub(item.MA_PMIS);
                        }
                    }
                }
                else
                {
                    if (dvql != "PN")
                    {
                        if (all == 1)
                        {
                            var d = from vt in dataVitri.M_VITRI_V5_Alls where vt.MA_DVQLY == dvql && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" && vt.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && vt.THOIGIANKETTHUC <= DateTime.Parse(timeEnd) select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                        else
                        {
                            if (all == 2)
                            {
                                var d = from vt in dataVitri.M_VITRI_V5_Alls where vt.MA_DVQLY == dvql && vt.MA_CAPDA == "05" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" && vt.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && vt.THOIGIANKETTHUC <= DateTime.Parse(timeEnd) select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                            else
                            {
                                var d = from vt in dataVitri.M_VITRI_V5_Alls where vt.MA_DVQLY == dvql && vt.MA_CAPDA == "06" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" && vt.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && vt.THOIGIANKETTHUC <= DateTime.Parse(timeEnd) select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                        }
                    }
                    else
                    {
                        if (all == 1)
                        {
                            var d = from vt in dataVitri.M_VITRI_V5_Alls where vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" && vt.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && vt.THOIGIANKETTHUC <= DateTime.Parse(timeEnd) select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                        else
                        {
                            if (all == 2)
                            {
                                var d = from vt in dataVitri.M_VITRI_V5_Alls where vt.MA_CAPDA == "05" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" && vt.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && vt.THOIGIANKETTHUC <= DateTime.Parse(timeEnd) select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                            else
                            {
                                var d = from vt in dataVitri.M_VITRI_V5_Alls where vt.MA_CAPDA == "06" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" && vt.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && vt.THOIGIANKETTHUC <= DateTime.Parse(timeEnd) select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                        }
                    }
                }
            }
        }
        public void getWarning_VM(string searchDay, string dvql, int all)
        {
            geo = new SqlGeometry();
            ListWarning = new List<string>();
            using (LDSongDataContext dataVitri = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                if (all == 0)
                {
                    string[] xl = searchDay.Split(',');
                    for (int i = 0; i < xl.Count() - 1; i++)
                    {
                        var d = from vt in dataVitri.M_VITRI_V1_VMs where vt.MA_PMIS == xl[i] && vt.LOAI_PTDIEN != "DZ" && vt.LOAI_PTDIEN != "1S" select new { vt.TOA_DO, vt.MA_PMIS, vt.RIGHT_TRANGTHAI, vt.LEFT_TRANGTHAI ,vt.LOAI_PTDIEN};
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null && item.RIGHT_TRANGTHAI == false && item.LEFT_TRANGTHAI == false && item.LOAI_PTDIEN != "DZ" && item.LOAI_PTDIEN != "1S")
                            {
                                geo.Read(new System.IO.BinaryReader(
                                        new System.IO.MemoryStream(
                                        item.TOA_DO.ToArray()
                                        )));
                                ListWarning.Add(geo.ToString());
                            }
                            getSubVM(item.MA_PMIS);
                        }
                    }
                }
                else
                {
                    if (dvql != "PN")
                    {
                        if (all == 1)
                        {
                            var d = from vt in dataVitri.M_VITRI_V1_VMs where vt.MA_DVQLY == dvql && vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                        else
                        {
                            if (all == 2)
                            {
                                var d = from vt in dataVitri.M_VITRI_V1_VMs where vt.MA_DVQLY == dvql && vt.MA_CAPDA == "05" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                            else
                            {
                                var d = from vt in dataVitri.M_VITRI_V1_VMs where vt.MA_DVQLY == dvql && vt.MA_CAPDA == "06" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                        }
                    }
                    else
                    {
                        if (all == 1)
                        {
                            var d = from vt in dataVitri.M_VITRI_V1_VMs where vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                        else
                        {
                            if (all == 2)
                            {
                                var d = from vt in dataVitri.M_VITRI_V1_VMs where vt.MA_CAPDA == "05" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                            else
                            {
                                var d = from vt in dataVitri.M_VITRI_V1_VMs where vt.MA_CAPDA == "06" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN != "1S" && vt.LOAI_PTDIEN != "DZ" select new { vt.TOA_DO, vt.ID_PTDIEN };
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
                        }
                    }
                }
            }
        }
        public void getSub(string _macha) {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                var d = from vt in data.M_VITRI_V1s where vt.MA_PMISCHA == _macha select new { vt.TOA_DO, vt.MA_PMIS, vt.RIGHT_TRANGTHAI, vt.LEFT_TRANGTHAI,vt.LOAI_PTDIEN };
                foreach (var item in d)
                {
                    if (item.TOA_DO != null && item.RIGHT_TRANGTHAI == false && item.LEFT_TRANGTHAI == false && item.LOAI_PTDIEN != "DZ" && item.LOAI_PTDIEN != "1S")
                    {
                        geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                        ListWarning.Add(geo.ToString());
                        //getSub(item.MA_PMIS);
                    }
                    getSub(item.MA_PMIS);
                }
            }
        }
        public void getSubVM(string _macha)
        {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                var d = from vt in data.M_VITRI_V1_VMs where vt.MA_PMISCHA == _macha select new { vt.TOA_DO, vt.MA_PMIS, vt.RIGHT_TRANGTHAI, vt.LEFT_TRANGTHAI, vt.LOAI_PTDIEN };
                foreach (var item in d)
                {
                    if (item.TOA_DO != null && item.RIGHT_TRANGTHAI == false && item.LEFT_TRANGTHAI == false && item.LOAI_PTDIEN != "DZ" && item.LOAI_PTDIEN != "1S")
                    {
                        geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                        ListWarning.Add(geo.ToString());
                        //getSubVM(item.MA_PMIS);
                    }
                    getSubVM(item.MA_PMIS);
                }
            }
        }
        public void getWarningDZ_LS(string searchDay, string dvql, int all,string timeBegin,string timeEnd)
        {
            geo = new SqlGeometry();
            ListWarningDZ = new List<string>();
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                if (all == 0)
                {
                    string[] xl = searchDay.Split(',');
                    for (int i = 0; i < xl.Count() - 1; i++)
                    {
                        var d = from vt in data.M_VITRI_V5_Alls where vt.MA_PMIS == xl[i] && vt.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && vt.THOIGIANKETTHUC <= DateTime.Parse(timeEnd) select new { vt.TOA_DO, vt.MA_PMIS, vt.RIGHT_TRANGTHAI, vt.LEFT_TRANGTHAI, vt.LOAI_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null && item.RIGHT_TRANGTHAI == false && item.LEFT_TRANGTHAI == false && item.LOAI_PTDIEN == "DZ")
                            {
                                geo.Read(new System.IO.BinaryReader(
                                        new System.IO.MemoryStream(
                                        item.TOA_DO.ToArray()
                                        )));
                                ListWarningDZ.Add(geo.ToString());
                            }
                            getSub_DZ(item.MA_PMIS);
                        }
                    }
                }
                else
                {
                    if (dvql != "PN")
                    {
                        if (all == 1)
                        {
                            var d = from vt in data.M_VITRI_V5_Alls where vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.MA_DVQLY == dvql && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" && vt.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && vt.THOIGIANKETTHUC <= DateTime.Parse(timeEnd) select new { vt.TOA_DO };
                            foreach (var item in d)
                            {
                                if (item.TOA_DO != null)
                                {
                                    geo.Read(new System.IO.BinaryReader(
                                            new System.IO.MemoryStream(
                                            item.TOA_DO.ToArray()
                                            )));
                                    ListWarningDZ.Add(geo.ToString());
                                }
                            }
                        }
                        else
                        {
                            if (all == 2)
                            {
                                var d = from vt in data.M_VITRI_V5_Alls where vt.MA_CAPDA == "05" && vt.MA_DVQLY == dvql && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" && vt.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && vt.THOIGIANKETTHUC <= DateTime.Parse(timeEnd) select new { vt.TOA_DO };
                                foreach (var item in d)
                                {
                                    if (item.TOA_DO != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                                new System.IO.MemoryStream(
                                                item.TOA_DO.ToArray()
                                                )));
                                        ListWarningDZ.Add(geo.ToString());
                                    }
                                }
                            }
                            else
                            {
                                var d = from vt in data.M_VITRI_V5_Alls where vt.MA_CAPDA == "06" && vt.MA_DVQLY == dvql && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" && vt.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && vt.THOIGIANKETTHUC <= DateTime.Parse(timeEnd) select new { vt.TOA_DO };
                                foreach (var item in d)
                                {
                                    if (item.TOA_DO != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                                new System.IO.MemoryStream(
                                                item.TOA_DO.ToArray()
                                                )));
                                        ListWarningDZ.Add(geo.ToString());
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (all == 1)
                        {
                            var d = from vt in data.M_VITRI_V5_Alls where vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" && vt.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && vt.THOIGIANKETTHUC <= DateTime.Parse(timeEnd) select new { vt.TOA_DO };
                            foreach (var item in d)
                            {
                                if (item.TOA_DO != null)
                                {
                                    geo.Read(new System.IO.BinaryReader(
                                            new System.IO.MemoryStream(
                                            item.TOA_DO.ToArray()
                                            )));
                                    ListWarningDZ.Add(geo.ToString());
                                }
                            }
                        }
                        else
                        {
                            if (all == 2)
                            {
                                var d = from vt in data.M_VITRI_V5_Alls where vt.MA_CAPDA == "05" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" && vt.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && vt.THOIGIANKETTHUC <= DateTime.Parse(timeEnd) select new { vt.TOA_DO };
                                foreach (var item in d)
                                {
                                    if (item.TOA_DO != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                                new System.IO.MemoryStream(
                                                item.TOA_DO.ToArray()
                                                )));
                                        ListWarningDZ.Add(geo.ToString());
                                    }
                                }
                            }
                            else
                            {
                                var d = from vt in data.M_VITRI_V5_Alls where vt.MA_CAPDA == "06" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" && vt.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && vt.THOIGIANKETTHUC <= DateTime.Parse(timeEnd) select new { vt.TOA_DO };
                                foreach (var item in d)
                                {
                                    if (item.TOA_DO != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                                new System.IO.MemoryStream(
                                                item.TOA_DO.ToArray()
                                                )));
                                        ListWarningDZ.Add(geo.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void getWarningDZ(string searchDay, string dvql, int all)
        {
            geo = new SqlGeometry();
            ListWarningDZ = new List<string>();
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                if (all==0)
                {
                    string[] xl = searchDay.Split(',');
                    for (int i = 0; i < xl.Count() - 1; i++)
                    {
                        var d = from vt in data.M_VITRI_V1s where vt.MA_PMIS == xl[i] select new { vt.TOA_DO, vt.MA_PMIS, vt.RIGHT_TRANGTHAI, vt.LEFT_TRANGTHAI,vt.LOAI_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null && item.RIGHT_TRANGTHAI == false && item.LEFT_TRANGTHAI == false && item.LOAI_PTDIEN == "DZ")
                            {
                                geo.Read(new System.IO.BinaryReader(
                                        new System.IO.MemoryStream(
                                        item.TOA_DO.ToArray()
                                        )));
                                ListWarningDZ.Add(geo.ToString());
                            }
                            getSub_DZ(item.MA_PMIS);
                        }
                    }
                }
                else
                {
                    if (dvql != "PN")
                    {
                        if (all==1)
                        {
                            var d = from vt in data.M_VITRI_V1s where vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.MA_DVQLY == dvql && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" select new { vt.TOA_DO };
                            foreach (var item in d)
                            {
                                if (item.TOA_DO != null)
                                {
                                    geo.Read(new System.IO.BinaryReader(
                                            new System.IO.MemoryStream(
                                            item.TOA_DO.ToArray()
                                            )));
                                    ListWarningDZ.Add(geo.ToString());
                                }
                            }
                        }
                        else
                        {
                            if (all==2)
                            {
                                var d = from vt in data.M_VITRI_V1s where vt.MA_CAPDA == "05" && vt.MA_DVQLY == dvql && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" select new { vt.TOA_DO };
                                foreach (var item in d)
                                {
                                    if (item.TOA_DO != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                                new System.IO.MemoryStream(
                                                item.TOA_DO.ToArray()
                                                )));
                                        ListWarningDZ.Add(geo.ToString());
                                    }
                                }
                            }
                            else
                            {
                                var d = from vt in data.M_VITRI_V1s where vt.MA_CAPDA == "06" && vt.MA_DVQLY == dvql && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" select new { vt.TOA_DO };
                                foreach (var item in d)
                                {
                                    if (item.TOA_DO != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                                new System.IO.MemoryStream(
                                                item.TOA_DO.ToArray()
                                                )));
                                        ListWarningDZ.Add(geo.ToString());
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (all == 1)
                        {
                            var d = from vt in data.M_VITRI_V1s where vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08"  && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" select new { vt.TOA_DO };
                            foreach (var item in d)
                            {
                                if (item.TOA_DO != null)
                                {
                                    geo.Read(new System.IO.BinaryReader(
                                            new System.IO.MemoryStream(
                                            item.TOA_DO.ToArray()
                                            )));
                                    ListWarningDZ.Add(geo.ToString());
                                }
                            }
                        }
                        else
                        {
                            if (all == 2)
                            {
                                var d = from vt in data.M_VITRI_V1s where vt.MA_CAPDA == "05" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" select new { vt.TOA_DO };
                                foreach (var item in d)
                                {
                                    if (item.TOA_DO != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                                new System.IO.MemoryStream(
                                                item.TOA_DO.ToArray()
                                                )));
                                        ListWarningDZ.Add(geo.ToString());
                                    }
                                }
                            }
                            else
                            {
                                var d = from vt in data.M_VITRI_V1s where vt.MA_CAPDA == "06" &&  vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" select new { vt.TOA_DO };
                                foreach (var item in d)
                                {
                                    if (item.TOA_DO != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                                new System.IO.MemoryStream(
                                                item.TOA_DO.ToArray()
                                                )));
                                        ListWarningDZ.Add(geo.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void getSub_DZ(string _macha)
        {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                var d = from vt in data.M_VITRI_V1s where vt.MA_PMISCHA == _macha select new { vt.TOA_DO, vt.MA_PMIS, vt.RIGHT_TRANGTHAI, vt.LEFT_TRANGTHAI, vt.LOAI_PTDIEN };
                foreach (var item in d)
                {
                    if (item.TOA_DO != null && item.RIGHT_TRANGTHAI == false && item.LEFT_TRANGTHAI == false && item.LOAI_PTDIEN == "DZ" )
                    {
                        geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                        ListWarningDZ.Add(geo.ToString());
                        //getSub_DZ(item.MA_PMIS);
                    }
                    getSub_DZ(item.MA_PMIS);
                }
            }
        }
        public void getSubVM_DZ(string _macha)
        {
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                var d = from vt in data.M_VITRI_V1_VMs where vt.MA_PMISCHA == _macha select new { vt.TOA_DO, vt.MA_PMIS, vt.RIGHT_TRANGTHAI, vt.LEFT_TRANGTHAI, vt.LOAI_PTDIEN };
                foreach (var item in d)
                {
                    if (item.TOA_DO != null && item.RIGHT_TRANGTHAI == false && item.LEFT_TRANGTHAI == false && item.LOAI_PTDIEN == "DZ")
                    {
                        geo.Read(new System.IO.BinaryReader(
                                new System.IO.MemoryStream(
                                item.TOA_DO.ToArray()
                                )));
                        ListWarningDZ.Add(geo.ToString());
                        //getSubVM_DZ(item.MA_PMIS);
                    }
                    getSubVM_DZ(item.MA_PMIS);
                }
            }
        }
        public void getWarningDZ_VM(string searchDay, string dvql, int all)
        {
            geo = new SqlGeometry();
            ListWarningDZ = new List<string>();
            using (LDSongDataContext data = new LDSongDataContext(LDSong.Properties.Settings.Default.connect))
            {
                if (all == 0)
                {
                    string[] xl = searchDay.Split(',');
                    for (int i = 0; i < xl.Count() - 1; i++)
                    {
                        var d = from vt in data.M_VITRI_V1_VMs where vt.MA_PMIS == xl[i]  select new { vt.TOA_DO, vt.MA_PMIS, vt.RIGHT_TRANGTHAI, vt.LEFT_TRANGTHAI,vt.LOAI_PTDIEN };
                        foreach (var item in d)
                        {
                            if (item.TOA_DO != null && item.RIGHT_TRANGTHAI == false && item.LEFT_TRANGTHAI == false && item.LOAI_PTDIEN == "DZ")
                            {
                                geo.Read(new System.IO.BinaryReader(
                                        new System.IO.MemoryStream(
                                        item.TOA_DO.ToArray()
                                        )));
                                ListWarningDZ.Add(geo.ToString());
                            }
                            getSubVM_DZ(item.MA_PMIS);
                        }
                    }
                }
                else
                {
                    if (dvql != "PN")
                    {
                        if (all == 1)
                        {
                            var d = from vt in data.M_VITRI_V1_VMs where vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.MA_DVQLY == dvql && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" select new { vt.TOA_DO };
                            foreach (var item in d)
                            {
                                if (item.TOA_DO != null)
                                {
                                    geo.Read(new System.IO.BinaryReader(
                                            new System.IO.MemoryStream(
                                            item.TOA_DO.ToArray()
                                            )));
                                    ListWarningDZ.Add(geo.ToString());
                                }
                            }
                        }
                        else
                        {
                            if (all == 2)
                            {
                                var d = from vt in data.M_VITRI_V1_VMs where vt.MA_CAPDA == "05" && vt.MA_DVQLY == dvql && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" select new { vt.TOA_DO };
                                foreach (var item in d)
                                {
                                    if (item.TOA_DO != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                                new System.IO.MemoryStream(
                                                item.TOA_DO.ToArray()
                                                )));
                                        ListWarningDZ.Add(geo.ToString());
                                    }
                                }
                            }
                            else
                            {
                                var d = from vt in data.M_VITRI_V1_VMs where vt.MA_CAPDA == "06" && vt.MA_DVQLY == dvql && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" select new { vt.TOA_DO };
                                foreach (var item in d)
                                {
                                    if (item.TOA_DO != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                                new System.IO.MemoryStream(
                                                item.TOA_DO.ToArray()
                                                )));
                                        ListWarningDZ.Add(geo.ToString());
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (all == 1)
                        {
                            var d = from vt in data.M_VITRI_V1_VMs where vt.MA_CAPDA != "03" && vt.MA_CAPDA != "08" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" select new { vt.TOA_DO };
                            foreach (var item in d)
                            {
                                if (item.TOA_DO != null)
                                {
                                    geo.Read(new System.IO.BinaryReader(
                                            new System.IO.MemoryStream(
                                            item.TOA_DO.ToArray()
                                            )));
                                    ListWarningDZ.Add(geo.ToString());
                                }
                            }
                        }
                        else
                        {
                            if (all == 2)
                            {
                                var d = from vt in data.M_VITRI_V1_VMs where vt.MA_CAPDA == "05" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" select new { vt.TOA_DO };
                                foreach (var item in d)
                                {
                                    if (item.TOA_DO != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                                new System.IO.MemoryStream(
                                                item.TOA_DO.ToArray()
                                                )));
                                        ListWarningDZ.Add(geo.ToString());
                                    }
                                }
                            }
                            else
                            {
                                var d = from vt in data.M_VITRI_V1_VMs where vt.MA_CAPDA == "06" && vt.RIGHT_TRANGTHAI == false && vt.LEFT_TRANGTHAI == false && vt.LOAI_PTDIEN == "DZ" select new { vt.TOA_DO };
                                foreach (var item in d)
                                {
                                    if (item.TOA_DO != null)
                                    {
                                        geo.Read(new System.IO.BinaryReader(
                                                new System.IO.MemoryStream(
                                                item.TOA_DO.ToArray()
                                                )));
                                        ListWarningDZ.Add(geo.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
