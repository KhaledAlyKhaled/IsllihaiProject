using IsllihaiProjectBL.ViewModels.TechnicainViewModels;
using IsllihaiProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectBL.Services.Interfaces
{
    public interface ITechnicainService
    {
        IEnumerable <TechnicainViewModel> GetAllTechnicans ();
    }
}
