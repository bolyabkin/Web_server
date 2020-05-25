using WeatherForecast.DomainObjects;
using WeatherForecast.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.ApplicationServices.Repositories
{
    public class InMemoryForecastRepository : IReadOnlyForecastRepository,
                                           IForecastRepository
    {
        private readonly List<Forecast> _forecasts = new List<Forecast>();

        public InMemoryForecastRepository(IEnumerable<Forecast> forecasts = null)
        {
            if (forecasts != null)
            {
                _forecasts.AddRange(forecasts);
            }
        }

        public Task AddForecast(Forecast forecast)
        {
            _forecasts.Add(forecast);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Forecast>> GetAllForecasts()
        {
            return Task.FromResult(_forecasts.AsEnumerable());
        }

        public Task<Forecast> GetForecast(long id)
        {
            return Task.FromResult(_forecasts.Where(o => o.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<Forecast>> QueryForecasts(ICriteria<Forecast> criteria)
        {
            return Task.FromResult(_forecasts.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveForecast(Forecast forecast)
        {
            _forecasts.Remove(forecast);
            return Task.CompletedTask;
        }

        public Task UpdateForecast(Forecast forecast)
        {
            var foundForecast = GetForecast(forecast.Id).Result;
            if (foundForecast == null)
            {
                AddForecast(forecast);
            }
            else
            {
                if (foundForecast != forecast)
                {
                    _forecasts.Remove(foundForecast);
                    _forecasts.Add(forecast);
                }
            }
            return Task.CompletedTask;
        }
    }
}
