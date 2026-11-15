using System.Net;
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
}