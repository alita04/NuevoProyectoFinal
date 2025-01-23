using EMV.Domain.Entities.Structures;
using EMV.Application.Abstract; 
using System;

namespace EMV.Application.Varaibles.Commands.RoomComands.CreateRoom
{
    public record CreateRoomCommand(
        int Number,
        bool IsProduction,
        string? Description,
        Guid FloorId // ID del piso al que pertenece la habitación
    ) : ICommand<Room>;
}