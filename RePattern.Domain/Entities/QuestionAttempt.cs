using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePattern.Domain.Entities
{
    [Table("QuestionAttempt")]
    public class QuestionAttempt
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public required string? ShortText { get; set; }
        public required bool WasCorrect { get; set; }

        public required int TestQuestionId { get; set; }
        public virtual TestQuestion TestQuestion { get; set; }
        public required int TestExecutionId { get; set; }
        public virtual TestExecution TestExecution { get; set; }
        public virtual ICollection<SelectedAnswers> SelectedAnswers { get; set; }
    }
}
