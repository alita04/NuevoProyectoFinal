using System;
using System.Threading;
using System.Threading.Tasks;
using EMV.Contracts;
using EMV.Application.Abstract;



namespace EMV.Application.Varaibles.Commands.SampleCommands.DeleteSample
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
