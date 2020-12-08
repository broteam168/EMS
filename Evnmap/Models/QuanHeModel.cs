using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnmap.Models
{
    class QuanHeModel
    {
        private int _ID;

        private int _ID_PTDienCha;

        private string _TEN_PTDIEN;

        private string _TEN_LOAI;

        private string _VITRI;

        public QuanHeModel()
		{
		}
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }
        public int ID_PTDienCha
        {
            get
            {
                return this._ID_PTDienCha;
            }
            set
            {
                this._ID_PTDienCha = value;
            }
        }
        public string TEN_PTDIEN
        {
            get
            {
                return this._TEN_PTDIEN;
            }
            set
            {
                this._TEN_PTDIEN = value;
            }
        }
        public string TEN_LOAI
        {
            get
            {
                return this._TEN_LOAI;
            }
            set
            {
                this._TEN_LOAI = value;
            }
        }
        public string VITRI
        {
            get
            {
                return this._VITRI;
            }
            set
            {
                this._VITRI = value;
            }
        }
    }
}
