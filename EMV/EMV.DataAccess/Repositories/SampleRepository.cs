using EMV.Contracts;
using EMV.DataAccess.Contexts;
using EMV.DataAccess.Repositories.Common;
using EMV.Domain.Entities;
using EMV.Domain.Entities.Samples;
using EMV.Domain.Entities.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMV.DataAccess.Repositories
{
    public class SampleRepository : RepositoryBase<Sample>, ISampleRepository
    {
        public SampleRepository(ApplicationContext context) : base(context)
        {
        }

        // Aquí puedes agregar métodos específicos para Building si es necesario




    }

}
