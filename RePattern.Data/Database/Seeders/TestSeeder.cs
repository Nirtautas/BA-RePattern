using RePattern.Common.Enums;
using RePattern.Domain.Entities;

namespace RePattern.Data.Database.Seeders
{
    public class TestSeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            if (context.Tests.Any())
                return;

            var tests = new List<Test>
            {
                new() { Id = 1, Title = "Periodic test", Type = TestTypeEnum.SPACED, CategoryId = null},
                new() { Id = 2, Title = "Sneak into basket test", Type = TestTypeEnum.CATEGORY, CategoryId = 2},
                new() { Id = 3, Title = "Hidden costs test", Type = TestTypeEnum.CATEGORY, CategoryId = 3},
                new() { Id = 4, Title = "Hidden subscription test", Type = TestTypeEnum.CATEGORY, CategoryId = 4},
                new() { Id = 5, Title = "Limited time message test", Type = TestTypeEnum.CATEGORY, CategoryId = 5},
                new() { Id = 6, Title = "Confirmshaming test", Type = TestTypeEnum.CATEGORY, CategoryId = 6},
                new() { Id = 7, Title = "Visual interference test", Type = TestTypeEnum.CATEGORY, CategoryId = 7},
                new() { Id = 8, Title = "Trick questions test", Type = TestTypeEnum.CATEGORY, CategoryId = 8},
                new() { Id = 9, Title = "Hard to cancel test", Type = TestTypeEnum.CATEGORY, CategoryId = 9},
                new() { Id = 10, Title = "Forced enrollment test", Type = TestTypeEnum.CATEGORY, CategoryId = 10},
            };

            SeederSqlServerHelper.SeedWithIdentityInsert(context, "Test", context.Tests, tests);
        }
    }
}
