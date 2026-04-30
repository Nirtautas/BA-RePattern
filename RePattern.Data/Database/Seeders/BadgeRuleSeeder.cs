using RePattern.Common.Enums;
using RePattern.Domain.Entities;

namespace RePattern.Data.Database.Seeders
{
    public class BadgeRuleSeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            if (context.BadgeRules.Any())
                return;

            var badgeRules = new List<BadgeRule>
            {
                new() { Id = 1, RuleType = BadgeRuleType.CATEGORY_COMPLETE, Threshold = null},
                new() { Id = 2, RuleType = BadgeRuleType.TEST_SCORE_AT_LEAST, Threshold = 0},
                new() { Id = 3, RuleType = BadgeRuleType.TEST_SCORE_AT_LEAST, Threshold = 60},
                new() { Id = 4, RuleType = BadgeRuleType.TEST_SCORE_AT_LEAST, Threshold = 80}
            };

            context.BadgeRules.AddRange(badgeRules);
        }
    }
}
