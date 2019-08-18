using MyNotes.Common.Helpers;
using MyNotes.DataAccessLayer.EntityFramework;
using MyNotes.Entities;
using MyNotes.Entities.Messages;
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
                    // Hata kodu, Hata içeriği
                    loginResult.AddError(ErrorMessageCode.UserIsNotActive, "Hesabınız aktif değildir.");
                    loginResult.AddError(ErrorMessageCode.CheckYourEmail, "Lütfen e-posta adresinizi kontrol ediniz.");
                }
            }
            else
            {
                // Hata kodu, Hata içeriği
                loginResult.AddError(ErrorMessageCode.UsernameOrPasswordWrong, "Kullanıcı adı yada şifre alanı uyuşmuyor.");
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

            //Bu class nesnesi, bulunduğumuz metodunun dönüş tipidir. Error listesi ve kayıt olan kullanıcı verisini tutar.
            BusinessLayerResult<MyNotesUser> RegisterResult = new BusinessLayerResult<MyNotesUser>();


            // Error Kontrolü
            if (user != null)
            {
                if (user.Username == model.Username)
                {
                    RegisterResult.AddError(ErrorMessageCode.UsernameAlreadyExists, "Username alanı kullanılıyor.");
                }
                if (user.Email == model.EMail)
                {
                    RegisterResult.AddError(ErrorMessageCode.EmailAlreadyExists, "E-Posta adresi kullanılıyor.");
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
                    // Get User > User Set to RegisterResult
                    RegisterResult.Result =  repo_user.Find(x =>x.Username == model.Username || x.Email == model.EMail);

                    // Mail Context
                    string siteUri = ConfigHelper.Get<string>("SiteRootUri");
                    string activateUri = $"{siteUri}/Home/UserActivate/{RegisterResult.Result.ActivateGuid}";
                    string body = $"Merhaba {RegisterResult.Result.Username};<br><br>Hesabınızı aktifleştirmek için <a href='{activateUri}' target='_blank'>tıklayınız</a>.";

                    MailHelper.SendMail(body, RegisterResult.Result.Email, "MyNotes Hesap Aktifleştirme");
                }
            }

            //RegisterResult: Hata varsa hata mesajlarını veya kullanıcı eklendiyse kullanıcı bilgisini barındırır.
            return RegisterResult;
        }
        public BusinessLayerResult<MyNotesUser> ActivateUser(Guid model)
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////    
            //Activasyon e-postası sonucunun değerlendirilmesi ve User'ın IsActive = true olarak güncellenmesi.
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                        

            //Bu class nesnesi, bulunduğumuz metodunun dönüş tipidir. Error listesi ve kayıt olan kullanıcı verisini tutar.
            BusinessLayerResult<MyNotesUser> ActivateResult = new BusinessLayerResult<MyNotesUser>();

            ActivateResult.Result = repo_user.Find(x => x.ActivateGuid == model);

            if (ActivateResult.Result != null)
            {
                if (ActivateResult.Result.IsActive == true)
                {
                    ActivateResult.AddError(ErrorMessageCode.UserAlreadyActive, "Kullanıcı zaten aktif edilmiştir.");
                }
                else
                {
                    ActivateResult.Result.IsActive = true;
                    repo_user.Update(ActivateResult.Result);
                }
            }
            else
            {
                ActivateResult.AddError(ErrorMessageCode.ActivateIdDoesNotExists, "Aktifleştirilecek kullanıcı bulunamadı.");
            }

            return ActivateResult;
        }

    }
}
