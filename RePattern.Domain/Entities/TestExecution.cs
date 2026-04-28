using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePattern.Domain.Entities
{
    [Table("TestExecution")]
    public class TestExecution
    {
        [Key]
        public int Id { get; set; }

        public required DateTime StartedAt { get; set; }
        public required DateTime EndedAt { get; set; }

        public required int UserId { get; set; }
        public required int TestId { get; set; }
        public virtual Test Test { get; set; }
        public virtual ICollection<QuestionAttempt> QuestionAttempts { get; set; }
    }
}
