using RePattern.Domain.Entities;

namespace RePattern.Data.Database.Seeders
{
    public class BadgeAcquisitionSeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            if (context.BadgeAcquisitions.Any())
                return;

            var badgeAcquisitions = new List<BadgeAcquisition> { };

            SeederSqlServerHelper.SeedWithIdentityInsert(context, "BadgeAcquisition", context.BadgeAcquisitions, badgeAcquisitions);
        }
    }
}
