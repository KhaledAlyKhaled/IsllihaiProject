using IsllihaiProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Interface
{
    public interface IBookingRepo : IGenericRepo<Booking>
    {
        IEnumerable<Booking> GetAllWithCategoryAndUSerAndTech(Func<Booking,bool>? condition = null);
    }
}
