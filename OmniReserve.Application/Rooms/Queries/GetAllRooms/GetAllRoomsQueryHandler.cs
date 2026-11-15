using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using OmniReserve.Application.Common.Interfaces;
using OmniReserve.Application.Rooms.Common;

namespace OmniReserve.Application.Rooms.Queries.GetAllRooms;

public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, List<RoomDto>>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IDistributedCache _cache;
    private const string CACHE_KEY = "rooms_catalog";

    public GetAllRoomsQueryHandler(IRoomRepository roomRepository, IDistributedCache cache)
    {
        _roomRepository = roomRepository;
        _cache = cache;
    }

    public async Task<List<RoomDto>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        var cachedRooms = await _cache.GetStringAsyncInvalid(CACHE_KEY, cancellationToken);

        if (!string.IsNullOrEmpty(cachedRooms))
        {
            return JsonSerializer.Deserialize<List<RoomDto>>(cachedRooms)!;
        }

        var rooms = await _roomRepository.GetAllAsync();

        var roomDtos = rooms.Select(r => new RoomDto(
            r.Id,
            r.RoomNumber,
            r.Type.ToString(),
            r.PricePerNight,
            r.IsAvailable
        )).ToList();

        var serializedRooms = JsonSerializer.Serialize(roomDtos);

        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        await _cache.SetStringAsync(CACHE_KEY, serializedRooms, options, cancellationToken);

        return roomDtos;
    }
}