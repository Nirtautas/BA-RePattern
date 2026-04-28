using RePattern.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePattern.Domain.Entities
{
    [Table("BadgeRule")]
    public class BadgeRule
    {
        [Key]
        public int Id { get; set; }

        public required BadgeRuleType RuleType { get; set; }
        public int? Threshold { get; set; }

        public virtual ICollection<Badge> Badges { get; set; }
    }
}
