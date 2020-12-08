using LDSong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class HISTRORY_LOGINcontroler
    {
        //private HISTORY_LOGIN obj;
        private LDSongDataContext db;
        public HISTRORY_LOGINcontroler() {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }
        public void insertLogin(HISTORY_LOGIN _obj) {
            db.HISTORY_LOGINs.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }
        public IPAddress LocalIPAddress()
        {
            try
            {
                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    return null;
                }
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                return host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            }
            catch (Exception)
            {

                return null;
            }
        }

        // cach 1 lay IP 
        public string getIPinternet()
        {
            try
            {
                string url = "http://checkip.dyndns.org";
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string response = sr.ReadToEnd().Trim();
                string[] a = response.Split(':');
                string a2 = a[1].Substring(1);
                string[] a3 = a2.Split('<');
                string a4 = a3[0];
                return a4;
            }
            catch (Exception)
            {
                return "Khong co ket noi internet";
            }
        }
        // cach 2 lay IP -- dang ap dung
        public string getIPaddressInter(string _url = "https://ipinfo.io/ip")
        {
            try
            {
                return new System.Net.WebClient().DownloadString(_url);
            }
            catch (Exception)
            {
                try
                {
                    return new System.Net.WebClient().DownloadString("https://api.ipify.org/");
                }
                catch (Exception)
                {
                    return "Khong co ket noi internet";   
                }
            }
        }
        public DateTime getDateServer()
        {
            return db.GetServerDate();
        }
        public void update(string userName)
        {

            try
            {
                var m = (from p in db.HISTORY_LOGINs where p.USERNAME == userName orderby p.ID_HS descending select p).Skip(0).Take(1);
                foreach (var item in m)
                {
                    item.THOIGIAN_DANGXUAT = getDateServer();
                    db.SubmitChanges();
                }
            }
            catch (Exception)
            {
                
            }

        }
        public double getVerSion() {
            try
            {
                return double.Parse(db.Versions.FirstOrDefault().Version1.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public void insert(string key)
        {
            Models.Version vr = new Models.Version();
            vr.Version1 = key;
            db.Versions.InsertOnSubmit(vr);
            db.SubmitChanges();
        }
        public bool checkExist(string key)
        {
            int c=db.Versions.Where(v => v.Version1.Equals(key)).Count();
            if (c>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int countPer()
        {
            return db.Versions.Count();
        }
    }
}
