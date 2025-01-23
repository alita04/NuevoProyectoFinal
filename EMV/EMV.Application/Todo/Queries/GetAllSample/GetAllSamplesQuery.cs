
using Enviromental_Measurement.Domain.Entities.Samples;

using MediatR;
using System.Collections.Generic;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Queries.GetAllSample
{
    public class GetAllSamplesQuery : IRequest<List<Sample>>
    {
    }
}
