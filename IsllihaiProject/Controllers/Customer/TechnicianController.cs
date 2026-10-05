using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectDAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsllihaiProject.Controllers.Customer
{
    [Authorize]
    public class TechnicianController : Controller
    {
        private readonly ITechnicainService technicainService;

        public TechnicianController(ITechnicainService technicainService)
        {
            this.technicainService = technicainService;
        }
        public IActionResult Search(int categoryId,string city,double minRating)
        {
            var tec = technicainService.SearchTechnicains(categoryId, minRating, city);
            
            return View(tec);
        }
        public IActionResult Details(int tecId)
        {
            var tec = technicainService.GetForDetailsPage(tecId);
            return View(tec);
        }
    }
}
