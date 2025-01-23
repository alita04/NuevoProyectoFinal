
using EMV.Domain.Entities.Variable;
using EMV.Application.Abstract;
using System;

namespace EMV.Application.Varaibles.Queries.GetVariable
{
    public record GetVariableByIdQuery(Guid Id) : IQuery<Variable>;
}