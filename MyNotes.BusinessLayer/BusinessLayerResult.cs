using MyNotes.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.BusinessLayer
{
    //Login ve Register sayfalarının business layer' daki işlemlerinde kullanılır.
    //Usermanager'deki metodların geri dönüş tipidir.
    
    public class BusinessLayerResult<T> where T : class
    {

        // Usermanager class'ının metodlarında meydana gelen errorları tutar.
        public List<ErrorMessageObj> ErrorList { get; set; }
        // Login ve Register işlemlerinde Usermanager'den dönen kullanıcı nesnesi tutulur.
        public T Result { get; set; }




        //Listenin boş olması durumunda hata almamak için başta kullanılmasa bile new'liyoruz.
        public BusinessLayerResult()
        {
            ErrorList = new List<ErrorMessageObj> ();
        }

        // Error Listesine metod üzerinden veri ekleme.
        public void AddError(ErrorMessageCode code, string message)
        {
            ErrorList.Add(new ErrorMessageObj() { Code = code, Error = message });
        }
    }
}
