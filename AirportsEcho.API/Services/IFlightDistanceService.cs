using AirportsEcho.Calculator;

namespace AirportsEcho.API.Services
{
    public interface IFlightDistanceService
    {
        /// <summary>
        /// Получение расстояния между аэропортами
        /// </summary>
        /// <param name="fromIata">Код IATA первого аэропорта</param>
        /// <param name="toIata">Код IATA второго аэропорта</param>
        /// <returns></returns>
        public Task<double> GetAirportsDistanceAsync(string firstIata, string secondIata, DistanceMeasure Mi);
    }
}
