using RePattern.Domain.Entities;

namespace RePattern.Data.Database.Seeders
{
    public class AnswerSeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            if (context.Answers.Any())
                return;

            var answers = new List<Answer>
            {
                //Sneak into basket
                new() { Id = 10, Description = "True", IsCorrect = true, TestQuestionId = 10},
                new() { Id = 20, Description = "False", IsCorrect = false, TestQuestionId = 10},

                new() { Id = 30, Description = "True", IsCorrect = false, TestQuestionId = 20},
                new() { Id = 40, Description = "False", IsCorrect = true, TestQuestionId = 20},

                new() { Id = 50, Description = "True", IsCorrect = false, TestQuestionId = 30},
                new() { Id = 60, Description = "False", IsCorrect = true, TestQuestionId = 30},

                new() { Id = 70, Description = "Number 1", IsCorrect = false, TestQuestionId = 40},
                new() { Id = 80, Description = "Number 2", IsCorrect = false, TestQuestionId = 40},
                new() { Id = 90, Description = "Number 3", IsCorrect = false, TestQuestionId = 40},
                new() { Id = 100, Description = "Number 4", IsCorrect = true, TestQuestionId = 40},

                new() { Id = 110, Description = "Yes", IsCorrect = false, TestQuestionId = 50},
                new() { Id = 120, Description = "No", IsCorrect = true, TestQuestionId = 50},

                new() { Id = 130, Description = "Is sneaky in nature", IsCorrect = true, TestQuestionId = 70},
                new() { Id = 140, Description = "Urges you to buy something", IsCorrect = false, TestQuestionId = 70},
                new() { Id = 150, Description = "Uses preselection", IsCorrect = true, TestQuestionId = 70},
                new() { Id = 160, Description = "Forces to disclose personal data", IsCorrect = false, TestQuestionId = 70},
            };

            context.Answers.AddRange(answers);
        }
    }
}
