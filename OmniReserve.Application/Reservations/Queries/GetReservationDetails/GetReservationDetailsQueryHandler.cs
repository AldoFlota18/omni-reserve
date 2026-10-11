using MediatR;
using OmniReserve.Application.Common.Interfaces;

namespace OmniReserve.Application.Reservations.Queries.GetReservationDetails;

public class GetReservationDetailsQueryHandler : IRequestHandler<GetReservationDetailsQuery, ReservationDetailsDto>
{
    private readonly IReservationRepository _reservationRepository;

    public GetReservationDetailsQueryHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<ReservationDetailsDto> Handle(GetReservationDetailsQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetReservationWithDetailsAsync(request.ReservationId);

        if (reservation == null)
        {
            throw new Exception("Reservation not found");
        }

        return new ReservationDetailsDto
        {
            Id = reservation.Id,
            UserEmail = reservation.User.Mail,
            RoomNumber = reservation.Room.RoomNumber,
            StartDate = reservation.CheckInDate,
            EndDate = reservation.CheckOutDate
        };
    }
}