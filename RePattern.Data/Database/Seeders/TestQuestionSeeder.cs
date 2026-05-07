using RePattern.Common.Enums;
using RePattern.Domain.Entities;

namespace RePattern.Data.Database.Seeders
{
    public class TestQuestionSeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            if (context.TestQuestions.Any())
                return;

            var testQuestions = new List<TestQuestion>
            {
                new() { Id = 1, Description = "Test question 1 multiselect", Hint = "Some hint 1", Difficulty = TestQuestionDifficultyEnum.EASY, Type = TestQuestionTypeEnum.MULTI_SELECT, ShortText = null, TestId = 2, ImageURL = "/images/badges/limited-time-message/bronze.png"},
                new() { Id = 2, Description = "Test question 2 multiselect", Hint = "Some hint 2", Difficulty = TestQuestionDifficultyEnum.NORMAL, Type = TestQuestionTypeEnum.MULTI_SELECT, ShortText = null, TestId = 2},
                new() { Id = 3, Description = "Test question 3 singleselect", Hint = "Some hint 3", Difficulty = TestQuestionDifficultyEnum.HARD, Type = TestQuestionTypeEnum.SINGLE_SELECT, ShortText = null, TestId = 2, ImageURL = "/images/badges/limited-time-message/bronze.png"},
                new() { Id = 4, Description = "Test question 4 short text", Hint = "Some hint 3", Difficulty = TestQuestionDifficultyEnum.NORMAL, Type = TestQuestionTypeEnum.SHORT_TEXT, ShortText = "Test Test", TestId = 2},
            };

            context.TestQuestions.AddRange(testQuestions);
        }
    }
}
