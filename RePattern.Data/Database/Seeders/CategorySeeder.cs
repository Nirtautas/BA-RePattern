using RePattern.Domain.Entities;

namespace RePattern.Data.Database.Seeders
{
    public class CategorySeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            if (context.Categories.Any())
                return;

            var categories = new List<Category>
            {
                new() { Id = 1, Title = "Consumer-centered guidelines", UniquePathFragment = "consumer-centered-guidelines", Order = 1, OnlyTheory = true },
                new() { Id = 2, Title = "Sneak Into Basket", UniquePathFragment = "sneak-into-basket", Order = 2, OnlyTheory = false },
                new() { Id = 3, Title = "Hidden Costs", UniquePathFragment = "hidden-costs", Order = 3, OnlyTheory = false },
                new() { Id = 4, Title = "Hidden Subscription", UniquePathFragment = "hidden-subscription", Order = 4, OnlyTheory = false },
                new() { Id = 5, Title = "Limited Time Message", UniquePathFragment = "limited-time-message", Order = 5, OnlyTheory = false },
                new() { Id = 6, Title = "Confirmshaming", UniquePathFragment = "confirmshaming", Order = 6, OnlyTheory = false },
                new() { Id = 7, Title = "Visual Interference", UniquePathFragment = "visual-interference", Order = 7, OnlyTheory = false },
                new() { Id = 8, Title = "Trick Questions", UniquePathFragment = "trick-questions", Order = 8, OnlyTheory = false },
                new() { Id = 9, Title = "Hard To Cancel", UniquePathFragment = "hard-to-cancel", Order = 9, OnlyTheory = false },
                new() { Id = 10, Title = "Forced Enrollment", UniquePathFragment = "forced-enrollment", Order = 10, OnlyTheory = false },
            };

            context.Categories.AddRange(categories);
        }
    }
}
