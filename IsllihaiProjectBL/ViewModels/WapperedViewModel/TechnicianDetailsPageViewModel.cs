using IsllihaiProjectBL.ViewModels.ReviewViewModels;
using IsllihaiProjectBL.ViewModels.TechnicainViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.ViewModels.WapperedViewModel
{
    public class TechnicianDetailsPageViewModel
    {
        public IEnumerable<ReviewViewModel> Reviews { get; set; }
        public TechnicainViewModel Technician { get; set; }
    }
}
