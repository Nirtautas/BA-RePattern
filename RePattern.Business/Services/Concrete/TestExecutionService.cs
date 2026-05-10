using AutoMapper;
using RePattern.Business.Dtos.TestExecution;
using RePattern.Business.Services.Interfaces;
using RePattern.Common.Exceptions.Custom;
using RePattern.Data.Repositories.Interfaces;

namespace RePattern.Business.Services.Concrete
{
    public class TestExecutionService(IUnitOfWork unitOfWork, IMapper mapper) : ITestExecutionService
    {
        public async Task<TestExecutionResponse> GetLatestCategoryTestExecutionAsync(int userId, int categoryId, CancellationToken cancellationToken)
        {
            var testExecution = await unitOfWork.TestExecutionRepository.GetLatestCategoryByUserIdAndCategoryIdAsync(userId, categoryId, cancellationToken);
            var testExecutionResponse = mapper.Map<TestExecutionResponse>(testExecution);

            return testExecutionResponse;
        }

        public async Task<TestExecutionResponse> GetLatestPeriodicTestExecutionAsync(int userId, CancellationToken cancellationToken)
        {
            var testExecution = await unitOfWork.TestExecutionRepository.GetLatestPeriodicByUserIdAsync(userId, cancellationToken);
            var testExecutionResponse = mapper.Map<TestExecutionResponse>(testExecution);

            return testExecutionResponse;
        }

        public async Task<TestExecutionReviewResponse> GetExecutionReviewAsync(int executionId, int? userId, CancellationToken cancellationToken)
        {
            var execution = await unitOfWork.TestExecutionRepository.GetExecutionReviewAsync(executionId, cancellationToken)
                ?? throw new NotFoundException($"Test execution with id {executionId} was not found!");

            if (execution.UserId != userId)
                throw new UnauthorizedException($"Unauthorized while trying to access another users data!");

            var response = mapper.Map<TestExecutionReviewResponse>(execution);

            foreach (var questionAttempt in execution.QuestionAttempts)
            {
                var selectedAnswerIds = questionAttempt.SelectedAnswers
                    .Select(x => x.AnswerId)
                    .ToList();

                var questionResponse = response.QuestionAttempts.First(x => x.Id == questionAttempt.TestQuestionId);

                foreach (var answerResponse in questionResponse.Answers)
                {
                    answerResponse.WasSelectedByUser = selectedAnswerIds.Contains(answerResponse.Id);
                }
            }

            return response;
        }
    }
}
