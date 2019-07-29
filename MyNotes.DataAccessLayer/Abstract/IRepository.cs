using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.DataAccessLayer.Abstract
{
    //Repository yapısını buradan çekiyoruz.    
    //Amaç:Eğer yeni bir db(MySql,Oracle,vs.) eklenirse bu interfaceyi implemente etsin ve bu metottları kullansın.
    public interface IRepository<T>
    {
        int Save();

        List<T> List();

        List<T> List(Expression<Func<T, bool>> whereKosulu);

        T Find(Expression<Func<T, bool>> whereKosulu);

        int Insert(T obj);

        int Update(T obj);

        int Delete(T obj);
    }
}
