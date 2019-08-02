using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyNotes.DataAccessLayer;
using MyNotes.DataAccessLayer.Abstract;
using MyNotes.Entities;

namespace MyNotes.DataAccessLayer.EntityFramework
{
    //---------------------------------------REPOSİTORY PATTERN--------------------------------------------------------

    //'RepositoryBase' classından miras alarak 'db' nesnesine erişebiliyoruz.
    //'IRepository<T>' bu interface bize bu class'ta kullandığımız metodları veriyor.
    //'where T : class' komutuyla 'Repository<T>' generic classına gelen 'T' tipini class olarak kısıtlıyoruz.(int,vs olamaz)
    public class Repository<T> : RepositoryBase, IRepository<T> where T : class 
    {
        /////////////////////////////////////////////////////////////////////////////////
               
        private DbSet<T> _dbSet;
        public Repository()
        {            
            //Her seferinde 'db.Set<T>()' yerine '_dbSet' ifadesini kullanacağız.
            _dbSet = db.Set<T>();   
        }
        public int Save()
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

            // Parametre gelen nesnenin class'ı 'MyEntityBase' class'ından miras alıyor mu?
            if (obj is MyEntityBase)
            {
                // Alıyorsa, gelen obj'yi 'MyEntityBase' tipine dönüstürülür ve o classın attributelerine default veriler eklenicek. 
                MyEntityBase o = obj as MyEntityBase;

                DateTime nowtime = DateTime.Now;

                o.CreatedOn = nowtime;
                o.ModifiedOn = nowtime;
                o.ModifiedUsername = "System";      // TODO: İşlem yapan kullanıcı adı gelicek.
            }
            return Save();
        }

        public int Update(T obj)
        {
            // Parametre gelen nesnenin class'ı 'MyEntityBase' class'ından miras alıyor mu?
            if (obj is MyEntityBase)
            {
                // Alıyorsa, gelen obj'yi 'MyEntityBase' tipine dönüstürülür ve o classın attributelerine default veriler eklenicek. 
                MyEntityBase o = obj as MyEntityBase;

                o.ModifiedOn = DateTime.Now;
                o.ModifiedUsername = "System";      // TODO: İşlem yapan kullanıcı adı gelicek.
            }
            return Save(); 
        }

        public int Delete(T obj)
        {
            _dbSet.Remove(obj);
            return Save();
        }
    }
}
