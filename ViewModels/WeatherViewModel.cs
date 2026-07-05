using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        //private readonly AiService _aiService;
        private readonly ChatMessageViewModel _chatMVM;
        public ICommand GetWeatherCommand { get; }

        public WeatherViewModel(ChatMessageViewModel ChatMVM) {
           
            _chatMVM = ChatMVM;
            _apiService = new ApiService();
         
            GetWeatherCommand = new RelayCommand(() => {

                _ = CityWeatherDetails(City);
                });
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
                OnPropertyChanged(nameof(WeatherIcon));

            }
        }
        private String? _aiResponse;
        public String? AiResponse
        {
            get => _aiResponse;
            set
            {
                if (_aiResponse == value) return;
                _aiResponse = value;
                OnPropertyChanged(nameof(AiResponse));
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading == value) return;
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));   
            }
        }
        private String? _errorMessage;
        public String ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage == value) return;
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        private bool _hasWeatherData;

        public bool HasWeatherData
        {
            get => _hasWeatherData;
            set
            {
                _hasWeatherData = value;
                OnPropertyChanged(nameof(HasWeatherData));
            }
        }


        public String WeatherIcon
        {
            get
            {
                
                if (string.IsNullOrEmpty(Condition))
                    return "❓";

                string condition = Condition.ToLower();

                if (condition.Contains("clear"))
                    return "☀️";

                if (condition.Contains("cloud"))
                    return "☁️";

                if (condition.Contains("rain"))
                    return "🌧️";

                if (condition.Contains("thunder"))
                    return "⛈️";

                return "🌤️";
            }
        }
       
        //Get City weather details
        private async Task CityWeatherDetails(String? city)
        {
            if (String.IsNullOrWhiteSpace(city)) return;
            //WeatherModel weather = new WeatherModel();
            try
            {
                ErrorMessage = "";
                IsLoading = true;
                WeatherModel weather = await _apiService.GetWeatherAsync1(city);
         
            Humidity = weather.Humidity;
            Temperature = weather.Celsius_Temp;
            Condition = weather.Condition;
            City = city;

                HasWeatherData = true;

                var response = await _chatMVM.ProcessWeather(weather);
             

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
             
            }
            finally
            {
                IsLoading = false;
            } 
        }   

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
