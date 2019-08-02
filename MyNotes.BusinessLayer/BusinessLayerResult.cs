using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.BusinessLayer
{
    public class BusinessLayerResult<T> where T : class
    {
        public List<string> ErrorList { get; set; }
        public T Result { get; set; }


        //Listenin boş olması durumunda hata almamak için başta kullanılmasa bile new'liyoruz.
        public BusinessLayerResult()
        {
            ErrorList = new List<string>();
        }
    }
}
