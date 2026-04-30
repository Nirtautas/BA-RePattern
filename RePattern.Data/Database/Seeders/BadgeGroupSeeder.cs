using RePattern.Domain.Entities;

namespace RePattern.Data.Database.Seeders
{
    public class BadgeGroupSeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            if (context.BadgeGroups.Any())
                return;

            var badgeGroups = new List<BadgeGroup>
            {
                new() { Id = 1, IsTrackingGroup = true, Title = "Consumer centered guidelines tracking badge group", CategoryId = 1},
                new() { Id = 2, IsTrackingGroup = true, Title = "Sneak Into Basket tracking badge group", CategoryId = 2},
                new() { Id = 3, IsTrackingGroup = true, Title = "Hidden Costs tracking badge group", CategoryId = 3},
                new() { Id = 4, IsTrackingGroup = true, Title = "Hidden Subscription tracking badge group", CategoryId = 4},
                new() { Id = 5, IsTrackingGroup = true, Title = "Limited Time Message tracking badge group", CategoryId = 5},
                new() { Id = 6, IsTrackingGroup = true, Title = "Confirmshaming tracking badge group", CategoryId = 6},
                new() { Id = 7, IsTrackingGroup = true, Title = "Visual Interference tracking badge group", CategoryId = 7},
                new() { Id = 8, IsTrackingGroup = true, Title = "Trick Questions tracking badge group", CategoryId = 8},
                new() { Id = 9, IsTrackingGroup = true, Title = "Hard to Cancel tracking badge group", CategoryId = 9},
                new() { Id = 10, IsTrackingGroup = true, Title = "Forced Enrollment tracking badge", CategoryId = 10},
            };

            context.BadgeGroups.AddRange(badgeGroups);
        }
    }
}
