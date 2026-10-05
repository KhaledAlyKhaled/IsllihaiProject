using IsllihaiProjectDAL.Contexts;
using IsllihaiProjectDAL.Entities;
using IsllihaiProjectDAL.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Classes
{
    public class TecnicianRepo : GenericRepo<Technican> ,ITecnicianRepo
    {
        private readonly IslahiniDbContext dbContext;

        public TecnicianRepo(IslahiniDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Technican> GetAllTechnicainWithUserInfos(Expression<Func<Technican, bool>>? conditain = null)
        {
            if (conditain is null)
            return dbContext.Technican.Include(x =>x.User)
                                      .Include(x=>x.Category)
                                      .AsNoTracking()
                                      .ToList();
            else
                return dbContext.Technican.Include(x => x.User)
                                      .Include(x => x.Category)
                                      .AsNoTracking()
                                      .Where(conditain)
                                      .ToList();
        }

        public Technican GetTechnicanById(int id)
        {
            return dbContext.Technican.Include(x => x.User)
                                      .Include(x => x.Category)
                                      .FirstOrDefault(x=>x.Id == id);
        }
    }
}
