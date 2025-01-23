using EMV.Domain.Entities.Structures; 
using System;
using System.Threading;
using System.Threading.Tasks;
using EMV.Contracts;
using EMV.Application.Abstract;


namespace EMV.Application.Varaibles.Commands.RoomComands.DeleteRoom
{
    public class DeleteRoomCommandHandler : ICommandHandler<DeleteRoomCommand, bool>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoomCommandHandler(
            IRoomRepository roomRepository,
            IUnitOfWork unitOfWork)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            bool result = true;

            // Lógica para eliminar la habitación
            _roomRepository.Delete(request.Id);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}