using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.ViewModels.BookingViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string? TechName { get; set; }
        public DateTime StartDate { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
}
