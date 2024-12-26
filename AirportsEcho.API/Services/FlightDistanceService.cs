
using AirportsEcho.Calculator;
using AirportsEcho.Calculator.Model;
using AirportsEcho.Interaction;

namespace AirportsEcho.API.Services
{
    public class FlightDistanceService : IFlightDistanceService
    {
        private readonly ICalculatorService _calculatorService;
        private readonly IAirportsInfoService _airportsInfo;

        public FlightDistanceService(ICalculatorService calculatorService, IAirportsInfoService airportsInfo)
        {
            _calculatorService = calculatorService;
            _airportsInfo = airportsInfo;
        }

        public async Task<double> GetAirportsDistanceAsync(string firstIata, string secondIata, DistanceMeasure Mi)
        {
            var firstAirportInfoTask = _airportsInfo.GetAirportInfoAsync(firstIata);
            var secondairportInfoTask = _airportsInfo.GetAirportInfoAsync(secondIata);
            var airportsTask = Task.WhenAll(firstAirportInfoTask, secondairportInfoTask);

            try
            {
                var airports = await airportsTask;
                var firstAirportInfoResult = airports[0];
                var secondAirportInfoResul = airports[1];

                if (firstAirportInfoResult == null || secondAirportInfoResul == null)
                {
                    throw new AirportsEchoApiException($"Ошибка получения информации об аэропортах", APIErrors.InteractionError);
                }
                else if (!firstAirportInfoResult.IsSuccess)
                {
                    throw new AirportsEchoApiException(firstAirportInfoResult.ErrorMessage, APIErrors.InteractionError);
                }
                else if (!secondAirportInfoResul.IsSuccess)
                {
                    throw new AirportsEchoApiException(secondAirportInfoResul.ErrorMessage, APIErrors.InteractionError);
                }

                var point1 = new GeoPoint
                {
                    Longitude = firstAirportInfoResult.AirportInfo.Longitude,
                    Latitude = firstAirportInfoResult.AirportInfo.Latitude
                };
                var point2 = new GeoPoint
                {
                    Longitude = secondAirportInfoResul.AirportInfo.Longitude,
                    Latitude = secondAirportInfoResul.AirportInfo.Latitude
                };
                return _calculatorService.GetDistanceBetweenPoints(point1, point2, Mi);
            }
            catch (Exception)
            {
                if (airportsTask.Exception != null)
                {
                    throw airportsTask.Exception;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
