using System.Text.Json.Serialization;

namespace AirportsEcho.Interaction
{
    /// <summary>
    /// Объект ответа по информации об аэропорте для координат
    /// </summary>
    public class LocationDto
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
    }

    /// <summary>
    /// Объект ответа по информации об аэропорте
    /// </summary>
    public class AirPortInfoDto
    {
        [JsonPropertyName("iata")]
        public string Iata {  get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("location")]
        public LocationDto Location { get; set; }

    }
}
