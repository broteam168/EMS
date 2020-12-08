using LDSong.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class TT_PTDIEN_LRControler
    {
        //private M_TTHAI_PTDIEN_LR obj;
        private LDSongDataContext db;
        public List<M_TTHAI_PTDIEN_LR> ListUpdate;
        public List<D_PTDIEN> list02;
        public int cout03,count05,count01,count06,KH01;
        public TT_PTDIEN_LRControler()
        {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
            ListUpdate = new List<M_TTHAI_PTDIEN_LR>();
        }
        public List<M_TTHAI_PTDIEN_LR> getOFF() {
            return db.M_TTHAI_PTDIEN_LRs.ToList();
        }
        public List<M_TTHAI_PTDIEN_LR> getOFF(string dvql, string timeBegin, string timeEnd)
        {
            if (dvql!="PN")
            {
                return db.M_TTHAI_PTDIEN_LRs.Where(rp => rp.D_PTDIEN.MA_DVQLY.Equals(dvql) && rp.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && rp.NGAY_CAP_NHAT <= DateTime.Parse(timeEnd) && rp.D_PTDIEN.LOAI_PTDIEN.Equals("TT")  && rp.RIGHT_TRANGTHAI.Equals("0")).ToList();
                
            }
            else
            {
                return db.M_TTHAI_PTDIEN_LRs.Where(rp => rp.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && rp.NGAY_CAP_NHAT <= DateTime.Parse(timeEnd) && rp.D_PTDIEN.LOAI_PTDIEN.Equals("TT")  && rp.RIGHT_TRANGTHAI.Equals("0")).ToList();
                
            }
            
            //return db.M_TTHAI_PTDIEN_LRs.Where(rp => rp.NGAY_CAP_NHAT >= timeBegin && rp.NGAY_CAP_NHAT <= timeEnd && rp.D_PTDIEN.LOAI_PTDIEN.Equals("TT") && rp.RIGHT_TRANGTHAI.Equals("0")).Select(rp => new M_TTHAI_PTDIEN_LR_New() { ID = rp.ID, ID_PTDIEN = rp.ID_PTDIEN, LEFT_TRANGTHAI = rp.LEFT_TRANGTHAI, RIGHT_TRANGTHAI = rp.RIGHT_TRANGTHAI, CHIEUDONGDIEN = rp.CHIEUDONGDIEN, NGAY_CAP_NHAT = rp.NGAY_CAP_NHAT, THOIGIANKETTHUC = rp.THOIGIANKETTHUC }).ToList(); 
        }
        public List<M_TTHAI_PTDIEN_LR> getOFF1(string dvql, string timeBegin, string timeEnd)
        {
            if (dvql != "PN")
            {
                return db.M_TTHAI_PTDIEN_LRs.Where(rp => rp.D_PTDIEN.MA_DVQLY.Equals(dvql) && ((rp.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && rp.NGAY_CAP_NHAT <= DateTime.Parse(timeEnd)) ||(rp.NGAY_CAP_NHAT < DateTime.Parse(timeEnd)&&( rp.THOIGIANKETTHUC.ToString().Equals("")||rp.THOIGIANKETTHUC> DateTime.Parse(timeBegin)))) && rp.D_PTDIEN.LOAI_PTDIEN.Equals("TT") && rp.RIGHT_TRANGTHAI.Equals("0")).ToList();

            }
            else
            {
                return db.M_TTHAI_PTDIEN_LRs.Where(rp => ((rp.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && rp.NGAY_CAP_NHAT <= DateTime.Parse(timeEnd)) || (rp.NGAY_CAP_NHAT < DateTime.Parse(timeEnd) && (rp.THOIGIANKETTHUC.ToString().Equals("") || rp.THOIGIANKETTHUC > DateTime.Parse(timeBegin)))) && rp.D_PTDIEN.LOAI_PTDIEN.Equals("TT") && rp.RIGHT_TRANGTHAI.Equals("0")).ToList();

            }

            //return db.M_TTHAI_PTDIEN_LRs.Where(rp => rp.NGAY_CAP_NHAT >= timeBegin && rp.NGAY_CAP_NHAT <= timeEnd && rp.D_PTDIEN.LOAI_PTDIEN.Equals("TT") && rp.RIGHT_TRANGTHAI.Equals("0")).Select(rp => new M_TTHAI_PTDIEN_LR_New() { ID = rp.ID, ID_PTDIEN = rp.ID_PTDIEN, LEFT_TRANGTHAI = rp.LEFT_TRANGTHAI, RIGHT_TRANGTHAI = rp.RIGHT_TRANGTHAI, CHIEUDONGDIEN = rp.CHIEUDONGDIEN, NGAY_CAP_NHAT = rp.NGAY_CAP_NHAT, THOIGIANKETTHUC = rp.THOIGIANKETTHUC }).ToList(); 
        }
        public int sumKh(string madv)
        {
            if (!madv.Equals("PN"))
            {
                return db.K_KHACH_HANGs.Where(m => m.MA_DVIQLY.Equals(madv)).Count();
            }
            else
            {
                return db.K_KHACH_HANGs.Count();
            }
        }

        public int getCountKH(string matram)
        {
            try
            {
                return db.K_DIEM_DOs.Where(d => d.MA_TRAM.Equals(matram)).Count();
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
        public List<D_PTDIEN> getOFFBC03(string dvql, string timeBegin, string timeEnd)
        {
            if (dvql != "PN")
            {
                return db.D_PTDIENs.Where(rp => rp.MA_DVQLY.Equals(dvql) && rp.LOAI_PTDIEN.Equals("TT")  && rp.M_TTHAI_PTDIEN_LRs.Any(m => m.RIGHT_TRANGTHAI == false && m.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && m.NGAY_CAP_NHAT <= DateTime.Parse(timeEnd))).ToList();
            }
            else
            {
                return db.D_PTDIENs.Where(rp => rp.LOAI_PTDIEN.Equals("TT")  && rp.M_TTHAI_PTDIEN_LRs.Any(m => m.RIGHT_TRANGTHAI == false && m.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && m.NGAY_CAP_NHAT <= DateTime.Parse(timeEnd))).ToList();
            }

            //return db.M_TTHAI_PTDIEN_LRs.Where(rp => rp.NGAY_CAP_NHAT >= timeBegin && rp.NGAY_CAP_NHAT <= timeEnd && rp.D_PTDIEN.LOAI_PTDIEN.Equals("TT") && rp.RIGHT_TRANGTHAI.Equals("0")).Select(rp => new M_TTHAI_PTDIEN_LR_New() { ID = rp.ID, ID_PTDIEN = rp.ID_PTDIEN, LEFT_TRANGTHAI = rp.LEFT_TRANGTHAI, RIGHT_TRANGTHAI = rp.RIGHT_TRANGTHAI, CHIEUDONGDIEN = rp.CHIEUDONGDIEN, NGAY_CAP_NHAT = rp.NGAY_CAP_NHAT, THOIGIANKETTHUC = rp.THOIGIANKETTHUC }).ToList(); 
        }
        public List<D_DVI_QLY> listDVi(string dvql) {
            if (dvql!="PN")
            {
                return db.D_DVI_QLies.Where(p=>p.MA_DVIQLY.Equals(dvql)).ToList();
            }
            else
            {
                return db.D_DVI_QLies.ToList();
            }
        }
        public List<D_LOAI_YCAU> listLoaiYeuCau() {
            return db.D_LOAI_YCAUs.ToList();
        }
        public List<K_YEU_CAU> listKHYeuCau(string dvql,string maloai, string timeBegin, string timeEnd)
        {
            if (dvql != "PN")
            {
                return db.K_YEU_CAUs.Where(p => p.MA_LOAI == maloai && p.NGAY_TAO >= DateTime.Parse(timeBegin) && p.NGAY_TAO <= DateTime.Parse(timeEnd)).ToList();
            }
            else
            {
                return db.K_YEU_CAUs.Where(p =>p.MA_DVIQLY.Equals(dvql) && p.MA_LOAI == maloai && p.NGAY_TAO >= DateTime.Parse(timeBegin) && p.NGAY_TAO <= DateTime.Parse(timeEnd)).ToList();
            }
        }
        public string TenDVi(string dvql)
        {
             return db.D_DVI_QLies.Where(p => p.MA_DVIQLY.Equals(dvql)).FirstOrDefault().TEN_DVIQLY;
        }
        public List<S_BAOCAO> listBCao()
        {
             return db.S_BAOCAOs.ToList();
        }
        public S_BAOCAO getLoaiBCao(int id) {
            return db.S_BAOCAOs.Where(b => b.ID == id).SingleOrDefault();
        }
        public DateTime getDateServer()
        {
            return db.GetServerDate();
        }
        public int getTram(int id, string timeBegin, string timeEnd ) {
            TimeSpan sumTime = default(TimeSpan), tam; 
            List<M_TTHAI_PTDIEN_LR> list = db.M_TTHAI_PTDIEN_LRs.Where(m => m.ID_PTDIEN == id && m.RIGHT_TRANGTHAI == false && m.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && m.NGAY_CAP_NHAT <= DateTime.Parse(timeEnd)).ToList();
            cout03 = list.Count;
            foreach (var item in list)
            {
                if (item.THOIGIANKETTHUC!=null)
                {
                    tam = DateTime.Parse(item.THOIGIANKETTHUC.ToString()) - DateTime.Parse(item.NGAY_CAP_NHAT.ToString());
                    sumTime = sumTime + tam;
                }
            }
            return sumTime.Days * 24 * 60 + sumTime.Hours * 60 + sumTime.Minutes;
        }
        public List<D_DVI_QLY> getDVQL05(string dvql) {
            if (dvql!="PN")
            {
                return db.D_DVI_QLies.Where(d=>d.MA_DVIQLY.Equals(dvql)).ToList();
            }
            else
            {
                return db.D_DVI_QLies.Where(d => !d.MA_DVIQLY.Equals("PN") && !d.MA_DVIQLY.Equals("PNX110")).ToList();
            }
        }
        public int getOFF05(string dvql, string timeBegin, string timeEnd)
        {
            TimeSpan sumTime = default(TimeSpan), tam;
            var d = db.M_TTHAI_PTDIEN_LRs.Where(rp => rp.D_PTDIEN.MA_DVQLY.Equals(dvql) && rp.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && rp.NGAY_CAP_NHAT <= DateTime.Parse(timeEnd) && rp.D_PTDIEN.LOAI_PTDIEN.Equals("TT") && rp.RIGHT_TRANGTHAI.Equals("0")).ToList();
            count05 = d.Count;
            foreach (var item in d)
            {
                if (item.THOIGIANKETTHUC!=null)
                {
                    tam = DateTime.Parse(item.THOIGIANKETTHUC.ToString()) - DateTime.Parse(item.NGAY_CAP_NHAT.ToString());
                    sumTime = sumTime + tam;
                }
            }
            return sumTime.Days * 24 * 60 + sumTime.Hours * 60 + sumTime.Minutes;
        }
        public int getID05(string dvql, string timeBegin, string timeEnd)
        {
            int SL = 0;
            var d= db.D_PTDIENs.Where(rp => rp.MA_DVQLY.Equals(dvql) && rp.LOAI_PTDIEN.Equals("TT") && rp.M_TTHAI_PTDIEN_LRs.Any(m => m.RIGHT_TRANGTHAI == false && m.NGAY_CAP_NHAT >= DateTime.Parse(timeBegin) && m.NGAY_CAP_NHAT <= DateTime.Parse(timeEnd))).ToList();
            foreach (var item in d)
            {
                if (item.MA_CMIS!=null || item.MA_CMIS!="")
                {
                    SL = SL + db.K_DIEM_DOs.Where(k => k.MA_TRAM.Equals(item.MA_CMIS)).Count();
                }
            }
            return SL;
        }
        public List<D_PTDIEN> getOFF01(string dvql)
        {
            if (dvql!="PN")
            {
                return db.D_PTDIENs.Where(p => !p.MA_CAPDA.Equals("03") && !p.MA_CAPDA.Equals("08") && p.MA_PMISCHA.Equals(dvql)).ToList();
            }
            else
            {
                List<D_PTDIEN> list = new List<D_PTDIEN>();
                var dv = db.D_DVI_QLies.Where(d => !d.MA_DVIQLY.Equals("PN") && !d.MA_DVIQLY.Equals("PNX110")).ToList();
                foreach (var item in dv)
                {
                    var d=db.D_PTDIENs.Where(p => !p.MA_CAPDA.Equals("03") && !p.MA_CAPDA.Equals("08") && p.MA_PMISCHA.Equals(item.MA_DVIQLY)).ToList();
                    foreach (var items in d)
                    {
                        list.Add(items);
                    }
                }
                return list;
            }
        }
        public void getTram01(int id) {
            var d = db.D_PTDIENs.Where(p => p.ID_PTDIEN == id).SingleOrDefault();
            getALLDuongDAY(d.MA_PMIS);
        }
        public void getALLDuongDAY(string maPmisCha)
        {
                try
                {
                    var d = db.D_PTDIENs.Where(p => p.MA_PMISCHA == maPmisCha).ToList();
                    foreach (var item in d)
                    {
                        if (item.LOAI_PTDIEN=="TT")
                        {
                            count01 = count01 + 1;
                            if (item.MA_CMIS!=null || item.MA_CMIS.Trim()=="")
                            {
                                var d1 = db.K_DIEM_DOs.Where(k => k.MA_TRAM.Equals(item.MA_CMIS)).Count();
                                KH01 = KH01 + d1;
                            }
                        }
                        getALLDuongDAY(item.MA_PMIS);
                    }
                    
                }
                catch (Exception)
                {

                }
        }
        public void getALLDuongDay02(string maPmisCha,bool _Parrent=false) {
            if (_Parrent==true)
            {
                list02 = new List<D_PTDIEN>();
            }
            try
            {
                var d = db.D_PTDIENs.Where(p => p.MA_PMISCHA == maPmisCha).ToList();
                foreach (var item in d)
                {
                    if (item.LOAI_PTDIEN == "TT")
                    {
                        list02.Add(item);
                    }
                    getALLDuongDay02(item.MA_PMIS);
                }

            }
            catch (Exception)
            {

            }
        }
        public string getNameCapDa(string maPmis) {
            return db.D_PTDIENs.Where(d => d.MA_PMIS.Equals(maPmis)).SingleOrDefault().D_CAP_DAP.TEN_CAPDA;
        }
        public int countKH02(string maCmis) {
            return db.K_DIEM_DOs.Where(k => k.MA_TRAM.Equals(maCmis)).Count();
        }
        public string congsuat(string maCmis)
        {
            return db.D_PTDIENs.Where(d => d.MA_CMIS.Equals(maCmis)).SingleOrDefault().CONGSUAT.ToString();
        }
        public List<M_TTHAI_CD_KDCB> getListDao06(string dvql) {
            if (!dvql.Equals("PN"))
            {
                return db.M_TTHAI_CD_KDCBs.Where(p => p.D_PTDIEN.MA_DVQLY.Equals(dvql)).ToList();
            }
            else
            {
                return db.M_TTHAI_CD_KDCBs.ToList();
            }
        }
        public int getSumTimeTram06(int id, string timeBegin, string timeEnd)
        {
            TimeSpan sumTime = default(TimeSpan), tam;
            List<M_TTHAI_PTDIEN> list = db.M_TTHAI_PTDIENs.Where(p => p.ID_PTDIEN == id && p.THOI_DIEM >= DateTime.Parse(timeBegin) && p.THOIGIANKETTHUC <= DateTime.Parse(timeEnd) && p.TRANG_THAI == 1).ToList();
            count06 = list.Count;
            foreach (var item in list)
            {
                if (item.THOIGIANKETTHUC != null)
                {
                    tam = DateTime.Parse(item.THOIGIANKETTHUC.ToString()) - DateTime.Parse(item.THOI_DIEM.ToString());
                    sumTime = sumTime + tam;
                }
            }
            return sumTime.Days * 24 * 60 + sumTime.Hours * 60 + sumTime.Minutes;
        }
    }
    
}
