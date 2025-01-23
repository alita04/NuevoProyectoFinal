using Enviromental_Measurement.Domain.Entities.Structures; // Ajusta según tu estructura de carpetas
using System;
using System.Threading;
using System.Threading.Tasks;
using Enviromental_Measurement.Contracts;
using Eviromental_Variable_Measurement.Application.Abstract;


namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.BuildingCommand.UpdateBuilding
{
    public class UpdateBuildingCommandHandler : ICommandHandler<UpdateBuildingCommand, bool>
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBuildingCommandHandler(
            IBuildingRepository buildingRepository,
            IUnitOfWork unitOfWork)
        {
            _buildingRepository = buildingRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            // Buscar el edificio existente
            var existingBuilding = _buildingRepository.GetById(request.Id);

            if (existingBuilding == null)
            {
                return Task.FromResult(false); // Devuelve false si no se encuentra el edificio
            }

            // Crear un nuevo objeto Building con los valores actualizados usando el constructor
            var updatedBuilding = new Building(
                existingBuilding.Id, // Mantener el mismo ID
                request.Address,
                request.BuildingNumber
            );

            // Actualizar el edificio en el repositorio
            _buildingRepository.Update(updatedBuilding);
            _unitOfWork.SaveChanges();

            return Task.FromResult(true); // Devuelve true si la actualización fue exitosa
        }
    }
}