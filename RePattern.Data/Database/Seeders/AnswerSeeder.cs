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
                new() { Id = 1, Description = "Answer 1", IsCorrect = true, TestQuestionId = 1},
                new() { Id = 2, Description = "Answer 2", IsCorrect = false, TestQuestionId = 1},
                new() { Id = 3, Description = "Answer 3", IsCorrect = true, TestQuestionId = 1},
                new() { Id = 4, Description = "Answer 4", IsCorrect = false, TestQuestionId = 1},

                new() { Id = 5, Description = "Answer 5", IsCorrect = true, TestQuestionId = 2},
                new() { Id = 6, Description = "Answer 6", IsCorrect = true, TestQuestionId = 2},
                new() { Id = 7, Description = "Answer 7", IsCorrect = true, TestQuestionId = 2},
                new() { Id = 8, Description = "Answer 8", IsCorrect = true, TestQuestionId = 2},

                new() { Id = 9, Description = "Answer 9", IsCorrect = true, TestQuestionId = 3},
                new() { Id = 10, Description = "Answer 10", IsCorrect = false, TestQuestionId = 3},
                new() { Id = 11, Description = "Answer 11", IsCorrect = false, TestQuestionId = 3},
                new() { Id = 12, Description = "Answer 12", IsCorrect = false, TestQuestionId = 3},
            };

            context.Answers.AddRange(answers);
        }
    }
}
