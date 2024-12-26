namespace AirportsEcho.Calculator.CalcDistance
{
    /// <summary>
    /// Использует формулу для расчета из stackoverflow https://stackoverflow.com/questions/6544286/calculate-distance-of-two-geo-points-in-km-c-sharp
    /// </summary>
    public class StackoverflowCalcDistance : ICalcDistance
    {
        public double GetDistance(double lon1, double lat1, double lon2, double lat2, DistanceMeasure measure)
        {
            //throw new AirportsEchoCoreException("Не реализован алгоритм stackoverflow для получение дистанции между двумя точками", CoreErrors.NotImplement);
            double radio = GeoHelper.GetPlanetRadio(measure);

            double sLat1 = Math.Sin(GeoHelper.Radians(lat1));
            double sLat2 = Math.Sin(GeoHelper.Radians(lat2));
            double cLat1 = Math.Cos(GeoHelper.Radians(lat1));
            double cLat2 = Math.Cos(GeoHelper.Radians(lat2));
            double cLon = Math.Cos(GeoHelper.Radians(lon1) - GeoHelper.Radians(lon2));

            double cosD = sLat1 * sLat2 + cLat1 * cLat2 * cLon;

            double d = Math.Acos(cosD);

            double dist = radio * d;

            return dist;
        }
    }
}
