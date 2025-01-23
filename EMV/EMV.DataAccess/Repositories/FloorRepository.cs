using EMV.Contracts;
using EMV.DataAccess.Contexts;
using EMV.DataAccess.Repositories.Common;
using EMV.Domain.Entities.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMV.DataAccess.Repositories
{
    public class FloorRepository : RepositoryBase<Floor>, IFloorRepository
    {
        public FloorRepository(ApplicationContext context) : base(context)
        {
        }

        // Aquí puedes agregar métodos específicos para Building si es necesario
    }
}
