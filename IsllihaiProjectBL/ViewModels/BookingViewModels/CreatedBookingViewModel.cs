using IsllihaiProjectDAL.Entities;
using IsllihaiProjectDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.ViewModels.BookingViewModels
{
    public class CreatedBookingViewModel
    {
        public int price { get; set; }
        public string Address { get; set; }
        public DateTime OrderedAt { get; set; }
        public string Description { get; set; }
        public Status Status = Status.Pending;
        public int? TechnicanId { get; set; } 
        public int CategoryId { get; set; }

    }
}
