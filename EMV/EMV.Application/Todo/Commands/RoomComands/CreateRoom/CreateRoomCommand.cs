using Enviromental_Measurement.Domain.Entities.Structures;
using Eviromental_Variable_Measurement.Application.Abstract; 
using System;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.RoomComands.CreateRoom
{
    public record CreateRoomCommand(
        int Number,
        bool IsProduction,
        string? Description,
        Guid FloorId // ID del piso al que pertenece la habitación
    ) : ICommand<Room>;
}