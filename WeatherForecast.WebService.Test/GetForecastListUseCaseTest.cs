using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using WeatherForecast.ApplicationServices.Repositories;
using WeatherForecast.ApplicationServices.Ports;
using WeatherForecast.ApplicationServices.GetForecastListUseCase;
using Xunit;
using WeatherForecast.DomainObjects;

namespace WeatherForecast.WebService.Tests
{
    public class GetForecastListUseCaseTest
    {
        private InMemoryForecastRepository CreateRoteRepository()
        {
            var repo = new InMemoryForecastRepository(new List<Forecast> {
                new Forecast { Id = 1,  Date = "10.02.2017 17:58:00", MinTemperature = 4,  MaxTemperature = 5, TypeForecast ="двенадцатичасовой прогноз",
                    StartForecast = "10.02.2017 20:00:00",  EndForecast = "11.02.2017 09:00:00"},
                new Forecast { Id = 2,  Date = "11.03.2017 17:57:00", MinTemperature = -6,  MaxTemperature = 6, TypeForecast ="одиннадцатичасовой прогноз",
                    StartForecast = "11.03.2017 21:00:00",  EndForecast = "11.02.2017 10:00:00"},
                new Forecast { Id = 3,  Date = "12.04.2017 17:56:00", MinTemperature = -5,  MaxTemperature = 7, TypeForecast ="тринадцатичасовой прогноз",
                    StartForecast = "12.04.2017 22:00:00",  EndForecast = "11.02.2017 11:00:00"},
                new Forecast { Id = 4,  Date = "13.05.2017 17:55:00", MinTemperature = -3,  MaxTemperature = 8, TypeForecast ="пятнадцатичасовой прогноз",
                    StartForecast = "13.05.2017 23:00:00",  EndForecast = "11.02.2017 12:00:00"},
            });
            return repo;
        }

        [Fact]
        public void TestGetAllForecasts()
        {
            var useCase = new GetForecastListUseCase(CreateRoteRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetForecastListUseCaseRequest.CreateAllForecastsRequest(), outputPort).Result);
            Assert.Equal<int>(4, outputPort.Forecasts.Count());
            Assert.Equal(new long[] { 1, 2, 3, 4 }, outputPort.Forecasts.Select(o => o.Id));
        }

        [Fact]
        public void TestGetAlllympiadsFromEmptyRepository()
        {
            var useCase = new GetForecastListUseCase(new InMemoryForecastRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetForecastListUseCaseRequest.CreateAllForecastsRequest(), outputPort).Result);
            Assert.Empty(outputPort.Forecasts);
        }

        [Fact]
        public void TestGetForecast()
        {
            var useCase = new GetForecastListUseCase(CreateRoteRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetForecastListUseCaseRequest.CreateForecastRequest(2), outputPort).Result);
            Assert.Single(outputPort.Forecasts, r => 2 == r.Id);
        }

        [Fact]
        public void TestTryGetNotExistingForecast()
        {
            var useCase = new GetForecastListUseCase(CreateRoteRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetForecastListUseCaseRequest.CreateForecastRequest(999), outputPort).Result);
            Assert.Empty(outputPort.Forecasts);
        }

    }

    class OutputPort : IOutputPort<GetForecastListUseCaseResponse>
    {
        public IEnumerable<Forecast> Forecasts { get; private set; }

        public void Handle(GetForecastListUseCaseResponse response)
        {
            Forecasts = response.Forecasts;
        }
    }

}
