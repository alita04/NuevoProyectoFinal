
using EMV.Application.Abstract; 
using System;

namespace EMV.Application.Varaibles.Commands.RoomComands.UpdateRoom
{
    public record UpdateRoomCommand(
        Guid Id,
        int Number, // Nuevo número de la habitación
        bool IsProduction, // Nuevo estado de producción
        string? Description, // Nueva descripción de la habitación
        Guid FloorId // ID del piso al que pertenece la habitación
    ) : ICommand<bool>;
}
