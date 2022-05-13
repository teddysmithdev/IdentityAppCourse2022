using IdentityAppCourse2022.Helpers;
using IdentityAppCourse2022.Interfaces;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace IdentityAppCourse2022.Services
{
    public class SendGridEmail : ISendGridEmail
    {
        private readonly ILogger<SendGridEmail> _logger;

        public AuthMessageSenderOptions Options { get; set; }
        public SendGridEmail(IOptions<AuthMessageSenderOptions> options, ILogger<SendGridEmail> logger)
        {
            Options = options.Value;
            _logger = logger;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            if (string.IsNullOrEmpty(Options.ApiKey))
            {
                throw new Exception("Null SendGridKey");
            }
            await Execute(Options.ApiKey, subject, message, toEmail);
        }

        private async Task Execute(string apiKey, string subject, string message, string toEmail)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("rungroops@gmail.com"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(toEmail));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
            var dummy = response.StatusCode;
            var dummy2 = response.Headers;
            _logger.LogInformation(response.IsSuccessStatusCode
                                   ? $"Email to {toEmail} queued successfully!"
                                   : $"Failure Email to {toEmail}");
        }
    }
}
