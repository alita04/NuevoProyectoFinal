


using EMV.Domain.Entities.Structures;

using MediatR;
using System.Collections.Generic;

namespace EMV.Application.Varaibles.Queries.GetAllFloor
{
    public class GetAllFloorsQuery : IRequest<List<Floor>>
    {
    }
}
