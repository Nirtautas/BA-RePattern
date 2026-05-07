using RePattern.Common.Enums;

namespace RePattern.Business.Dtos.Test
{
    public record TestQuestionTakingResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string? ShortText { get; set; }
        public string? Hint { get; set; }
        public TestQuestionDifficultyEnum Difficulty { get; set; }
        public TestQuestionTypeEnum Type { get; set; }
        public string? ImageUrl { get; set; }

        public List<AnswerTakingResponse> Answers { get; set; }
    }
}
