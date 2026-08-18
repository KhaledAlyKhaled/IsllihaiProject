using IsllihaiProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Interface
{
    public interface IReviewRepo
    {
        IEnumerable<Review> GetAll();
        int Add(Review review);
        int Update(Review review);
        Review? GetById(int Id);
        int Delete(int id);
    }
}
