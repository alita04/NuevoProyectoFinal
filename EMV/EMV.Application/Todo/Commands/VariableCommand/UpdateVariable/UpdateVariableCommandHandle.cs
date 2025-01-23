
using System;
using System.Threading;
using System.Threading.Tasks;
using Enviromental_Measurement.Contracts;
using Eviromental_Variable_Measurement.Application.Abstract;
using Enviromental_Measurement.Domain.Entities.Variable;


namespace Evironmental_Variables_Measurement.Application.Varaibles.Commands.VariableCommand.UpdateVariable
{
    public class UpdateVariableCommandHandler : ICommandHandler<UpdateVariableCommand, bool>
    {
        private readonly IVariableRepository _variableRepository; 
        private readonly IUnitOfWork _unitOfWork;

        public UpdateVariableCommandHandler(
            IVariableRepository variableRepository,
            IUnitOfWork unitOfWork)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(UpdateVariableCommand request, CancellationToken cancellationToken)
        {
            // Buscar la variable existente
            var existingVariable = _variableRepository.GetById(request.Id);

            if (existingVariable == null)
            {
                return Task.FromResult(false); // Devuelve false si no se encuentra la variable
            }

            // Crear un nuevo objeto Variable con los valores actualizados usando el constructor
            var updatedVariable = new Variable(
                existingVariable.Id, // Mantener el mismo ID
                request.VariableName,
                request.Measurement_Unit,
                request.VariableCode,
                request.Type,
                request.BuildingID,
                request.FloorID,
                request.RoomID
            );

            // Actualizar la variable en el repositorio
            _variableRepository.Update(updatedVariable);
            _unitOfWork.SaveChanges();

            return Task.FromResult(true); // Devuelve true si la actualización fue exitosa
        }
    }
}