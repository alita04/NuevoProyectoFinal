using Enviromental_Measurement.Domain.Entities.Samples; 
using System;
using System.Threading;
using System.Threading.Tasks;
using Enviromental_Measurement.Contracts;

using Enviromental_Measurement.Domain.Types;
using Eviromental_Variable_Measurement.Application.Abstract;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.SampleCommands.CreateSample
{
    public class CreateSampleCommandHandler : ICommandHandler<CreateSampleCommand, Sample>
    {
        private readonly ISampleRepository _sampleRepository; 
        private readonly IUnitOfWork _unitOfWork;

        public CreateSampleCommandHandler(
            ISampleRepository sampleRepository,
            IUnitOfWork unitOfWork)
        {
            _sampleRepository = sampleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Sample> Handle(CreateSampleCommand request, CancellationToken cancellationToken)
        {
            // Crear una nueva instancia de Sample
            var sample = new Sample
            {
                Id = Guid.NewGuid(), // Asigna un nuevo ID
                DateTime = request.DateTime,
                VariableId = request.VariableId,
                type = request.Type,
                DecimalValue = request.Type == SampleType.ContinueSample ? request.DecimalValue : null,
                IntValue = request.Type == SampleType.DiscreteSample ? request.IntValue : null,
                BoolValue = request.Type == SampleType.BooleanSample ? request.BoolValue : null
            };

            // Agregar la muestra al repositorio
            _sampleRepository.Add(sample);
            _unitOfWork.SaveChanges();

            return Task.FromResult(sample);
        }
    }
}