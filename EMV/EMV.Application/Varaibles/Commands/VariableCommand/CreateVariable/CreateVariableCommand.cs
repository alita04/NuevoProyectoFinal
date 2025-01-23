using EMV.Application.Abstract;
using EMV.Domain.Types; 
using System;
using EMV.Domain.Entities.Variable;
using EMV.Domain.ValueObjects;

namespace EMV.Application.Varaibles.Commands.VariableCommand.CreateVariable
{
    public record CreateVariableCommand(
        string VariableName,
        Measurement_Unit Measurement_Unit,
        string VariableCode,
        VariableType Type,
        Guid? BuildingID, // ID del edificio (opcional)
        Guid? FloorID,    // ID del piso (opcional)
        Guid? RoomID      // ID de la habitación (opcional)
    ) : ICommand<Variable>;
}