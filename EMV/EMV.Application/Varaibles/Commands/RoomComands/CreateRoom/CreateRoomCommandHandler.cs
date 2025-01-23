using EMV.Domain.Entities.Structures; 
using System.Threading;
using System.Threading.Tasks;
using EMV.Contracts;
using EMV.Application.Abstract;



namespace EMV.Application.Varaibles.Commands.RoomComands.CreateRoom
{
    public class CreateRoomCommandHandler : ICommandHandler<CreateRoomCommand, Room>
    {
        private readonly IRoomRepository _roomRepository; 
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoomCommandHandler(
            IRoomRepository roomRepository,
            IUnitOfWork unitOfWork)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Room> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            // Crear una nueva instancia de Room
            var room = new Room
            {
                Id = Guid.NewGuid(), // Asigna un nuevo ID
                Number = request.Number,
                IsProduction = request.IsProduction,
                Description = request.Description,
                FloorId = request.FloorId
            };

            // Agregar la habitación al repositorio
            _roomRepository.Add(room);
            _unitOfWork.SaveChanges();

            return Task.FromResult(room);
        }
    }
}