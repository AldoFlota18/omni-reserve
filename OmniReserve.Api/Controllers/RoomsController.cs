using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System;
using OmniReserve.Application.Rooms.Commands.CreateRoom;

namespace OmniReserve.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly ISender _sender;

    public RoomsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom(CreateRoomCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoom(string id)
    {
        var query = new GetRoomByIdQuery { RoomId = id };
        var result = await _sender.Send(query);
        return Ok(result);
    }
}