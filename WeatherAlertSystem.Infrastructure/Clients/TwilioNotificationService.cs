using WeatherAlertSystem.Domain.Interfaces;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WeatherAlertSystem.Infrastructure.Clients
{
    public class TwilioNotificationService : INotificationService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _fromPhoneNumber;

        public TwilioNotificationService(string accountSid, string authToken, string fromPhoneNumber)
        {
            _accountSid = accountSid;
            _authToken = authToken;
            _fromPhoneNumber = fromPhoneNumber;
            TwilioClient.Init(_accountSid, _authToken);
            Console.WriteLine($"Twilio initialized with From Number: {_fromPhoneNumber}");
        }

        public async Task SendWarningAsync(string message, string phoneNumber)
        {
            Console.WriteLine($"Twilio: Received phoneNumber: {phoneNumber}");
            Console.WriteLine($"Twilio: Sending SMS to {phoneNumber} with message: {message}");
            await MessageResource.CreateAsync(
                body: message,
                from: new Twilio.Types.PhoneNumber(_fromPhoneNumber),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );
            Console.WriteLine($"Twilio: SMS sent to {phoneNumber}");
        }
    }
}