namespace OmniReserve.Application.Reservations.Common;

public record ReservationDto(
    Guid Id,
    Guid UserId,
    Guid RoomId,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    decimal TotalPrice
);