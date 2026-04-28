using RePattern.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RePattern.Domain.Entities
{
    [Table("TestQuestion")]
    public class TestQuestion
    {
        [Key]
        public int Id { get; set; }

        public required string Description { get; set; }
        public string? Hint { get; set; }
        public TestQuestionDifficultyEnum Difficulty { get; set; }
        public required TestQuestionTypeEnum Type { get; set; }
        public string? ImageURL { get; set; }

        public required int TestId { get; set; }
        public virtual Test Test { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<QuestionAttempt> QuestionAttempts { get; set; }
    }
}
