using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LDSong.Models;
using System.Windows.Forms;

namespace LDSong.Controlers
{
    class UserControler
    {
        private S_USER obj;
        private LDSongDataContext db;

        public UserControler()
        {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }

        public S_USER getByUserName(string _Name)
        {
            try
            {
                return db.S_USERs.Where(p => p.UserName.Equals(_Name)).SingleOrDefault();
            }
            catch (Exception)
            {

                MessageBox.Show("Vui lòng kiểm tra lại kết nối tới máy chủ!" );
                return null;
            }
        }

        public void add(S_USER _obj)
        {
            try
            {
                db.S_USERs.InsertOnSubmit(_obj);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể thêm mới, vui lòng kiểm tra lại.");
            }
        }

        public bool checkExists(string _UserName)
        {
            obj = db.S_USERs.Where(p => p.UserName.Equals(_UserName)).SingleOrDefault();
            if (obj != null) return true;
            return false;
        }

        public void clearPass(int _Id)
        {
            obj = db.S_USERs.Where(p => p.UserId.Equals(_Id)).SingleOrDefault();
            if (obj != null)
            {
                obj.UserPassword = obj.UserName;
                db.SubmitChanges();
            }
        }

        public void delete(int _Id)
        {
            obj = db.S_USERs.Where(p => p.UserId.Equals(_Id)).SingleOrDefault();
            if (obj != null)
            {
                db.S_USERs.DeleteOnSubmit(obj);
                db.SubmitChanges();
            }
        }

        public void update(S_USER _obj)
        {
            obj = db.S_USERs.Where(p => p.UserName.Equals(_obj.UserName)).SingleOrDefault();
            if (obj != null)
            {
                obj.IsActive = _obj.IsActive;
                obj.MaDVQL = _obj.MaDVQL;
                obj.Phone = _obj.Phone;
                obj.UserFullname = _obj.UserFullname;
                obj.UserGroup = _obj.UserGroup;
                obj.UserPoss = _obj.UserPoss;
                //obj.UserPassword = _obj.UserPassword;
                db.SubmitChanges();
            }            
        }
        public List<S_USER> list()
        {
            return db.S_USERs.ToList();
        }

        public List<S_GROUP> listGroup()
        {
            return db.S_GROUPs.ToList();
        }

        public List<D_DVI_QLY> listDVQL()
        {
            return db.D_DVI_QLies.ToList();
        }
    }
}
