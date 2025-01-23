using Eviromental_Variable_Measurement.Application.Abstract; 
using System;

namespace Eviromental_Variable_Measurement.Application.Varaibles.Commands.RoomComands.DeleteRoom
{
    public record DeleteRoomCommand(Guid Id) : ICommand<bool>;
}