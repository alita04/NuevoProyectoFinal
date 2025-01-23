using System;
using System.Threading;
using System.Threading.Tasks;
using EMV.Application.Abstract;
using EMV.Contracts;
using EMV.Domain.Entities.Variable;

namespace EMV.Application.Varaibles.Queries.GetVariable
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