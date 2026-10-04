using System;
using OmniReserve.Domain.Enums;

namespace OmniReserve.Application.Rooms.Commands.CreateRoom;

public class CreateRoomCommand : IRequest<Guid>
{
    public string RoomNumber { get; set; }
    public RoomType Type { get; set; }
    public decimal PricePerNight { get; set; }
}