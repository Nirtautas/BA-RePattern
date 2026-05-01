namespace RePattern.Business.Utils.EmailService.Dtos
{
    public record SendEmailRequest
    {
        public string RecipientName { get; init; } = "Receipient";
        public required string RecipientEmail { get; init; }
        public required string Subject { get; init; }
        public required string Body { get; init; }
    }
}
