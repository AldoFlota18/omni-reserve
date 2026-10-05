using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OmniReserve.Domain.Entities;

namespace OmniReserve.Infrastructure.Persistence.Repositories;

public class RoomRepository : IRoomRepository
{
    private static readonly Dictionary<Guid, Room> _rooms = new();

    public Task AddAsync(Room room)
    {
        _rooms[room.Id] = room;
        return Task.CompletedTask;
    }

    public Task<Room?> GetByIdAsync(Guid id)
    {
        _rooms.TryGetValue(id, out var room);
        return room;
    }
}