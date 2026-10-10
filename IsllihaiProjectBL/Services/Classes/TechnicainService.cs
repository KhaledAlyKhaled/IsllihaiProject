using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectBL.ViewModels.TechnicainViewModels;
using IsllihaiProjectBL.ViewModels.WapperedViewModel;
using IsllihaiProjectDAL.Entities;
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

        public IEnumerable<TechnicainViewModel> GetAllTechnicansForSpecificCategoreyForAdmin(int CategoreyId)
        {
            var Techs =unitOfWork.tecnicianRepo.GetAllTechnicainWithUserInfos(x=> x.CategoryId == CategoreyId);
            if (Techs  is null || !Techs.Any())
                return Enumerable.Empty<TechnicainViewModel>();

            var techsToReturn = Techs.Select(x => new TechnicainViewModel
            {
                Id = x.Id ,
                TechnicainName =x.User.name,
                AVGRating = x.AvgRating,
                YearsOfExperince=x.YearsOfExperience,
                IsVertifed =x.IsVertified,
                CategoryName =x.Category.Name,
            }
            );

            return techsToReturn;

        }

        public TechnicainViewModel GetTechnicainById(int Id)
        {
            var Tech = unitOfWork.tecnicianRepo.GetTechnicanById(Id);
            if (Tech is null)
                return null;

            var TechToBeReturned = new TechnicainViewModel
            {
                Id = Tech.Id,
                TechnicainName = Tech.User.name,
                CategoryName = Tech.Category.Name,
                YearsOfExperince = Tech.YearsOfExperience,
                IsVertifed = Tech.IsVertified,
                AVGRating = Tech.AvgRating
            };
            return TechToBeReturned;
        }

        public IEnumerable<TechnicainViewModel> SearchTechnicains(int CategoryId, double MinRating, string Address)
        {
            var Technicains = unitOfWork.tecnicianRepo.GetAllTechnicainWithUserInfos(x=> x.CategoryId == CategoryId && x.AvgRating >= MinRating && x.IsVertified == true);

            if (Technicains is null || !Technicains.Any())
                return [];

            
            var TechnicainsViewModelsResult = Technicains.Select(x => new TechnicainViewModel
            {
                Id = x.Id,
                TechnicainName = x.User.name,
                CategoryName = x.Category.Name,
                YearsOfExperince = x.YearsOfExperience,
                IsVertifed = x.IsVertified
                ,
                AVGRating = x.AvgRating

            });
            if (Address == null)
                return TechnicainsViewModelsResult;
            else
            {
                var Technicains2 = unitOfWork.tecnicianRepo.GetAllTechnicainWithUserInfos(x => x.CategoryId == CategoryId && x.AvgRating >= MinRating && x.City==Address && x.IsVertified == true);
                if (Technicains2 is null || !Technicains2.Any())
                    return [];
                var TechnicainsViewModelsResult2 = Technicains.Select(x => new TechnicainViewModel
                {
                    Id = x.Id,
                    TechnicainName = x.User.name,
                    CategoryName = x.Category.Name,
                    YearsOfExperince = x.YearsOfExperience,
                    IsVertifed = x.IsVertified
                ,
                    AVGRating = x.AvgRating


                });
                return TechnicainsViewModelsResult2;
            }
            
        }

        public UpdatedTechnicainViewModel TechnicainToUpdate(int Id)
        {
            var techToBeUpdated = unitOfWork.tecnicianRepo.GetTechnicanById(Id);
            if (techToBeUpdated is null)
                return null;
            return new UpdatedTechnicainViewModel
                {

            YearsOfExperiance = techToBeUpdated.YearsOfExperience,
            IsVertified = techToBeUpdated.IsVertified,
            CategoryId = techToBeUpdated.CategoryId
            };

        }

        public bool UpdateTechnicaian(int Id, UpdatedTechnicainViewModel model)
        {
            var Tech = unitOfWork.tecnicianRepo.GetTechnicanById(Id);
            if (Tech is null)
                return false;

            (Tech.YearsOfExperience, Tech.CategoryId, Tech.IsVertified)
                = (model.YearsOfExperiance, model.CategoryId, model.IsVertified);

            try
            {
                unitOfWork.GetRepo<Technican>().Update(Tech);
                return unitOfWork.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool VerifyTechnician(int Id)
        {
            var Tecnicain = unitOfWork.GetRepo<Technican>().GetById(Id);
            if (Tecnicain is null) 
                return false;

            if (Tecnicain.IsVertified)
                Tecnicain.IsVertified = false;
            else 
                Tecnicain.IsVertified = true;

            try
            {
                unitOfWork.GetRepo<Technican>().Update(Tecnicain);
                return unitOfWork.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool UpdateAverageRating(int technicianId)
        {
            var technician = unitOfWork.tecnicianRepo.GetTechnicanById(technicianId);
            if (technician is null)
                return false;

            var reviews = unitOfWork.reviewRepo.GetReviewsByTechnicianId(technicianId);
            if (!reviews.Any())
                return false;

            technician.AvgRating = reviews.Average(r => r.Rating);

            try
            {
                unitOfWork.GetRepo<Technican>().Update(technician);
                return unitOfWork.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TechnicianDetailsPageViewModel? GetForDetailsPage(int id)
        {
            var tec = unitOfWork.tecnicianRepo.GetTechnicanById(id);
            if (tec is null)
                return null;

            var review = unitOfWork.reviewRepo.GetReviewsByTechnicianId(id);

            var details = new TechnicianDetailsPageViewModel
            {
                Technician = new TechnicainViewModel
                {
                    TechnicainName = tec.User.name,
                    Id = id,
                    AVGRating =tec.AvgRating,
                    CategoreyId = tec.CategoryId,
                    CategoryName = tec.Category.Name,
                    IsVertifed = tec.IsVertified ,
                    YearsOfExperince =tec.YearsOfExperience
                }
                ,
                Reviews = review.Select(x=> new ViewModels.ReviewViewModels.ReviewViewModel
                {
                    Id = x.Id,
                    Comment = x.Comment,
                    CreatedAt = x.CreatedAt,
                    CustomerName =x.Booking.User.name,
                    Rating = x.Rating,
                })
                
            };

            return details;
        }
        public int GetTechnicianIdByUserId(int userId)
    => unitOfWork.GetRepo<Technican>().GetAll(t => t.UserId == userId).FirstOrDefault().Id;
    }
}
