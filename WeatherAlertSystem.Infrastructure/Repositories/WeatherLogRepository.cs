using WeatherAlertSystem.Domain.Entities;
using WeatherAlertSystem.Domain.Interfaces;
using WeatherAlertSystem.Infrastructure.Data;

namespace WeatherAlertSystem.Infrastructure.Repositories
{
    public class WeatherLogRepository : IWeatherLogRepository
    {
        private readonly AppDbContext _context;

        public WeatherLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddWeatherLogAsync(WeatherLog log)
        {
            await _context.WeatherLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}