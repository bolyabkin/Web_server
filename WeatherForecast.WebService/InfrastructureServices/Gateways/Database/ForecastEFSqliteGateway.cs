using WeatherForecast.DomainObjects;
using WeatherForecast.ApplicationServices.Ports.Gateways.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace WeatherForecast.InfrastructureServices.Gateways.Database
{
    public class ForecastEFSqliteGateway : IForecastDatabaseGateway
    {
        private readonly ForecastContext _forecastContext;

        public ForecastEFSqliteGateway(ForecastContext forecastContext)
            => _forecastContext = forecastContext;

        public async Task<Forecast> GetForecast(long id)
           => await _forecastContext.Forecasts.Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Forecast>> GetAllForecasts()
            => await _forecastContext.Forecasts.ToListAsync();

        public async Task<IEnumerable<Forecast>> QueryForecasts(Expression<Func<Forecast, bool>> filter)
            => await _forecastContext.Forecasts.Where(filter).ToListAsync();

        public async Task AddForecast(Forecast forecast)
        {
            _forecastContext.Forecasts.Add(forecast);
            await _forecastContext.SaveChangesAsync();
        }

        public async Task UpdateForecast(Forecast forecast)
        {
            _forecastContext.Entry(forecast).State = EntityState.Modified;
            await _forecastContext.SaveChangesAsync();
        }

        public async Task RemoveForecast(Forecast forecast)
        {
            _forecastContext.Forecasts.Remove(forecast);
            await _forecastContext.SaveChangesAsync();
        }
    }
}
