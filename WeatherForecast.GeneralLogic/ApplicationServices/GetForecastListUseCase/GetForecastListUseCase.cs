using System.Threading.Tasks;
using System.Collections.Generic;
using WeatherForecast.DomainObjects;
using WeatherForecast.DomainObjects.Ports;
using WeatherForecast.ApplicationServices.Ports;

namespace WeatherForecast.ApplicationServices.GetForecastListUseCase 
{
    public class GetForecastListUseCase : IGetForecastListUseCase
    {
        private readonly IReadOnlyForecastRepository _readOnlyForecastRepository;

        public GetForecastListUseCase(IReadOnlyForecastRepository readOnlyForecastRepository)
            => _readOnlyForecastRepository = readOnlyForecastRepository;

        public async Task<bool> Handle(GetForecastListUseCaseRequest request, IOutputPort<GetForecastListUseCaseResponse> outputPort)
        {
            IEnumerable<Forecast> forecasts = null;
            if (request.ForecastId != null)
            {
                var forecast = await _readOnlyForecastRepository.GetForecast(request.ForecastId.Value);
                forecasts = (forecast != null) ? new List<Forecast>() { forecast } : new List<Forecast>();

            }
            else
            {
                forecasts = await _readOnlyForecastRepository.GetAllForecasts();
            }
            outputPort.Handle(new GetForecastListUseCaseResponse(forecasts));
            return true;
        }
    }
}
