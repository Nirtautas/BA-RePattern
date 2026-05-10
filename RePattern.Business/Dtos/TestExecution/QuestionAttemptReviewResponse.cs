using RePattern.Common.Enums;

namespace RePattern.Business.Dtos.TestExecution
{
    public record QuestionAttemptReviewResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string? ShortText { get; set; }
        public string? CorrectShortText { get; set; }
        public string? Explanation { get; set; }
        public TestQuestionDifficultyEnum Difficulty { get; set; }
        public TestQuestionTypeEnum Type { get; set; }
        public string? ImageUrl { get; set; }
        public bool WasCorrect { get; set; }
        public ICollection<AnswerReviewResponse> Answers { get; set; }
    }
}
