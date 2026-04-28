using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePattern.Domain.Entities
{
    [Table("SelectedAnswers")]
    [PrimaryKey(nameof(QuestionAttemptId), nameof(AnswerId))]
    public class SelectedAnswers
    {
        public required int QuestionAttemptId { get; set; }
        public virtual QuestionAttempt QuestionAttempt { get; set; }
        public required int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
