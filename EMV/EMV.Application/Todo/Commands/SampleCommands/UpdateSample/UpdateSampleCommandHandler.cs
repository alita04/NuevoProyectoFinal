using Enviromental_Measurement.Domain.Entities.Samples; 
using System;
using System.Threading;
using System.Threading.Tasks;
using Enviromental_Measurement.Contracts;

using Eviromental_Variable_Measurement.Application.Abstract;


namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.SampleCommands.UpdateSample
{
    public class UpdateSampleCommandHandler : ICommandHandler<UpdateSampleCommand, bool>
    {
        private readonly ISampleRepository _sampleRepository; 
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSampleCommandHandler(
            ISampleRepository sampleRepository,
            IUnitOfWork unitOfWork)
        {
            _sampleRepository = sampleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(UpdateSampleCommand request, CancellationToken cancellationToken)
        {
            // Buscar la muestra existente
            var existingSample = _sampleRepository.GetById(request.Id);

            if (existingSample == null)
            {
                return Task.FromResult(false); // Devuelve false si no se encuentra la muestra
            }

            // Crear un nuevo objeto Sample con los valores actualizados usando el constructor
            var updatedSample = new Sample(
                existingSample.Id, // Mantener el mismo ID
                request.DateTime,
                request.VariableId,
                request.Type,
                request.DecimalValue,
                request.IntValue,
                request.BoolValue
            );

            // Actualizar la muestra en el repositorio
            _sampleRepository.Update(updatedSample);
            _unitOfWork.SaveChanges();

            return Task.FromResult(true); // Devuelve true si la actualización fue exitosa
        }
    }
}