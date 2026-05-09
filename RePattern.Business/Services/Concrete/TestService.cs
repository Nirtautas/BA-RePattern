using AutoMapper;
using RePattern.Business.Dtos.Test;
using RePattern.Business.Services.Interfaces;
using RePattern.Common.Enums;
using RePattern.Common.Exceptions.Custom;
using RePattern.Data.Repositories.Interfaces;
using RePattern.Domain.Entities;

namespace RePattern.Business.Services.Concrete
{
    public class TestService(IUnitOfWork unitOfWork, IBadgeAcquisitionService badgeAcquisitionService, IMapper mapper) : ITestService
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

            var testResponse = mapper.Map<TestTakingResponse?>(test);
            return testResponse;
        }

        public async Task<TestCompletionResponse> HandleTestCompletion(int testId, int? userId, CompleteTestRequest completeTestRequest, CancellationToken cancellationToken)
        {
            var test = await unitOfWork.TestRepository.GetTestWithQuestionsByIdAsync(testId, cancellationToken)
                ?? throw new NotFoundException($"Test with id {testId} was not found!");

            var testExecution = new TestExecution
            {
                TestId = test.Id,
                UserId = userId,
                CompletedAt = DateTime.UtcNow,
                QuestionAttempts = []
            };

            foreach (var testQuestion in test.TestQuestions)
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

            if (userId is int actualUserId && test.CategoryId is int categoryId)
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
    }
}
