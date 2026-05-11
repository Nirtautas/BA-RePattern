using AutoMapper;
using Microsoft.Extensions.Configuration;
using RePattern.Business.Dtos.Test;
using RePattern.Business.Services.Interfaces;
using RePattern.Common.Enums;
using RePattern.Common.Exceptions.Custom;
using RePattern.Data.Repositories.Interfaces;
using RePattern.Domain.Entities;

namespace RePattern.Business.Services.Concrete
{
    public class TestService(IUnitOfWork unitOfWork, IBadgeAcquisitionService badgeAcquisitionService, IMapper mapper, IConfiguration configuration) : ITestService
    {
        public async Task<TestTakingResponse?> GetCategoryTestAsync(int categoryId, CancellationToken cancellationToken)
        {
            var test = await unitOfWork.TestRepository.GetCategoryTestWithQuestionsAsync(categoryId, cancellationToken)
                ?? throw new NotFoundException($"Test data with category id {categoryId} was not found!");

            if (test.TestQuestions is null || test.TestQuestions.Count() == 0)
                throw new NotFoundException($"Test for category id {categoryId} must have at least one question!");

            foreach (var question in test.TestQuestions)
            {
                var hasShortTextAnswer = !string.IsNullOrWhiteSpace(question.ShortText);

                var hasCorrectAnswer = question.Answers is not null && question.Answers.Any(a => a.IsCorrect);

                if (!hasShortTextAnswer && !hasCorrectAnswer)
                    throw new NotFoundException($"Question with id {question.Id} has neither a short text answer nor a correct answer.");
            }

            test.TestQuestions = test.TestQuestions
                .OrderBy(_ => Guid.NewGuid())
                .ToList();

            foreach (var question in test.TestQuestions)
            {
                question.Answers = question.Answers
                    .OrderBy(_ => Guid.NewGuid())
                    .ToList();
            }

            var testResponse = mapper.Map<TestTakingResponse?>(test);
            return testResponse;
        }

        public async Task<TestTakingResponse> GetPeriodicTestAsync(int userId, CancellationToken cancellationToken)
        {
            var maxQuestionAmount = configuration.GetValue<int?>("PeriodicTests:MaxQuestionAmount")
                ?? throw new ConfigValueNotFound("No configuration value for \"PeriodicTests:MaxQuestionAmount\" is specified!");

            var periodicTest = await unitOfWork.TestRepository.GetByExpressionAsync(t => t.CategoryId == null && t.Type == TestTypeEnum.SPACED)
                ?? throw new NotFoundException("Periodic test entity not found!");

            var latestQuestionAttempts = await unitOfWork.QuestionAttemptRepository.GetLatestUserQuestionAttemptsAsync(userId, cancellationToken);

            var unresolvedQuestions = latestQuestionAttempts
                .Where(qa => !qa.WasCorrect)
                .OrderBy(qa => qa.TestExecution.CompletedAt)
                .Take(maxQuestionAmount)
                .Select(qa => qa.TestQuestion)
                .ToList();

            var fillerQuestions = latestQuestionAttempts
                .Where(qa => qa.WasCorrect)
                .OrderBy(qa => qa.TestExecution.CompletedAt)
                .Take(maxQuestionAmount - unresolvedQuestions.Count)
                .Select(qa => qa.TestQuestion)
                .ToList();

            var selectedQuestions = unresolvedQuestions
                .Concat(fillerQuestions)
                .OrderBy(_ => Guid.NewGuid())
                .ToList();

            foreach (var question in selectedQuestions)
            {
                question.Answers = question.Answers
                    .OrderBy(_ => Guid.NewGuid())
                    .ToList();
            }

            if (selectedQuestions.Count == 0)
                throw new NotFoundException("Unable to generate a periodic test as no category tests have been completed previously!");

            var questionResponse = mapper.Map<List<TestQuestionTakingResponse>>(selectedQuestions);

            return new TestTakingResponse
            {
                Id = periodicTest.Id,
                Title = periodicTest.Title,
                Type = periodicTest.Type,
                CategoryId = periodicTest.CategoryId,
                TestQuestions = questionResponse
            };
        }

