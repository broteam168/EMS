using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LDSong.Models;

namespace LDSong.Libs
{
    public static class LDSongGlobal
    {
        private static LDSongDataContext DB;

        public static List<D_DVI_QLY> listDVQLy()
        {
            DB = new LDSongDataContext();
            return DB.D_DVI_QLies.OrderBy(p => p.MA_DVIQLY).ToList();
        }
        public static List<D_DVI_QLY> listDVQLy(string dvql)
        {
            DB = new LDSongDataContext();
            if (dvql!="PN")
            {
                return DB.D_DVI_QLies.Where(p=>p.MA_DVIQLY.Equals(dvql)).OrderBy(p => p.MA_DVIQLY).ToList();
            }
            else
            {
                return DB.D_DVI_QLies.OrderBy(p => p.MA_DVIQLY).ToList();
            }
        }
    }
}
