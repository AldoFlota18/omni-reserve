using MediatR;
using OmniReserve.Domain.Enums;

namespace OmniReserve.Application.Rooms.Commands.CreateRoom;

public record CreateRoomCommand(string RoomNumber, RoomType Type, decimal PricePerNight) : IRequest<Guid>;