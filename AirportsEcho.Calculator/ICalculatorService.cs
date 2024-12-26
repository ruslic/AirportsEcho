using AirportsEcho.Calculator.Model;

namespace AirportsEcho.Calculator
{
    public interface ICalculatorService
    {
        /// <summary>
        /// Получение дистанции между двумя точками
        /// </summary>
        /// <param name="point1">Координата первой точки</param>
        /// <param name="point2">Координата второй точки</param>
        /// <param name="measure">Размерность расстояния</param>
        /// <returns>Расстояние между точками</returns>
        public double GetDistanceBetweenPoints(GeoPoint point1, GeoPoint point2, DistanceMeasure measure);
    }
}
