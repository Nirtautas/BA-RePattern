namespace RePattern.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAnswerRepository AnswerRepository { get; }
        IBadgeAcquisitionRepository BadgeAcquisitionRepository { get; }
        IBadgeRepository BadgeRepository { get; }
        IBadgeRuleRepository BadgeRuleRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IQuestionAttemptRepository QuestionAttemptRepository { get; }
        ISelectedAnswersRepository SelectedAnswersRepository { get; }
        ITestExecutionRepository TestExecutionRepository { get; }
        ITestRepository TestRepository { get; }
        IUserRepository UserRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
