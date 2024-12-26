using System.Net;

namespace MockData
{
    public class MockHttpResponse
    {
        public MockHttpResponse()
        {
        }

        public MockHttpResponse(string urlPart, object response, HttpStatusCode statusCode)
        {
            this.UrlPart = urlPart;
            this.Response = response;
            this.StatusCode = statusCode;
        }


        public string UrlPart { get; set; } = String.Empty;

        public object Response { get; set; } = default!;

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
