


using Eviromental_Variable_Measurement.Application.Abstract;
using Enviromental_Measurement.Domain.Types;
using System;


namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.SampleCommands.UpdateSample
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