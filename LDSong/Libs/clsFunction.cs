using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DevExpress.XtraEditors;

using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography;
using LDSong.Models;

namespace LDSong.Libs
{
    public partial class LDSFunction
    {
        public List<string> getMenuByUser(string _type = "mn",int _parent =-1)
        {
            LDSongDataContext DB = new LDSongDataContext();
            S_GROUP g = DB.S_GROUPs.Where(p => p.GroupId.Equals(Program._User.UserGroup)).SingleOrDefault();
            string[] ids = g.Permission.Split(',');
            List<string> buttons = new List<string>();
            IList<S_MENU> menus;
            if (_parent == -1)
            {
                menus = DB.S_MENUs.Where(p => p.MenuButton.Contains(_type)).ToList();
            }
                
            else {
                menus = DB.S_MENUs.Where(p => p.MenuButton.Contains(_type) && p.ParentId.Equals(_parent)).ToList();
            }
                
            foreach (S_MENU item in menus)
            {
                if (ids.Contains(item.MenuId.ToString()))
                {
                    buttons.Add(item.MenuButton);
                }
            }
            return buttons;
        }
    }
    public partial class clsFunction
    {
        public void showReport()
        { 
            
        }
      
        
    
        public void showMSG(string title, string msg)
        {
            /*
            msgAlert frm = new msgAlert(msg);
            frm.Text = title;
            frm.ShowDialog();*/
            MessageBox.Show(msg, title);
        }


        public bool IsMonth(string pText)
        {
            int _month = -1;
            if (IsNumber(pText))
            {
                _month = int.Parse(pText);
                if (_month > 0 && _month < 13) return true;
            }
            return false;
        }

        public bool IsYear(string pText)
        {
            int _year = -1;
            if (IsNumber(pText))
            {
                _year = int.Parse(pText);
                if (_year > 2000 && _year < 3000) return true;
            }
            return false;
        }
        
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public void changeFocus(BaseEdit obj, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            obj.Focus();
        }

        public void changeFocus(BaseButton obj, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            obj.Focus();
        }

        public string RandomString(int size)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
        public static string Encrypt(string Message)
        {
            string Passphrase = "PCNB";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }

        public static string Decrypt(string Message)
        {
            string Passphrase = "PCNB";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }
    }
}
