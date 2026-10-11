namespace OmniReserve.Domain.Exceptions;

public class RoomNotAvailableException : DomainException
{
    public RoomNotAvailableException(string roomNumber) 
        : base($"La habitacion {roomNumber} no se encuentra disponible para reserva")
    {
    }
}