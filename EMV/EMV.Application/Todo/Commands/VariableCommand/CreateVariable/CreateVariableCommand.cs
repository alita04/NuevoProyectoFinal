using Eviromental_Variable_Measurement.Application.Abstract;
using Enviromental_Measurement.Domain.Types; 
using System;
using Enviromental_Measurement.Domain.Entities.Variable;
using Enviromental_Measurement.Domain.ValueObjects;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.VariableCommand.CreateVariable
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