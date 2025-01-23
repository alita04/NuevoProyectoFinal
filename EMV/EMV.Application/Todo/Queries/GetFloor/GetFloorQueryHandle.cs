using Enviromental_Measurement.Domain.Entities.Structures; 
using System.Threading;
using System.Threading.Tasks;
using Enviromental_Measurement.Contracts;
using Eviromental_Variable_Measurement.Application.Abstract;


namespace Evironmental_Variables_Measurement.Application.Varaibles.Queries.GetFloor
{
    public class GetFloorByIdQueryHandler : IQueryHandler<GetFloorByIdQuery, Floor>
    {
        private readonly IFloorRepository _floorRepository; 

        public GetFloorByIdQueryHandler(IFloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
        }

        public Task<Floor> Handle(GetFloorByIdQuery request, CancellationToken cancellationToken)
        {
            // Obtener el piso del repositorio
            Floor floor = _floorRepository.GetById(request.Id);

            return Task.FromResult(floor);
        }
    }
}