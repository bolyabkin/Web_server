using WeatherForecast.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WeatherForecast.ApplicationServices.Ports.Gateways.Database
{
    public interface IForecastDatabaseGateway
    {
        Task AddForecast(Forecast forecast);

        Task RemoveForecast(Forecast forecast);

        Task UpdateForecast(Forecast forecast);

        Task<Forecast> GetForecast(long id);

        Task<IEnumerable<Forecast>> GetAllForecasts();

        Task<IEnumerable<Forecast>> QueryForecasts(Expression<Func<Forecast, bool>> filter);

    }
}
