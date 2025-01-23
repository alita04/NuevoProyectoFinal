using Eviromental_Variable_Measurement.Application.Abstract;

using System;

namespace Evironmental_Variables_Measurement.Application.Varaibles.Commands.VariableCommand.DeleteVariable
{
    public record DeleteVariableCommand(Guid Id) : ICommand<bool>;
}