using System.Net;

namespace AirportsEcho.Interaction
{
    public class AirportsEchoInteractionResult
    {
        public AirportInfo AirportInfo { get; set; }

        public HttpStatusCode? HttpStatusCode { get; set; }

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }
    }
}
