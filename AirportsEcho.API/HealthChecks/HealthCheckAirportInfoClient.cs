using AirportsEcho.Interaction;
using AirportsEcho.Interaction.Model;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net;

namespace AirportsEcho.API.HealthChecks
{
    public class HealthCheckAirportInfoClient : IHealthCheck
    {
        private readonly IAirportInfoClient _httpClient;

        public HealthCheckAirportInfoClient(IAirportInfoClient airportInfoClient)
        {
            _httpClient = airportInfoClient;
        }

        public async Task<HealthCheckResult> CheckDetailHealthAsync()
        {
            string error = string.Empty;
            CheckIntegrationResponse response = await _httpClient.CheckIntegrationAsync();

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                return await Task.FromResult(HealthCheckResult.Healthy($"{response.Url} is available"));
            }
            else
            {
                return await Task.FromResult(HealthCheckResult.Unhealthy($"{response.Url} is not available. {response.HttpStatusCode}. {response.ErrorMessage}"));
            }
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return await CheckDetailHealthAsync();
        }
    }
}
