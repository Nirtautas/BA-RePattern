using RePattern.Business.Utils.EmailService.Dtos;

namespace RePattern.Business.Utils.EmailService.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(SendEmailRequest sendEmailRequest, CancellationToken cancellationToken);
    }
}
