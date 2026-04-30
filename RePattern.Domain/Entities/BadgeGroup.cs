using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePattern.Domain.Entities
{
    [Table("BadgeGroup")]
    public class BadgeGroup
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public required string Title { get; set; }
        public required bool IsTrackingGroup { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Badge> Badges { get; set; }
    }
}
