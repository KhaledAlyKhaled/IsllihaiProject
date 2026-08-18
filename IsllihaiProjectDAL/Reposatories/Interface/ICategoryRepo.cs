using IsllihaiProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Interface
{
    public interface ICategoryRepo
    {
        IEnumerable<Category> GetAll();

        int Add(Category category);
        int Update(Category category);
        Category? GetById(int Id);
        int Delete(int id);
    }
}
