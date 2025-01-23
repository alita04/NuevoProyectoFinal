using Eviromental_Variable_Measurement.Application.Abstract;
using System;
using Enviromental_Measurement.Domain.Entities.Structures;
using Enviromental_Measurement.Domain.ValueObjects;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.BuildingCommand.CreateBuilding
{
    public record CreateBuildingCommand(
        PhysicalAddress Address, // Dirección del edificio
        int BuildingNumber       // Número del edificio
    ) : ICommand<Building>;
}