using WeatherAlertSystem.Domain.Entities;
using WeatherAlertSystem.Domain.Interfaces;
using WeatherAlertSystem.Application.Interfaces;
using Microsoft.Extensions.Configuration;
namespace WeatherAlertSystem.Application.Services
{
    public class WeatherAnalysisService : IWeatherAnalysisService
    {
        private readonly IWeatherApiClient _weatherApiClient;
        //private readonly IWeatherAnalysisStrategy _analysisStrategy;
        private readonly INotificationService _notificationService;
        private readonly IWeatherLogRepository _weatherLogRepository;
        private readonly IRainAnalysisStrategy _rainStrategy;
        private readonly IWindAnalysisStrategy _windStrategy;
        private readonly IConfiguration _configuration;

        public WeatherAnalysisService(
            IWeatherApiClient weatherApiClient,
            IRainAnalysisStrategy rainStrategy,
            IWindAnalysisStrategy windStrategy,
            //IWeatherAnalysisStrategy analysisStrategy,
            INotificationService notificationService,
            IWeatherLogRepository weatherLogRepository,
            IConfiguration configuration)
        {
            _weatherApiClient = weatherApiClient;
            //_analysisStrategy = analysisStrategy;
            _rainStrategy = rainStrategy;
            _windStrategy = windStrategy;
            _notificationService = notificationService;
            _weatherLogRepository = weatherLogRepository;
            _configuration = configuration;
        }

        public async Task<(bool IsHeavyRain, bool isStrongWind, double Rainfall, double Windspeed, double Temperature)> CheckWeatherAsync(string city)
        {
            var weatherData = await _weatherApiClient.GetWeatherDataAsync(city);

            var log = new WeatherLog
            {
                City = city,
                Temperature = weatherData.Temperature,
                Rainfall = weatherData.Rainfall,
                WindSpeed = weatherData.WindSpeed,
                RecordedAt = DateTime.UtcNow
            };
            await _weatherLogRepository.AddWeatherLogAsync(log);

            bool isHeavyRain = _rainStrategy.Analyze(weatherData);
            bool isStrongWind = _windStrategy.Analyze(weatherData);
            string recipientNumber = _configuration["Notification:RecipientPhoneNumber"];
            Console.WriteLine($"Recipient Number: {recipientNumber}");

            if (isHeavyRain)
            {
                await _notificationService.SendWarningAsync(
                    $"تحذير: هيحصل مطر شديد في {city}! اتخذ الاحتياطات اللازمة.",
                    recipientNumber // غير الرقم ده برقمك
                );
            }
            if (isStrongWind) 
            {
                await _notificationService.SendWarningAsync(
                    $"تحذير: هيحصل رياح شديد في {city}! اتخذ الاحتياطات اللازمة.",
                    recipientNumber // غير الرقم ده برقمك
                );

            }

            return (isHeavyRain, isStrongWind, weatherData.Rainfall, weatherData.WindSpeed, weatherData.Temperature);
        }
    }
}