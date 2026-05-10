namespace RePattern.Business.Dtos.TestExecution
{
    public record TestExecutionReviewResponse
    {
        public int Id { get; set; }
        public int TotalQuestionsCount { get; set; }
        public int CorrectQuestionsCount { get; set; }
        public decimal ScorePercentage { get; set; }
        public ICollection<QuestionAttemptReviewResponse> QuestionAttempts { get; set; }
    }
}
