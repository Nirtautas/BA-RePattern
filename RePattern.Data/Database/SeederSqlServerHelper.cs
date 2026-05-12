using Microsoft.EntityFrameworkCore;

namespace RePattern.Data.Database
{
    public static class SeederSqlServerHelper
    {
        public static void SeedWithIdentityInsert<T>(ApplicationDbContext context, string tableName, DbSet<T> dbSet, IEnumerable<T> entities) where T : class
        {
            context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [{tableName}] ON");
            dbSet.AddRange(entities);
            context.SaveChanges();
            context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [{tableName}] OFF");
        }
    }
}
