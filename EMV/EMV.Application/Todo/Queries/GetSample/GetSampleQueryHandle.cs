using Enviromental_Measurement.Domain.Entities.Samples;
using System;
using System.Threading;
using System.Threading.Tasks;
using Eviromental_Variable_Measurement.Application.Abstract;
using Enviromental_Measurement.Contracts;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Queries.GetSample
{
    public class GetSampleByIdQueryHandler : IQueryHandler<GetSampleByIdQuery, Sample>
    {
        private readonly ISampleRepository _sampleRepository; 

        public GetSampleByIdQueryHandler(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public Task<Sample> Handle(GetSampleByIdQuery request, CancellationToken cancellationToken)
        {
            // Obtener la muestra del repositorio
            Sample sample = _sampleRepository.GetById(request.Id);

            return Task.FromResult(sample);
        }
    }
}