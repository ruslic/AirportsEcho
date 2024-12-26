using AirportsEcho.Calculator.CalcDistance;
using AirportsEcho.Calculator.Model;

namespace AirportsEcho.Calculator
{
    /// <summary>
    /// Сервис калькуляции
    /// </summary>
    public class CalculatorService : ICalculatorService
    {
        private readonly ICalcDistance _calcDistance;

        public CalculatorService(ICalcDistance calcDistance)
        {
            _calcDistance = calcDistance;
        }

        public double GetDistanceBetweenPoints(GeoPoint point1, GeoPoint point2, DistanceMeasure measure)
        {
            //throw new NotImplementedException("Не реализован сервис калькуляции");
            if (point1 == null || point2 == null)
            {
                throw new AirportsEchoCalculatorException("Не переданы координаты точек");
            }

            return _calcDistance.GetDistance(point1.Longitude, point1.Latitude, point2.Longitude, point2.Latitude, measure);
        }
    }
}
