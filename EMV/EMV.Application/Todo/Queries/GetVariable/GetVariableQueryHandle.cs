using System;
using System.Threading;
using System.Threading.Tasks;
using Eviromental_Variable_Measurement.Application.Abstract;
using Enviromental_Measurement.Contracts;
using Enviromental_Measurement.Domain.Entities.Variable;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Queries.GetVariable
{

    public class GetVariableByIdQueryHandler : IQueryHandler<GetVariableByIdQuery, Variable>
    {
        private readonly IVariableRepository _variableRepository; 

        public GetVariableByIdQueryHandler(IVariableRepository variableRepository)
        {
            _variableRepository = variableRepository;
        }

        public Task<Variable> Handle(GetVariableByIdQuery request, CancellationToken cancellationToken)
        {
            // Obtener la variable del repositorio
            Variable variable = _variableRepository.GetById(request.Id);

            return Task.FromResult(variable);
        }
    }
}