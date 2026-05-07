using RePattern.Common.Enums;

namespace RePattern.Business.Dtos.Test
{
    public record TestTakingResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public required TestTypeEnum Type { get; set; }
        public int? CategoryId { get; set; }
        public ICollection<TestQuestionTakingResponse> TestQuestions { get; set; }
    }
}
