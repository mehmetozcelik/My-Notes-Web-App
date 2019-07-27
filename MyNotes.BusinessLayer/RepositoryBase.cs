using MyNotes.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.BusinessLayer
{
    //---------------------------------------SİNGLETON PATTERN--------------------------------------------------------
    //Amaç: 'DatabaseContex db' nesnesinden uygulamada sadece 1 kere olmasını istediğimizden dolayı.
    public class RepositoryBase
    {
        //protected: Bu 'DatabaseContext' nesnesinin erişim alanı => Bu class'ı miras alan classlar.
        protected static DatabaseContext db;     
        private static object _lockSync = new object();


        //Class'ın consturuction'ını proetected yaparak bu class'tan nesne oluşturulamaz hale getiriyoruz.
        protected RepositoryBase()
        {
            CreateContext();
        }
        
        
        private static void CreateContext()
        {
            if (db == null)
            {
                //lock:Multithreed uygulamalarda iki iş parcacığı buraya geldiğinde birinin işi bitmeden diğeri bu işi yapmıyor.
                lock (_lockSync)
                {
                    if (db == null)
                    {                        
                        db = new DatabaseContext();        
                    }
                }
            }
            
                
        }

    }
}
