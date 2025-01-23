using EMV.Application.Abstract; 
using System;

namespace EMV.Application.Varaibles.Commands.BuildingCommand.DeleteBuilding
{
    public record DeleteBuildingCommand(Guid Id) : ICommand<bool>;
}