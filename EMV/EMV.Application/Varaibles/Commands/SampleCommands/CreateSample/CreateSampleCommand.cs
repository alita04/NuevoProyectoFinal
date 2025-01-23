using EMV.Application.Abstract;
using EMV.Domain.Types;
using System;
using EMV.Domain.Entities.Samples;

namespace EMV.Application.Varaibles.Commands.SampleCommands.CreateSample
{
    public record CreateSampleCommand(
        DateTime DateTime,
        Guid VariableId, // ID de la variable asociada
        SampleType Type,
        double? DecimalValue = null,
        int? IntValue = null,
        bool? BoolValue = null
    ) : ICommand<Sample>;
}