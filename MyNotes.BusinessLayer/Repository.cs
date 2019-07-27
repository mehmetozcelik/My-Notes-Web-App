using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyNotes.DataAccessLayer;
using MyNotes.Entities;

namespace MyNotes.BusinessLayer
{
    //---------------------------------------REPOSİTORY PATTERN--------------------------------------------------------

    //'RepositoryBase' classından miras alarak 'db' nesnesine erişebiliyoruz.
    //'where T : class' komutuyla 'Repository<T>' generic classına gelen 'T' tipini class olarak kısıtlıyoruz.(int,vs olamaz)
    public class Repository<T> : RepositoryBase where T : class 
    {
        /////////////////////////////////////////////////////////////////////////////////
               
        private DbSet<T> _dbSet;


        public Repository()
        {            
            //Her seferinde 'db.Set<T>()' yerine '_dbSet' ifadesini kullanacağız.
            _dbSet = db.Set<T>();   
        }

        private int Save()
        {
            //Direk Save() metodu çağırılarak database kayıt işlemi sağlanacak.
            return db.SaveChanges();    
        }  

        
        /////////////////////////////////////////////////////////////////////////////////
        
        public List<T> List()
        {
            //return db.Set<T>().ToList();
            return _dbSet.ToList();
        }

        public List<T> List(Expression<Func<T,bool>> whereKosulu)
        {
            return _dbSet.Where(whereKosulu).ToList();
        }

        public T Find(Expression<Func<T,bool>> whereKosulu)
        {
            return _dbSet.FirstOrDefault(whereKosulu);
        }

        public int Insert(T obj)
        {
            _dbSet.Add(obj);
            return Save();
        }

        public int Update(T obj)
        {
            return Save();
        }

        public int Delete(T obj)
        {
            _dbSet.Remove(obj);
            return Save();
        }
    }
}
