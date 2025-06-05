using Microsoft.EntityFrameworkCore;
using WeatherAlertSystem.Infrastructure.Data;
using WeatherAlertSystem.Infrastructure.Clients;
using WeatherAlertSystem.Infrastructure.Repositories;
using WeatherAlertSystem.Application.Services;
using WeatherAlertSystem.Application.Interfaces;
using WeatherAlertSystem.Domain.AnalysisStrategies;
using WeatherAlertSystem.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add HttpClient for Weather API
builder.Services.AddHttpClient<IWeatherApiClient, WeatherApiClient>(client =>
{
    client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
})
.AddTypedClient<IWeatherApiClient>(client => new WeatherApiClient(client, builder.Configuration["WeatherApi:ApiKey"]));

// Add services
builder.Services.AddScoped<IWeatherLogRepository, WeatherLogRepository>();
builder.Services.AddScoped<IWeatherAnalysisService, WeatherAnalysisService>();
//builder.Services.AddScoped<IWeatherAnalysisStrategy, HeavyRainAnalysisStrategy>();
builder.Services.AddScoped<IRainAnalysisStrategy, HeavyRainAnalysisStrategy>();
builder.Services.AddScoped<IWindAnalysisStrategy, StrongWindAnalysisStrategy>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<INotificationService>(provider => new TwilioNotificationService(
    builder.Configuration["Twilio:AccountSid"],
    builder.Configuration["Twilio:AuthToken"],
    builder.Configuration["Twilio:PhoneNumber"]
));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();