

using EMV.Domain.Entities.Structures;
using EMV.Application.Abstract;
using System;

namespace EMV.Application.Varaibles.Queries.GetRoom
{
    public record GetRoomByIdQuery(Guid Id) : IQuery<Room>;
}