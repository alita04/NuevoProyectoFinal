
using Enviromental_Measurement.Domain.Entities.Variable;
using Eviromental_Variable_Measurement.Application.Abstract;
using System;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Queries.GetVariable
{
    public record GetVariableByIdQuery(Guid Id) : IQuery<Variable>;
}