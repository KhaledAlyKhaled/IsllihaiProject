using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectBL.ViewModels.BookingViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IsllihaiProject.Controllers.Customer
{
    [Authorize (Roles = "Customer")]
    public class BookingController : Controller
    {
        private readonly IBookingServices bookingServices;
        private readonly ITechnicainService technicainService;

        public BookingController(IBookingServices bookingServices, ITechnicainService technicainService)
        {
            this.bookingServices = bookingServices;
            this.technicainService = technicainService;
        }
        [HttpGet]
        public IActionResult MyBookings()
        {
            var id =int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var booking = bookingServices.GetAllSpecifiecCustomerBooking(id);
            return View(booking);
        }
        [HttpGet]
        public IActionResult Create(int technicianId)
        {
            var tech = technicainService.GetTechnicainById(technicianId);
            if (tech is null)
                return NotFound();

            ViewBag.Technician = tech;
            return View(new CreatedBookingViewModel { TechnicanId = technicianId });
        }
        [HttpPost]
        public IActionResult Create (CreatedBookingViewModel vm)
        {
            var userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            if (userid <= 0) 
                return BadRequest();
            var created = bookingServices.CreateBooking(userid, vm);
            if (!created)
            {
                ModelState.AddModelError("", "حصل خطأ في إنشاء الطلب");
                return View(vm);
            }

            return RedirectToAction(nameof(MyBookings));
        }
        [HttpPost]
        public IActionResult Cancel(int bookingid)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            if (userId <= 0 || bookingid <= 0)
                return NotFound();

            var result = bookingServices.CancelTheBooking(bookingid, userId);
            TempData[result ? "Success" : "Fail"] = result ? "تم حذف الطلب" : "حصل خطأ، تأكد إن الطلب ده بتاعك";
            return RedirectToAction(nameof(MyBookings), new { id = userId });
        }

    }
}
