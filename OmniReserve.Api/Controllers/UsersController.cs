using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using OmniReserve.Application.Users.Commands.CreateUser;
using OmniReserve.Application.Users.Commands.LoginUser;

namespace OmniReserve.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
    {
        var userId = await _sender.Send(command);
        return Ok(userId);
    }

    [EnableRateLimiting("AuthLimit")]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var token = await _sender.Send(command);
        return Ok(new { Token = token });
    }
}