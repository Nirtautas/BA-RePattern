namespace RePattern.Business.Dtos.Test
{
    public record CompletedAnswerRequest
    {
        public int TestQuestionId { get; set; }
        public ICollection<int> SelectedAnswerIds { get; set; }
        public string? ShortText { get; set; }
    }
}
