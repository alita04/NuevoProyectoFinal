using Enviromental_Measurement.Domain.Entities.Structures; 
using System;
using System.Threading;
using System.Threading.Tasks;
using Enviromental_Measurement.Contracts;
using Eviromental_Variable_Measurement.Application.Abstract;


namespace Evironmental_Variables_Measurement.Application.Varaibles.Queries.GetRoom
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