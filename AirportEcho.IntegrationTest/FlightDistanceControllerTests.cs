using AirportsEcho.API.DTO;
using System.Net.Http.Json;

namespace AirportEcho.IntegrationTest
{
    public class FlightDistanceControllerTests : IClassFixture<AirportEchoWebApplicationFactory>
    {
        private readonly AirportEchoWebApplicationFactory _fixture;

        public FlightDistanceControllerTests(AirportEchoWebApplicationFactory fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task FlightDistanceControllerGetDistance()
        {
            HttpClient client = _fixture.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/FlightDistance?fromIata=KZN&toIata=AMS");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            var airPortInfoDto = await response.Content.ReadFromJsonAsync<GetDistanceDto>();
            Assert.NotNull(airPortInfoDto);
        }
    }
}