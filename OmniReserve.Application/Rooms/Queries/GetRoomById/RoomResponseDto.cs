using System;

namespace OmniReserve.Application.Rooms.Queries.GetRoomById;

public class RoomResponseDto
{
    public Guid Id { get; set; }
    public required string RoomNumber { get; set; }
    public required string Type { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
}