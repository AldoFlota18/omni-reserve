namespace OmniReserve.Domain.Exceptions;

public class RoomNotAvailableException : DomainException
{
    public RoomNotAvailableException(string roomNumber)
    {
    }
}