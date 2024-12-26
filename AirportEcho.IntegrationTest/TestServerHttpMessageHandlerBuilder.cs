using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Http;
using System.Diagnostics.CodeAnalysis;

namespace AirportEcho.IntegrationTest
{
    /// <summary>
    /// Замена всех HttpClient
    /// https://stackoverflow.com/questions/70002621/inject-httpclient-from-webapplicationfactory
    /// </summary>
    public class TestServerHttpMessageHandlerBuilder : HttpMessageHandlerBuilder
    {
        public TestServerHttpMessageHandlerBuilder(TestServer testServer, IServiceProvider services)
        {
            Services = services;
            PrimaryHandler = testServer.CreateHandler();
        }

        private string? _name;

        [DisallowNull]
        public override string? Name
        {
            get => _name;
            set
            {
                ArgumentNullException.ThrowIfNull(value);
                _name = value;
            }
        }

        public override HttpMessageHandler PrimaryHandler { get; set; }

        public override IList<DelegatingHandler> AdditionalHandlers { get; } = new List<DelegatingHandler>();

        public override IServiceProvider Services { get; }

        public override HttpMessageHandler Build()
        {
            if (PrimaryHandler == null)
            {
                throw new InvalidOperationException($"{nameof(PrimaryHandler)} must not be null");
            }

            return CreateHandlerPipeline(PrimaryHandler, AdditionalHandlers);
        }
    }
}
