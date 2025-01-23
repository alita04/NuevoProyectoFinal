
using EMV.Domain.Entities.Samples;

using MediatR;
using System.Collections.Generic;

namespace EMV.Application.Varaibles.Queries.GetAllSample
{
    public class GetAllSamplesQuery : IRequest<List<Sample>>
    {
    }
}
