using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using RePattern.Api.Options;
using RePattern.Business.Utils.EmailService.Dtos;
using RePattern.Business.Utils.EmailService.Interfaces;
using RePattern.Common.Exceptions.Custom;

namespace RePattern.Business.Utils.EmailService.Services
{
    public class GmailServiceStrategy : IEmailService
    {
        private readonly GmailOptions _options;

        public GmailServiceStrategy(IOptions<GmailOptions> options)
        {
            _options = options.Value;

            if (string.IsNullOrEmpty(_options.Host) || string.IsNullOrEmpty(_options.Email) || string.IsNullOrEmpty(_options.Password))
                throw new ArgumentException("Invalid Gmail configuration");
        }

        public async Task SendEmailAsync(SendEmailRequest sendEmailRequest, CancellationToken cancellationToken)
        {
            var emailMessage = CreateMimeEmailMessage(sendEmailRequest);

            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_options.Host, _options.Port, SecureSocketOptions.StartTls, cancellationToken);
                    await client.AuthenticateAsync(_options.Email, _options.Password, cancellationToken);
                    await client.SendAsync(emailMessage, cancellationToken);
                    await client.DisconnectAsync(true, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                throw new FailedToSendEmailException(sendEmailRequest.RecipientEmail, ex);
            }

        }

        private MimeMessage CreateMimeEmailMessage(SendEmailRequest sendEmailRequest)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_options.Name, _options.Email));
            emailMessage.To.Add(new MailboxAddress(sendEmailRequest.RecipientName, sendEmailRequest.RecipientEmail));
            emailMessage.Subject = sendEmailRequest.Subject;

            var htmlBody = $@"
                <html>
                    <body style='background-color: #424c55; color: #ffffff; font-family: Arial, sans-serif; padding: 20px;'>
                        <h1 style='color: #ffffff;'>Hello, {sendEmailRequest.RecipientName}!</h1>
                        <p>{sendEmailRequest.Body}</p>
                        <hr style='border-color: #444;' />
                        <small>This is an automated message from {_options.Name}.</small>
                    </body>
                </html>";

            emailMessage.Body = new TextPart("html")
            {
                Text = htmlBody
            };

            return emailMessage;
        }
    }
}
