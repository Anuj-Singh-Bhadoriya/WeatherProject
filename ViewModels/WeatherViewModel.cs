using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using WeatherAppApi.Commands;
using WeatherAppApi.Model;
using WeatherAppApi.Services;

namespace WeatherAppApi.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly ApiService _apiService;
        public ICommand GetWeatherCommand { get; }

        public WeatherViewModel() {
            _apiService = new ApiService();
            GetWeatherCommand = new RelayCommand(() => _ = CityWeatherDetails(City));
        }
        private String? _city;
        public string? City
        {
            get => _city;

            set
            {
                if (_city == value) return;
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }
        private double? _temperature;
        public double? Temperature
        {
            get => _temperature;
            set
            {
                if(_temperature == value) return;
                _temperature = value;
                OnPropertyChanged(nameof(Temperature));
            
            }
        }
        private int? _humidity;
        public int? Humidity
        {
            get => _humidity;
            set
            {
                if (_humidity == value) return;
                _humidity = value;
                OnPropertyChanged(nameof(Humidity));
            }
        }
        private String? _condition;
        public String? Condition
        {
            get => _condition;
            set {
                if (_condition == value) return;
                _condition = value;
                OnPropertyChanged(nameof(Condition));

            }
        }
         
       
       
        //Get City weather details
        private async Task CityWeatherDetails(String? city)
        {
            if (String.IsNullOrWhiteSpace(city)) return;
            //WeatherModel weather = new WeatherModel();
                WeatherModel weather = await _apiService.GetWeatherAsync1(city);
            Humidity = weather.Humidity;
            Temperature = weather.Celsius_Temp;
            Condition = weather.Condition;
            City = city;
            

        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
