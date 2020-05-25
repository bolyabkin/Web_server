using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherForecast.DomainObjects;

namespace WeatherForecast.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForecastController : ControllerBase
    {
        private readonly ILogger<ForecastController> _logger;

        public ForecastController(ILogger<ForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Forecast> GetForecast()
        {
            return new List<Forecast>() 
            { 
                new Forecast() 
                { 
                    Id = 1, 
                    Date = "10.02.2017 17:59:00",
                    MinTemperature = -4,
                    MaxTemperature = -2,
                    TypeForecast ="двенадцатичасовой прогноз",
                    StartForecast = "10.02.2017 21:00:00",
                    EndForecast = "11.02.2017 09:00:00 "
                } 
            };
        }
    }
}
