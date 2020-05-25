using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherForecast.DomainObjects;
using WeatherForecast.ApplicationServices.GetForecastListUseCase;
using WeatherForecast.InfrastructureServices.Presenters;

namespace WeatherForecast.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForecastController : ControllerBase
    {
        private readonly ILogger<ForecastController> _logger;
        private readonly IGetForecastListUseCase _getForecastListUseCase;

        public ForecastController(ILogger<ForecastController> logger, IGetForecastListUseCase getForecastListUseCase)
        {
            _logger = logger; 
            _getForecastListUseCase = getForecastListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllForecasts()
        {
            var presenter = new ForecastListPresenter();
            await _getForecastListUseCase.Handle(GetForecastListUseCaseRequest.CreateAllForecastsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{routeId}")]
        public async Task<ActionResult> GetForecast(long forecastId) 
        {
            var presenter = new ForecastListPresenter();
            await _getForecastListUseCase.Handle(GetForecastListUseCaseRequest.CreateForecastRequest(forecastId), presenter);
            return presenter.ContentResult;
        }
    }
}
