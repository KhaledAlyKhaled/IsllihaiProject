using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.ViewModels.BookingViewModels
{
    public class BookingTechnicainViewModel
    {
        public int Id { get; set; }
        public string customerName { get; set; }
        public DateTime StartDate { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

    }
}
