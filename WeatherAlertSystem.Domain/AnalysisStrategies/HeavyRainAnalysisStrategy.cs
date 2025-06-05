using WeatherAlertSystem.Domain.Entities;
using WeatherAlertSystem.Domain.Interfaces;

namespace WeatherAlertSystem.Domain.AnalysisStrategies
{
    public class HeavyRainAnalysisStrategy : IRainAnalysisStrategy
    {
        private readonly double _rainfallThreshold;
        

        public HeavyRainAnalysisStrategy(double rainfallThreshold = 50.0)   
        {
            _rainfallThreshold = rainfallThreshold;
            
        }

        public bool Analyze(WeatherData data)
        {
            return data.Rainfall >= _rainfallThreshold;
        }
    }
}