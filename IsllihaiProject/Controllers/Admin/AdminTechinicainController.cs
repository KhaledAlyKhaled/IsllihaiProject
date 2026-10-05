using IsllihaiProjectBL.Services.Classes;
using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectBL.ViewModels.CategoryViewModels;
using IsllihaiProjectBL.ViewModels.TechnicainViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsllihaiProject.Controllers.Admin
{
    [Authorize(Roles ="Admin")]
    public class AdminTechnicainController : Controller
    {
        private readonly ITechnicainService _technicainService;
        private readonly ICategoryService categoryService;

        public AdminTechnicainController(ITechnicainService technicainService ,ICategoryService categoryService)
        {
            _technicainService = technicainService;
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var Tec = _technicainService.GetAllTechnicans();
            return View(Tec);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var tec = _technicainService.TechnicainToUpdate(id);
            if (tec is null)
                return NotFound();

            ViewData["TechnicainId"] = id;
            ViewBag.Categories = new SelectList(categoryService.GetAllCategories(), "Id", "Name", tec.CategoryId);
            return View(tec);
        }
        [HttpPost]

        public ActionResult Edit(int id, UpdatedTechnicainViewModel vm)
        {

            if (!ModelState.IsValid)
                return View(vm);
            var result = _technicainService.UpdateTechnicaian(id, vm);
            if (!result)
            {
                ModelState.AddModelError(nameof(vm.YearsOfExperiance), "عدد سنين الخبرة سالب او اكتر من 20");
                return View(vm);
            }
            TempData["Success"] = "تم تعديل بيانات الفني";
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public IActionResult Verify(int id)
        {
            var result = _technicainService.VerifyTechnician(id);
            TempData[result ? "Success" : "Fail"] = result ? "تم تحديث حالة التوثيق" : "الفني ده مش موجود";
            return RedirectToAction(nameof(Index));
        }

    }
}
