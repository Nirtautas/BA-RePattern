namespace RePattern.Business.Dtos.Test
{
    public record CompleteTestRequest
    {
        public ICollection<CompletedAnswerRequest> Answers { get; set; }
    }
}
