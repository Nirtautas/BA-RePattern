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
                new() { Id = 1, BadgeGroupId = 1, BadgeRuleId = 1, Description = "Complete the category", Title = "Completionist badge for Consumer-centered guidelines", Tier = Common.Enums.BadgeTierEnum.NO_TIER, ImageURL="/images/badges/guidelines/notier.png"},
                new() { Id = 2, BadgeGroupId = 2, BadgeRuleId = 2, Description = "Complete the category", Title = "Test badge for Sneak Into Basket", Tier = Common.Enums.BadgeTierEnum.BRONZE, ImageURL="/images/badges/sneak_into_basket/bronze.png"},
                new() { Id = 3, BadgeGroupId = 2, BadgeRuleId = 3, Description = "Complete the category test with a score >= 60%", Title = "Test badge for Sneak Into Basket", Tier = Common.Enums.BadgeTierEnum.SILVER, ImageURL="/images/badges/sneak_into_basket/silver.png"},
                new() { Id = 4, BadgeGroupId = 2, BadgeRuleId = 4, Description = "Complete the category test with a score >= 80%", Title = "Test badge for Sneak Into Basket", Tier = Common.Enums.BadgeTierEnum.GOLD, ImageURL="/images/badges/sneak_into_basket/gold.png"},
                new() { Id = 5, BadgeGroupId = 3, BadgeRuleId = 2, Description = "Complete the category", Title = "Test badge for Hidden Costs", Tier = Common.Enums.BadgeTierEnum.BRONZE, ImageURL="/images/badges/hidden_costs/bronze.png"},
                new() { Id = 6, BadgeGroupId = 3, BadgeRuleId = 3, Description = "Complete the category test with a score >= 60%", Title = "Test badge for Hidden Costs", Tier = Common.Enums.BadgeTierEnum.SILVER, ImageURL="/images/badges/hidden_costs/silver.png"},
                new() { Id = 7, BadgeGroupId = 3, BadgeRuleId = 4, Description = "Complete the category test with a score >= 80%", Title = "Test badge for Hidden Costs", Tier = Common.Enums.BadgeTierEnum.GOLD, ImageURL="/images/badges/hidden_costs/gold.png"},
                new() { Id = 8, BadgeGroupId = 4, BadgeRuleId = 2, Description = "Complete the category", Title = "Test badge for Hidden Subscription", Tier = Common.Enums.BadgeTierEnum.BRONZE, ImageURL="/images/badges/hidden_subscription/bronze.png"},
                new() { Id = 9, BadgeGroupId = 4, BadgeRuleId = 3, Description = "Complete the category test with a score >= 60%", Title = "Test badge for Hidden Subscription", Tier = Common.Enums.BadgeTierEnum.SILVER, ImageURL="/images/badges/hidden_subscription/silver.png"},
                new() { Id = 10, BadgeGroupId = 4, BadgeRuleId = 4, Description = "Complete the category test with a score >= 80%", Title = "Test badge for Hidden Subscription", Tier = Common.Enums.BadgeTierEnum.GOLD, ImageURL="/images/badges/hidden_subscription/gold.png"},
                new() { Id = 11, BadgeGroupId = 5, BadgeRuleId = 2, Description = "Complete the category", Title = "Test badge for Limited Time Message", Tier = Common.Enums.BadgeTierEnum.BRONZE, ImageURL="/images/badges/limited_time_message/bronze.png"},
                new() { Id = 12, BadgeGroupId = 5, BadgeRuleId = 3, Description = "Complete the category test with a score >= 60%", Title = "Test badge for Limited Time Message", Tier = Common.Enums.BadgeTierEnum.SILVER, ImageURL="/images/badges/limited_time_message/silver.png"},
                new() { Id = 13, BadgeGroupId = 5, BadgeRuleId = 4, Description = "Complete the category test with a score >= 80%", Title = "Test badge for Limited Time Message", Tier = Common.Enums.BadgeTierEnum.GOLD, ImageURL="/images/badges/limited_time_message/gold.png"},
                new() { Id = 14, BadgeGroupId = 6, BadgeRuleId = 2, Description = "Complete the category", Title = "Test badge for Confirmshaming", Tier = Common.Enums.BadgeTierEnum.BRONZE, ImageURL="/images/badges/confirmshaming/bronze.png"},
                new() { Id = 15, BadgeGroupId = 6, BadgeRuleId = 3, Description = "Complete the category test with a score >= 60%", Title = "Test badge for Confirmshaming", Tier = Common.Enums.BadgeTierEnum.SILVER, ImageURL="/images/badges/confirmshaming/silver.png"},
                new() { Id = 16, BadgeGroupId = 6, BadgeRuleId = 4, Description = "Complete the category test with a score >= 80%", Title = "Test badge for Confirmshaming", Tier = Common.Enums.BadgeTierEnum.GOLD, ImageURL="/images/badges/confirmshaming/gold.png"},
                new() { Id = 17, BadgeGroupId = 7, BadgeRuleId = 2, Description = "Complete the category", Title = "Test badge for Visual Interference", Tier = Common.Enums.BadgeTierEnum.BRONZE, ImageURL="/images/badges/visual_interference/bronze.png"},
                new() { Id = 18, BadgeGroupId = 7, BadgeRuleId = 3, Description = "Complete the category test with a score >= 60%", Title = "Test badge for Visual Interference", Tier = Common.Enums.BadgeTierEnum.SILVER, ImageURL="/images/badges/visual_interference/silver.png"},
                new() { Id = 19, BadgeGroupId = 7, BadgeRuleId = 4, Description = "Complete the category test with a score >= 80%", Title = "Test badge for Visual Interference", Tier = Common.Enums.BadgeTierEnum.GOLD, ImageURL="/images/badges/visual_interference/gold.png"},
                new() { Id = 20, BadgeGroupId = 8, BadgeRuleId = 2, Description = "Complete the category", Title = "Test badge for Trick Questions", Tier = Common.Enums.BadgeTierEnum.BRONZE, ImageURL="/images/badges/trick_questions/bronze.png"},
                new() { Id = 21, BadgeGroupId = 8, BadgeRuleId = 3, Description = "Complete the category test with a score >= 60%", Title = "Test badge for Trick Questions", Tier = Common.Enums.BadgeTierEnum.SILVER, ImageURL="/images/badges/trick_questions/silver.png"},
                new() { Id = 22, BadgeGroupId = 8, BadgeRuleId = 4, Description = "Complete the category test with a score >= 80%", Title = "Test badge for Trick Questions", Tier = Common.Enums.BadgeTierEnum.GOLD, ImageURL="/images/badges/trick_questions/gold.png"},
                new() { Id = 23, BadgeGroupId = 9, BadgeRuleId = 2, Description = "Complete the category", Title = "Test badge for Hard to Cancel", Tier = Common.Enums.BadgeTierEnum.BRONZE, ImageURL="/images/badges/hard_to_cancel/bronze.png"},
                new() { Id = 24, BadgeGroupId = 9, BadgeRuleId = 3, Description = "Complete the category test with a score >= 60%", Title = "Test badge for Hard to Cancel", Tier = Common.Enums.BadgeTierEnum.SILVER, ImageURL="/images/badges/hard_to_cancel/silver.png"},
                new() { Id = 25, BadgeGroupId = 9, BadgeRuleId = 4, Description = "Complete the category test with a score >= 80%", Title = "Test badge for Hard to Cancel", Tier = Common.Enums.BadgeTierEnum.GOLD, ImageURL="/images/badges/hard_to_cancel/gold.png"},
                new() { Id = 26, BadgeGroupId = 10, BadgeRuleId = 2, Description = "Complete the category", Title = "Test badge for Forced Enrollment", Tier = Common.Enums.BadgeTierEnum.BRONZE, ImageURL="/images/badges/forced_enrollment/bronze.png"},
                new() { Id = 27, BadgeGroupId = 10, BadgeRuleId = 3, Description = "Complete the category test with a score >= 60%", Title = "Test badge for Forced Enrollment", Tier = Common.Enums.BadgeTierEnum.SILVER, ImageURL="/images/badges/forced_enrollment/silver.png"},
                new() { Id = 28, BadgeGroupId = 10, BadgeRuleId = 4, Description = "Complete the category test with a score >= 80%", Title = "Test badge for Forced Enrollment", Tier = Common.Enums.BadgeTierEnum.GOLD, ImageURL="/images/badges/forced_enrollment/gold.png"},
            };

            context.Badges.AddRange(badges);
        }
    }
}
