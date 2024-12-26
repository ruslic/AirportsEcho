namespace AirportsEcho.API
{
    public class AirportsEchoApiException: Exception
    {
        public APIErrors ErrorCode { get; set; }
        public AirportsEchoApiException(string message, APIErrors ErrorCode) : base(message)
        {
            this.ErrorCode = ErrorCode;
        }
    }
}
