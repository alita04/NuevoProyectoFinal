


using AutoMapper;
using EMV.Application.Varaibles.Commands.BuildingCommand.CreateBuilding;
using EMV.Application.Varaibles.Commands.BuildingCommand.DeleteBuilding;
using EMV.Application.Varaibles.Commands.BuildingCommand.UpdateBuilding;
using EMV.Application.Varaibles.Queries.GetAllBuilding;
using EMV.Application.Varaibles.Queries.GetBuilding;
using EMV.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;


namespace EMV.GrpcService1.Services
{
    public class BuildingServices : BuildingService.BuildingServiceBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BuildingServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<BuildingDTO> CreateBuilding(CreateBuildingRequest request, ServerCallContext context)
        {
            var command = new CreateBuildingCommand(
                new EMV.Domain.ValueObjects.PhysicalAddress(
                    request.Address.Country,
                    request.Address.City,
                    request.Address.Address),
                request.BuildingNumber);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<BuildingDTO>(result));
        }

        public override Task<NullableBuildingDTO> GetBuilding(GetRequest request, ServerCallContext context)
        {
            var query = new GetBuildingByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result == null)
            {
                return Task.FromResult(new NullableBuildingDTO { Null = new Empty() });
            }

            return Task.FromResult(new NullableBuildingDTO { Building = _mapper.Map<BuildingDTO>(result) });
        }

        public override Task<Buildings> GetAllBuildings(Empty request, ServerCallContext context)
        {
            var query = new GetAllBuildingsQuery();

            var result = _mediator.Send(query).Result;

            var buildingsDTOs = new Buildings();
            buildingsDTOs.Items.AddRange(result.Select(b => _mapper.Map<BuildingDTO>(b)));

            return Task.FromResult(buildingsDTOs);
        }

        public override Task<Empty> UpdateBuilding(BuildingDTO request, ServerCallContext context)
        {
            var command = new UpdateBuildingCommand(
                new Guid(request.Id),
                new EMV.Domain.ValueObjects.PhysicalAddress(
                    request.Address.Country,
                    request.Address.City,
                    request.Address.Address),
                request.BuildingNumber);

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteBuilding(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteBuildingCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}