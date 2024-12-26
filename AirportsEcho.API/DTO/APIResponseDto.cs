using System.Text.Json.Serialization;

namespace AirportsEcho.API.DTO
{
    public class APIResponseDto
    {
        [JsonPropertyName("ErrorCode")]
        public APIErrors ErrorCode { get; set; }

        [JsonPropertyName("ErrorMessage")]
        public string ErrorMessage { get; set; }
    }
}
