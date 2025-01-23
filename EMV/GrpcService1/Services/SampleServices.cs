using AutoMapper;
using Enviromental_Measurement.Domain.Entities.Samples;

using Enviromental_Variables_Measurement.GrpcProto;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enviromental_Variable_Measurement.GrpcService.Services
{
    public class SampleServices : SampleService.SampleServiceBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SampleServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<SampleDTO> CreateSample(CreateSampleRequest request, ServerCallContext context)
        {
            var command = new CreateSampleCommand(
                request.DateTime.ToDateTime(), // Convertir Timestamp a DateTime
                new Guid(request.VariableId), // Convertir string a Guid
                request.Type,
                request.DecimalValue,
                request.IntValue,
                request.BoolValue);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<SampleDTO>(result));
        }

        public override Task<NullableSampleDTO> GetSample(GetRequest request, ServerCallContext context)
        {
            var query = new GetSampleByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result == null)
            {
                return Task.FromResult(new NullableSampleDTO { Null = new Empty() });
            }

            return Task.FromResult(new NullableSampleDTO { Sample = _mapper.Map<SampleDTO>(result) });
        }

        public override Task<Samples> GetAllSamples(Empty request, ServerCallContext context)
        {
            var query = new GetAllSamplesQuery();

            var result = _mediator.Send(query).Result;

            var samplesDTOs = new Samples();
            samplesDTOs.Items.AddRange(result.Select(s => _mapper.Map<SampleDTO>(s)));

            return Task.FromResult(samplesDTOs);
        }

        public override Task<Empty> UpdateSample(SampleDTO request, ServerCallContext context)
        {
            var command = new UpdateSampleCommand(
                new Guid(request.Id), // Convertir string a Guid
                request.DateTime.ToDateTime(), // Convertir Timestamp a DateTime
                new Guid(request.VariableId), // Convertir string a Guid
                request.Type,
                request.DecimalValue,
                request.IntValue,
                request.BoolValue);

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteSample(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteSampleCommand(new Guid(request.Id)); // Convertir string a Guid

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}