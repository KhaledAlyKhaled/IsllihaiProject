using IsllihaiProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Interface
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAll();

        int Add(User user);
        int Update(User user);
        User? GetById(int Id);
        int Delete(int id);
    }
}
