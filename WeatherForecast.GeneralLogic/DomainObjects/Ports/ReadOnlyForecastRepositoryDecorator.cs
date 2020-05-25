using WeatherForecast.DomainObjects;
using WeatherForecast.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.DomainObjects.Repositories
{
    public abstract class ReadOnlyForecastRepositoryDecorator : IReadOnlyForecastRepository
    {
        private readonly IReadOnlyForecastRepository _forecastRepository;

        public ReadOnlyForecastRepositoryDecorator(IReadOnlyForecastRepository forecastRepository)
        {
            _forecastRepository = forecastRepository;
        }

        public virtual async Task<IEnumerable<Forecast>> GetAllForecasts()
        {
            return await _forecastRepository?.GetAllForecasts();
        }

        public virtual async Task<Forecast> GetForecast(long id)
        {
            return await _forecastRepository?.GetForecast(id);
        }

        public virtual async Task<IEnumerable<Forecast>> QueryForecasts(ICriteria<Forecast> criteria)
        {
            return await _forecastRepository?.QueryForecasts(criteria);
        }
    }
}
