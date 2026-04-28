using RePattern.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePattern.Domain.Entities
{
    [Table("Test")]
    public class Test
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public required string Title { get; set; }
        public required TestTypeEnum Type { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<TestQuestion> TestQuestions { get; set; }
        public virtual ICollection<TestExecution> TestExecutions { get; set; }
    }
}
