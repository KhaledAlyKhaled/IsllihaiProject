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
    public class TecnicianRepo : GenericRepo<Technican> ,ITecnicianRepo
    {
        private readonly islahiniDbContext dbContext;

        public TecnicianRepo(islahiniDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Technican> GetAllTechnicainWithUserInfos()
        {
            return dbContext.Technican.Include(x =>x.User)
                                      .Include(x=>x.Category)
                                      .ToList();
        }
    }
}
