using Microsoft.AspNetCore.Mvc;
using WeatherAlertSystem.Application.Interfaces;
using WeatherAlertSystem.Domain.Entities;

namespace WeatherAlertSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherAnalysisService _weatherAnalysisService;

        public WeatherController(IWeatherAnalysisService weatherAnalysisService)
        {
            _weatherAnalysisService = weatherAnalysisService;
        }

        [HttpPost("check")]
        public async Task<IActionResult> CheckWeather([FromQuery] string city)
        {
            
            if (string.IsNullOrEmpty(city))
                return BadRequest("City is required.");
            var (isHeavyRain, isStrongWind, rainfall, windspeed, temperature) = await _weatherAnalysisService.CheckWeatherAsync(city);

            //var result = await _weatherAnalysisService.CheckWeatherAsync(city);
            return Ok(new { City = city, HeavyRainDetected = isHeavyRain, StrongWindDetected = isStrongWind, WindSpeed = windspeed, Temperature = temperature });
        }
    }
}