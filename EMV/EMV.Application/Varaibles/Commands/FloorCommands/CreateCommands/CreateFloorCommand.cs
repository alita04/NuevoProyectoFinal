using EMV.Domain.Entities.Structures;
using EMV.Application.Abstract; 
using System;

namespace EMV.Application.Varaibles.Commands.FloorCommands.CreateCommands
{
    public record CreateFloorCommand(
        string Location,
        Guid Building_Id 
    ) : ICommand<Floor>;
}