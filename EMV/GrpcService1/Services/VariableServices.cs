using AutoMapper;
using EMV.Application.Varaibles.Commands.VariableCommand.CreateVariable;
using EMV.Application.Varaibles.Commands.VariableCommand.DeleteVariable;
using EMV.Application.Varaibles.Commands.VariableCommand.UpdateVariable;
using EMV.Application.Varaibles.Queries.GetAllVariable;
using EMV.Application.Varaibles.Queries.GetVariable;
using EMV.Domain.ValueObjects;
using EMV.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EMV.GrpcService1.Services
{
    public class VariableServices : VariableService.VariableServiceBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public VariableServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<VariableDTO> CreateVariable(CreateVariableRequest request, ServerCallContext context)
        {
            var command = new CreateVariableCommand(
                request.VariableName,
                new Measurement_Unit(request.MeasurementUnit.Symbol, request.MeasurementUnit.Name),
                request.VariableCode,
                (EMV.Domain.Types.VariableType)request.Type,
                string.IsNullOrEmpty(request.BuildingID) ? (Guid?)null : Guid.Parse(request.BuildingID),
                string.IsNullOrEmpty(request.FloorID) ? (Guid?)null : Guid.Parse(request.FloorID),
                string.IsNullOrEmpty(request.RoomID) ? (Guid?)null : Guid.Parse(request.RoomID));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<VariableDTO>(result));
        }

        public override Task<NullableVariableDTO> GetVariable(GetRequest request, ServerCallContext context)
        {
            var query = new GetVariableByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result == null)
            {
                return Task.FromResult(new NullableVariableDTO { Null = new Empty() });
            }

            return Task.FromResult(new NullableVariableDTO { Variable = _mapper.Map<VariableDTO>(result) });
        }

        public override Task<Variables> GetAllVariables(Empty request, ServerCallContext context)
        {
            var query = new GetAllVariablesQuery();

            var result = _mediator.Send(query).Result;

            var variablesDTOs = new Variables();
            variablesDTOs.Items.AddRange(result.Select(v => _mapper.Map<VariableDTO>(v)));

            return Task.FromResult(variablesDTOs);
        }

        public override Task<Empty> UpdateVariable(VariableDTO request, ServerCallContext context)
        {
            var command = new UpdateVariableCommand(
                new Guid(request.Id), // Convertir string a Guid
                request.VariableName,
                new Measurement_Unit(request.MeasurementUnit.Symbol, request.MeasurementUnit.Name),
                request.VariableCode,
                (EMV.Domain.Types.VariableType)request.Type,
                string.IsNullOrEmpty(request.BuildingID) ? (Guid?)null : Guid.Parse(request.BuildingID),
                string.IsNullOrEmpty(request.FloorID) ? (Guid?)null : Guid.Parse(request.FloorID),
                string.IsNullOrEmpty(request.RoomID) ? (Guid?)null : Guid.Parse(request.RoomID));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteVariable(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteVariableCommand(new Guid(request.Id)); // Convertir string a Guid

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}