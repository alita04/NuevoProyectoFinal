

using EMV.Domain.Types;
using System;
using EMV.Application.Abstract;
using EMV.Domain.ValueObjects;


namespace EMV.Application.Varaibles.Commands.VariableCommand.UpdateVariable
{
    public record UpdateVariableCommand(
        Guid Id,
        string VariableName,
        Measurement_Unit Measurement_Unit,
        string VariableCode,
        VariableType Type,
        Guid? BuildingID, // ID del edificio (opcional)
        Guid? FloorID,    // ID del piso (opcional)
        Guid? RoomID      // ID de la habitación (opcional)
    ) : ICommand<bool>;
}