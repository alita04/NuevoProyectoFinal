using EMV.Application.Abstract; 
using System;

namespace EMV.Application.Varaibles.Commands.RoomComands.DeleteRoom
{
    public record DeleteRoomCommand(Guid Id) : ICommand<bool>;
}