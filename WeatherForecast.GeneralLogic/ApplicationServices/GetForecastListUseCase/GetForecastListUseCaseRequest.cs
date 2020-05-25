using WeatherForecast.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.ApplicationServices.GetForecastListUseCase
{
    public class GetForecastListUseCaseRequest : IUseCaseRequest<GetForecastListUseCaseResponse>
    {
        public long? ForecastId { get; private set; }

        private GetForecastListUseCaseRequest()
        { }

        public static GetForecastListUseCaseRequest CreateAllForecastsRequest()
        {
            return new GetForecastListUseCaseRequest();
        }

        public static GetForecastListUseCaseRequest CreateForecastRequest(long forecastId)
        {
            return new GetForecastListUseCaseRequest() { ForecastId = forecastId };

        }
    }
}

