using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectBL.ViewModels.CategoryViewModels;
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
            var category = unitOfWork.GetRepo<Category>().GetById(id);

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
    }
    }

