using IsllihaiProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Interface
{
    public interface ICategoreyRepo
    {
        IEnumerable<Category> GetAllWithTechAndBooking(Expression<Func<Category, bool>>? Condition = null);
        Category GetByIdWithTechAndBooking(int id);
        
    }
}
