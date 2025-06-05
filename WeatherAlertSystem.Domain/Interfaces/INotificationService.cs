namespace WeatherAlertSystem.Domain.Interfaces
{
    public interface INotificationService
    {
        Task SendWarningAsync(string message, string phoneNumber);
    }
}