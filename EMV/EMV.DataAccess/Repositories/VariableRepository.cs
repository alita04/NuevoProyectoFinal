using EMV.Contracts;
using EMV.DataAccess.Contexts;
using EMV.DataAccess.Repositories.Common;
using EMV.Domain.Entities.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMV.DataAccess.Repositories
{
    public class VariableRepository : RepositoryBase<Variable>, IVariableRepository
    {
        public VariableRepository(ApplicationContext context) : base(context)
        {
        }


    }
}
