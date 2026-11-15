namespace OmniReserve.Application.Rooms.Common;

public record RoomDto(
    Guid Id,
    string RoomNumber,
    string Type,
    decimal PricePerNight,
    bool IsAvailable
);