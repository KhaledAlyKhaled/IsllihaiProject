using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectBL.ViewModels.ReviewViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsllihaiProject.Controllers.Customer
{
    [Authorize (Roles = "Customer")]
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly IBookingServices bookingServices;

        public ReviewController(IReviewService reviewService, IBookingServices bookingServices)
        {
            this.reviewService = reviewService;
            this.bookingServices = bookingServices;
        }

        [HttpGet]
        public IActionResult Create(int bookingId)
        {
            return View(new CreateReviewViewModel());
        }

        [HttpPost]
        public IActionResult Create(int bookingId ,int userid, CreateReviewViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            
            var result = reviewService.CreateReview(bookingId, userid, vm);

            if (!result)
            {
                ModelState.AddModelError("", "مينفعش تقيّم الطلب ده دلوقتي");
                return View(vm);
            }

            return RedirectToAction("MyBookings", "Booking");
        }
    }
}
