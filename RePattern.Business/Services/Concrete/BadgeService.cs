using AutoMapper;
using RePattern.Business.Services.Interfaces;
using RePattern.Data.Repositories.Interfaces;

namespace RePattern.Business.Services.Concrete
{
    public class BadgeService(IUnitOfWork unitOfWork, IMapper mapper) : IBadgeService
    {
    }
}
