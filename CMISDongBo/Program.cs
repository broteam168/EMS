using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


namespace CMISDongBo
{
    class Program
    {
        private static CMISDBODataContext DB;

        static void Main(string[] args)
        {
            try
            {
                string log = "";

                StreamWriter file = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogDongBo.txt", true);

                WebReference.Service_CCDC SRV = new WebReference.Service_CCDC();
                DB = new CMISDBODataContext();
                List<K_DONGBO_CMI> lstDVi = DB.K_DONGBO_CMIs.ToList();

                Thread xoaKhachHang = new Thread((obj) =>
                {
                    DB.K_KHACH_HANG_TMPs.DeleteAllOnSubmit(DB.K_KHACH_HANG_TMPs.ToList());
                    DB.SubmitChanges();
                });
                xoaKhachHang.Start();
                xoaKhachHang.Join();
                Thread dboKhachHang = new Thread((obj) =>
                {
                    foreach (K_DONGBO_CMI tmp in lstDVi)
                    {
                        DataSet ds = SRV.LDSONG_DSKHANG(tmp.MA_DVIQLY, (DateTime)tmp.NGAY_KH);
                        insertKHANG_TMP(ds);
                        log = string.Format("{1:dd/MM/yyyy HH:mm:ss}: Lay du lieu khach hang don vi - {0}\n", tmp.MA_DVIQLY, DateTime.Now);
                        file.WriteLine(log);
                        Console.Write(log);
                    }
                });
                dboKhachHang.Start();
                dboKhachHang.Join();

                Thread updateKhachHang = new Thread((obj) =>
                {
                    foreach (K_DONGBO_CMI tmp in lstDVi)
                    {
                        DB.sp_CHUYENDL_KHANG(tmp.MA_DVIQLY);
                        log = string.Format("{1:dd/MM/yyyy HH:mm:ss}: Dong bo khach hang don vi - {0}\n", tmp.MA_DVIQLY, DateTime.Now);
                        file.WriteLine(log);
                        Console.Write(log);
                    }
                });
                updateKhachHang.Start();
                updateKhachHang.Join();

                Thread xoaDiemDo = new Thread((obj) =>
                {
                    DB.K_DIEM_DO_TMPs.DeleteAllOnSubmit(DB.K_DIEM_DO_TMPs.ToList());
                    DB.SubmitChanges();
                });
                xoaDiemDo.Start();
                xoaDiemDo.Join();

                Thread dboDiemDo = new Thread((obj) =>
                {
                    foreach (K_DONGBO_CMI tmp in lstDVi)
                    {
                        DataSet ds = SRV.LDSONG_DSDDO(tmp.MA_DVIQLY, (DateTime)tmp.NGAY_DD);
                        insertDDO_TMP(ds);
                        log = string.Format("{1:dd/MM/yyyy HH:mm:ss}: Lay du lieu diem do don vi - {0}\n", tmp.MA_DVIQLY, DateTime.Now);
                        file.WriteLine(log);
                        Console.Write(log);
                    }
                });
                dboDiemDo.Start();
                dboDiemDo.Join();

                Thread updateDiemDo = new Thread((obj) =>
                {
                    foreach (K_DONGBO_CMI tmp in lstDVi)
                    {
                        DB.sp_CHUYENDL_DDO(tmp.MA_DVIQLY);
                        log = string.Format("{1:dd/MM/yyyy HH:mm:ss}: Dong bo diem do don vi - {0}\n", tmp.MA_DVIQLY, DateTime.Now);
                        file.WriteLine(log);
                        Console.Write(log);
                    }
                });
                updateDiemDo.Start();
                updateDiemDo.Join();

                // Write the string to a file.
                file.Flush();
                file.Close();
            }
            catch (Exception Ex)
            {
                StreamWriter file = new StreamWriter(Directory.GetCurrentDirectory() + @"\LogDongBo.txt", true);
                file.WriteLine("{1:dd/MM/yyyy HH:mm:ss}: Loi dong bo {1}", DateTime.Now, Ex.Message);
                file.Flush();
                file.Close();
            }
        }


        private static void insertKHANG_TMP(DataSet _ds) {
            List<K_KHACH_HANG_TMP> lstObj = new List<K_KHACH_HANG_TMP>();

            foreach (DataRow dr in _ds.Tables[0].Rows)
            {
                K_KHACH_HANG_TMP obj = new K_KHACH_HANG_TMP();
                obj.MA_DVIQLY = dr["MA_DVIQLY"].ToString();
                obj.MA_KHANG = dr["MA_KHANG"].ToString();
                obj.TEN_KHANG = dr["TEN_KHANG"].ToString();
                obj.DIA_CHI = dr["DCHI_HDON"].ToString();
                obj.DIEN_THOAI = dr["DTHOAI"].ToString();
                obj.NGAY_DBO = dr["NGAY_SUA"] as DateTime?;
                lstObj.Add(obj);
            }
            DB.K_KHACH_HANG_TMPs.InsertAllOnSubmit(lstObj);
            DB.SubmitChanges();
        }

        private static void insertDDO_TMP(DataSet _ds)
        {
            List<K_DIEM_DO_TMP> lstObj = new List<K_DIEM_DO_TMP>();

            foreach (DataRow dr in _ds.Tables[0].Rows)
            {
                K_DIEM_DO_TMP obj = new K_DIEM_DO_TMP();
                obj.MA_DVIQLY = dr["MA_DVIQLY"].ToString();
                obj.MA_KHANG = dr["MA_KHANG"].ToString();
                obj.MA_DDO = dr["MA_DDO"].ToString();
                obj.SO_CTO = dr["SO_CTO"].ToString();
                obj.MA_SOGCS = dr["MA_SOGCS"].ToString();
                obj.STT = dr["STT"].ToString();
                obj.MA_TRAM = dr["MA_TRAM"].ToString();
                obj.MA_LO = dr["MA_LO"].ToString();
                obj.SO_COT = dr["SO_COT"].ToString();
                obj.SO_HOM = dr["SO_HOM"].ToString();
                obj.NGAY_DBO = dr["NGAY_SUA"] as DateTime?;
                lstObj.Add(obj);
            }
            DB.K_DIEM_DO_TMPs.InsertAllOnSubmit(lstObj);
            DB.SubmitChanges();
        }        
    }
}
