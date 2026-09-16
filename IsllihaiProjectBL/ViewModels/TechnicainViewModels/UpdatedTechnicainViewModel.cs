using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.ViewModels.TechnicainViewModels
{
    public class UpdatedTechnicainViewModel
    {
        [Required (ErrorMessage ="You Didn't Choose Category")]
        public int CategoryId { get; set; }
        [Required (ErrorMessage ="This Field Is Requierd")]
        [Range (0,60 , ErrorMessage ="Filed Cann't Be Negitaive Number Or Above 60")]
        public int YearsOfExperiance { get; set; }
        [Required (ErrorMessage = "This Field Is Requierd")]
        public bool IsVertified { get; set; }
    }
}
