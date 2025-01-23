using Eviromental_Variable_Measurement.Application.Abstract;
using Enviromental_Measurement.Domain.Types;
using System;
using Enviromental_Measurement.Domain.Entities.Samples;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.SampleCommands.CreateSample
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