using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LDSong.Models;

namespace LDSong.Controlers
{
    class GroupControler
    {
        //private S_GROUP obj;
        private LDSongDataContext db;

        public GroupControler()
        {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }

        public void add(S_GROUP _obj)
        {
            db.S_GROUPs.InsertOnSubmit(_obj);
            db.SubmitChanges();
        }

        public void update(S_GROUP _obj)
        {
            S_GROUP tmp = db.S_GROUPs.Where(p => p.GroupId.Equals(_obj.GroupId)).SingleOrDefault();
            if (tmp != null)
            {
                tmp.GroupName = _obj.GroupName;
                tmp.GroupDesc = _obj.GroupDesc;
                tmp.Permission = _obj.Permission;
                db.SubmitChanges();
            }
        }
        public List<S_GROUP> list()
        {
            return db.S_GROUPs.ToList();
        }
        public void delete(int _Id)
        {
            S_GROUP tmp = db.S_GROUPs.Where(p => p.GroupId.Equals(_Id)).SingleOrDefault();
            if (tmp != null)
            {
                db.S_GROUPs.DeleteOnSubmit(tmp);
                db.SubmitChanges();
            }
        }

        public List<S_MENU> listMenu(int _parent)
        {
            return db.S_MENUs.Where(p=>p.ParentId.Equals(_parent)).ToList();
        }
    }
}
