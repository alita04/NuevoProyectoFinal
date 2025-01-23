using EMV.Application.Abstract;
using System;
using EMV.Domain.Entities.Structures;
using EMV.Domain.ValueObjects;

namespace EMV.Application.Varaibles.Commands.BuildingCommand.CreateBuilding
{
    public record CreateBuildingCommand(
        PhysicalAddress Address, // Dirección del edificio
        int BuildingNumber       // Número del edificio
    ) : ICommand<Building>;
}