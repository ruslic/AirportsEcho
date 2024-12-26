using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AirportsEcho.API.HealthChecks
{
    public class HealthCheckLive : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var HealthCheckResult = new HealthCheckResult();
            HealthCheckResult = new HealthCheckResult(status: HealthStatus.Healthy);
            return Task.FromResult(HealthCheckResult);
        }
    }
}
