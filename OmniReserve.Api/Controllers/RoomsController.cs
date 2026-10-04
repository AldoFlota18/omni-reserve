using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;

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
    public Task<IActionResult> CreateRoom(CreateRoomCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
}