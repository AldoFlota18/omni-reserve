using MediatR;
using OmniReserve.Application.Rooms.Common;

namespace OmniReserve.Application.Rooms.Queries.GetAllRooms;

public record GetAllRoomsQuery : IRequest<List<RoomDto>>;