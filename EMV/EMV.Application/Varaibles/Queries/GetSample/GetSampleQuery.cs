
using EMV.Domain.Entities.Samples;
using EMV.Application.Abstract;
using System;

namespace EMV.Application.Varaibles.Queries.GetSample
{
    public record GetSampleByIdQuery(Guid Id) : IQuery<Sample>;
}