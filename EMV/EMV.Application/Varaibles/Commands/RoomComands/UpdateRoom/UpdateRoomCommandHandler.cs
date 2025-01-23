
using EMV.Domain.Entities.Structures; 
using System;
using System.Threading;
using System.Threading.Tasks;
using EMV.Contracts;
using EMV.Application.Abstract;


namespace EMV.Application.Varaibles.Commands.RoomComands.UpdateRoom
{
    public class UpdateRoomCommandHandler : ICommandHandler<UpdateRoomCommand, bool>
    {
        private readonly IRoomRepository _roomRepository; 
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRoomCommandHandler(
            IRoomRepository roomRepository,
            IUnitOfWork unitOfWork)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            // Buscar la habitación existente
            var existingRoom = _roomRepository.GetById(request.Id);

            if (existingRoom == null)
            {
                return Task.FromResult(false); // Devuelve false si no se encuentra la habitación
            }

            // Crear un nuevo objeto Room con los valores actualizados usando el constructor
            var updatedRoom = new Room(
                existingRoom.Id, // Mantener el mismo ID
                request.Number,
                request.IsProduction,
                request.Description,
                request.FloorId
            );

            // Actualizar la habitación en el repositorio
            _roomRepository.Update(updatedRoom);
            _unitOfWork.SaveChanges();

            return Task.FromResult(true); // Devuelve true si la actualización fue exitosa
        }
    }
}