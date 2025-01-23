


using EMV.Application.Abstract;
using EMV.Domain.Types;
using System;


namespace EMV.Application.Varaibles.Commands.SampleCommands.UpdateSample
{
    public record UpdateSampleCommand(
        Guid Id,
        DateTime DateTime,
        Guid VariableId, // ID de la variable asociada
        SampleType Type,
        double? DecimalValue = null,
        int? IntValue = null,
        bool? BoolValue = null
    ) : ICommand<bool>;
}