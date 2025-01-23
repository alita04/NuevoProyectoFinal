

using EMV.Application.Abstract;
using System;

namespace EMV.Application.Varaibles.Commands.FloorCommands.UpdateFloor
{
    public record UpdateFloorCommand(
        Guid Id,
        string Location, // Nueva ubicación del piso
        Guid Building_Id // ID del edificio al que pertenece el piso
    ) : ICommand<bool>;
}
