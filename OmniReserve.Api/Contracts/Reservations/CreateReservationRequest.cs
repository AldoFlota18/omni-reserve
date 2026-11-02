namespace OmniReserve.API.Contracts.Reservations;

public record CreateReservationRequest(
    Guid RoomId,
    DateTime CheckInDate,
    DateTime CheckOutDate
);