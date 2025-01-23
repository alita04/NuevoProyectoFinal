

using MediatR;

using Enviromental_Measurement.Contracts;
using Enviromental_Measurement.Domain.Entities.Structures;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Queries.GetAllRoom
{
    public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, List<Room>>
    {
        private readonly IRoomRepository _roomRepository;

        public GetAllRoomsQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Task<List<Room>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = _roomRepository.GetAll();
            return Task.FromResult(rooms.ToList());
        }
    }
}