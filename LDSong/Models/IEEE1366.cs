using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Models
{
    public class IEEE1366
    {
        private DateTime _day;
        private int _ci;
        private int _cmi;
        private int _cs;
        private double _saifi;
        private double _caidi;
        private double _asai;
        private double _saidi;
        private double _ln;
        public IEEE1366()
        {

        }
        public DateTime day
        {
            get
            {
                return this._day;
            }
            set
            {
                this._day = value;
            }
        }
        public int ci
        {
            get
            {
                return this._ci;
            }
            set
            {
                this._ci = value;
            }
        }
        public int cmi
        {
            get
            {
                return this._cmi;
            }
            set
            {
                this._cmi = value;
            }
        }
        public int cs
        {
            get
            {
                return this._cs;
            }
            set
            {
                this._cs = value;
            }
        }

        public double saifi
        {
            get
            {
                return this._saifi;
            }
            set
            {
                this._saifi = value;
            }
        }
        public double asai
        {
            get
            {
                return this._asai;
            }
            set
            {
                this._asai = value;
            }
        }
        public double caidi
        {
            get
            {
                return this._caidi;
            }
            set
            {
                this._caidi = value;
            }
        }
        public double saidi
        {
            get
            {
                return this._saidi;
            }
            set
            {
                this._saidi = value;
            }
        }
        public double ln
        {
            get
            {
                return this._ln;
            }
            set
            {
                this._ln = value;
            }
        }
    }
}
