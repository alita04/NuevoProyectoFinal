using EMV.Domain.Entities.Structures; 
using System;
using System.Threading;
using System.Threading.Tasks;
using EMV.Contracts;
using EMV.Application.Abstract;


namespace EMV.Application.Varaibles.Commands.BuildingCommand.CreateBuilding
{
    public class CreateBuildingCommandHandler : ICommandHandler<CreateBuildingCommand, Building>
    {
        private readonly IBuildingRepository _buildingRepository; // Asegúrate de tener una interfaz para manejar los edificios
        private readonly IUnitOfWork _unitOfWork;

        public CreateBuildingCommandHandler(
            IBuildingRepository buildingRepository,
            IUnitOfWork unitOfWork)
        {
            _buildingRepository = buildingRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Building> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            // Crear una nueva instancia de Building
            var building = new Building
            {
                Id = Guid.NewGuid(), // Asigna un nuevo ID
                Address = request.Address,
                BuildingNumber = request.BuildingNumber
            };

            // Agregar el edificio al repositorio
            _buildingRepository.Add(building);
            _unitOfWork.SaveChanges();

            return Task.FromResult(building);
        }
    }
}