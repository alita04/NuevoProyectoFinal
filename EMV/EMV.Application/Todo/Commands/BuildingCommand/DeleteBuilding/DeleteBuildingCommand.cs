using Eviromental_Variable_Measurement.Application.Abstract; 
using System;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.BuildingCommand.DeleteBuilding
{
    public record DeleteBuildingCommand(Guid Id) : ICommand<bool>;
}