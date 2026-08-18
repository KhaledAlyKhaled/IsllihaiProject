using IsllihaiProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Reposatories.Interface
{
    public interface ITecnicainRepo
    {
        IEnumerable<Technican> GetAll();

        int Add(Technican technican);
        int Update(Technican technican);
        Technican? GetById(int Id);
        int Delete(int id);
    }
}
