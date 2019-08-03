
namespace MyNotes.Entities.Messages
{
    public enum ErrorMessageCode
    {
        //Username alanı zaten mevcut
        UsernameAlreadyExists = 101,

        //Email alanı zaten mevcut
        EmailAlreadyExists = 102,

        //Kullancı aktif değil
        UserIsNotActive = 151,
        
        //Username ve Password eşleşmiyor
        UsernameOrPasswordWrong = 152,

        // E-mail'i kontrol edin
        CheckYourEmail = 153

    }
}
