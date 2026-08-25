using IsllihaiProjectBL.ViewModels.CategoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable <CaregoryViewModel> GetAllCategories ();
        bool CreateCategory (CaregoryCreatedViewModel category);
        CaregoryViewModel? GetCategoryById (int id);
        CaregoryCreatedViewModel? CategoryToUpdate(int id);
        bool UpdateCategory(int Id,CaregoryCreatedViewModel category);
        bool DeleteCategory(int Id);
    }
}
