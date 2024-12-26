using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Text;

namespace AirportsEcho.API.HealthChecks
{
    public static class HealhCheckSettings
    {
        public static void RegestryHealhCheck(IServiceCollection Services)
        {
            Services.AddHealthChecks().AddCheck<HealthCheckLive>(name: "Health_Live", tags: new List<string>() { "Live" });
            Services.AddTransient<HealthCheckAirportInfoClient>();
        }

        public static void EndpointsHealhCheck(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = check => check.Tags.Contains("Live")
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/health/details", async context =>
                {
                    string stringResult = string.Empty;
                    var myHealthCheckAvanpostFam = context.RequestServices.GetService<HealthCheckAirportInfoClient>();

                    if (myHealthCheckAvanpostFam != null)
                    {
                        var resultHealthCheckAvanpostFam = await myHealthCheckAvanpostFam.CheckDetailHealthAsync();
                        stringResult =  $"AirportInfoClient status: {resultHealthCheckAvanpostFam.Status}. {resultHealthCheckAvanpostFam.Description};";
                    }

                    await context.Response.WriteAsync(stringResult);
                });
            });
        }
    }
}
