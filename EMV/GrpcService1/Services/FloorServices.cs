
using AutoMapper;
using EMV.Application.Varaibles.Commands.FloorCommands.CreateCommands;
using EMV.Application.Varaibles.Commands.FloorCommands.DeleteFloor;
using EMV.Application.Varaibles.Commands.FloorCommands.UpdateFloor;
using EMV.Application.Varaibles.Queries.GetAllFloor;
using EMV.Application.Varaibles.Queries.GetFloor;
using EMV.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMV.GrpcService1.Services
{

    public class FloorServices : FloorService.FloorServiceBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FloorServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<FloorDTO> CreateFloor(CreateFloorRequest request, ServerCallContext context)
        {
            var command = new CreateFloorCommand(
                request.Location,
                new Guid(request.BuildingId)); 

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<FloorDTO>(result));
        }

        public override Task<NullableFloorDTO> GetFloor(GetRequest request, ServerCallContext context)
        {
            var query = new GetFloorByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result == null)
            {
                return Task.FromResult(new NullableFloorDTO { Null = new Empty() });
            }

            return Task.FromResult(new NullableFloorDTO { Floor = _mapper.Map<FloorDTO>(result) });
        }

        public override Task<Floors> GetAllFloors(Empty request, ServerCallContext context)
        {
            var query = new GetAllFloorsQuery();

            var result = _mediator.Send(query).Result;

            var floorsDTOs = new Floors();
            floorsDTOs.Items.AddRange(result.Select(f => _mapper.Map<FloorDTO>(f)));

            return Task.FromResult(floorsDTOs);
        }

        public override Task<Empty> UpdateFloor(FloorDTO request, ServerCallContext context)
        {
            var command = new UpdateFloorCommand(
                new Guid(request.Id),
                request.Location,
                new Guid(request.BuildingId)); 

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteFloor(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteFloorCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}

