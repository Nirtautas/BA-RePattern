using RePattern.Common.Enums;

namespace RePattern.Domain.Entities
{
    public record BadgeResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public BadgeTierEnum Tier { get; set; }
        public string? ImageURL { get; set; }
    }
}
