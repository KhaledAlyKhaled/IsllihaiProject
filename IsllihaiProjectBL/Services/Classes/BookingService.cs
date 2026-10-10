using IsllihaiProjectBL.Services.Interfaces;
using IsllihaiProjectBL.ViewModels.BookingViewModels;
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
    public class BookingService : IBookingServices
    {
        private readonly IUnitOfWork unitOfWork;

        public BookingService (IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }

        public bool AcceptTheBooking(int BookingId, int TechnicainId)
        {
            var booking = unitOfWork.bookingRepo.GetById(BookingId);

            if (booking is null || booking.TechnicanId != TechnicainId  || booking.Status !=Status.Pending)
                return false;

            booking.Status = Status.Accepted;
            try
            {
                unitOfWork.GetRepo<Booking>().Update(booking);
                return unitOfWork.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CancelTheBooking(int BookingId, int CustomerId)
        {
            var booking = unitOfWork.bookingRepo.GetById(BookingId);

            if (booking is null || booking.UserId != CustomerId || booking.Status == Status.Completed || booking.Status == Status.Cancelled)
                return false;

            booking.Status = Status.Cancelled;
            try
            {
                unitOfWork.GetRepo<Booking>().Update(booking);
                return unitOfWork.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CompleteTheBooking(int BookingId, int TechnicainId)
        {
            var booking = unitOfWork.bookingRepo.GetById(BookingId);

            if (booking is null || booking.TechnicanId != TechnicainId || booking.Status != Status.InProgress)
                return false;

            booking.Status = Status.Completed;
            try
            {
                unitOfWork.GetRepo<Booking>().Update(booking);
                return unitOfWork.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CreateBooking(int UserId , CreatedBookingViewModel model)
        {
            try
            {
                if (model.TechnicanId is null) return false;
                var tech = unitOfWork.tecnicianRepo.GetTechnicanById(model.TechnicanId.Value);
                if (tech is null || !tech.IsVertified) return false;
                var booking = new Booking
                {
                    price =model.price,
                    Address =model.Address,
                    OrderedAt = model.OrderedAt,
                    Description = model.Description,
                    Status = Status.Pending,
                    UserId = UserId,
                    TechnicanId = model.TechnicanId,
                    CategoryId = tech.CategoryId,
                };

                unitOfWork.GetRepo<Booking>().Add(booking);
                return unitOfWork.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public IEnumerable<BookingAdminViewModel> GetAllBookings()
        {
            var AllBookings = unitOfWork.bookingRepo.GetAllWithCategoryAndUSerAndTech();
            if (!AllBookings.Any())
                return [];

            var BookingViewModelToReturn = AllBookings.Select(booking => new BookingAdminViewModel
            {
                Id = booking.Id,
                CategoryName =booking.Category.Name,
                CustomerName=booking.User.name,
                TechName=booking.Technican?.User.name ?? "—",
                StartDate=booking.OrderedAt.Date,
                Status =booking.Status.ToString()
            });

            return BookingViewModelToReturn;

        }

        public IEnumerable<BookingViewModel>? GetAllSpecifiecCustomerBooking(int customerId)
        {
            var BookingToReturn = unitOfWork.bookingRepo.GetAllWithCategoryAndUSerAndTech(x=> x.UserId == customerId);
            if (!BookingToReturn.Any())
                return [];

            var booking = BookingToReturn.Select(x => new BookingViewModel
            {
                Id = x.Id,
                CategoryName = x.Category.Name,
                TechName = x.Technican?.User.name ?? "—",
                StartDate=x.OrderedAt.Date,
                Address = x.Address,
                Status = x.Status.ToString()
            });

            return booking;
        }

        public IEnumerable<BookingTechnicainViewModel> GetAllSpecifiecTechnicainBooking(int TechnicainId)
        {
            var booking = unitOfWork.bookingRepo.GetAllWithCategoryAndUSerAndTech(x=>x.TechnicanId == TechnicainId);
            if (!booking.Any())
                return [];

            var BookingToReturn = booking.Select(x => new BookingTechnicainViewModel
            {
                Id = x.Id,
                Address = x.Address,
                customerName = x.User.name,
                Description = x.Description,
                StartDate = x.OrderedAt.Date,
                Status = x.Status.ToString(),
                Phone = x.User.PhoneNumber
                
            });

            return BookingToReturn;
        }

        public BookingAdminViewModel GetBookingDetails(int BookingId)
        {
            var AllBookings = unitOfWork.bookingRepo.GetAllWithCategoryAndUSerAndTech(BookingId);
            if (AllBookings is null)
                return null;

            var BookingViewModelToReturn =  new BookingAdminViewModel
            {
                Id = AllBookings.Id,
                Adress = AllBookings.Address.ToString(),
                CategoryName = AllBookings.Category.Name,
                CustomerName = AllBookings.User.name,
                Description = AllBookings.Description,
                StartDate= AllBookings.OrderedAt.Date,
                Status = AllBookings.Status.ToString(),
                Price = AllBookings.price,
                TechName = AllBookings.Technican.User.name
                
            };

            return BookingViewModelToReturn;
        }

        public bool RejectTheBooking(int BookingId, int TechnicainId)
        {
            var booking = unitOfWork.bookingRepo.GetById(BookingId);

            if (booking is null || booking.TechnicanId != TechnicainId || booking.Status != Status.Pending)
                return false;

            booking.Status = Status.Rejected;
            try
            {
                unitOfWork.GetRepo<Booking>().Update(booking);
                return unitOfWork.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool StartTheBooking(int BookingId, int TechnicainId)
        {
            var booking = unitOfWork.bookingRepo.GetById(BookingId);

            if (booking is null || booking.TechnicanId != TechnicainId || booking.Status != Status.Accepted)
                return false;

            booking.Status = Status.InProgress;
            try
            {
                unitOfWork.GetRepo<Booking>().Update(booking);
                return unitOfWork.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
