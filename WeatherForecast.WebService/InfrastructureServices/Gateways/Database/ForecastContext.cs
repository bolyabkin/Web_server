using Microsoft.EntityFrameworkCore;
using WeatherForecast.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.InfrastructureServices.Gateways.Database
{
    public class ForecastContext : DbContext
    {
        public DbSet<Forecast> Forecasts { get; set; }

        public ForecastContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Forecast>().HasData(
                new
                {
                    Id = 1L,
                    Date = "10.02.2017 17:59:00",
                    MinTemperature = -4,
                    MaxTemperature = -2,
                    TypeForecast = "двенадцатичасовой прогноз",
                    StartForecast = "10.02.2017 21:00:00",
                    EndForecast = "11.02.2017 09:00:00 "
                },
                new 
                {
                    Id = 2L,
                    Date = "29.06.2018 06:02:00",
                    MinTemperature = 27,
                    MaxTemperature = 29,
                    TypeForecast = "трехчасовой прогноз",
                    StartForecast = "29.06.2018 09:00:00",
                    EndForecast = "29.06.2018 12:00:00"
                 },
                 new 
                 {
                     Id = 3L,
                     Date = "26.06.2018 05:54:00",
                     MinTemperature = 24,
                     MaxTemperature = 26,
                     TypeForecast = "трехчасовой прогноз",
                     StartForecast = "26.06.2018 09:00:00",
                     EndForecast = "26.06.2018 12:00:00"
                  },
                 new
                 {
                     Id = 4L,
                     Date = "28.06.2018 05:35:00",
                     MinTemperature = 27,
                     MaxTemperature = 29,
                     TypeForecast = "трехчасовой прогноз",
                     StartForecast = "28.06.2018 09:00:00",
                     EndForecast = "28.06.2018 12:00:00"
                 }
            );
        }
    }
}
