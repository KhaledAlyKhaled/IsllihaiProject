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

        public IEnumerable<Booking>? GetAllWithCategoryAndUSerAndTech(Expression<Func<Booking, bool>>? condition = null)
        {
            if (condition is null)
                return WithRelations()
                .ToList();
            else
                return WithRelations()
                .Where(condition)
                .ToList();

        }

        public Booking? GetAllWithCategoryAndUSerAndTech(int id)
        {
            return WithRelations().FirstOrDefault(x=>x.Id == id);
        }
        private IQueryable<Booking> WithRelations() => dbContext.Bookings
    .Include(x => x.Category)
    .Include(x => x.User)                                  
    .Include(x => x.Technican).ThenInclude(t => t.User)    
    .AsNoTracking();
    }
}
