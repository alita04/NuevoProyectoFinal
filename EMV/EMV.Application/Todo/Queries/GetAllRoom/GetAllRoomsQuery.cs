﻿
using Enviromental_Measurement.Domain.Entities.Structures;

using MediatR;
using System.Collections.Generic;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Queries.GetAllRoom
{
    public class GetAllRoomsQuery : IRequest<List<Room>>
    {
    }
}
