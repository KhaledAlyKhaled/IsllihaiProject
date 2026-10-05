using IsllihaiProjectBL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsllihaiProject.Controllers.Admin
{
    [Authorize(Roles ="Admin")]
    public class AdminBookingController : Controller
    {
        private readonly IBookingServices bookingServices;

        public AdminBookingController(IBookingServices bookingServices)
        {
            this.bookingServices = bookingServices;
        }
        public IActionResult Index()
        {
            var booking = bookingServices.GetAllBookings();
            return View(booking);
        }
        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
                

                var booking = bookingServices.GetBookingDetails(id);
                if (booking is null)
                    return RedirectToAction(nameof(Index));
                else
                {
                    return View(booking);
                }
            
        }
    }
}
