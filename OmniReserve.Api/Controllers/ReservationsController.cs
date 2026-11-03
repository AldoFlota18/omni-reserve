using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmniReserve.API.Contracts.Reservations;
using OmniReserve.Application.Reservations.Commands.CreateReservation;
using OmniReserve.Application.Reservations.Queries.GetAllReservations;
using OmniReserve.Domain.Constants;
using System.Security.Claims;

namespace OmniReserve.API.Controllers;

[Authorize]
[ApiController]
[Route("api/reservations")]
public class ReservationsController : ControllerBase
{
    private readonly ISender _sender;

    public ReservationsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReservationRequest request)
    {
        var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        var userId = Guid.Parse(userIdClaim);

        var command = new CreateReservationCommand(
            userId,
            request.RoomId,
            request.CheckInDate,
            request.CheckOutDate
        );

        var reservationId = await _sender.Send(command);

        return Ok(reservationId);
    }

    [HttpGet("all")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> GetAllReservations()
    {
        var query = new GetAllReservationsQuery();
        var reservations = await _sender.Send(query);
        return Ok(reservations);
    }
}