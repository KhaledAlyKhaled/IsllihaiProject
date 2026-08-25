using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.ViewModels.CategoryViewModels
{
    public class CaregoryCreatedViewModel
    {
        [Required (ErrorMessage ="Name Is Requierd")]
        [MaxLength (50 , ErrorMessage ="Max Length Is 50")]
        public string Name { get; set; }
    }
}
