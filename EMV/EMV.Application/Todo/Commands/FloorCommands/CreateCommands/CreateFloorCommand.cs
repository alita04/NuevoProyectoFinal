using Enviromental_Measurement.Domain.Entities.Structures;
using Eviromental_Variable_Measurement.Application.Abstract; 
using System;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.FloorCommands.CreateCommands
{
    public record CreateFloorCommand(
        string Location,
        Guid Building_Id 
    ) : ICommand<Floor>;
}