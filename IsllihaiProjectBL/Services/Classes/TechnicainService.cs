using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectBL.ViewModels.TechnicainViewModels;
using IsllihaiProjectDAL.Reposatories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.Services.Classes
{
    public class TechnicainService : ITechnicainService
    {
        private readonly IUnitOfWork unitOfWork;

        public TechnicainService(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<TechnicainViewModel> GetAllTechnicans()
        {
            var Technicains = unitOfWork.tecnicianRepo.GetAllTechnicainWithUserInfos();

            if (Technicains is null || !Technicains.Any())
                return [];

            var TechnicainsViewModelsResult = Technicains.Select(x => new TechnicainViewModel
            {
                Id = x.Id,
                TechnicainName = x.User.name,
                CategoryName = x.Category.Name,
                YearsOfExperince = x.YearsOfExperience,
                IsVertifed = x.IsVertified
                , AVGRating = x.AvgRating

            });
            return TechnicainsViewModelsResult;
        }
    }
}
