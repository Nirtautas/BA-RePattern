using RePattern.Data.Database;
using RePattern.Data.Identity;
using RePattern.Data.Repositories.Base;
using RePattern.Data.Repositories.Interfaces;

namespace RePattern.Data.Repositories.Concrete
{
    public class UserRepository(ApplicationDbContext dbContext) : Repository<ApplicationUser>(dbContext), IUserRepository
    {
    }
}
