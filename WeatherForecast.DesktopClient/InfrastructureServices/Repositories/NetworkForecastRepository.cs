using WeatherForecast.ApplicationServices.Ports.Cache;
using WeatherForecast.DomainObjects;
using WeatherForecast.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WeatherForecast.InfrastructureServices.Repositories
{
    public class NetworkForecastRepository : NetworkRepositoryBase, IReadOnlyForecastRepository
    {
        private readonly IDomainObjectsCache<Forecast> _forecastCache;

        public NetworkForecastRepository(string host, ushort port, bool useTls, IDomainObjectsCache<Forecast> forecastCache)
            : base(host, port, useTls)
            => _forecastCache = forecastCache;

        public async Task<Forecast> GetForecast(long id)
            => CacheAndReturn(await ExecuteHttpRequest<Forecast>($"Forecast/{id}"));

        public async Task<IEnumerable<Forecast>> GetAllForecasts()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<Forecast>>($"Forecast"), allObjects: true);

        public async Task<IEnumerable<Forecast>> QueryForecasts(ICriteria<Forecast> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<Forecast>>($"Forecast"), allObjects: true)
               .Where(criteria.Filter.Compile());

        private IEnumerable<Forecast> CacheAndReturn(IEnumerable<Forecast> forecasts, bool allObjects = false)
        {
            if (allObjects)
            {
                _forecastCache.ClearCache();
            }
            _forecastCache.UpdateObjects(forecasts, DateTime.Now.AddDays(1), allObjects);
            return forecasts;
        }

        private Forecast CacheAndReturn(Forecast forecast)
        {
            _forecastCache.UpdateObject(forecast, DateTime.Now.AddDays(1));
            return forecast;
        }
    }
}
