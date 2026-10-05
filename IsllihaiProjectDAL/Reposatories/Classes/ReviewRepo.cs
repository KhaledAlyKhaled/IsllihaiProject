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
    public class ReviewRepo : GenericRepo<Review>, IReviewRepo
    {
        private readonly IslahiniDbContext dbContext;

        public ReviewRepo(IslahiniDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Review> GetReviewsByTechnicianId(int technicianId)
        {
            return dbContext.Reviews
                .Include(r => r.Booking)
                    .ThenInclude(b => b.User)
                .Where(r => r.Booking.TechnicanId == technicianId)
                .AsNoTracking()
                .ToList();
        }

        public Review? GetByBookingId(int bookingId)
        {
            return dbContext.Reviews
                .FirstOrDefault(r => r.BookingId == bookingId);
        }
    }
}