using AirportsEcho.Interaction.Model;

namespace AirportsEcho.Interaction
{
    public interface IAirportsInfoService
    {
        /// <summary>
        /// Получение информации об аэропорте
        /// </summary>
        /// <param name="iata">Код IATA</param>
        /// <returns></returns>
        public Task<AirportsEchoInteractionResult?> GetAirportInfoAsync(string iata);
    }
}
