using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.ViewModels.TechnicainViewModels
{
    public class TechnicainViewModel
    {
        public int Id { get; set; }
        public string TechnicainName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public int YearsOfExperince { get; set; }
        public double AVGRating {  get; set; }
        public bool IsVertifed { get; set; }

    }
}
