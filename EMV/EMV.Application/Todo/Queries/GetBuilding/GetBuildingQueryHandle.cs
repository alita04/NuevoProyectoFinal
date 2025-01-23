using Enviromental_Measurement.Domain.Entities.Structures;
using System;
using System.Threading;
using System.Threading.Tasks;
using Enviromental_Measurement.Contracts;
using Eviromental_Variable_Measurement.Application.Abstract;


namespace Evironmental_Variables_Measurement.Application.Varaibles.Queries.GetBuilding
{
    public class GetBuildingByIdQueryHandler : IQueryHandler<GetBuildingByIdQuery, Building>
    {
        private readonly IBuildingRepository _buildingRepository; // Asegúrate de tener una interfaz para manejar los edificios

        public GetBuildingByIdQueryHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public Task<Building> Handle(GetBuildingByIdQuery request, CancellationToken cancellationToken)
        {
            // Obtener el edificio del repositorio
            Building building = _buildingRepository.GetById(request.Id);

            return Task.FromResult(building);
        }
    }
}