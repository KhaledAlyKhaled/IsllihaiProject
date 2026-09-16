using IsllihaiProjectBL.ViewModels.TechnicainViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.ViewModels.CategoryViewModels
{
    public class CategoreyTechesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfTechnicians { get; set; }
        public int NumberOfBookings { get; set; }
        public IEnumerable<TechnicainViewModel> Technicians { get; set; } = [];
    }
}
