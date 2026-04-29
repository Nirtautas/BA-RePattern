using AutoMapper;
using RePattern.Business.Dtos.Auth;
using RePattern.Business.Dtos.Category;
using RePattern.Data.Identity;
using RePattern.Domain.Entities;

namespace RePattern.Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserResponse>();
            CreateMap<UserRegisterRequest, ApplicationUser>();

            CreateMap<Category, CategoryResponse>();
        }
    }
}
