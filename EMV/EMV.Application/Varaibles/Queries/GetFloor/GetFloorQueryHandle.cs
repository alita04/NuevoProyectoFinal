using EMV.Domain.Entities.Structures; 
using System.Threading;
using System.Threading.Tasks;
using EMV.Contracts;
using EMV.Application.Abstract;


namespace EMV.Application.Varaibles.Queries.GetFloor
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