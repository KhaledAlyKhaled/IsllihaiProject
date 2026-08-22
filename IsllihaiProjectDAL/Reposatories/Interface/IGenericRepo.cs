using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Interface
{
    public interface IGenericRepo <T> where T : class
    {
        T? GetById (int  id) ;
        IEnumerable<T> GetAll() ;
        int Add (T item) ;
        int Delete(T item) ;
        int Update (T item) ;
    }
}
