using IsllihaiProjectBL.ViewModels.AccountViewModel;
using IsllihaiProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.Services.Interfaces
{
    public interface ILoginService
    {
        ApplicationUser User(ApplicationUserViewModel user);
        ApplicationUser Cheack_Email_Avilable(RegisterViewModel user);
        Task<List<string>> RegisterAsync(RegisterViewModel model);
    }
}
