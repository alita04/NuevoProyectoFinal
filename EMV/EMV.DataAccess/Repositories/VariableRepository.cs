using Enviromental_Measurement.Contracts;
using Enviromental_Measurement.DataAccess.Contexts;
using Enviromental_Measurement.DataAccess.Repositories.Common;
using Enviromental_Measurement.Domain.Entities.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviromental_Measurement.DataAccess.Repositories
{
    public class VariableRepository : RepositoryBase<Variable>, IVariableRepository
    {
        public VariableRepository(ApplicationContext context) : base(context)
        {
        }


    }
}
