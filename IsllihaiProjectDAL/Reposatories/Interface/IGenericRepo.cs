using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Interface
{
    public interface IGenericRepo <T> where T : class , new()
    {
        T? GetById (int  id) ;
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? condetion = null) ;
        void Add (T item) ;
        void Delete(T item) ;
        void Update (T item) ;
    }
}
