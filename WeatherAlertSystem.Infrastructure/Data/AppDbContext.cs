using Microsoft.EntityFrameworkCore;
using Twilio.TwiML.Voice;
using WeatherAlertSystem.Domain.Entities;

namespace WeatherAlertSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<WeatherLog> WeatherLogs { get; set; }
        public DbSet<WeatherData> WeatherDatas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WeatherLog>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<WeatherData>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}