using IsllihaiProjectBL.ViewModels.ReviewViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.Services.Interfaces
{
    public interface IReviewService
    {
        bool CreateReview(int bookingId, int customerId, CreateReviewViewModel vm);
        IEnumerable<ReviewViewModel> GetTechnicianReviews(int technicianId);
    }
}
