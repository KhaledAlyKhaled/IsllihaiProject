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
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly islahiniDbContext _DbContext;

        public GenericRepo(islahiniDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public int Add(T item)
        {
            _DbContext.Set<T>().Add(item);
            return _DbContext.SaveChanges();

        }

        public int Delete(T item)
        {
            _DbContext.Set<T>().Remove(item);
            return _DbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _DbContext.Set<T>().AsNoTracking().ToList();
        }

        public T? GetById(int id)
        {
            return _DbContext.Set<T>().Find(id);
        }

        public int Update(T item)
        {
            _DbContext.Set<T>().Update(item);
            return _DbContext.SaveChanges();
        }
    }
}
