using RePattern.Data.Database;
using RePattern.Data.Repositories.Base;
using RePattern.Data.Repositories.Interfaces;
using RePattern.Domain.Entities;

namespace RePattern.Data.Repositories.Concrete
{
    public class BadgeRepository(ApplicationDbContext dbContext) : Repository<Badge>(dbContext), IBadgeRepository
    {
    }
}
