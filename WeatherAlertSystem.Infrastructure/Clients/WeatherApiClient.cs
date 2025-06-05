using WeatherAlertSystem.Domain.Entities;
using WeatherAlertSystem.Domain.Interfaces;
using System.Net.Http;
using Newtonsoft.Json;

namespace WeatherAlertSystem.Infrastructure.Clients
{
    public class WeatherApiClient : IWeatherApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherApiClient(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<WeatherData> GetWeatherDataAsync(string city)
        {
            var response = await _httpClient.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric");
            dynamic data = JsonConvert.DeserializeObject(response);

            return new WeatherData
            {
                City = city,
                Temperature = data.main.temp,
                Rainfall = data.rain != null && data.rain["1h"] != null ? (double)data.rain["1h"] : 0.0,
                WindSpeed = data.wind != null && data.wind.speed != null ? (double)data.wind.speed : 0.0
            };
        }
    }
}