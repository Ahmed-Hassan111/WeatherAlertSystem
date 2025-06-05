using WeatherAlertSystem.Domain.Entities;

namespace WeatherAlertSystem.Domain.Interfaces
{
    public interface IWeatherLogRepository
    {
        Task AddWeatherLogAsync(WeatherLog log);
    }
}