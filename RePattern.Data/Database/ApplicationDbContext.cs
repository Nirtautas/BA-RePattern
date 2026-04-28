using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RePattern.Data.Identity;
using RePattern.Domain.Entities;

namespace RePattern.Data.Database
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser, ApplicationRole, int>(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TestExecution> TestExecutions { get; set; }
        public DbSet<QuestionAttempt> QuestionAttempts { get; set; }
        public DbSet<SelectedAnswers> SelectedAnswers { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<BadgeRule> BadgeRules { get; set; }
        public DbSet<BadgeAcquisition> BadgeAcquisitions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Linker.LinkAll(builder);
            base.OnModelCreating(builder);
        }
    }
}
