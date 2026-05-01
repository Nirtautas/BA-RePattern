using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RePattern.Business.Utils.EmailService.Dtos;
using RePattern.Business.Utils.EmailService.Interfaces;
using RePattern.Business.Utils.EmailService.Services;

namespace RePattern.Business.Utils.EmailService
{
    public class EmailContextService : IEmailService
    {
        private readonly IServiceProvider _provider;
        private readonly IConfiguration _configuration;

        public EmailContextService(IServiceProvider provider, IConfiguration configuration)
        {
            _provider = provider;
            _configuration = configuration;
        }

        public Task SendEmailAsync(SendEmailRequest sendEmailRequest, CancellationToken cancellationToken)
        {
            var providerKey = _configuration["Email:Provider"] ?? "Gmail";
            IEmailService strategy = providerKey switch
            {
                "Gmail" => _provider.GetRequiredService<GmailServiceStrategy>(),
                _ => throw new NotImplementedException($"Email provider '{providerKey}' is not supported")
            };

            return strategy.SendEmailAsync(sendEmailRequest, cancellationToken);
        }
    }
}
