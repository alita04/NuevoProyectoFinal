using EMV.Domain.Entities.Structures;
using System;
using System.Threading;
using System.Threading.Tasks;
using EMV.Contracts;
using EMV.Application.Abstract;



namespace EMV.Application.Varaibles.Commands.FloorCommands.UpdateFloor
{
    public class UpdateFloorCommandHandler : ICommandHandler<UpdateFloorCommand, bool>
    {
        private readonly IFloorRepository _floorRepository; 
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFloorCommandHandler(
            IFloorRepository floorRepository,
            IUnitOfWork unitOfWork)
        {
            _floorRepository = floorRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(UpdateFloorCommand request, CancellationToken cancellationToken)
        {
            // Buscar el piso existente
            var existingFloor = _floorRepository.GetById(request.Id);

            if (existingFloor == null)
            {
                return Task.FromResult(false); // Devuelve false si no se encuentra el piso
            }

            // Crear un nuevo objeto Floor con los valores actualizados usando el constructor
            var updatedFloor = new Floor(
                existingFloor.Id, // Mantener el mismo ID
                request.Location,
                request.Building_Id
            );

            // Actualizar el piso en el repositorio
            _floorRepository.Update(updatedFloor);
            _unitOfWork.SaveChanges();

            return Task.FromResult(true); // Devuelve true si la actualización fue exitosa
        }
    }
}