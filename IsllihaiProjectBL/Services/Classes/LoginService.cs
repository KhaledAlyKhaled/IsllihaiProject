using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectBL.ViewModels.AccountViewModel;
using IsllihaiProjectDAL.Entities;
using IsllihaiProjectDAL.Entities.Enums;
using IsllihaiProjectDAL.Reposatories.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.Services.Classes
{
    public class LoginService :ILoginService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUnitOfWork unitOfWork;

        public LoginService(UserManager<ApplicationUser> userManager , IUnitOfWork unitOfWork) 
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        public ApplicationUser Cheack_Email_Avilable(RegisterViewModel user)
        {
         var UserEmail = userManager.FindByEmailAsync(user.Email).Result;

            if (UserEmail is null)
                return UserEmail;
            else
                return null;

        }

        public async Task<List<string>> RegisterAsync(RegisterViewModel model)
        {
            var errors = new List<string>();

            if (model.Role != RoleNames.Customer && model.Role != RoleNames.Technician)
            {
                errors.Add("نوع الحساب غير صحيح");
                return errors;
            }
            bool isTechnician = model.Role == RoleNames.Technician;

            if (isTechnician)
            {
                if (model.CategoryId is null || model.YearsOfExperience is null)
                {
                    errors.Add("اختار التخصص واكتب سنين الخبرة");
                    return errors;
                }

                var category = unitOfWork.GetRepo<Category>().GetById(model.CategoryId.Value);
                if (category is null)
                {
                    errors.Add("التخصص ده غير موجود");
                    return errors;
                }
            }

            var user = new ApplicationUser
            {
                name = model.FullName,
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var createResult = await userManager.CreateAsync(user, model.Password);
            if (!createResult.Succeeded)
            {
                errors.AddRange(createResult.Errors.Select(e => e.Description));
                return errors;
            }

            var roleResult = await userManager.AddToRoleAsync(user, model.Role);
            if (!roleResult.Succeeded)
            {
                await userManager.DeleteAsync(user);   
                errors.Add("حصل خطأ أثناء تحديد نوع الحساب، حاول تاني");
                return errors;
            }

            
            if (isTechnician)
            {
                try
                {
                    unitOfWork.GetRepo<Technican>().Add(new Technican
                    {
                        UserId = user.Id,
                        CategoryId = model.CategoryId!.Value,
                        YearsOfExperience = model.YearsOfExperience!.Value,
                        IsVertified = false,
                        AvgRating = 0,
                        City = model.City,
                    });
                    unitOfWork.SaveChanges();
                }
                catch (Exception)
                {
                    await userManager.DeleteAsync(user);
                    errors.Add("حصل خطأ أثناء إنشاء بروفايل الفني، حاول تاني");
                }
            }

            return errors;
        }

        public ApplicationUser User(ApplicationUserViewModel user)
        {
            var useremail =userManager.FindByEmailAsync(user.Email).GetAwaiter().GetResult();
            if (useremail is null)
                return null;
            var userpassword = userManager.CheckPasswordAsync(useremail, user.Password);
            
                return useremail;
        }
    }
}
