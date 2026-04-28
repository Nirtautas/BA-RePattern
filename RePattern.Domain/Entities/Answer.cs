using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePattern.Domain.Entities
{
    [Table("Answer")]
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public required string Description { get; set; }
        public required string IsCorrect { get; set; }
        [MaxLength(255)]
        public string? ShortText { get; set; }

        public required int TestQuestionId { get; set; }
        public virtual TestQuestion TestQuestion { get; set; }
        public virtual ICollection<SelectedAnswers> SelectedAnswers { get; set; }
    }
}
