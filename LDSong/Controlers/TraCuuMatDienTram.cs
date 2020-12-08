using LDSong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class TraCuuMatDienTram
    {
        private LDSongDataContext db;
        public TraCuuMatDienTram() {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }
        public List<D_PTDIEN> getListTram(int idPTDIEN,string dvql) {
            if (dvql!="PN")
            {
                return db.D_PTDIENs.Where(p => p.ID_PTDIEN == idPTDIEN && p.MA_DVQLY.Equals(dvql)).ToList();
            }
            else
            {
                return db.D_PTDIENs.Where(p => p.ID_PTDIEN == idPTDIEN).ToList();
            }
        }
        public List<D_PTDIEN> getListTram1(string matram, string dvql)
        {
            if (dvql != "PN")
            {
                return db.D_PTDIENs.Where(p => p.MA_CMIS.Equals(matram) && p.MA_DVQLY.Equals(dvql) ).ToList();
            }
            else
            {
                return db.D_PTDIENs.Where(p => p.MA_CMIS.Equals(matram) ).ToList();
            }
        }
        public List<D_PTDIEN> getListTram(string tenPTDIEN, string dvql )
        {
            if (dvql != "PN")
            {
                return db.D_PTDIENs.Where(p => p.TEN_PTDIEN.Contains(tenPTDIEN) && p.MA_DVQLY.Equals(dvql) ).ToList();
            }
            else
            {
                return db.D_PTDIENs.Where(p => p.TEN_PTDIEN.Contains(tenPTDIEN)).ToList();
            }
        }
        public List<M_TTHAI_PTDIEN_LR> getListTTLR(int idPTDien) {
            return db.M_TTHAI_PTDIEN_LRs.Where(p => p.ID_PTDIEN.Equals(idPTDien) && p.RIGHT_TRANGTHAI==false).OrderByDescending(p => p.NGAY_CAP_NHAT).ToList();
        }
        public List<M_TTHAI_PTDIEN> getListTTOC(int idPTDien)
        {
            return db.M_TTHAI_PTDIENs.Where(p => p.ID_PTDIEN.Equals(idPTDien)).OrderByDescending(p => p.THOI_DIEM).ToList();
        }
        public List<M_TTHAI_PTDIEN_LR> getListTTLR(int idPTDien,DateTime begin,DateTime end)
        {
            string[] b = begin.ToString().Split(' ');
            string[] c = end.ToString().Split(' ');
            string b1=b[0]+" 00:00:01";
            string c1=c[0]+" 23:59:59";
            DateTime d = DateTime.Parse("1/1/0001 12:00:00 AM");
            if (begin.Equals(d) && !end.Equals(d))
            {
                return db.M_TTHAI_PTDIEN_LRs.Where(p => p.ID_PTDIEN.Equals(idPTDien) && p.RIGHT_TRANGTHAI == false && p.NGAY_CAP_NHAT <= DateTime.Parse(c1)).OrderByDescending(p => p.NGAY_CAP_NHAT).ToList();
            }
            else
            {
                if (!begin.Equals(d) && end.Equals(d))
                {
                    return db.M_TTHAI_PTDIEN_LRs.Where(p => p.ID_PTDIEN.Equals(idPTDien) && p.RIGHT_TRANGTHAI == false && p.NGAY_CAP_NHAT >= DateTime.Parse(b1)).OrderByDescending(p => p.NGAY_CAP_NHAT).ToList();
                }
                else
                {
                    return db.M_TTHAI_PTDIEN_LRs.Where(p => p.ID_PTDIEN.Equals(idPTDien) && p.RIGHT_TRANGTHAI == false && p.NGAY_CAP_NHAT >= DateTime.Parse(b1) && p.NGAY_CAP_NHAT <= DateTime.Parse(c1)).OrderByDescending(p => p.NGAY_CAP_NHAT).ToList();
                }
            }
        }
        public List<M_TTHAI_PTDIEN> getListTTOC(int idPTDien, DateTime begin, DateTime end)
        {
            string[] b = begin.ToString().Split(' ');
            string[] c = end.ToString().Split(' ');
            string b1 = b[0] + " 00:00:01";
            string c1 = c[0] + " 23:59:59";
            DateTime d = DateTime.Parse("1/1/0001 12:00:00 AM");
            if (begin.Equals(d) && !end.Equals(d))
            {
                return db.M_TTHAI_PTDIENs.Where(p => p.ID_PTDIEN.Equals(idPTDien)  && p.THOI_DIEM <= DateTime.Parse(c1)).OrderByDescending(p => p.THOI_DIEM).ToList();
            }
            else
            {
                if (!begin.Equals(d) && end.Equals(d))
                {
                    return db.M_TTHAI_PTDIENs.Where(p => p.ID_PTDIEN.Equals(idPTDien)  && p.THOI_DIEM >= DateTime.Parse(b1)).OrderByDescending(p => p.THOI_DIEM).ToList();
                }
                else
                {
                    return db.M_TTHAI_PTDIENs.Where(p => p.ID_PTDIEN.Equals(idPTDien)  && p.THOIGIANKETTHUC >= DateTime.Parse(b1) && p.THOI_DIEM <= DateTime.Parse(c1)).OrderByDescending(p => p.THOI_DIEM).ToList();
                }
            }
        }
    }
}
