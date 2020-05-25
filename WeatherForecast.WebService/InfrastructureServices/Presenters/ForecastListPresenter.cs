using System.Net;
using Newtonsoft.Json;
using WeatherForecast.ApplicationServices.Ports;
using WeatherForecast.ApplicationServices.GetForecastListUseCase;

namespace WeatherForecast.InfrastructureServices.Presenters
{
    public class ForecastListPresenter : IOutputPort<GetForecastListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ForecastListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetForecastListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.Forecasts) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
