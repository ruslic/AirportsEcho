using MockData;
using Moq;

namespace AirportsEcho.Interaction.Tests
{
    public class AirportInfoClientTests
    {
        [Fact]
        public async Task GetAirportInfoAsync_IsType_AirportInfo()
        {
            var httpResponses = new List<MockHttpResponse>
            {
                new MockHttpResponse
                {
                    UrlPart = "/some-path", 
                    Response = new AirPortInfoDto
                    {
                        City = "TestCity",
                        Iata = "TCY",
                        Location = new LocationDto{Latitude = 1, Longitude = 2}
                    }
                }
            };
            var httpClientFactory = MockHttpClientFactory.Create(AirportInfoClient.HttpClientName, httpResponses);
            var airportInfoClient = new AirportInfoClient(httpClientFactory);
            AirportsEchoInteractionResult result = await airportInfoClient.GetAirportInfoAsync(It.IsAny<string>());
            Assert.IsType<AirportInfo>(result.AirportInfo);
        }
    }
}