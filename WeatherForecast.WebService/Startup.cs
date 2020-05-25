using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherForecast.DomainObjects;
using WeatherForecast.DomainObjects.Ports;
using WeatherForecast.ApplicationServices.GetForecastListUseCase;
using WeatherForecast.ApplicationServices.Ports.Gateways.Database;
using WeatherForecast.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
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
            services.AddDbContext<ForecastContext>(opts =>
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "WeatherForecast.db")}")
            );

            services.AddScoped<IForecastDatabaseGateway, ForecastEFSqliteGateway>();

            services.AddScoped<DbForecastRepository>();
            services.AddScoped<IReadOnlyForecastRepository>(x => x.GetRequiredService<DbForecastRepository>());
            services.AddScoped<IForecastRepository>(x => x.GetRequiredService<DbForecastRepository>());

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
