using System;
using System.Threading;
using System.Threading.Tasks;
using EMV.Contracts;

using EMV.Application.Abstract;
using EMV.Application.Varaibles.Commands.VariableCommand.CreateVariable;
using EMV.Domain.Entities.Variable;



namespace EMV.Application.Varaibles.Commands.VariableCommand.CreateVariable
{
    public class CreateVariableCommandHandler : ICommandHandler<CreateVariableCommand, Variable>
    {
        private readonly IVariableRepository _variableRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateVariableCommandHandler(
            IVariableRepository variableRepository,
            IUnitOfWork unitOfWork)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Variable> Handle(CreateVariableCommand request, CancellationToken cancellationToken)
        {
            // Crear una nueva instancia de Variable
            var result = new Variable
            {
                Id = Guid.NewGuid(), // Asigna un nuevo ID
                VariableName = request.VariableName,
                unit = request.Measurement_Unit,
                VariableCode = request.VariableCode,
                type = request.Type,
                BuildingID = request.BuildingID, // Ya es Guid? así que no se necesita conversión
                FloorID = request.FloorID,       // Ya es Guid? así que no se necesita conversión
                RoomID = request.RoomID            // Ya es Guid? así que no se necesita conversión
            };

            // Agregar la variable al repositorio
            _variableRepository.Add(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}