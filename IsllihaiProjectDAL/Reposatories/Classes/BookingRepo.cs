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
    public class BookingRepo : GenericRepo<Booking>, IBookingRepo
    {
        private readonly islahiniDbContext dbContext;

        public BookingRepo(islahiniDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Booking> GetAllWithCategoryAndUSerAndTech(Func<Booking, bool>? condition = null)
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
    }
}
