using System.Net.Http;
using System.Text.Json;

namespace WeatherAppApi.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        // Replace with your OpenWeatherMap API key
        private const string ApiKey = "fc2064fd82bdff63bcc2b357dfdeb6dd";

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetWeatherAsync(string city)
        {
            string url =
                $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}&units=metric";

            string json = await _httpClient.GetStringAsync(url);

            using JsonDocument doc = JsonDocument.Parse(json);

            double temp = doc.RootElement
                             .GetProperty("main")
                             .GetProperty("temp")
                             .GetDouble();

            int humidity = doc.RootElement
                              .GetProperty("main")
                              .GetProperty("humidity")
                              .GetInt32();

            string condition = doc.RootElement
                                  .GetProperty("weather")[0]
                                  .GetProperty("description")
                                  .GetString() ?? "";

            return $"🌡 Temperature: {temp}°C\n" +
                   $"💧 Humidity: {humidity}%\n" +
                   $"☁ Condition: {condition}";
        }
    }
}