

using EMV.Domain.Entities.Structures;
using EMV.Application.Abstract;
using System;

namespace EMV.Application.Varaibles.Queries.GetFloor
{
    public record GetFloorByIdQuery(Guid Id) : IQuery<Floor>;
}
