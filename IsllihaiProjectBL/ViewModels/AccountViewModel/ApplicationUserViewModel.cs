using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.ViewModels.AccountViewModel
{
    public class ApplicationUserViewModel
    {
        [Required (ErrorMessage = "The Email Is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password Is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
