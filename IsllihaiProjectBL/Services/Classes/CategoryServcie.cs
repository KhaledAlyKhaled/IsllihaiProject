using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectBL.ViewModels.CategoryViewModels;
using IsllihaiProjectBL.ViewModels.TechnicainViewModels;
using IsllihaiProjectDAL.Entities;
using IsllihaiProjectDAL.Reposatories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IsllihaiProjectBL.Services.Classes
{
    public class CategoryServcie : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryServcie (IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool CreateCategory(CaregoryCreatedViewModel category)
        {
            try
            {
                var NameExist = unitOfWork.GetRepo<Category>().GetAll(X => X.Name == category.Name).Any();
                if (NameExist)
                    return false;

                var cate = new Category
                {
                    Name = category.Name
                };

                unitOfWork.GetRepo<Category>().Add(cate);
                return unitOfWork.SaveChanges() >0;
            }
            catch (Exception) 
            {
                return false;
            }
            
        }

        public IEnumerable<CaregoryViewModel> GetAllCategories()
        {
         var Category = unitOfWork.GetRepo<Category>().GetAll() ?? [];

            
         var CategoryViewModels = Category.Select(x => new CaregoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }
           );
            return CategoryViewModels;
                
            }

        public CaregoryViewModel? GetCategoryById(int id)
        {
            var category = unitOfWork.categoreyRepo.GetByIdWithTechAndBooking(id);

            if (category is null) 
                return null;

            var ViewModel = new CaregoryViewModel
            {
                Id =category.Id,
                Name = category.Name,
            }
            ;
            return ViewModel;
        }

        public CaregoryCreatedViewModel? CategoryToUpdate(int id)
        {
            var categoryToUpdate = unitOfWork.GetRepo<Category>().GetById(id);
            if (categoryToUpdate is null)
                return null;
            return new CaregoryCreatedViewModel
            {
                Name = categoryToUpdate.Name
            };
  
        }

        public bool UpdateCategory(int Id,CaregoryCreatedViewModel category)
        {
            try
            {
                var NameExiist = unitOfWork.GetRepo<Category>().GetAll(x => x.Name == category.Name && x.Id != Id).Any();
                if (NameExiist)
                    return false;

                var categorytoupdate = unitOfWork.GetRepo<Category>().GetById(Id);
                if (categorytoupdate is null)
                    return false;

                 categorytoupdate.Name = category.Name;
                 unitOfWork.GetRepo<Category>().Update(categorytoupdate);
                return unitOfWork.SaveChanges() >0;
            }
            catch 
            {
                return false;
            }
        }

        public bool DeleteCategory(int Id)
        {
            var RemoveTheMember = unitOfWork.GetRepo<Category>().GetById(Id);
            if (RemoveTheMember is null)
                return false;

            var TecExist =unitOfWork.GetRepo<Technican>().GetAll(x=> x.CategoryId == Id).Any();

            if (TecExist)
                return false;

            unitOfWork.GetRepo<Category>().Delete(RemoveTheMember);
            return unitOfWork.SaveChanges() > 0;
        }

        public IEnumerable<CategoryWithNumbersViewModel> GetAllCateGoriesWithNumbers()
        {
            var categoreyForAdmin = unitOfWork.categoreyRepo.GetAllWithTechAndBooking();
            if (categoreyForAdmin is null)
                return Enumerable.Empty<CategoryWithNumbersViewModel>();

            var CatToReturn = categoreyForAdmin.Select(x => new CategoryWithNumbersViewModel
            {
                CategoryName = x.Name,
                NumberOfBookings =x.Bookings.Count(),
                NumberOfTechnicains = x.Technicans.Count()
                
            });
            return CatToReturn;
        }

        public IEnumerable<CategoreyForAdminViewModel> GetAllCateGoriesForAdmin()
        {
            
            var Category = unitOfWork.categoreyRepo.GetAllWithTechAndBooking() ?? [];


            var CategoryViewModels = Category.Select(x => new CategoreyForAdminViewModel
            {
                Id = x.Id,
                Name = x.Name,
                NumberOfBooking = x.Bookings.Count(),
                NumberOfTechnicains= x.Technicans.Count(),
                NumberOfCategories = unitOfWork.GetRepo<Category>().GetAll().Count()
            }
              );
            return CategoryViewModels;

        }

        public CategoreyTechesViewModel GetAllTechesForCastegorey(int id)
        {
            var Cate = unitOfWork.categoreyRepo.GetByIdWithTechAndBooking(id);
            if (Cate is null)
                return null;

            var Tech = new CategoreyTechesViewModel 
            {
                Id =Cate.Id,
                Name=Cate.Name,
                NumberOfBookings =Cate.Bookings.Count(),
                NumberOfTechnicians = Cate.Technicans.Count(),
                Technicians = Cate.Technicans.Select(t => new TechnicainViewModel
                {
                    Id = t.Id,
                    TechnicainName = t.User.name,
                    YearsOfExperince = t.YearsOfExperience,
                    AVGRating = t.AvgRating,
                    IsVertifed = t.IsVertified,
                    CategoryName = Cate.Name
                })
            };

            return Tech;
        }

        public CategoreyForAdminViewModel GetCategoreyDetailsToDelete(int id)
        {
            var category = unitOfWork.categoreyRepo.GetByIdWithTechAndBooking(id);

            if (category is null)
                return null;

            var ViewModel = new CategoreyForAdminViewModel
            {
                Id = category.Id,
                Name = category.Name,
                NumberOfCategories =0,
                NumberOfBooking = category.Bookings.Count(),
                NumberOfTechnicains = category.Technicans.Count(),
               
            }
            ;
            return ViewModel;
        }
    }
    }
    

