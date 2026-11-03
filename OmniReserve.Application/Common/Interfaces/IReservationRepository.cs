using OmniReserve.Domain.Entities;

namespace OmniReserve.Application.Common.Interfaces;

public interface IReservationRepository
{
    Task AddAsync(Reservation reservation);
    Task<bool> ExistsOverlappingAsync(Guid roomId, DateTime checkInDate, DateTime checkOutDate);
    Task<bool> IsRoomAvailableAsync(Guid roomId, DateTime checkInDate, DateTime checkOutDate);
    Task<List<Reservation>> GetAllAsync();
    Task<Reservation?> GetByIdAsync(Guid id);
    Task<Reservation?> GetReservationWithDetailsAsync(Guid id);
}