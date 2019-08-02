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

        
        public BusinessLayerResult<MyNotesUser> LoginUser(LoginViewModel model)
        {
            /////////////////////////////////////////////////////////////////////////////
            // Giriş kontrolü ve yönlendirme.
            // Hesap aktive edilmiş mi?
            /////////////////////////////////////////////////////////////////////////////

            BusinessLayerResult<MyNotesUser> loginResult = new BusinessLayerResult<MyNotesUser>();

            loginResult.Result = repo_user.Find(x => x.Username == model.Username && x.Password == model.Password);

            if (loginResult.Result != null)
            {
                if (loginResult.Result.IsActive != true)
                {
                    loginResult.ErrorList.Add("Hesabınız aktif değildir. Lütfen e-posta adresinizi kontrol ediniz.");                    
                }
            }
            else
            {
                loginResult.ErrorList.Add("Kullanıcı adı yada şifre alanı uyuşmuyor.");
            }

            return loginResult;
        }
        public BusinessLayerResult<MyNotesUser> RegisterUser(RegisterViewModel model)
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Kullanıcı e-mail ve username kotrolü.
            //Kayıt işlem.
            //Activasyon e-postası gönderimi.
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////

            //Register Page'den gelen model nesnesinin  'Username' ve 'Email' attributeleri User tablosunda var mı?
            MyNotesUser user = repo_user.Find(x => x.Username == model.Username || x.Email == model.EMail);

            //Bu class nesnesi, bulunduğumuz metodunun dönüş tipidir. Error listesi ve kayıt olanh kullanıcı verisini tutar.
            BusinessLayerResult<MyNotesUser> RegisterResult = new BusinessLayerResult<MyNotesUser>();


            // Error Kontrolü
            if (user != null)
            {
                if (user.Username == model.Username)
                {
                    RegisterResult.ErrorList.Add("Username alanı kullanılıyor.");
                }
                if (user.Email == model.EMail)
                {
                    RegisterResult.ErrorList.Add("E-Posta adresi kullanılıyor.");
                }
            }
            // db Insert User
            else
            {
                int insertResult = repo_user.Insert(new MyNotesUser() {
                    Username = model.Username,
                    Email = model.EMail,
                    Password = model.Password,
                    ActivateGuid = Guid.NewGuid(),                    
                    IsActive = false,
                    IsAdmin = false                 
                });

                // db Insert Success
                if (insertResult > 0)
                {   
                    // Get User
                    MyNotesUser RegisterUser =  repo_user.Find(x =>x.Username == model.Username || x.Email == model.EMail);
                }
            }

            //TODO: aktivasyon maili atılacak
            //RegisterUSer.ActivateGuid


            //RegisterResult: Hata varsa hata mesajlarını veya kullanıcı eklendiyse kullanıcı bilgisini barındırır.
            return RegisterResult;
        }


        
    }
}
