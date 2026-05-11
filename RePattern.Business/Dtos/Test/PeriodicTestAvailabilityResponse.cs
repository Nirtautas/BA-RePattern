namespace RePattern.Business.Dtos.Test
{
    public record PeriodicTestAvailabilityResponse
    {
        public bool CanTakeTest { get; set; }
        public DateTime? NextAvailableAt { get; set; }
        public int RemainingCooldownSeconds { get; set; }
        public bool HasQuestionHistory { get; set; }
    }
}
