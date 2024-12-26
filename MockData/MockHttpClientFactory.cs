using Moq;
using Moq.Protected;
using System.Text.Json;

namespace MockData
{
    /// <summary>
    /// https://stackoverflow.com/questions/54227487/how-to-mock-the-new-httpclientfactory-in-net-core-2-1-using-moq
    /// </summary>
    public class MockHttpClientFactory
    {
        public static IHttpClientFactory Create(string name, MockHttpResponse response)
        {
            return Create(name, new List<MockHttpResponse> { response });
        }

        public static IHttpClientFactory Create(string name, List<MockHttpResponse> responses)
        {

            Mock<HttpMessageHandler> messageHandler = SendAsyncHandler(responses);

            var mockHttpClientFactory = new Mock<IHttpClientFactory>();

            mockHttpClientFactory
                .Setup(x => x.CreateClient(name))
                .Returns(new HttpClient(messageHandler.Object)
                {
                    BaseAddress = new Uri("https://mockdomain.mock")
                });

            return mockHttpClientFactory.Object;
        }

        private static Mock<HttpMessageHandler> SendAsyncHandler(List<MockHttpResponse> responses)
        {
            var messageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            foreach (var response in responses)
            {
                messageHandler
                    .Protected()
                    .Setup<Task<HttpResponseMessage>>("SendAsync",
                        ItExpr.IsAny<HttpRequestMessage>(),
                        ItExpr.IsAny<CancellationToken>())
                    .ReturnsAsync(new HttpResponseMessage
                    {
                        StatusCode = response.StatusCode,
                        Content = (response.Response?.GetType() == typeof(string)
                            ? new StringContent(response.Response?.ToString() ?? "")
                            : new StringContent(JsonSerializer.Serialize(response.Response)))
                    })
                    .Verifiable();
            }

            return messageHandler;
        }
    }
}
