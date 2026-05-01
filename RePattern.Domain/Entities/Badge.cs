using RePattern.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePattern.Domain.Entities
{
    [Table("Badge")]
    public class Badge
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public required string Title { get; set; }
        public string? Description { get; set; }
        public BadgeTierEnum Tier { get; set; }
        public string? ImageURL { get; set; }

        public required int BadgeGroupId { get; set; }
        public BadgeGroup BadgeGroup { get; set; }
        public required int BadgeRuleId { get; set; }
        public virtual BadgeRule BadgeRule { get; set; }
        public virtual ICollection<BadgeAcquisition> BadgeAcquisitions { get; set; }
    }
}
