using AirportsEcho.Interaction.Model;

namespace AirportsEcho.Interaction
{
    public interface IAirportInfoClient
    {
        public Task<CheckIntegrationResponse> CheckIntegrationAsync();

        public Task<AirportsEchoInteractionResult> GetAirportInfoAsync(string iata);
    }
}
