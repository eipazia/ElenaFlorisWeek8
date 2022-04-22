using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.InterfaceRepository
{
    public interface IRepositoryContatti :IRepository<Contatto>
    {
        Contatto GetByIdC(int id);
    }
}
