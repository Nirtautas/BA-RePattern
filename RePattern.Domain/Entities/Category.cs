using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePattern.Domain.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public required string Title { get; set; }
        [MaxLength(255)]
        public required string UniquePathFragment { get; set; }
        public int Order { get; set; }
        public bool OnlyTheory { get; set; }

        public virtual Test Test { get; set; }
        public virtual ICollection<Badge> Badges { get; set; }
    }
}
