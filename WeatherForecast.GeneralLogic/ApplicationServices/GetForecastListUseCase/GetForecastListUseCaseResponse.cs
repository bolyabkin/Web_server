using WeatherForecast.DomainObjects;
using WeatherForecast.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.ApplicationServices.GetForecastListUseCase
{
    public class GetForecastListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<Forecast> Forecasts { get; }

        public GetForecastListUseCaseResponse(IEnumerable<Forecast> forecasts) => Forecasts = forecasts;
    }
}
