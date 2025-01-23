using System;
using System.Threading;
using System.Threading.Tasks;
using Enviromental_Measurement.Contracts;
using Eviromental_Variable_Measurement.Application.Abstract;


namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.BuildingCommand.DeleteBuilding
{
    public class DeleteBuildingCommandHandler : ICommandHandler<DeleteBuildingCommand, bool>
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBuildingCommandHandler(
            IBuildingRepository buildingRepository,
            IUnitOfWork unitOfWork)
        {
            _buildingRepository = buildingRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            bool result = true;

            // Lógica para eliminar el edificio
            _buildingRepository.Delete(request.Id);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}