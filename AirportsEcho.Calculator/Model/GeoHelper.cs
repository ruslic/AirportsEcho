namespace AirportsEcho.Calculator
{
    /// <summary>
    /// Географические замеры
    /// </summary>
    public static class GeoHelper
    {
        /// <summary>
        /// Число Пи
        /// </summary>
        public const double PIx = Math.PI;

        /// <summary>
        /// Радиус земли в километрах
        /// </summary>
        public const double KMRADIO = 6378.16;// km

        /// <summary>
        /// Радиус земли в милях
        /// </summary>
        public const double MilsRADIO = 3963.105464;// mi

        /// <summary>
        /// Получение значение радиуса земли
        /// </summary>
        /// <param name="measure">Размерность</param>
        /// <returns></returns>
        public static double GetPlanetRadio(DistanceMeasure measure)
        {
            double radio = 0;

            switch (measure)
            {
                case DistanceMeasure.Mi:
                    radio = GeoHelper.MilsRADIO;
                    break;
                default:
                    radio = GeoHelper.KMRADIO;
                    break;
            }

            return radio;
        }

        /// <summary>
        /// Получение угла в радианах
        /// </summary>
        /// <param name="x">Точка на окружности</param>
        /// <returns></returns>
        public static double Radians(double x)
        {
            return x * GeoHelper.PIx / 180;
        }
    }
}
