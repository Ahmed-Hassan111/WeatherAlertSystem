using WeatherAlertSystem.Domain.Entities;

namespace WeatherAlertSystem.Domain.Interfaces
{
    public interface IWeatherAnalysisStrategy
    {
        bool Analyze(WeatherData data);
    }
}