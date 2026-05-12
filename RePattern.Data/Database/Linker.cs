using Microsoft.EntityFrameworkCore;
using RePattern.Common.Enums;
using RePattern.Data.Identity;
using RePattern.Domain.Entities;

namespace RePattern.Data.Database
{
    public static class Linker
    {
        public static void LinkAll(ModelBuilder modelBuilder)
        {
            LinkEntities(modelBuilder);
            SetDefaults(modelBuilder);
        }

        private static void LinkEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.UniquePathFragment)
                .IsUnique();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<TestExecution>()
                .WithOne()
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<BadgeAcquisition>()
                .WithOne()
                .HasForeignKey(a => a.UserId)
                .IsRequired();

            modelBuilder.Entity<BadgeGroup>()
                .HasIndex(x => new { x.CategoryId, x.IsTrackingGroup })
                .IsUnique()
                .HasFilter("[IsTrackingGroup] = 1 AND [CategoryId] IS NOT NULL");

            modelBuilder.Entity<QuestionAttempt>()
                .HasOne(x => x.TestQuestion)
                .WithMany(x => x.QuestionAttempts)
                .HasForeignKey(x => x.TestQuestionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TestExecution>()
                .Property(x => x.ScorePercentage)
                .HasPrecision(5, 2);

            modelBuilder.Entity<SelectedAnswers>()
                .HasOne(x => x.QuestionAttempt)
                .WithMany(x => x.SelectedAnswers)
                .HasForeignKey(x => x.QuestionAttemptId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        private static void SetDefaults(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                .Property(q => q.CategoryId)
                .HasDefaultValue(null);

            modelBuilder.Entity<TestQuestion>()
                .Property(q => q.Hint)
                .HasDefaultValue(null);

            modelBuilder.Entity<TestQuestion>()
                .Property(q => q.ImageURL)
                .HasDefaultValue(null);

            modelBuilder.Entity<TestQuestion>()
                .Property(q => q.Difficulty)
                .HasDefaultValue(TestQuestionDifficultyEnum.EASY);

            modelBuilder.Entity<TestQuestion>()
                .Property(q => q.ShortText)
                .HasDefaultValue(null);

            modelBuilder.Entity<Badge>()
                .Property(q => q.ImageURL)
                .HasDefaultValue(null);

            modelBuilder.Entity<BadgeRule>()
                .Property(q => q.Threshold)
                .HasDefaultValue(null);

            modelBuilder.Entity<Category>()
                .Property(q => q.Order)
                .HasDefaultValue(9999);

            modelBuilder.Entity<Category>()
                .Property(q => q.OnlyTheory)
                .HasDefaultValue(false);
        }
    }
}
