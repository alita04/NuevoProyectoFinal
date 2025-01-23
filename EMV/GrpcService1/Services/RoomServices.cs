using AutoMapper;
using EMV.Domain.Entities.Structures;

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
{
    public class RoomServices : RoomService.RoomServiceBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RoomServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<RoomDTO> CreateRoom(CreateRoomRequest request, ServerCallContext context)
        {
            var command = new CreateRoomCommand(
                request.Number,
                request.IsProduction,
                request.Description,
                new Guid(request.FloorId)); 

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<RoomDTO>(result));
        }

        public override Task<NullableRoomDTO> GetRoom(GetRequest request, ServerCallContext context)
        {
            var query = new GetRoomByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result == null)
            {
                return Task.FromResult(new NullableRoomDTO { Null = new Empty() });
            }

            return Task.FromResult(new NullableRoomDTO { Room = _mapper.Map<RoomDTO>(result) });
        }

        public override Task<Rooms> GetAllRooms(Empty request, ServerCallContext context)
        {
            var query = new GetAllRoomsQuery();

            var result = _mediator.Send(query).Result;

            var roomsDTOs = new Rooms();
            roomsDTOs.Items.AddRange(result.Select(r => _mapper.Map<RoomDTO>(r)));

            return Task.FromResult(roomsDTOs);
        }

        public override Task<Empty> UpdateRoom(RoomDTO request, ServerCallContext context)
        {
            var command = new UpdateRoomCommand(
                new Guid(request.Id),
                request.Number,
                request.IsProduction,
                request.Description,
                new Guid(request.FloorId)); 

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteRoom(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteRoomCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}