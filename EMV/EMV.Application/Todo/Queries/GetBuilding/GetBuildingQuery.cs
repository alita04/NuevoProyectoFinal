﻿
using Enviromental_Measurement.Domain.Entities.Structures;
using Eviromental_Variable_Measurement.Application.Abstract;
using System;

namespace Evironmental_Variables_Measurement.Application.Varaibles.Queries.GetBuilding
{
    public record GetBuildingByIdQuery(Guid Id) : IQuery<Building>;
}