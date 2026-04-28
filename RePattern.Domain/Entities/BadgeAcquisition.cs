using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePattern.Domain.Entities
{
    [Table("BadgeAcquisition")]
    [PrimaryKey(nameof(UserId), nameof(BadgeId))]
    public class BadgeAcquisition
    {
        [Key]
        public int Id { get; set; }

        public required DateTime AcquiredAt { get; set; }

        public required int UserId { get; set; }
        public required int BadgeId { get; set; }
        public virtual Badge Badge { get; set; }
    }
}
