using IsllihaiProjectBL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsllihaiProject.Controllers.Customer
{
    [Authorize]
    public class CustomerCategoreyController : Controller
    {
        private readonly ICategoryService categoryService;

        public CustomerCategoreyController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var cat = categoryService.GetAllCategories();
            return View(cat);
        }
    }
}
