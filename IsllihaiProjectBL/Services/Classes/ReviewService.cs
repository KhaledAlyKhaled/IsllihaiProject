using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectBL.ViewModels.ReviewViewModels;
using IsllihaiProjectDAL.Entities;
using IsllihaiProjectDAL.Entities.Enums;
using IsllihaiProjectDAL.Reposatories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.Services.Classes
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITechnicainService technicainService;

        public ReviewService(IUnitOfWork unitOfWork, ITechnicainService technicainService)
        {
            this.unitOfWork = unitOfWork;
            this.technicainService = technicainService;
        }

        public bool CreateReview(int bookingId, int customerId, CreateReviewViewModel vm)
        {

            var booking = unitOfWork.bookingRepo.GetById(bookingId);
            if (booking is null)
                return false;


            if (booking.UserId != customerId)
                return false;


            if (booking.Status != Status.Completed)
                return false;


            var existingReview = unitOfWork.reviewRepo.GetByBookingId(bookingId);
            if (existingReview is not null)
                return false;


            if (booking.TechnicanId is null)
                return false;

            var review = new Review
            {
                BookingId = bookingId,
                Rating = vm.Rating,
                Comment = vm.Comment,
                CreatedAt = DateTime.Now
            };

            try
            {
                unitOfWork.GetRepo<Review>().Add(review);
                var saved = unitOfWork.SaveChanges() > 0;

                if (saved)
                {

                    technicainService.UpdateAverageRating(booking.TechnicanId.Value);
                }

                return saved;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<ReviewViewModel> GetTechnicianReviews(int technicianId)
        {
            var reviews = unitOfWork.reviewRepo.GetReviewsByTechnicianId(technicianId);
            if (reviews is null || !reviews.Any())
                return [];

            return reviews.Select(r => new ReviewViewModel
            {
                Id = r.Id,
                Rating = r.Rating,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt,
                CustomerName = r.Booking.User.name
            });
        }
    }
}
