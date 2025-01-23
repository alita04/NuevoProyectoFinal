
using Enviromental_Measurement.Domain.Entities.Samples;
using Eviromental_Variable_Measurement.Application.Abstract;
using System;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Queries.GetSample
{
    public record GetSampleByIdQuery(Guid Id) : IQuery<Sample>;
}