using MyNotes.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.DataAccessLayer.MySql
{
    //Temsili
    public class RepositoryBase
    {
        
            
        private static object _lockSync = new object();


        
        protected RepositoryBase()
        {
            CreateContext();
        }
        
        
        private static void CreateContext()
        {
            
        }

    }
}
