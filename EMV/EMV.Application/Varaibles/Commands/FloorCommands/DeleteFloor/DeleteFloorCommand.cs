using EMV.Application.Abstract;
using System;

namespace EMV.Application.Varaibles.Commands.FloorCommands.DeleteFloor
{
    public record DeleteFloorCommand(Guid Id) : ICommand<bool>;
}