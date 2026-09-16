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
    public class CategoreyRepo : GenericRepo<Category>, ICategoreyRepo
    {
        private readonly islahiniDbContext dbContext;

        public CategoreyRepo(islahiniDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    
public IEnumerable<Category> GetAllWithTechAndBooking(Func<Category, bool>? Condition = null)
        {
            if (Condition is null)
                return dbContext.Category.Include(x => x.Technicans)
                .Include(x => x.Bookings)
                .AsNoTracking()
                .ToList();
            else
                return dbContext.Category.Include(x => x.Technicans)
                .Include(x => x.Bookings)
                .AsNoTracking()
                .Where(Condition)
                .ToList();
        }

        public Category GetByIdWithTechAndBooking(int id)
        {
            return dbContext.Category.Include(x => x.Technicans)
                .Include(x => x.Bookings).FirstOrDefault(x=>x.Id ==id);
        }
    }
}
