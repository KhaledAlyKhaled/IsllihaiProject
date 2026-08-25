using IsllihaiProjectDAL.Contexts;
using IsllihaiProjectDAL.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Classes
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class , new()
    {
        private readonly islahiniDbContext _DbContext;

        public GenericRepo(islahiniDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public void Add(T item)
        {
            _DbContext.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            _DbContext.Set<T>().Remove(item);
            
        }

        public IEnumerable<T> GetAll(Func<T, bool>? condetion = null)
        {
            if (condetion is null)
                return _DbContext.Set<T>().AsNoTracking().ToList();

            return _DbContext.Set<T>().AsNoTracking().Where(condetion).ToList();
        }

        public T? GetById(int id)
        {
            return _DbContext.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            _DbContext.Set<T>().Update(item);
            
        }
    }
}
