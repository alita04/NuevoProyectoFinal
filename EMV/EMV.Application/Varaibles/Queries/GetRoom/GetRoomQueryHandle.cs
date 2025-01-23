using EMV.Domain.Entities.Structures; 
using System;
using System.Threading;
using System.Threading.Tasks;
using EMV.Contracts;
using EMV.Application.Abstract;


namespace EMV.Application.Varaibles.Queries.GetRoom
{
    public class GetRoomByIdQueryHandler : IQueryHandler<GetRoomByIdQuery, Room>
    {
        private readonly IRoomRepository _roomRepository; 

        public GetRoomByIdQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Task<Room> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            // Obtener la habitación del repositorio
            Room room = _roomRepository.GetById(request.Id);

            return Task.FromResult(room);
        }
    }
}