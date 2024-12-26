using AirportsEcho.Interaction.Model;
using System.Net.Http.Json;

namespace AirportsEcho.Interaction
{
    public class AirportInfoClient : IAirportInfoClient
    {
        public const string HttpClientName = "AirportsEcho";
        private readonly IHttpClientFactory _clientFactory;

        public AirportInfoClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<CheckIntegrationResponse> CheckIntegrationAsync()
        {
            string url = $"airports/KZN"; //$"{baseUrl}airports/AMS";

            var checkIntegration = new CheckIntegrationResponse();

            try
            {
                var client = _clientFactory.CreateClient(HttpClientName);
                checkIntegration.Url = $"{client.BaseAddress}{url}";
                HttpResponseMessage response = await client.GetAsync(url);
                checkIntegration.HttpStatusCode = response.StatusCode;
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException httpException)
            {
                checkIntegration.ErrorMessage = httpException.Message;
                checkIntegration.HttpStatusCode = httpException.StatusCode;
            }
            catch (Exception ex)
            {
                checkIntegration.ErrorMessage = ex.Message;
            }

            return checkIntegration;
        }

        public async Task<AirportsEchoInteractionResult> GetAirportInfoAsync(string iata)
        {
            var airportInfoClientResponse = new AirportsEchoInteractionResult();

            try
            {
                var client = _clientFactory.CreateClient(HttpClientName);
                string url = $"airports/{iata}";
                HttpResponseMessage response = await client.GetAsync(url);
                airportInfoClientResponse.HttpStatusCode = response.StatusCode;
                airportInfoClientResponse.IsSuccess = response.IsSuccessStatusCode;
                response.EnsureSuccessStatusCode();
                AirPortInfoDto? airPortInfoDto = await response.Content.ReadFromJsonAsync<AirPortInfoDto>();

                if (airPortInfoDto == null)
                {
                    throw new AirportsEchoInteractionException($"Не смог преобразовать объект ответа по запросу {url}");
                }

                airportInfoClientResponse.AirportInfo = new AirportInfo
                {
                    City = airPortInfoDto.City,
                    Latitude = airPortInfoDto.Location.Latitude,
                    Longitude = airPortInfoDto.Location.Longitude,
                };
            }
            catch (AirportsEchoInteractionException ex)
            {
                airportInfoClientResponse.ErrorMessage = ex.Message;
            }
            catch (HttpRequestException ex)
            {
                airportInfoClientResponse.ErrorMessage = $"Ошибка получения информации об аэропорте {iata}: {ex.Message}";
                airportInfoClientResponse.HttpStatusCode = ex.StatusCode;
            }
            catch (Exception ex)
            {
                airportInfoClientResponse.ErrorMessage = ex.Message;
            }

            return airportInfoClientResponse;
        }
    }
}
