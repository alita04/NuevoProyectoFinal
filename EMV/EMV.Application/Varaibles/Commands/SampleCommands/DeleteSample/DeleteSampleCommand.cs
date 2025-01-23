using EMV.Application.Abstract;
using System;

namespace EMV.Application.Varaibles.Commands.SampleCommands.DeleteSample
{
    public record DeleteSampleCommand(Guid Id) : ICommand<bool>;
}
