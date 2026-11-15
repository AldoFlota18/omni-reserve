using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace OmniReserve.IntegrationTests;

public class RoomsControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public RoomsControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetRooms_ReturnsOk()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/rooms");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetRoomById_WhenRoomDoesNotExist_ReturnsNotFound()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"/api/rooms/{Guid.NewGuid()}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CreateRoom_WithInvalidJson_ReturnsBadRequest()
    {
        var client = _factory.CreateClient();

        var invalidCommand = new { RoomNumber = "", PricePerNight = -100 };

        var response = await client.PostAsJsonAsync("/api/rooms", invalidCommand);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}