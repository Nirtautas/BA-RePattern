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
            modelBuilder.Entity<ApplicationUser>()
                .HasMany<TestExecution>()
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<BadgeAcquisition>()
                .WithOne()
                .HasForeignKey(a => a.UserId)
                .IsRequired();
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

            modelBuilder.Entity<Answer>()
                .Property(q => q.ShortText)
                .HasDefaultValue(null);

            modelBuilder.Entity<Badge>()
                .Property(q => q.ImageURL)
                .HasDefaultValue(null);

            modelBuilder.Entity<Badge>()
                .Property(q => q.CategoryId)
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
