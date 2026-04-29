using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RePattern.Common.Constants;
using RePattern.Data.Database;
using RePattern.Data.Database.Seeders;
using RePattern.Data.Identity;
using RePattern.Data.Repositories.Concrete;
using RePattern.Data.Repositories.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseConnectionString = Environment.GetEnvironmentVariable("REPATTERN_DATABASE_URL") ?? configuration.GetConnectionString("RePatternDatabaseConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(databaseConnectionString, npgsqlOptionsAction => npgsqlOptionsAction.MigrationsAssembly("RePattern.Data"));
                options.UseSeeding(async (context, hasSchema) =>
                {
                    var appContext = (ApplicationDbContext)context;
                    DatabaseSeeder.Seed(appContext);
                });
            });

            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 4;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = Shared.AlphanumericCharactersAndSymbols;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddDefaultTokenProviders();

            services
                .AddScoped<IAnswerRepository, AnswerRepository>()
                .AddScoped<IBadgeAcquisitionRepository, BadgeAcquisitionRepository>()
                .AddScoped<IBadgeRepository, BadgeRepository>()
                .AddScoped<IBadgeRuleRepository, BadgeRuleRepository>()
                .AddScoped<ITestExecutionRepository, TestExecutionRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IQuestionAttemptRepository, QuestionAttemptRepository>()
                .AddScoped<ISelectedAnswersRepository, SelectedAnswersRepository>()
                .AddScoped<ITestQuestionRepository, TestQuestionRepository>()
                .AddScoped<ITestRepository, TestRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
