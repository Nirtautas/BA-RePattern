using AutoMapper;
using RePattern.Business.Dtos.Auth;
using RePattern.Business.Dtos.BadgeAcquisition;
using RePattern.Business.Dtos.Category;
using RePattern.Data.Identity;
using RePattern.Data.Repositories.JoinQueryEntities;
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

            CreateMap<BadgeWithCategoryInfo, BadgeWithCategoryResponse>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Badge.Id))
                .ForMember(dest => dest.Title,
                    opt => opt.MapFrom(src => src.Badge.Title))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.Badge.Description))
                .ForMember(dest => dest.Tier,
                    opt => opt.MapFrom(src => src.Badge.Tier))
                .ForMember(dest => dest.ImageURL,
                    opt => opt.MapFrom(src => src.Badge.ImageURL))
                .ForMember(dest => dest.AcquiredAt,
                    opt => opt.MapFrom(src => src.AcquiredAt))
                .ForMember(dest => dest.CategoryId,
                    opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.IsTrackingGroup,
                    opt => opt.MapFrom(src => src.IsTrackingGroup));
        }
    }
}
