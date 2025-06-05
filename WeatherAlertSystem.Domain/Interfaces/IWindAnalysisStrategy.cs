using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAlertSystem.Domain.Entities;

namespace WeatherAlertSystem.Domain.Interfaces
{
    public interface IWindAnalysisStrategy
    {
        public bool Analyze(WeatherData data);
    }
}
