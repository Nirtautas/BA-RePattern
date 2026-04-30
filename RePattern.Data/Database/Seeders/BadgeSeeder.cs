using RePattern.Domain.Entities;

namespace RePattern.Data.Database.Seeders
{
    public class BadgeSeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            if (context.Badges.Any())
                return;

            var badges = new List<Badge>
            {
                new() { Id = 1, BadgeGroupId = 1, BadgeRuleId = 1, Title = "Completionist badge for Consumer-centered guidelines", Tier = Common.Enums.BadgeTierEnum.NO_TIER},
                new() { Id = 2, BadgeGroupId = 2, BadgeRuleId = 2, Title = "Test badge for Sneak Into Basket", Tier = Common.Enums.BadgeTierEnum.BRONZE},
                new() { Id = 3, BadgeGroupId = 2, BadgeRuleId = 3, Title = "Test badge for Sneak Into Basket", Tier = Common.Enums.BadgeTierEnum.SILVER},
                new() { Id = 4, BadgeGroupId = 2, BadgeRuleId = 4, Title = "Test badge for Sneak Into Basket", Tier = Common.Enums.BadgeTierEnum.GOLD},
                new() { Id = 5, BadgeGroupId = 3, BadgeRuleId = 2, Title = "Test badge for Hidden Costs", Tier = Common.Enums.BadgeTierEnum.BRONZE},
                new() { Id = 6, BadgeGroupId = 3, BadgeRuleId = 3, Title = "Test badge for Hidden Costs", Tier = Common.Enums.BadgeTierEnum.SILVER},
                new() { Id = 7, BadgeGroupId = 3, BadgeRuleId = 4, Title = "Test badge for Hidden Costs", Tier = Common.Enums.BadgeTierEnum.GOLD},
                new() { Id = 8, BadgeGroupId = 4, BadgeRuleId = 2, Title = "Test badge for Hidden Subscription", Tier = Common.Enums.BadgeTierEnum.BRONZE},
                new() { Id = 9, BadgeGroupId = 4, BadgeRuleId = 3, Title = "Test badge for Hidden Subscription", Tier = Common.Enums.BadgeTierEnum.SILVER},
                new() { Id = 10, BadgeGroupId = 4, BadgeRuleId = 4, Title = "Test badge for Hidden Subscription", Tier = Common.Enums.BadgeTierEnum.GOLD},
                new() { Id = 11, BadgeGroupId = 5, BadgeRuleId = 2, Title = "Test badge for Limited Time Message", Tier = Common.Enums.BadgeTierEnum.BRONZE},
                new() { Id = 12, BadgeGroupId = 5, BadgeRuleId = 3, Title = "Test badge for Limited Time Message", Tier = Common.Enums.BadgeTierEnum.SILVER},
                new() { Id = 13, BadgeGroupId = 5, BadgeRuleId = 4, Title = "Test badge for Limited Time Message", Tier = Common.Enums.BadgeTierEnum.GOLD},
                new() { Id = 14, BadgeGroupId = 6, BadgeRuleId = 2, Title = "Test badge for Confirmshaming", Tier = Common.Enums.BadgeTierEnum.BRONZE},
                new() { Id = 15, BadgeGroupId = 6, BadgeRuleId = 3, Title = "Test badge for Confirmshaming", Tier = Common.Enums.BadgeTierEnum.SILVER},
                new() { Id = 16, BadgeGroupId = 6, BadgeRuleId = 4, Title = "Test badge for Confirmshaming", Tier = Common.Enums.BadgeTierEnum.GOLD},
                new() { Id = 17, BadgeGroupId = 7, BadgeRuleId = 2, Title = "Test badge for Visual Interference", Tier = Common.Enums.BadgeTierEnum.BRONZE},
                new() { Id = 18, BadgeGroupId = 7, BadgeRuleId = 3, Title = "Test badge for Visual Interference", Tier = Common.Enums.BadgeTierEnum.SILVER},
                new() { Id = 19, BadgeGroupId = 7, BadgeRuleId = 4, Title = "Test badge for Visual Interference", Tier = Common.Enums.BadgeTierEnum.GOLD},
                new() { Id = 20, BadgeGroupId = 8, BadgeRuleId = 2, Title = "Test badge for Trick Questions", Tier = Common.Enums.BadgeTierEnum.BRONZE},
                new() { Id = 21, BadgeGroupId = 8, BadgeRuleId = 3, Title = "Test badge for Trick Questions", Tier = Common.Enums.BadgeTierEnum.SILVER},
                new() { Id = 22, BadgeGroupId = 8, BadgeRuleId = 4, Title = "Test badge for Trick Questions", Tier = Common.Enums.BadgeTierEnum.GOLD},
                new() { Id = 23, BadgeGroupId = 9, BadgeRuleId = 2, Title = "Test badge for Hard to Cancel", Tier = Common.Enums.BadgeTierEnum.BRONZE},
                new() { Id = 24, BadgeGroupId = 9, BadgeRuleId = 3, Title = "Test badge for Hard to Cancel", Tier = Common.Enums.BadgeTierEnum.SILVER},
                new() { Id = 25, BadgeGroupId = 9, BadgeRuleId = 4, Title = "Test badge for Hard to Cancel", Tier = Common.Enums.BadgeTierEnum.GOLD},
                new() { Id = 26, BadgeGroupId = 10, BadgeRuleId = 2, Title = "Test badge for Forced Enrollment", Tier = Common.Enums.BadgeTierEnum.BRONZE},
                new() { Id = 27, BadgeGroupId = 10, BadgeRuleId = 3, Title = "Test badge for Forced Enrollment", Tier = Common.Enums.BadgeTierEnum.SILVER},
                new() { Id = 28, BadgeGroupId = 10, BadgeRuleId = 4, Title = "Test badge for Forced Enrollment", Tier = Common.Enums.BadgeTierEnum.GOLD},
            };

            context.Badges.AddRange(badges);
        }
    }
}
