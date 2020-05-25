using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.ApplicationServices.GetForecastListUseCase;
using WeatherForecast.ApplicationServices.Ports.Cache;
using WeatherForecast.ApplicationServices.Repositories;
using WeatherForecast.DesktopClient.InfrastructureServices.ViewModels;
using WeatherForecast.DomainObjects;
using WeatherForecast.DomainObjects.Ports;
using WeatherForecast.InfrastructureServices.Cache;
using WeatherForecast.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WeatherForecast.DesktopClient 
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<Forecast>, DomainObjectsMemoryCache<Forecast>>();
            services.AddSingleton<NetworkForecastRepository>(
                x => new NetworkForecastRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<Forecast>>())
            );
            services.AddSingleton<CachedReadOnlyForecastRepository>(
                x => new CachedReadOnlyForecastRepository(
                    x.GetRequiredService<NetworkForecastRepository>(),
                    x.GetRequiredService<IDomainObjectsCache<Forecast>>()
                )
            );
            services.AddSingleton<IReadOnlyForecastRepository>(x => x.GetRequiredService<CachedReadOnlyForecastRepository>());
            services.AddSingleton<IGetForecastListUseCase, GetForecastListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
