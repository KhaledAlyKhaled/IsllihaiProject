using IsllihaiProjectDAL.Contexts;
using IsllihaiProjectDAL.Entities;
using IsllihaiProjectDAL.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Classes
{
    public class UserRepo :IUserRepo
    {
        private readonly islahiniDbContext _DbContext;
        public UserRepo (islahiniDbContext dbContext )
        {
            _DbContext = dbContext;
        }
        public int Add(User user)
        {
            _DbContext.Add(user);
            return _DbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var user = _DbContext.Users.Find(id);
            if (user is null)
                return 0;
            return _DbContext.SaveChanges();
        }

        public IEnumerable<User>GetAll()
        {
            return _DbContext.Users.ToList();
        }

        public User? GetById(int Id)
        {
            return _DbContext.Users.Find(Id);
        }

        public int Update(User user)
        {
            _DbContext.Users.Update(user);
            return _DbContext.SaveChanges();
        }
    }
}
