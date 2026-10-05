using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectDAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsllihaiProject.Controllers.Technician
{
    [Authorize(Roles = "Technician")]
    public class TechnicianJobsController : Controller
    {
        private readonly ITechnicainService technicainService;
        private readonly IBookingServices bookingServices;

        public TechnicianJobsController(ITechnicainService technicainService , IBookingServices bookingServices)
        {
            this.technicainService = technicainService;
            this.bookingServices = bookingServices;
        }
        public IActionResult MyJobs(int id)
        {
            var tecBooking = bookingServices.GetAllSpecifiecTechnicainBooking(id);
            return View(tecBooking);
        }
        [HttpPost]
        public IActionResult Accept(int bookingid , int tecId)
        {
            if (tecId <= 0 || bookingid <= 0)
                return NotFound();

            var result = bookingServices.AcceptTheBooking(bookingid, tecId);
            TempData[result ? "Success" : "Fail"] = result ? "تم قبول الطلب" : "حصل خطأ، تأكد إن الطلب ده بتاعك";
            return RedirectToAction(nameof(MyJobs), new { id = tecId });
        }
        [HttpPost]
        public IActionResult Start(int bookingid, int tecId)
        {
            if (tecId <= 0 || bookingid <= 0)
                return NotFound();

            var result = bookingServices.StartTheBooking(bookingid, tecId);
            TempData[result ? "Success" : "Fail"] = result ? "بدء الطلب" : "حصل خطأ، تأكد إن الطلب ده بتاعك";
            return RedirectToAction(nameof(MyJobs), new { id = tecId });
        }
        [HttpPost]
        public IActionResult Complete(int bookingid, int tecId)
        {
            if (tecId <= 0 || bookingid <= 0)
                return NotFound();

            var result = bookingServices.CompleteTheBooking(bookingid, tecId);
            TempData[result ? "Success" : "Fail"] = result ? "تم انهاء الطلب" : "حصل خطأ، تأكد إن الطلب ده بتاعك";
            return RedirectToAction(nameof(MyJobs), new { id = tecId });
        }
        [HttpPost]
        public IActionResult Reject(int bookingid, int tecId)
        {
            if (tecId <= 0 || bookingid <= 0)
                return NotFound();

            var result = bookingServices.RejectTheBooking(bookingid, tecId);
            TempData[result ? "Success" : "Fail"] = result ? "تم قبول الطلب" : "حصل خطأ، تأكد إن الطلب ده بتاعك";
            return RedirectToAction(nameof(MyJobs), new { id = tecId });
        }
    }

}
