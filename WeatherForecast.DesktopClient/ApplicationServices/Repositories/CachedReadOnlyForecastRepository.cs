using WeatherForecast.ApplicationServices.Ports.Cache;
using WeatherForecast.DomainObjects;
using WeatherForecast.DomainObjects.Ports;
using WeatherForecast.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.ApplicationServices.Repositories 
{
    public class CachedReadOnlyForecastRepository : ReadOnlyForecastRepositoryDecorator
    {
        private readonly IDomainObjectsCache<Forecast> _forecastsCache;

        public CachedReadOnlyForecastRepository(IReadOnlyForecastRepository forecastRepository,
                                             IDomainObjectsCache<Forecast> forecastsCache)
            : base(forecastRepository)
            => _forecastsCache = forecastsCache;

        public async override Task<Forecast> GetForecast(long id)
            => _forecastsCache.GetObject(id) ?? await base.GetForecast(id);

        public async override Task<IEnumerable<Forecast>> GetAllForecasts()
            => _forecastsCache.GetObjects() ?? await base.GetAllForecasts();

        public async override Task<IEnumerable<Forecast>> QueryForecasts(ICriteria<Forecast> criteria)
            => _forecastsCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryForecasts(criteria);

    }
}
