namespace RePattern.Business.Dtos.TestExecution
{
    public record AnswerReviewResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
        public bool WasSelectedByUser { get; set; }
    }
}
