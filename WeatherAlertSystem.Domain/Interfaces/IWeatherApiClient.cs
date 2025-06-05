using WeatherAlertSystem.Domain.Entities;

namespace WeatherAlertSystem.Domain.Interfaces
{
    public interface IWeatherApiClient
    {
        Task<WeatherData> GetWeatherDataAsync(string city);
    }
}