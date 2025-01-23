
using EMV.Domain.Entities.Structures;
using EMV.Application.Abstract;
using System;

namespace EMV.Application.Varaibles.Queries.GetBuilding
{
    public record GetBuildingByIdQuery(Guid Id) : IQuery<Building>;
}