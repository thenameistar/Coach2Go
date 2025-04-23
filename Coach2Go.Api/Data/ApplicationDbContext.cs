using Microsoft.EntityFrameworkCore;
using Coach2Go.Api.Models;

namespace Coach2Go.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorkoutPlan>().HasData(
                new WorkoutPlan
                {
                    Id = 1,
                    Goal = "Lose Weight",
                    Type = "Bodyweight",
                    Experience = "Beginner",
                    Duration = 20,
                    Intensity = "Low"
                }
            );

            modelBuilder.Entity<WorkoutSession>().HasData(
                new WorkoutSession
                {
                    Id = 1,
                    Title = "Core Burn",
                    Week = 1,
                    WorkoutPlanId = 1
                }
            );

            modelBuilder.Entity<Exercise>().HasData(
                new Exercise
                {
                    Id = 1,
                    Name = "Jumping Jacks",
                    Details = "40 secs",
                    ImagePath = "images/jumping-jack.png",
                    WorkoutSessionId = 1
                },
                new Exercise
                {
                    Id = 2,
                    Name = "Squats",
                    Details = "12 reps",
                    ImagePath = "images/squat.png",
                    WorkoutSessionId = 1
                }
            );
        }
    }
}