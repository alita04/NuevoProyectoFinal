using Enviromental_Measurement.Domain.Entities.Structures;
using System;
using System.Threading;
using System.Threading.Tasks;
using Enviromental_Measurement.Contracts;
using Eviromental_Variable_Measurement.Application.Abstract;


namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.FloorCommands.CreateCommands
{
    public class CreateFloorCommandHandler : ICommandHandler<CreateFloorCommand, Floor>
    {
        private readonly IFloorRepository _floorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFloorCommandHandler(
            IFloorRepository floorRepository,
            IUnitOfWork unitOfWork)
        {
            _floorRepository = floorRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Floor> Handle(CreateFloorCommand request, CancellationToken cancellationToken)
        {
            // Crear una nueva instancia de Floor
            var floor = new Floor
            {
                Id = Guid.NewGuid(), // Asigna un nuevo ID
                Location = request.Location,
                Building_Id = request.Building_Id
            };

            // Agregar el piso al repositorio
            _floorRepository.Add(floor);
            _unitOfWork.SaveChanges();

            return Task.FromResult(floor);
        }
    }
}