

using MediatR;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EMV.Contracts;
using EMV.Domain.Entities.Samples;

namespace EMV.Application.Varaibles.Queries.GetAllSample
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