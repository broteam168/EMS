using LDSong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Controlers
{
    class ImageControler
    {
        private LDSongDataContext db;
        public ImageControler()
        {
            db = new LDSongDataContext(LDSong.Properties.Settings.Default.connect);
        }
        public List<D_Image> listFile(int idPTDien)
        {
            return db.D_Images.Where(p => p.ID_PTDIEN == idPTDien).ToList();
        }
        public void delete(int id)
        {
            D_Image tmp = db.D_Images.Where(p => p.ID == id).SingleOrDefault();
            if (tmp != null)
            {
                db.D_Images.DeleteOnSubmit(tmp);
                db.SubmitChanges();
            }
        }
        public Byte[] attachment(int id)
        {
            return db.D_Images.Where(p => p.ID == id).SingleOrDefault().Image.ToArray();
        }
        
    }
}
