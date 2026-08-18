using IsllihaiProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Interface
{
    public interface IBookingRepo
    {
        IEnumerable<Booking> GetAll();

        int Add(Booking booking);
        int Update(Booking booking);
        Booking? GetById(int Id);
        int Delete(int id);
    }
}
