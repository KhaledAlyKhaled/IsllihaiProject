using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.ViewModels.TechnicainViewModels
{
    public class CreateTechnicainViewModel
    {
        public string Email { get; set; }
        public string TechnicainName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public int YearsOfExperince { get; set; }
        public int Phone {  get; set; }
        
    }
}
