using RePattern.Domain.Entities;

namespace RePattern.Data.Database.Seeders
{
    //REMOVE LATER!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public class BadgeAcquisitionSeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            if (context.BadgeAcquisitions.Any())
                return;

            var badgeAcquisitions = new List<BadgeAcquisition>
            {
                new() { BadgeId = 1, UserId = 1, AcquiredAt = DateTime.UtcNow},
                new() { BadgeId = 2, UserId = 1, AcquiredAt = DateTime.UtcNow},
                new() { BadgeId = 3, UserId = 1, AcquiredAt = DateTime.UtcNow},
                new() { BadgeId = 5, UserId = 1, AcquiredAt = DateTime.UtcNow},
                new() { BadgeId = 6, UserId = 1, AcquiredAt = DateTime.UtcNow},
                new() { BadgeId = 7, UserId = 1, AcquiredAt = DateTime.UtcNow},
                new() { BadgeId = 8, UserId = 1, AcquiredAt = DateTime.UtcNow},
            };

            context.BadgeAcquisitions.AddRange(badgeAcquisitions);
        }
    }
}
