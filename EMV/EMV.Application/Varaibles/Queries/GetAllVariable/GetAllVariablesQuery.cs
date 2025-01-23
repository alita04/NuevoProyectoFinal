

using EMV.Domain.Entities.Variable;
using MediatR;
using System.Collections.Generic;

namespace EMV.Application.Varaibles.Queries.GetAllVariable
{
    public class GetAllVariablesQuery : IRequest<List<Variable>>
    {
    }
}
