using IsllihaiProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Interface
{
    public interface ITecnicianRepo :IGenericRepo<Technican>
    {
        IEnumerable<Technican> GetAllTechnicainWithUserInfos();
    }
}
