
using EMV.Contracts;
using EMV.Domain.Entities.Structures;

using MediatR;


namespace EMV.Application.Varaibles.Queries.GetAllBuilding
{
    public class GetAllBuildingsQueryHandler : IRequestHandler<GetAllBuildingsQuery, List<Building>>
    {
        private readonly IBuildingRepository _buildingRepository;

        public GetAllBuildingsQueryHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public Task<List<Building>> Handle(GetAllBuildingsQuery request, CancellationToken cancellationToken)
        {
            // Obtener todos los edificios del repositorio
            var buildings = _buildingRepository.GetAll();

            // Convertir a List<Building> y devolver como Task
            return Task.FromResult(buildings.ToList());
        }
    }
}

