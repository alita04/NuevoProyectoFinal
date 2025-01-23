using Eviromental_Variable_Measurement.Application.Abstract;
using System;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.SampleCommands.DeleteSample
{
    public record DeleteSampleCommand(Guid Id) : ICommand<bool>;
}
