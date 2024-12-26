using AirportsEcho.Calculator.CalcDistance;

namespace AirportsEcho.Calculator.Tests
{
    public class CalcStackoverflowTests
    {
        [Theory]
        [InlineData(4.763385, 52.309069, 49.29824, 55.608439, DistanceMeasure.Km, 2888.8875)]
        [InlineData(4.763385, 52.309069, 49.29824, 55.608439, DistanceMeasure.Mi, 1795.0265)]
        public void CalcStackoverflow_AbsoluteEqual(double lon1, double lat1, double lon2, double lat2, DistanceMeasure measure, double expected)
        {
            var calcStackoverflow = new StackoverflowCalcDistance();
            var result = calcStackoverflow.GetDistance(lon1, lat1, lon2, lat2, measure);
            Assert.Equal(expected, Math.Round(result, 4));
        }

        [Fact]
        public void CalcStackoverflow_InvertEqual()
        {
            double lon1 = 4.763385;
            double lat1 = 52.309069;
            double lon2 = 49.29824;
            double lat2 = 55.608439;
            DistanceMeasure measure = DistanceMeasure.Km;
            var calcStackoverflow = new StackoverflowCalcDistance();
            var result1 = calcStackoverflow.GetDistance(lon1, lat1, lon2, lat2, measure);
            var result2 = calcStackoverflow.GetDistance(lon2, lat2, lon1, lat1, measure);
            Assert.Equal(result1, result2);
        }

        [Fact]
        public void CalcStackoverflow_ZeroEqual()
        {
            double lon1 = 4.763385;
            double lat1 = 52.309069;
            DistanceMeasure measure = DistanceMeasure.Km;
            var calcStackoverflow = new StackoverflowCalcDistance();
            var result = calcStackoverflow.GetDistance(lon1, lat1, lon1, lat1, measure);
            Assert.Equal(result, 0);
        }
    }
}