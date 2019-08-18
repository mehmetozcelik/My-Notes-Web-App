
namespace MyNotes.Entities.Messages
{
    // Enum : Uygulamada kullanılacak sabitler olarak düşünebiliriz.
    public enum ErrorMessageCode
    {
        // Username alanı zaten mevcut
        UsernameAlreadyExists = 101,

        // Email alanı zaten mevcut
        EmailAlreadyExists = 102,

        // Kullancı aktif değil
        UserIsNotActive = 151,
        
        // Username ve Password eşleşmiyor
        UsernameOrPasswordWrong = 152,

        // E-mail'i kontrol edin
        CheckYourEmail = 153,

        // User zaten aktif edilmiştir
        UserAlreadyActive = 154,

        // Aktifleştirilecek kullanıcı bulunamadı
        ActivateIdDoesNotExists = 155


    }
}
