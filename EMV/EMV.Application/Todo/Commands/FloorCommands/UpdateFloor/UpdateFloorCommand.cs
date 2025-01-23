

using Eviromental_Variable_Measurement.Application.Abstract;
using System;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.FloorCommands.UpdateFloor
{
    public record UpdateFloorCommand(
        Guid Id,
        string Location, // Nueva ubicación del piso
        Guid Building_Id // ID del edificio al que pertenece el piso
    ) : ICommand<bool>;
}
