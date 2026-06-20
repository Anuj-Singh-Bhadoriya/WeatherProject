using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;



namespace WeatherAppApi.Services
{
   
    public class AiService
    {
        private readonly HttpClient _client;

        public AiService()
        {
            _client = new HttpClient();
            _client.Timeout = TimeSpan.FromMinutes(10);
        }

        public async Task<string> AskAsync(string prompt)
        {
            var request = new
            {
                model = "llama3",
                prompt = prompt,
                stream = false
            };

            string json = JsonSerializer.Serialize(request);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await _client.PostAsync(
                "http://127.0.0.1:11434/api/generate",
                content);

            Console.WriteLine(response.StatusCode);

            string result = await response.Content.ReadAsStringAsync();

            using JsonDocument doc = JsonDocument.Parse(result);

            string answer = doc.RootElement
                               .GetProperty("response")
                               .GetString() ?? "";

            return answer;
        }
    }
}
    
