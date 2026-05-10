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
                //Sneak into basket
                new() { Id = 10, Description = "The \"Sneak into Basket\" deceptive pattern places unwanted products or services into the shopping cart?", Hint = "See the deceptive pattern's name.", Difficulty = TestQuestionDifficultyEnum.EASY, Type = TestQuestionTypeEnum.SINGLE_SELECT, ShortText = null, TestId = 2 },
                new() { Id = 20, Description = "The \"Sneak into Basket\" deceptive pattern manipulates through \"double negatives\" or \"inversion of choices\"?", Hint = "See the deceptive pattern's name.", Difficulty = TestQuestionDifficultyEnum.EASY, Type = TestQuestionTypeEnum.SINGLE_SELECT, ShortText = null, TestId = 2 },
                new() { Id = 30, Description = "The \"Sneak into Basket\" deceptive pattern forces users to buy extra products?", Hint = "Can users remove extra products?", Difficulty = TestQuestionDifficultyEnum.NORMAL, Type = TestQuestionTypeEnum.SINGLE_SELECT, ShortText = null, TestId = 2, Explanation = "The \"Sneak into Basket\" deceptive pattern sneaks products or services into the shopping cart, but allows consumers to remove them." },
                new() { Id = 40, Description = "Which of these deceptive patterns is the \"Sneak into basket\" one?", Hint = "Which picture shows an extra unwanted product added to the cart?", Difficulty = TestQuestionDifficultyEnum.EASY, Type = TestQuestionTypeEnum.SINGLE_SELECT, ShortText = null, TestId = 2, ImageURL = "/images/tests/sneak-into-basket/select_1.png", Explanation = "Number 2 as it shows an extra product in the cart - \"Forever Sports magazine\""},
                new() { Id = 50, Description = "Would this be categorized as the \"Sneak into basket\" deceptive pattern?", Hint = "Is the added product quantity larger than 0?", Difficulty = TestQuestionDifficultyEnum.NORMAL, Type = TestQuestionTypeEnum.SINGLE_SELECT, ShortText = null, TestId = 2, ImageURL = "/images/tests/sneak-into-basket/choose_1.png"},
                new() { Id = 60, Description = "Which deceptive pattern is shown in the picture?", Difficulty = TestQuestionDifficultyEnum.EASY, Type = TestQuestionTypeEnum.SHORT_TEXT, ShortText = "sneak into basket", TestId = 2, ImageURL = "/images/tests/sneak-into-basket/short_1.png"},
                new() { Id = 70, Description = "Select all characteristics of the \"Sneak into basket\" deceptive pattern?", Hint = "Sneaks products and is not forceful, but nudges.", Difficulty = TestQuestionDifficultyEnum.NORMAL, Type = TestQuestionTypeEnum.MULTI_SELECT, ShortText = null, TestId = 2},
            };

            context.TestQuestions.AddRange(testQuestions);
        }
    }
}
