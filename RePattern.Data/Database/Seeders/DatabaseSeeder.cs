namespace RePattern.Data.Database.Seeders
{
    public static class DatabaseSeeder
    {
        private static readonly IEnumerable<IDataSeeder> Seeders = new List<IDataSeeder>()
        {
            new CategorySeeder()
        };

        public static void Seed(ApplicationDbContext context)
        {
            foreach (var seeder in Seeders)
            {
                seeder.Seed(context);
            }

            context.SaveChanges();
        }
    }
}
