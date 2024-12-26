using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

namespace AirportEcho.IntegrationTest
{
    public class AirportEchoWebApplicationFactory: WebApplicationFactory<AirportsEcho.API.Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddTransient<HttpMessageHandlerBuilder>(sp => new TestServerHttpMessageHandlerBuilder(this.Server, sp));
            });
        }
    }
}
