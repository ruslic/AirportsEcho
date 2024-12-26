using System.Text.Json.Serialization;

namespace AirportsEcho.API.DTO
{
    public class GetDistanceDto: APIResponseDto
    {
        [JsonPropertyName("Distance")]
        public double Distance { get; set; }
    }
}
