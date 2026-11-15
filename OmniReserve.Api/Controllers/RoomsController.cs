using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using OmniReserve.Application.Rooms.Commands.CreateRoom;
using OmniReserve.Application.Rooms.Queries.GetRoomById;
using OmniReserve.Application.Rooms.Queries.GetAllRooms;

namespace OmniReserve.API.Controllers;

[EnableRateLimiting("GlobalLimit")]
[ApiController]
[Route("api/rooms")]
public class RoomsController : ControllerBase
{
    private readonly ISender _sender;

    public RoomsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom([FromBody] CreateRoomCommand command)
    {
        var roomId = await _sender.Send(command);
        return Ok(roomId);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoom(Guid id)
    {
        var query = new GetRoomByIdQuery(id);
        var result = await _sender.Send(query);
        
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRooms()
    {
        var query = new GetAllRoomsQuery();
        var result = await _sender.Send(query);
        return Ok(result);
    }
}