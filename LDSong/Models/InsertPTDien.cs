using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel;
using LinqToExcel.Attributes;

namespace LDSong.Models
{
    class InsertPTDien
    {
        [ExcelColumn("MA_DVQLY")]
        public string MA_DVQLY { get; set; }

        [ExcelColumn("TEN_PTDIEN")]
        public string TEN_PTDIEN { get; set; }

        [ExcelColumn("MA_CAPDA")]
        public string MA_CAPDA { get; set; }

        [ExcelColumn("TEN_CAPDA")]
        public string TEN_CAPDA { get; set; }

        [ExcelColumn("LOAI_PTDIEN")]
        public string LOAI_PTDIEN { get; set; }

        [ExcelColumn("MA_PMIS")]
        public string MA_PMIS { get; set; }

        [ExcelColumn("MA_PMISCHA")]
        public string MA_PMISCHA { get; set; }

        [ExcelColumn("TOA_DO")]
        public string TOA_DO { get; set; }
    }
}
