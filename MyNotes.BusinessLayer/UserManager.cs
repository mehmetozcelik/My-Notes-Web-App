using MyNotes.DataAccessLayer.EntityFramework;
using MyNotes.Entities;
using MyNotes.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.BusinessLayer
{
    public class UserManager
    {
        Repository<MyNotesUser> repo_user = new Repository<MyNotesUser>();

        public MyNotesUser RegisterUserTest1(RegisterViewModel model)
        {
            //Kullanıcı e-mail ve username kotrolü.
            //Kayıt işlem.
            //Activasyon e-postası gönderimi.

            //MyNotesUser user = repo_user.Find(x => x.Username == model.Username || x.Email == model.EMail);
            MyNotesUser user = repo_user.Find(x => x.Username == model.Username);
            

            if (user != null)
            {
                throw new Exception("Kullanıcı adı kullanılıyor.");
            }
            
            return user;
        }
        public MyNotesUser RegisterUserTest2(RegisterViewModel model)
        {
            //Kullanıcı e-mail ve username kotrolü.
            //Kayıt işlem.
            //Activasyon e-postası gönderimi.

            //MyNotesUser user = repo_user.Find(x => x.Username == model.Username || x.Email == model.EMail);            
            MyNotesUser user2 = repo_user.Find(x => x.Email == model.EMail);

            
            if (user2 != null)
            {
                throw new Exception("E-Posta adresi kullanılıyor.");
            }
            return user2;
        }

    }
}
