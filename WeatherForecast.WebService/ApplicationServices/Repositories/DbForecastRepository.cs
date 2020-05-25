using System;
using WeatherForecast.DomainObjects;
using WeatherForecast.DomainObjects.Ports;
using WeatherForecast.ApplicationServices.Ports.Gateways.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.ApplicationServices.Repositories
{
    public class DbForecastRepository : IReadOnlyForecastRepository,
                                     IForecastRepository
    {
        private readonly IForecastDatabaseGateway _databaseGateway;

        public DbForecastRepository(IForecastDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<Forecast> GetForecast(long id)
            => await _databaseGateway.GetForecast(id);

        public async Task<IEnumerable<Forecast>> GetAllForecasts()
            => await _databaseGateway.GetAllForecasts();

        public async Task<IEnumerable<Forecast>> QueryForecasts(ICriteria<Forecast> criteria)
            => await _databaseGateway.QueryForecasts(criteria.Filter);

        public async Task AddForecast(Forecast forecast)
            => await _databaseGateway.AddForecast(forecast);

        public async Task RemoveForecast(Forecast forecast)
            => await _databaseGateway.RemoveForecast(forecast);

        public async Task UpdateForecast(Forecast forecast)
            => await _databaseGateway.UpdateForecast(forecast);
    }
}
