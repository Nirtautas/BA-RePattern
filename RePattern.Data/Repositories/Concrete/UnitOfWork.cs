using RePattern.Data.Database;
using RePattern.Data.Repositories.Interfaces;

namespace RePattern.Data.Repositories.Concrete
{
    public class UnitOfWork(ApplicationDbContext dbContext,
                        IAnswerRepository answerRepository,
                        IBadgeAcquisitionRepository badgeAcquisitionRepository,
                        IBadgeRepository badgeRepository,
                        IBadgeRuleRepository badgeRuleRepository,
                        ICategoryRepository categoryRepository,
                        IQuestionAttemptRepository questionAttemptRepository,
                        ISelectedAnswersRepository selectedAnswersRepository,
                        ITestExecutionRepository testExecutionRepository,
                        ITestRepository testRepository,
                        IUserRepository userRepository) : IUnitOfWork
    {
        public IAnswerRepository AnswerRepository { get; } = answerRepository;
        public IBadgeAcquisitionRepository BadgeAcquisitionRepository { get; } = badgeAcquisitionRepository;
        public IBadgeRepository BadgeRepository { get; } = badgeRepository;
        public IBadgeRuleRepository BadgeRuleRepository { get; } = badgeRuleRepository;
        public ICategoryRepository CategoryRepository { get; } = categoryRepository;
        public IQuestionAttemptRepository QuestionAttemptRepository { get; } = questionAttemptRepository;
        public ISelectedAnswersRepository SelectedAnswersRepository { get; } = selectedAnswersRepository;
        public ITestExecutionRepository TestExecutionRepository { get; } = testExecutionRepository;
        public ITestRepository TestRepository { get; } = testRepository;
        public IUserRepository UserRepository { get; } = userRepository;

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
