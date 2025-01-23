using Eviromental_Variable_Measurement.Application.Abstract;
using System;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.FloorCommands.DeleteFloor
{
    public record DeleteFloorCommand(Guid Id) : ICommand<bool>;
}