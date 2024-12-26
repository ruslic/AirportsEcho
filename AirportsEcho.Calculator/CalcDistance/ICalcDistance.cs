namespace AirportsEcho.Calculator.CalcDistance
{
    public interface ICalcDistance
    {
        /// <summary>
        /// Получение дистанции между двумя точками
        /// </summary>
        /// <param name="lon1">Долгота первой точки</param>
        /// <param name="lat1">Широта первой точки</param>
        /// <param name="lon2">Долгота второй точки</param>
        /// <param name="lat2">Широта второй точки</param>
        /// <returns></returns>
        public double GetDistance(double lon1, double lat1, double lon2, double lat2, DistanceMeasure measure);
    }
}
