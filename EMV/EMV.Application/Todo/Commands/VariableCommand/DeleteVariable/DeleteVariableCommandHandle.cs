using System;
using System.Threading;
using System.Threading.Tasks;

using Enviromental_Measurement.Contracts;
using Eviromental_Variable_Measurement.Application.Abstract;


namespace Evironmental_Variables_Measurement.Application.Varaibles.Commands.VariableCommand.DeleteVariable
{
    public class DeleteVariableCommandHandler : ICommandHandler<DeleteVariableCommand, bool>
    {
        private readonly IVariableRepository _variableRepository; // Asegúrate de tener una interfaz para manejar las variables
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVariableCommandHandler(
            IVariableRepository variableRepository,
            IUnitOfWork unitOfWork)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteVariableCommand request, CancellationToken cancellationToken)
        {
            bool result = true;

            // Lógica para eliminar la variable
            _variableRepository.Delete(request.Id);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}