        public async Task<TestCompletionResponse> HandleTestCompletion(int testId, int? userId, CompleteTestRequest completeTestRequest, CancellationToken cancellationToken)
        {
            var test = await unitOfWork.TestRepository.GetByIdAsync(testId, cancellationToken)
                ?? throw new NotFoundException($"Test with id {testId} was not found!");

            var testExecution = new TestExecution
            {
                TestId = test.Id,
                UserId = userId,
                CompletedAt = DateTime.UtcNow,
                QuestionAttempts = []
            };

            var submittedQuestionIds = completeTestRequest.Answers
                .Select(a => a.TestQuestionId)
                .Distinct()
                .ToList();

            var testQuestions = await unitOfWork.TestQuestionRepository.GetQuestionsWithAnswersByIdsAsync(submittedQuestionIds, cancellationToken);

            foreach (var testQuestion in testQuestions)
            {
                var submittedAnswer = completeTestRequest.Answers.FirstOrDefault(a => a.TestQuestionId == testQuestion.Id)
                    ?? throw new BadRequestException($"Question {testQuestion.Id} was not answered!");

                var questionAnsweredCorrectly = IsQuestionAnswerCorrect(testQuestion, submittedAnswer);

                var questionAttempt = new QuestionAttempt
                {
                    TestQuestionId = testQuestion.Id,
                    ShortText = submittedAnswer.ShortText,
                    WasCorrect = questionAnsweredCorrectly,
                    SelectedAnswers = submittedAnswer.SelectedAnswerIds
                        .Select(answerId => new SelectedAnswers
                        {
                            AnswerId = answerId
                        })
                        .ToList()
                };

                testExecution.QuestionAttempts.Add(questionAttempt);
            }

            var totalQuestions = testExecution.QuestionAttempts.Count;
            var correctQuestions = testExecution.QuestionAttempts.Count(x => x.WasCorrect);

            testExecution.TotalQuestionsCount = totalQuestions;
            testExecution.CorrectQuestionsCount = correctQuestions;
            testExecution.ScorePercentage = totalQuestions == 0 ? 0 : Math.Round((decimal)correctQuestions / totalQuestions * 100, 2);

            await unitOfWork.TestExecutionRepository.CreateAsync(testExecution, cancellationToken);

            if (userId is int actualUserId && test.CategoryId is int categoryId && test.Type != TestTypeEnum.SPACED)
            {
                await badgeAcquisitionService.AcquireCategoryTestCompleteTrackingBadge(actualUserId, categoryId, testExecution.ScorePercentage, cancellationToken);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new TestCompletionResponse { testExecutionId = testExecution.Id };
        }

        private static bool IsQuestionAnswerCorrect(TestQuestion testQuestion, CompletedAnswerRequest submittedAnswer)
        {
            if (testQuestion.Type == TestQuestionTypeEnum.SHORT_TEXT)
            {
                return string.Equals(testQuestion.ShortText?.Trim(), submittedAnswer.ShortText?.Trim(), StringComparison.OrdinalIgnoreCase);
            }

            var correctAnswerIds = testQuestion.Answers.Where(a => a.IsCorrect).Select(a => a.Id).OrderBy(id => id).ToList();
            var submittedAnswerIds = submittedAnswer.SelectedAnswerIds.OrderBy(id => id).ToList();

            return correctAnswerIds.SequenceEqual(submittedAnswerIds);
        }

        public async Task<PeriodicTestAvailabilityResponse> GetPeriodicTestAvailabilityAsync(int userId, CancellationToken cancellationToken)
        {
            var cooldownSeconds = configuration.GetValue<int?>("PeriodicTests:NextTestIntervalSeconds")
                ?? throw new ConfigValueNotFound("No configuration value for \"PeriodicTests:NextTestIntervalSeconds\" is specified!");

            var questionAttempts = await unitOfWork.QuestionAttemptRepository.GetAllByExpressionAsync(qa => qa.TestExecution.UserId == userId, cancellationToken);

            if (questionAttempts is null || questionAttempts.Count == 0)
            {
                return new PeriodicTestAvailabilityResponse
                {
                    HasQuestionHistory = false,
                    CanTakeTest = false,
                    NextAvailableAt = null,
                    RemainingCooldownSeconds = 0
                };
            }

            var latestPeriodicExecution = await unitOfWork.TestExecutionRepository.GetLatestPeriodicByUserIdAsync(userId, cancellationToken);

            if (latestPeriodicExecution is null)
            {
                return new PeriodicTestAvailabilityResponse
                {
                    HasQuestionHistory = true,
                    CanTakeTest = true,
                    NextAvailableAt = null,
                    RemainingCooldownSeconds = 0
                };
            }

            var now = DateTime.UtcNow;
            var nextAvailableAt = latestPeriodicExecution.CompletedAt.AddSeconds(cooldownSeconds);
            var canTakeTest = now >= nextAvailableAt;

            return new PeriodicTestAvailabilityResponse
            {
                HasQuestionHistory = true,
                CanTakeTest = canTakeTest,
                NextAvailableAt = nextAvailableAt,
                RemainingCooldownSeconds = canTakeTest ? 0 : (int)Math.Ceiling((nextAvailableAt - now).TotalSeconds)
            };
        }
    }
}
