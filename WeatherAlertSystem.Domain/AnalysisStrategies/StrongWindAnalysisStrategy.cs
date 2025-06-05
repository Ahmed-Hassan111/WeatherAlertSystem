using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAlertSystem.Domain.Entities;
using WeatherAlertSystem.Domain.Interfaces;

namespace WeatherAlertSystem.Domain.AnalysisStrategies
{
    public class StrongWindAnalysisStrategy : IWindAnalysisStrategy
    {
        private readonly double _windspeedThreshold;

        public StrongWindAnalysisStrategy(double windspeedThreshold = 7.0)
        {
            _windspeedThreshold = windspeedThreshold;
        }
        public bool Analyze(WeatherData data)
        {
            Console.WriteLine($"Analyzing Wind Speed: {data.WindSpeed}, Threshold: {_windspeedThreshold}");
            return data.WindSpeed >= _windspeedThreshold;
        }
    }
}
