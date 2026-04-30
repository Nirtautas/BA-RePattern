using RePattern.Common.Enums;

namespace RePattern.Business.Dtos.BadgeAcquisition
{
    public record BadgeWithCategoryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public BadgeTierEnum Tier { get; set; }
        public string? ImageURL { get; set; }
        public DateTime AcquiredAt { get; set; }
        public int? CategoryId { get; set; }
        public bool IsTrackingGroup { get; set; }
    }
}
