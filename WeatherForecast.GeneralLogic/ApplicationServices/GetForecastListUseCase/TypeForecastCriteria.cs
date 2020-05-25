using WeatherForecast.DomainObjects;
using WeatherForecast.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace WeatherForecast.ApplicationServices.GetForecastListUseCase
{
    public class TypeForecastCriteria : ICriteria<Forecast>
    {
        public string TypeForecast { get; }

        public TypeForecastCriteria(string typeForecast)
            => TypeForecast = typeForecast;

        public Expression<Func<Forecast, bool>> Filter
            => (s => s.TypeForecast == TypeForecast);
    }
}
