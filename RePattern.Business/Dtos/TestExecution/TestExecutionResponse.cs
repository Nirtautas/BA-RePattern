namespace RePattern.Business.Dtos.TestExecution
{
    public record TestExecutionResponse
    {
        public int Id { get; set; }
        public DateTime CompletedAt { get; set; }
        public int CorrectQuestionsCount { get; set; }
        public int TotalQuestionsCount { get; set; }
        public decimal ScorePercentage { get; set; }
        public int TestId { get; set; }
        public int? UserId { get; set; }
    }
}
