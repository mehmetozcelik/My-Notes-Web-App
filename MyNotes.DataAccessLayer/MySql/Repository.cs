using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyNotes.DataAccessLayer;
using MyNotes.DataAccessLayer.Abstract;
using MyNotes.DataAccessLayer.MySql;
using MyNotes.Entities;

namespace MyNotes.DataAccessLayer.MySql
{
    //Temsili
    //'IRepository<T>' bu interfaceden implemente edilen repository metodları gövdelendiriliyor.
    public class Repository<T> : RepositoryBase, IRepository<T> where T : class
    {
        public int Delete(T obj)
        {
            throw new NotImplementedException();
        }

        public T Find(Expression<Func<T, bool>> whereKosulu)
        {
            throw new NotImplementedException();
        }

        public int Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public List<T> List()
        {
            throw new NotImplementedException();
        }

        public List<T> List(Expression<Func<T, bool>> whereKosulu)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public int Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
