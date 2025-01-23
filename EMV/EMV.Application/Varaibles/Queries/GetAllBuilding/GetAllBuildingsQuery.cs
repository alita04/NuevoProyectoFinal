
using EMV.Domain.Entities.Structures;

using MediatR;
using System.Collections.Generic;

namespace EMV.Application.Varaibles.Queries.GetAllBuilding
{
    public class GetAllBuildingsQuery : IRequest<List<Building>>
    {
    }
}
