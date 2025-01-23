
using Eviromental_Variable_Measurement.Application.Abstract;
using System;
using Enviromental_Measurement.Domain.ValueObjects;


namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.BuildingCommand.UpdateBuilding
{
    public record UpdateBuildingCommand(
        Guid Id,
        PhysicalAddress Address, // Dirección del edificio
        int BuildingNumber       // Número del edificio
    ) : ICommand<bool>;
}
