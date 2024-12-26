using AirportsEcho.Interaction;
using Polly;

namespace AirportsEcho.API
{
    public static class InteractionDI
    {
        public static IServiceCollection AirportsEchoInteraction(this IServiceCollection services, string url)
        {
            services.AddScoped<IAirportInfoClient, AirportInfoClient>();
            services.AddHttpClient(AirportInfoClient.HttpClientName, httpClient =>
            {
                httpClient.BaseAddress = new Uri(url);
            })
                .AddTransientHttpErrorPolicy(policyBuilder =>
                    policyBuilder.WaitAndRetryAsync(3, retryNumber => TimeSpan.FromMilliseconds(600)));
            services.AddMemoryCache();

            return services;
        }
    }
}
