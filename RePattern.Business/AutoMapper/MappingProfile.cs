using AutoMapper;
using RePattern.Business.Dtos.Auth;
using RePattern.Business.Dtos.BadgeAcquisition;
using RePattern.Business.Dtos.Category;
using RePattern.Business.Dtos.Test;
using RePattern.Business.Dtos.TestExecution;
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

            CreateMap<Badge, BadgeResponse>();

            CreateMap<Test, TestTakingResponse>();
            CreateMap<TestQuestion, TestQuestionTakingResponse>();
            CreateMap<Answer, AnswerTakingResponse>();

            CreateMap<TestExecution, TestExecutionResponse>();

            CreateMap<TestExecution, TestExecutionReviewResponse>();

            CreateMap<QuestionAttempt, QuestionAttemptReviewResponse>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.TestQuestion.Id)
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.TestQuestion.Description)
                )
                .ForMember(
                    dest => dest.CorrectShortText,
                    opt => opt.MapFrom(src => src.TestQuestion.ShortText)
                )
                .ForMember(
                    dest => dest.Explanation,
                    opt => opt.MapFrom(src => src.TestQuestion.Explanation)
                )
                .ForMember(
                    dest => dest.Difficulty,
                    opt => opt.MapFrom(src => src.TestQuestion.Difficulty)
                )
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(src => src.TestQuestion.Type)
                )
                .ForMember(
                    dest => dest.ImageUrl,
                    opt => opt.MapFrom(src => src.TestQuestion.ImageURL)
                ).ForMember(
                    dest => dest.Answers,
                    opt => opt.MapFrom(src => src.TestQuestion.Answers)
                );

            CreateMap<Answer, AnswerReviewResponse>()
                .ForMember(
                    dest => dest.WasSelectedByUser,
                    opt => opt.Ignore()
                );
        }
    }
}
