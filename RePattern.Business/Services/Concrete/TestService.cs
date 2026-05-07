using AutoMapper;
using RePattern.Business.Dtos.Test;
using RePattern.Business.Services.Interfaces;
using RePattern.Common.Exceptions.Custom;
using RePattern.Data.Repositories.Interfaces;

namespace RePattern.Business.Services.Concrete
{
    public class TestService(IUnitOfWork unitOfWork, IMapper mapper) : ITestService
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
    }
}
