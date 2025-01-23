using System;
using System.Threading;
using System.Threading.Tasks;
using Enviromental_Measurement.Contracts;
using Eviromental_Variable_Measurement.Application.Abstract;



namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.SampleCommands.DeleteSample
{
    public class DeleteSampleCommandHandler : ICommandHandler<DeleteSampleCommand, bool>
    {
        private readonly ISampleRepository _sampleRepository; 
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSampleCommandHandler(
            ISampleRepository sampleRepository,
            IUnitOfWork unitOfWork)
        {
            _sampleRepository = sampleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteSampleCommand request, CancellationToken cancellationToken)
        {
            bool result = true;

            // Lógica para eliminar la muestra
            _sampleRepository.Delete(request.Id);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
