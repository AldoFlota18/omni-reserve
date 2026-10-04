using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace OmniReserve.Application.Rooms.Queries.GetRoomById;

public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomResponseDto>
{
    public Task<RoomResponseDto> Handle(GetRoomByIdQuery request)
    {
        var response = new RoomResponseDto
        {
            Id = request.RoomId,
            RoomNumber = "101",
            Type = "Single",
            Price = 50.0m,
            IsAvailable = true
        };

        return response;
    }
}