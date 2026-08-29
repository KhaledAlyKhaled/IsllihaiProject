using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Interface
{
    public interface IUnitOfWork
    {
        IGenericRepo<T> GetRepo<T>() where T : class, new();
        public ITecnicianRepo tecnicianRepo { get; }
        int SaveChanges ();
    }
}
