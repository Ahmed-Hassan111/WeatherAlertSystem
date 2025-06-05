namespace WeatherAlertSystem.Application.Interfaces
{
    public interface IWeatherAnalysisService
    {
        Task<(bool IsHeavyRain, bool isStrongWind, double Rainfall, double Windspeed, double Temperature)> CheckWeatherAsync(string city);
    }
}