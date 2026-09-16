using IsllihaiProjectBL.ViewModels.TechnicainViewModels;
using IsllihaiProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.Services.Interfaces
{
    public interface ITechnicainService
    {
        IEnumerable <TechnicainViewModel> GetAllTechnicans ();
        bool VerifyTechnician(int Id);
        UpdatedTechnicainViewModel TechnicainToUpdate (int Id);
        bool UpdateTechnicaian (int Id,UpdatedTechnicainViewModel model);
        TechnicainViewModel GetTechnicainById (int Id);
        IEnumerable<TechnicainViewModel> SearchTechnicains(int CategoryId, double MinRating, string Address);
        IEnumerable<TechnicainViewModel> GetAllTechnicansForSpecificCategoreyForAdmin(int CategoreyId);

    }
}
