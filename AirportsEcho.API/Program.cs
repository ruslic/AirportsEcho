using AirportsEcho.API.HealthChecks;
using AirportsEcho.API.Services;
using AirportsEcho.Interaction;

namespace AirportsEcho.API
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IFlightDistanceService, FlightDistanceService>();
            builder.Services.AddScoped<IAirportsInfoService, AirportsInfoService>();
            HealhCheckSettings.RegestryHealhCheck(builder.Services);

            string? url = builder.Configuration["AirportInfoClient"];
            builder.Services.AirportsEchoInteraction(url);
            builder.Services.AirportsEchoCalculator();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            HealhCheckSettings.EndpointsHealhCheck(app);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

