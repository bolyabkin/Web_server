using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.ApplicationServices.Interfaces;

namespace WeatherForecast.ApplicationServices.GetForecastListUseCase
{
    public interface IGetForecastListUseCase : IUseCase<GetForecastListUseCaseRequest, GetForecastListUseCaseResponse>
    {
    }
}
