using AirportsEcho.API.DTO;
using AirportsEcho.API.Services;
using AirportsEcho.Calculator;
using AirportsEcho.Interaction;
using Microsoft.AspNetCore.Mvc;

namespace AirportsEcho.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightDistanceController : ControllerBase
    {
        private readonly ILogger<FlightDistanceController> _logger;
        private readonly IFlightDistanceService _flightDistance;

        public FlightDistanceController(ILogger<FlightDistanceController> logger, IFlightDistanceService flightDistance)
        {
            _logger = logger;
            _flightDistance = flightDistance;
        }

        [HttpGet]
        public async Task<GetDistanceDto> GetDistanceMiAsync([FromQuery] string fromIata, [FromQuery] string toIata)
        {
            var getDistanceDto = new GetDistanceDto();
            _logger.LogInformation($"Запрос на получение дистанции. fromIata: {fromIata}, toIata: {toIata}");

            try
            {
                var distance = await _flightDistance.GetAirportsDistanceAsync(fromIata, toIata, DistanceMeasure.Mi);
                getDistanceDto.Distance = distance;
            }
            catch (AirportsEchoInteractionException ex)
            {
                getDistanceDto.ErrorCode = APIErrors.InteractionError;
                getDistanceDto.ErrorMessage = ex.Message;
            }
            catch (AirportsEchoCalculatorException ex)
            {
                getDistanceDto.ErrorCode = APIErrors.Calculation;
                getDistanceDto.ErrorMessage = ex.Message;

            }
            catch (AirportsEchoApiException ex)
            {
                getDistanceDto.ErrorCode = ex.ErrorCode;
                getDistanceDto.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                var inner = ex.GetOriginalException();
                _logger.LogInformation($"Необработанная ошибка: {inner.Message}");
                getDistanceDto.ErrorCode = APIErrors.UbknownError;
                getDistanceDto.ErrorMessage = $"Непредвиденная ошибка получения дистанции между аэропортами {fromIata} и {toIata}";
            }
            finally
            {
                _logger.LogInformation($"Ответ на получение дистанции. Distance: {getDistanceDto.Distance}, ErrorCode: {getDistanceDto.ErrorCode}, ErrorMessage: {getDistanceDto.ErrorMessage}");
            }

            return getDistanceDto;
        }
    }
}
