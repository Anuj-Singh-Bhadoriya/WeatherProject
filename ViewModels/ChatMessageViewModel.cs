using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherAppApi.Model;
using WeatherAppApi.Services;

namespace WeatherAppApi.ViewModels
{
    public class ChatMessageViewModel :  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly AiService _aiService;
        private ICommand getApiCommand { get; }
        
        public ChatMessageViewModel()
        {
            _aiService = new AiService();
            
        }

        private string? _sender;
        public string? Sender 
        {

            get => _sender;
            set
            {
                if (_sender == value) return;
                    _sender = value;

                OnPropertyChanged(nameof(Sender));
               
            }
                
        }
        private String? _message;
        public String? Message
        {
            get=> _message;
            set
            {
                if (_message == value) return;
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        private TimeOnly? _time;
        public TimeOnly? Time
        {
            get => _time;
            set
            {
                if (_time == value) return;
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }
        private String? _cityWeather;
        public String? CityWeather
        {
            get => _cityWeather;
            set
            {
                if(_cityWeather == value) return;
                _cityWeather    = value;    
                OnPropertyChanged(nameof(CityWeather));

            }
        }
        
        public async Task<String> ProcessWeather(WeatherModel weather)
        {

            string prompt =
                $"""
                    Explain this weather and give advice:

                    City: {weather.City}
                    Temperature: {weather.Celsius_Temp}
                    Humidity: {weather.Humidity}
                    Condition: {weather.Condition}

                    Give 2 lines of advice.
                    """;

            CityWeather =  $"👤 City: {weather.City}";

            Sender = "AI";

            Time = TimeOnly.FromDateTime(DateTime.Now);

            Message = await _aiService.AskAsync(prompt);
            return Message;
        }
        private async Task ConvertWeatherIntoNormalLanguage()
        {
            string prompt =
       $"The weather in {Sender} is {Message}. Explain it in simple language and give advice.";

            string response =
                await _aiService.AskAsync(prompt);

            Message = response;
            Time = TimeOnly.FromDateTime(DateTime.Now);

        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }


    }
}
