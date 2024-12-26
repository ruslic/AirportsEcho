using AirportsEcho.Calculator.CalcDistance;
using AirportsEcho.Calculator;

namespace AirportsEcho.API
{
    public static class CalculatorDI
    {
        public static IServiceCollection AirportsEchoCalculator(this IServiceCollection services)
        {
            services.AddScoped<ICalcDistance, StackoverflowCalcDistance>();
            services.AddScoped<ICalculatorService, CalculatorService>();
            return services;
        }
    }
}
