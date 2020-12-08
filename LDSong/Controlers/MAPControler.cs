using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

using LDSong.Libs;
using DevExpress.XtraMap;

namespace LDSong.Controlers
{   
    class MAPControler
    {
        private clsSQL sqlDB;

        public MAPControler()
        {
            sqlDB = new clsSQL();
        }

        public DataTable searcDZ(string _SearchText,string _MaDV, string _CapDAp = "")
        {
            string sql = "SELECT PT.MA_DVQLY,PT.ID_PTDIEN,PT.TEN_PTDIEN,DA.TEN_CAPDA FROM D_PTDIEN PT INNER JOIN D_CAP_DAP DA ON PT.MA_CAPDA = DA.MA_CAPDA WHERE PT.MA_DVQLY LIKE '{0}%' AND PT.LOAI_PTDIEN = 'DZ' AND PT.MA_CAPDA LIKE '%{1}%' AND (PT.TEN_PTDIEN LIKE '%{2}%' OR PT.MA_CMIS LIKE '%{2}%' OR PT.MA_PMIS LIKE '%{2}%' OR PT.MA_SCADA LIKE '%{2}%')";
            sql = string.Format(sql, _MaDV, _CapDAp, _SearchText);
            DataTable tbl = sqlDB.Select(sql);
            return tbl;
        }
        public VectorItemsLayer getViTriDZ(string _MaDV, int _IDPTDien)
        {
            return sqlDB.getItemLocation(_MaDV, _IDPTDien);
        }

    }
}
