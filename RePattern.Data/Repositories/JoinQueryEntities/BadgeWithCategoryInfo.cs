using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.JoinQueryEntities
{
    public class BadgeWithCategoryInfo
    {
        public required Badge Badge { get; set; }
        public required DateTime AcquiredAt { get; set; }
        public required int? CategoryId { get; set; }
        public required bool IsTrackingGroup { get; set; }
    }
}
