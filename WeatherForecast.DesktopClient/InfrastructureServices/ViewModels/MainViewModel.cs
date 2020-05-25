using WeatherForecast.ApplicationServices.GetForecastListUseCase;
using WeatherForecast.ApplicationServices.Ports;
using WeatherForecast.DomainObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WeatherForecast.DesktopClient.InfrastructureServices.ViewModels 
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetForecastListUseCase _getForecastListUseCase;

        public MainViewModel(IGetForecastListUseCase getForecastListUseCase)
            => _getForecastListUseCase = getForecastListUseCase;

        private Task<bool> _loadingTask;
        private Forecast _currentForecast;
        private ObservableCollection<Forecast> _forecasts;

        public event PropertyChangedEventHandler PropertyChanged;

        public Forecast CurrentForecast
        {
            get => _currentForecast;
            set
            {
                if (_currentForecast != value)
                {
                    _currentForecast = value;
                    OnPropertyChanged(nameof(CurrentForecast));
                }
            }
        }

        private async Task<bool> LoadForecasts()
        {
            var outputPort = new OutputPort();
            bool result = await _getForecastListUseCase.Handle(GetForecastListUseCaseRequest.CreateAllForecastsRequest(), outputPort);
            if (result)
            {
                Forecasts = new ObservableCollection<Forecast>(outputPort.Forecasts);
            }
            return result;
        }

        public ObservableCollection<Forecast> Forecasts
        {
            get
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadForecasts();
                }

                return _forecasts;
            }
            set
            {
                if (_forecasts != value)
                {
                    _forecasts = value;
                    OnPropertyChanged(nameof(Forecasts));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetForecastListUseCaseResponse>
        {
            public IEnumerable<Forecast> Forecasts { get; private set; }

            public void Handle(GetForecastListUseCaseResponse response)
            {
                if (response.Success)
                {
                    Forecasts = new ObservableCollection<Forecast>(response.Forecasts);
                }
            }
        }
    }
}
