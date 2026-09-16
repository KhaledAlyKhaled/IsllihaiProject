using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectBL.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IsllihaiProject.Controllers.Admin
{
    public class AdminCategoreyController : Controller
    {
        private readonly ICategoryService _categoryService;   

        public AdminCategoreyController(ICategoryService categoryService)   
        {
            _categoryService = categoryService;   
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCateGoriesForAdmin();
            return View(categories);
        }
        
        public IActionResult CategoreyDetails (int id)
        {
            var vm = _categoryService.GetAllTechesForCastegorey(id);
            if (vm == null) 
                return NotFound();
            return View(vm);
        }
        [HttpGet]
        public IActionResult Create ()
        {
            return View(new CaregoryCreatedViewModel());
        }

        [HttpPost]
        public IActionResult Create(CaregoryCreatedViewModel vm)
        {
            if(!ModelState.IsValid)
                return View(vm);
            var result = _categoryService.CreateCategory(vm);
            if (!result)
            {
                ModelState.AddModelError(nameof(vm.Name), "التصنيف ده موجود بالفعل");
                return View(vm);
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Edit (int id)
        {
            var categorey = _categoryService.CategoryToUpdate(id);
            return View(categorey);
        }
        [HttpPost]
        public ActionResult Edit(int id,CaregoryCreatedViewModel vm)
        {

            if (!ModelState.IsValid)
                return View(vm);
            var result = _categoryService.UpdateCategory(id,vm);
            if (!result)
            {
                ModelState.AddModelError(nameof(vm.Name), "الاسم ده موجود قبل كده");
                return View(vm);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
