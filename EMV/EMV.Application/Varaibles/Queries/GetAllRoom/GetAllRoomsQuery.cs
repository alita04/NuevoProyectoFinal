
using EMV.Domain.Entities.Structures;

using MediatR;
using System.Collections.Generic;

namespace EMV.Application.Varaibles.Queries.GetAllRoom
{
    public class GetAllRoomsQuery : IRequest<List<Room>>
    {
    }
}
