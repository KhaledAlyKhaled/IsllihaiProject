using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.ViewModels.ReviewViewModels
{
    public class CreateReviewViewModel
    {
        [Required(ErrorMessage = "Rating Is Required")]
        [Range(1, 5, ErrorMessage = "Rating Must Be Between 1 And 5")]
        public double Rating { get; set; }

        [MaxLength(500, ErrorMessage = "Max Length Is 500")]
        public string? Comment { get; set; }
    }
}
