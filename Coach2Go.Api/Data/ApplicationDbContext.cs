using Microsoft.EntityFrameworkCore;
using Coach2Go.Api.Models;
using Microsoft.AspNetCore.Components.Web;
using Coach2Go.Api.Migrations;

namespace Coach2Go.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "Ana",
                    Email = "ana@test.com",
                    Goal = "Lose Weight",
                    Type = "Bodyweight",
                    Experience = "Beginner",
                    WorkoutPlanId = 1
                },
                new User
                {
                    Id = 2,
                    Username = "Elijah",
                    Email = "elijah@test.com",
                    Goal = "Strength",
                    Type = "Gym",
                    Experience = "Intermediate",
                    WorkoutPlanId = 2
                },
                new User
                {
                    Id = 3,
                    Username = "Charlie",
                    Email = "charlie@test.com",
                    Goal = "General Fitness",
                    Type = "Bodyweight",
                    Experience = "Beginner",
                    WorkoutPlanId = 3
                },
                new User
                {
                    Id = 4,
                    Username = "Sasha",
                    Email = "sasha@test.com",
                    Goal = "Build Muscle",
                    Type = "Gym",
                    Experience = "Advanced",
                    WorkoutPlanId = 4
                },
                new User
                {
                    Id = 5,
                    Username = "Sham",
                    Email = "sham@test.com",
                    Goal = "Build Muscle",
                    Type = "Gym",
                    Experience = "Beginner",
                    WorkoutPlanId = 5
                },
                new User
                {
                    Id = 6,
                    Username = "Blessing",
                    Email = "blessing@test.com",
                    Goal = "Lose weight",
                    Type = "Gym",
                    Experience = "Beginner",
                    WorkoutPlanId = 6
                }
                );

            modelBuilder.Entity<WorkoutPlan>().HasData(
                new WorkoutPlan
                {
                    Id = 1,
                    Goal = "Lose Weight",
                    Type = "Bodyweight",
                    Experience = "Beginner",
                    Duration = 20,
                    Intensity = "Low"
                },
                new WorkoutPlan
                {
                    Id = 2,
                    Goal = "Strength",
                    Type = "Gym",
                    Experience = "Intermediate",
                    Duration = 40,
                    Intensity = "Medium"
                },
                new WorkoutPlan
                {
                    Id = 3,
                    Goal = "General Fitness",
                    Type = "Bodyweight",
                    Experience = "Beginner",
                    Duration = 30,
                    Intensity = "Low"
                },
                new WorkoutPlan
                {
                    Id = 4,
                    Goal = "Build Muscle",
                    Type = "Gym",
                    Experience = "Advanced",
                    Duration = 50,
                    Intensity = "High"
                },
                new WorkoutPlan
                {
                    Id = 5,
                    Goal = "Build Muscle",
                    Type = "Gym",
                    Experience = "Beginner",
                    Duration = 35,
                    Intensity = "Medium"
                },
                new WorkoutPlan
                {
                    Id = 6,
                    Goal = "Lose Weight",
                    Type = "Gym",
                    Experience = "Beginner",
                    Duration = 30,
                    Intensity = "Low"
                }
            );

            modelBuilder.Entity<WorkoutSession>().HasData(
                new WorkoutSession
                {
                    Id = 1,
                    Title = "Full Body",
                    Week = 1,
                    Day = "Monday",
                    WorkoutPlanId = 1,
                    ImagePath = "images/workout1.jpg",
                    Duration = 30,
                    Category = "Recommended"
                },
                new WorkoutSession
                {
                    Id = 2,
                    Title = "Cardio & Core",
                    Week = 1,
                    Day = "Tuesday",
                    WorkoutPlanId = 1,
                    ImagePath = "images/cardiocore.jpg",
                    Duration = 30,
                    Category = "Popular"
                },
                new WorkoutSession
                {
                    Id = 3,
                    Title = "Active Recovery",
                    Week = 1,
                    Day = "Wednesday",
                    WorkoutPlanId = 1,
                    ImagePath = "images/activerecovery1.jpg",
                    Duration = 20,
                    Category = "Recovery"
                },
                new WorkoutSession
                {
                    Id = 4,
                    Title = "Lower Body",
                    Week = 1,
                    Day = "Thursday",
                    WorkoutPlanId = 1,
                    ImagePath = "images/lowerbody.jpg",
                    Duration = 25
                },
                new WorkoutSession
                {
                    Id = 5,
                    Title = "HIIT",
                    Week = 1,
                    Day = "Friday",
                    WorkoutPlanId = 1,
                    ImagePath = "images/hiit.jpg",
                    Duration = 30
                },
                new WorkoutSession
                {
                    Id = 6,
                    Title = "Yoga",
                    Week = 1,
                    Day = "Saturday",
                    WorkoutPlanId = 1,
                    ImagePath = "images/yoga.jpg",
                    Duration = 20
                },
                new WorkoutSession
                {
                    Id = 7,
                    Title = "Full-Body Blast",
                    Week = 2,
                    Day = "Monday",
                    WorkoutPlanId = 1,
                    ImagePath = "images/fullbodyblast.jpg",
                    Duration = 25
                },
                new WorkoutSession
                {
                    Id = 8,
                    Title = "Core Focus Burn",
                    Week = 2,
                    Day = "Tuesday",
                    WorkoutPlanId = 1,
                    ImagePath = "images/coreburn.jpg",
                    Duration = 25

                },
                new WorkoutSession
                {
                    Id = 9,
                    Title = "Power Core",
                    Week = 3,
                    Day = "Monday",
                    WorkoutPlanId = 1,
                    ImagePath = "images/powercore.jpg",
                    Duration = 30
                },
                new WorkoutSession
                {
                    Id = 10,
                    Title = "Light Flow & Mobility",
                    Week = 3,
                    Day = "Tuesday",
                    WorkoutPlanId = 1,
                    ImagePath = "images/mobility.jpg",
                    Duration = 20
                },
                new WorkoutSession
                {
                    Id = 11,
                    Title = "Strength Circuit",
                    Week = 4,
                    Day = "Monday",
                    WorkoutPlanId = 1,
                    ImagePath = "images/strength.jpg",
                    Duration = 40
                },
                new WorkoutSession
                {
                    Id = 12,
                    Title = "Agility",
                    Week = 4,
                    Day = "Tuesday",
                    WorkoutPlanId = 1,
                    ImagePath = "images/agility.jpg",
                    Duration = 30
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
                },
                 new Exercise
                 {
                     Id = 3,
                     Name = "Push Ups",
                     Details = "10 reps",
                     ImagePath = "images/pushup.png",
                     WorkoutSessionId = 1
                 },
                 new Exercise
                 {
                     Id = 4,
                     Name = "Glute Bridges",
                     Details = "15 reps",
                     ImagePath = "images/glutebridges.png",
                     WorkoutSessionId = 1
                 },
                 new Exercise
                 {
                     Id = 5,
                     Name = "Plank",
                     Details = "1 min",
                     ImagePath = "images/plank.png",
                     WorkoutSessionId = 1
                 }
            );
        }
    }
}