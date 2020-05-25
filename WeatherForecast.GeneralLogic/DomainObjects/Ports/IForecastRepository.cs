using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace WeatherForecast.DomainObjects.Ports
{
    public interface IReadOnlyForecastRepository
    {
        Task<Forecast> GetForecast(long id);

        Task<IEnumerable<Forecast>> GetAllForecasts();

        Task<IEnumerable<Forecast>> QueryForecasts(ICriteria<Forecast> criteria);

    }

    public interface IForecastRepository
    {
        Task AddForecast(Forecast forecast);

        Task RemoveForecast(Forecast forecast);

        Task UpdateForecast(Forecast forecast);
    }
}
