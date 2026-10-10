using IsllihaiProjectBL.ViewModels.BookingViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.Services.Interfaces
{
    public interface IBookingServices
    {
        bool CreateBooking(int UserId, CreatedBookingViewModel model);
        bool AcceptTheBooking (int BookingId , int TechnicainId);
        bool RejectTheBooking(int BookingId, int TechnicainId);
        bool StartTheBooking(int BookingId, int TechnicainId);
        bool CancelTheBooking(int BookingId, int CustomerId);
        bool CompleteTheBooking(int BookingId, int TechnicainId);
        IEnumerable<BookingAdminViewModel> GetAllBookings();

        IEnumerable<BookingViewModel> GetAllSpecifiecCustomerBooking(int customerId);
        IEnumerable<BookingTechnicainViewModel>? GetAllSpecifiecTechnicainBooking(int TechnicainId);
        BookingAdminViewModel GetBookingDetails (int BookingId);


    }
}
