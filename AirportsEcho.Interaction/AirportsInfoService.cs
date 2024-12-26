using Microsoft.Extensions.Caching.Memory;

namespace AirportsEcho.Interaction
{
    public class AirportsInfoService : IAirportsInfoService
    {
        private IAirportInfoClient _airportInfoClient;
        private readonly IMemoryCache _memoryCache;

        public AirportsInfoService(IAirportInfoClient airportInfoClient, IMemoryCache memoryCache)
        {
            _airportInfoClient = airportInfoClient;
            _memoryCache = memoryCache;
        }

        public async Task<AirportsEchoInteractionResult?> GetAirportInfoAsync(string iata)
        {
            //throw new NotImplementedException("Не реализован сервис получения информации об аэропорте");
            if (string.IsNullOrEmpty(iata))
            {
                throw new AirportsEchoInteractionException("не передан код IATA");
            }

            _memoryCache.TryGetValue(iata, out AirportsEchoInteractionResult? result);

            if (result == null)
            {
                result = await _airportInfoClient.GetAirportInfoAsync(iata);
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(10)
                };
                _memoryCache.Set(iata, result, cacheOptions);
            }

            return result;
        }
    }
}
