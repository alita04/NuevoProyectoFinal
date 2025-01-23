using System;
using System.Threading;
using System.Threading.Tasks;
using EMV.Contracts;
using EMV.Application.Abstract;



namespace EMV.Application.Varaibles.Commands.FloorCommands.DeleteFloor
{
    public class DeleteFloorCommandHandler : ICommandHandler<DeleteFloorCommand, bool>
    {
        private readonly IFloorRepository _floorRepository; 
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFloorCommandHandler(
            IFloorRepository floorRepository,
            IUnitOfWork unitOfWork)
        {
            _floorRepository = floorRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteFloorCommand request, CancellationToken cancellationToken)
        {
            bool result = true;

            // Lógica para eliminar el piso
            _floorRepository.Delete(request.Id);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}