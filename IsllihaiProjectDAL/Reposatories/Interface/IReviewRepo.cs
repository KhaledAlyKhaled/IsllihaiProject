using IsllihaiProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Interface
{
    public interface IReviewRepo : IGenericRepo<Review>
    {
        IEnumerable<Review> GetReviewsByTechnicianId(int technicianId);
        Review? GetByBookingId(int bookingId);

    }
}
