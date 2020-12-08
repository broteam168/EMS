using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Libs
{
    public class Key
    {
        public Key() { 
        }
        public string getID()
        {
            string id = "";
            ManagementObjectSearcher MOS = new ManagementObjectSearcher("select * from Win32_DiskDrive");// lay id cua main Select * From Win32_BaseBoard
            foreach (ManagementObject getserial in MOS.Get())
            {
                id = getserial["SerialNumber"].ToString();
            }
            return id.Trim();
        }
        public string getIDMain()
        {
            string id = "";
            ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
            foreach (ManagementObject getserial in MOS.Get())
            {
                id = getserial["SerialNumber"].ToString();
            }
            return id.Trim();
        }
        public string EncodeSHA1(string pass)
        {

            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);

            bs = sha1.ComputeHash(bs);

            System.Text.StringBuilder s = new System.Text.StringBuilder();

            foreach (byte b in bs)
            {

                s.Append(b.ToString("x1").ToLower());

            }

            pass = s.ToString();

            return pass;

        }

        public string EncodeMD5(string pass)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);

            bs = md5.ComputeHash(bs);

            System.Text.StringBuilder s = new System.Text.StringBuilder();

            foreach (byte b in bs)
            {

                s.Append(b.ToString("x1").ToLower());

            }

            pass = s.ToString();

            return pass;

        }
        public string xuly(string s)
        {
            string s1 = s.Insert(4, "-").Insert(9, "-").Insert(14, "-").Insert(19, "-").Insert(24, "-").Substring(0, 29).Trim();
            //return s1.Substring(0,5);
            string s2 = "";
            int dem = 0;
            for (int y = 0; y <= 27; y = y + 2)
            {
                if (dem != 4 && dem != 9 && dem != 14)
                {
                    if (y != 4 && y != 9 && y != 14 && y != 19)
                    {
                        int i = (byte)s1.ElementAt(y);
                        int j = (byte)s1.ElementAt(y + 1);
                        s2 = s2 + xulyAscii(i, j).ToString();
                    }
                    else
                    {
                        y = y + 1;
                        int i = (byte)s1.ElementAt(y);
                        int j = (byte)s1.ElementAt(y + 1);
                        s2 = s2 + xulyAscii(i, j).ToString();
                    }

                }
                else
                {
                    s2 = s2 + "-";
                }
                dem++;
            }
            for (int y = 27; y >= 0; y = y - 2)
            {
                if (dem != 4 && dem != 9 && dem != 14)
                {
                    if (y != 4 && y != 9 && y != 14 && y != 19)
                    {
                        int i = (byte)s1.ElementAt(y);
                        int j = (byte)s1.ElementAt(y + 1);
                        s2 = s2 + xulyAscii(i, j).ToString();
                    }
                    else
                    {
                        y = y + 1;
                        int i = (byte)s1.ElementAt(y);
                        int j = (byte)s1.ElementAt(y + 1);
                        s2 = s2 + xulyAscii(i, j).ToString();
                    }

                }
                else
                {
                    s2 = s2 + "-";
                }
                dem--;
            }
            return s2.Trim();
        }
        private char xulyAscii(int i, int j)
        {
            if (i >= 48 && i <= 57)
            {
                if (j % 2 == 0)
                {
                    int x = i + 16;
                    return (char)x;
                }
                else
                {
                    int x = i + 33;
                    return (char)x;
                }
            }
            else if (i >= 65 && i <= 90)
            {
                int x = i + 32;
                return (char)x;
            }
            else
            {

                int x = i - 49;
                if (x > 106)
                {
                    return (char)i;
                }
                else
                {
                    return (char)x;
                }

            }
        }
    }
}
