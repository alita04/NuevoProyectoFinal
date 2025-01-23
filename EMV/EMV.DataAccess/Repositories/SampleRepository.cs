using Enviromental_Measurement.Contracts;
using Enviromental_Measurement.DataAccess.Contexts;
using Enviromental_Measurement.DataAccess.Repositories.Common;
using Enviromental_Measurement.Domain.Entities;
using Enviromental_Measurement.Domain.Entities.Samples;
using Enviromental_Measurement.Domain.Entities.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviromental_Measurement.DataAccess.Repositories
{
    public class SampleRepository : RepositoryBase<Sample>, ISampleRepository
    {
        public SampleRepository(ApplicationContext context) : base(context)
        {
        }

        // Aquí puedes agregar métodos específicos para Building si es necesario




    }

}
