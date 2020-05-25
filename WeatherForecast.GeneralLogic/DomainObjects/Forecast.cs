using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.DomainObjects
{
    public class Forecast : DomainObject 
    {
        public string Date { get; set; }

        public string StartForecast { get; set; }

        public string EndForecast { get; set; }

        public string TypeForecast { get; set; }

        public int MinTemperature { get; set; }

        public int MaxTemperature { get; set; }

    }
}
