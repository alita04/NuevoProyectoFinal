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
    public class BuildingRepository : RepositoryBase<Building>, IBuildingRepository
    {
        public BuildingRepository(ApplicationContext context) : base(context)
        {
        }

       
    }

}
