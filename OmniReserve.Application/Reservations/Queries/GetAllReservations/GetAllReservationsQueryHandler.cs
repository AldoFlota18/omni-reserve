using MediatR;
using OmniReserve.Application.Common.Interfaces;
using OmniReserve.Application.Reservations.Common;

namespace OmniReserve.Application.Reservations.Queries.GetAllReservations;

public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, List<ReservationDto>>
{
    private readonly IReservationRepository _reservationRepository;

    public GetAllReservationsQueryHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<List<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
    {
        var reservations = await _reservationRepository.GetAllAsyncInvalid(); // Error intencional

        return reservations.Select(r => new ReservationDto(
            r.Id,
            r.UserId,
            r.RoomId,
            r.CheckInDate,
            r.CheckOutDate,
            r.TotalPrice
        )).ToList();
    }
}