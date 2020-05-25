using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherForecast.DomainObjects;
using WeatherForecast.DomainObjects.Ports;
using WeatherForecast.ApplicationServices.GetForecastListUseCase;
using WeatherForecast.ApplicationServices.Repositories;
using System.Collections.Generic;


namespace WeatherForecast.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<InMemoryForecastRepository>(x => new InMemoryForecastRepository(
               new List<Forecast>()
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
                    },
                    new Forecast()
                    {
                    Id = 2,
                    Date = "29.06.2018 06:02:00",
                    MinTemperature = 27,
                    MaxTemperature = 29,
                    TypeForecast ="трехчасовой прогноз",
                    StartForecast = "29.06.2018 09:00:00",
                    EndForecast = "29.06.2018 12:00:00"
                    },
                    new Forecast
                    {
                    Id = 3,
                    Date = "26.06.2018 05:54:00",
                    MinTemperature = 24,
                    MaxTemperature = 26,
                    TypeForecast ="трехчасовой прогноз",
                    StartForecast = "26.06.2018 09:00:00",
                    EndForecast = "26.06.2018 12:00:00"
                    }
            }));
            services.AddScoped<IReadOnlyForecastRepository>(x => x.GetRequiredService<InMemoryForecastRepository>());
            services.AddScoped<IForecastRepository>(x => x.GetRequiredService<InMemoryForecastRepository>());

            services.AddScoped<IGetForecastListUseCase, GetForecastListUseCase>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
