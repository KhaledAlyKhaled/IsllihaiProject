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
    public class BookingRepo : GenericRepo<Booking>, IBookingRepo
    {
        private readonly IslahiniDbContext dbContext;

        public BookingRepo(IslahiniDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Booking> GetAllWithCategoryAndUSerAndTech(Expression<Func<Booking, bool>>? condition = null)
        {
            if (condition is null)
                return dbContext.Bookings.Include(x => x.Category)
                .Include(x => x.User)
                .Include(x => x.Technican)
                .AsNoTracking()
                .ToList();
            else
                return dbContext.Bookings.Include(x => x.Category)
                .Include(x => x.User)
                .Include(x => x.Technican)
                .AsNoTracking()
                .Where(condition)
                .ToList();

        }

        public Booking GetAllWithCategoryAndUSerAndTech(int id)
        {
            return dbContext.Bookings.Include(x => x.Category)
                .Include(x => x.User)
                .Include(x => x.Technican)
                .AsNoTracking().FirstOrDefault(x=>x.Id == id);
        }
    }
}
