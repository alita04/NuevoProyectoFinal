using EMV.Application.Abstract;

using System;

namespace EMV.Application.Varaibles.Commands.VariableCommand.DeleteVariable
{
    public record DeleteVariableCommand(Guid Id) : ICommand<bool>;
}