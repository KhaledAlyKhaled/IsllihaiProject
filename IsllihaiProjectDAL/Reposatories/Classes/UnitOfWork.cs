using IsllihaiProjectDAL.Contexts;
using IsllihaiProjectDAL.Reposatories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Classes
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly Dictionary<Type, object> _repositores = new();
        private readonly islahiniDbContext dbContext;

        public UnitOfWork(islahiniDbContext dbContext, ITecnicianRepo tecnicianRepo )
        {
            this.dbContext = dbContext;
            this.tecnicianRepo = tecnicianRepo;
        }

        public ITecnicianRepo tecnicianRepo { get; }

        public IGenericRepo<T> GetRepo<T>() where T : class, new()
        {
            var entity = typeof(T);
            if (_repositores.TryGetValue(entity, out var Repo))
                return (IGenericRepo<T>)Repo;

            var NewRepo = new GenericRepo<T>(dbContext);
            _repositores[entity] = NewRepo;
            return NewRepo;
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
    }
}
