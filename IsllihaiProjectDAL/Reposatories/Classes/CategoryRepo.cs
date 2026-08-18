using IsllihaiProjectDAL.Contexts;
using IsllihaiProjectDAL.Entities;
using IsllihaiProjectDAL.Reposatories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Classes
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly islahiniDbContext _DbContext;

        public CategoryRepo(islahiniDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public int Add(Category category)
        {
            _DbContext.Add(category);
            return _DbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var category = _DbContext.Category.Find(id);
            if (category is null)
                return 0;
            return _DbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _DbContext.Category.ToList();
        }

        public Category? GetById(int Id)
        {
            return _DbContext.Category.Find(Id);
        }

        public int Update(Category category)
        {
            _DbContext.Category.Update(category);
            return _DbContext.SaveChanges();
        }
    }
}
