

using MediatR;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Enviromental_Measurement.Contracts;
using Enviromental_Measurement.Domain.Entities.Samples;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Queries.GetAllSample
{
    public class GetAllSamplesQueryHandler : IRequestHandler<GetAllSamplesQuery, List<Sample>>
    {
        private readonly ISampleRepository _sampleRepository;

        public GetAllSamplesQueryHandler(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public Task<List<Sample>> Handle(GetAllSamplesQuery request, CancellationToken cancellationToken)
        {
            var samples = _sampleRepository.GetAll();
            return Task.FromResult(samples.ToList());
        }
    }
}