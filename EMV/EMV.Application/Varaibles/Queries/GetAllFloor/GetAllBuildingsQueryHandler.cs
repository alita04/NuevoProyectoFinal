
using MediatR;

using EMV.Contracts;
using EMV.Domain.Entities.Structures;


namespace EMV.Application.Varaibles.Queries.GetAllFloor
{
    public class GetAllFloorsQueryHandler : IRequestHandler<GetAllFloorsQuery, List<Floor>>
    {
        private readonly IFloorRepository _floorRepository;

        public GetAllFloorsQueryHandler(IFloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
        }

        public Task<List<Floor>> Handle(GetAllFloorsQuery request, CancellationToken cancellationToken)
        {
            var floors = _floorRepository.GetAll();
            return Task.FromResult(floors.ToList());
        }
    }
}