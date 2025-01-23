

using Enviromental_Measurement.Domain.Entities.Variable;
using MediatR;
using System.Collections.Generic;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Queries.GetAllVariable
{
    public class GetAllVariablesQuery : IRequest<List<Variable>>
    {
    }
}
