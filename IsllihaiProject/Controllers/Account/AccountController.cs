using IsllihaiProjectBL.Services.Classes;
using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectBL.ViewModels.AccountViewModel;
using IsllihaiProjectDAL.Entities;
using IsllihaiProjectDAL.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsllihaiProject.Controllers.Account
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ICategoryService categoryService;

        public ILoginService _LoginService { get; }
        public SignInManager<ApplicationUser> _SignInManager { get; }
        private void FillCategories()
        {
            ViewBag.Categories = new SelectList(categoryService.GetAllCategories(), "Id", "Name");
        }


        public AccountController(ILoginService loginService , SignInManager<ApplicationUser> signInManager , UserManager<ApplicationUser> userManager ,ICategoryService categoryService)
        {
            _LoginService = loginService;
            _SignInManager = signInManager;
            _userManager = userManager;
            this.categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(ApplicationUserViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var user = _LoginService.User(model);
            if (user is null)
                return View(model);
            
               var result = _SignInManager.PasswordSignInAsync(user, model.Password , true , false).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
                return View(model);
                 
            
        }

        [HttpGet]
        public IActionResult Register()
        {
            FillCategories();
            return View(new RegisterViewModel { Role = RoleNames.Customer });
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                FillCategories();      
                return View(model);
            }

            var errors = await _LoginService.RegisterAsync(model);
            if (errors.Count > 0)
            {
                foreach (var error in errors)
                    ModelState.AddModelError("", error);

                FillCategories();
                return View(model);
            }

            TempData["Success"] = model.Role == RoleNames.Technician
                ? "تم إنشاء الحساب. هتظهر في نتايج البحث بعد ما الأدمن يوثّق حسابك"
                : "تم إنشاء الحساب، سجّل دخول";
            return RedirectToAction(nameof(Login));
        }
        [HttpPost]
        public IActionResult LogOut()
        {
            _SignInManager.SignOutAsync().GetAwaiter().GetResult();

            return RedirectToAction(nameof(Login));
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }

}
