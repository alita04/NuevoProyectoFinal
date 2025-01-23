
using EMV.Application.Abstract;
using System;
using EMV.Domain.ValueObjects;


namespace EMV.Application.Varaibles.Commands.BuildingCommand.UpdateBuilding
{
    public record UpdateBuildingCommand(
        Guid Id,
        PhysicalAddress Address, // Dirección del edificio
        int BuildingNumber       // Número del edificio
    ) : ICommand<bool>;
}
