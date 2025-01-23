
using MediatR;
using EMV.Contracts;
using EMV.Domain.Entities.Variable;


namespace EMV.Application.Varaibles.Queries.GetAllVariable
{
    public class GetAllVariablesQueryHandler : IRequestHandler<GetAllVariablesQuery, List<Variable>>
    {
        private readonly IVariableRepository _variableRepository;

        public GetAllVariablesQueryHandler(IVariableRepository variableRepository)
        {
            _variableRepository = variableRepository;
        }

        public Task<List<Variable>> Handle(GetAllVariablesQuery request, CancellationToken cancellationToken)
        {
            var variables = _variableRepository.GetAll();
            return Task.FromResult(variables.ToList());
        }
    }
}