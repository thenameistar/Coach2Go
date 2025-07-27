using Microsoft.EntityFrameworkCore;
using Coach2Go.Api.Models;
using Microsoft.AspNetCore.Components.Web;

namespace Coach2Go.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GymEquipment> GymEquipment { get; set; }
        public DbSet<DiaryEntry> DiaryEntries { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WorkoutPlan>()
                .HasOne(p => p.User)
                .WithMany(u => u.Plans)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DiaryEntry>()
                .Property(d => d.Goals)
                .HasConversion(
                   v => string.Join("|||", v ?? new List<string>()),
                   v => v.Split("|||", StringSplitOptions.None).ToList()
            );


            modelBuilder.Entity<GymEquipment>().HasData(
                new GymEquipment { Id = 1, GymName = "PureGym", EquipmentName = "Treadmill", ImageUrl = "images/treadmill.png" },
                new GymEquipment { Id = 2, GymName = "PureGym", EquipmentName = "Cross Trainer", ImageUrl = "images/cross_trainer.png" },
                new GymEquipment { Id = 3, GymName = "PureGym", EquipmentName = "Stair Climber", ImageUrl = "images/stair_climber.png" },
                new GymEquipment { Id = 4, GymName = "PureGym", EquipmentName = "Stepper", ImageUrl = "images/stepper.png" },
                new GymEquipment { Id = 5, GymName = "PureGym", EquipmentName = "Exercise Bike", ImageUrl = "images/exercise_bike.png" },
                new GymEquipment { Id = 6, GymName = "PureGym", EquipmentName = "Rowing Machine", ImageUrl = "images/rowing_machine.png" },

                new GymEquipment { Id = 7, GymName = "PureGym", EquipmentName = "Dumbbells", ImageUrl = "images/dumbbells.png" },
                new GymEquipment { Id = 8, GymName = "PureGym", EquipmentName = "Weight Bench", ImageUrl = "images/weight_bench.png" },
                new GymEquipment { Id = 9, GymName = "PureGym", EquipmentName = "Squat Rack", ImageUrl = "images/squat_rack.png" },
                new GymEquipment { Id = 10, GymName = "PureGym", EquipmentName = "Plate-Loaded Machine", ImageUrl = "images/plate_loaded.png" },

                new GymEquipment { Id = 11, GymName = "PureGym", EquipmentName = "Chest Press", ImageUrl = "images/chest_press.png" },
                new GymEquipment { Id = 12, GymName = "PureGym", EquipmentName = "Shoulder Press", ImageUrl = "images/shoulder_press.png" },
                new GymEquipment { Id = 13, GymName = "PureGym", EquipmentName = "Bicep Curl Machine", ImageUrl = "images/bicep_curl.png" },
                new GymEquipment { Id = 14, GymName = "PureGym", EquipmentName = "Lateral Pulldown Machine", ImageUrl = "images/lat_pulldown.png" },
                new GymEquipment { Id = 15, GymName = "PureGym", EquipmentName = "Leg Press", ImageUrl = "images/leg_press.png" },
                new GymEquipment { Id = 16, GymName = "PureGym", EquipmentName = "Ab Machine", ImageUrl = "images/ab_machine.png" },
                new GymEquipment { Id = 17, GymName = "PureGym", EquipmentName = "Multi-Gym Station", ImageUrl = "images/multigym.png" },
                new GymEquipment { Id = 18, GymName = "PureGym", EquipmentName = "Hip Abductor", ImageUrl = "images/hip_abductor.png" },

                new GymEquipment { Id = 19, GymName = "PureGym", EquipmentName = "Kettlebell", ImageUrl = "images/kettlebell.png" },
                new GymEquipment { Id = 20, GymName = "PureGym", EquipmentName = "Medicine Ball", ImageUrl = "images/medicine_ball.png" },
                new GymEquipment { Id = 21, GymName = "PureGym", EquipmentName = "Battle Ropes", ImageUrl = "images/battle_ropes.png" },
                new GymEquipment { Id = 22, GymName = "PureGym", EquipmentName = "TRX", ImageUrl = "images/trx.png" }
            );

            modelBuilder.Entity<GymEquipment>().HasData(
                new GymEquipment { Id = 23, GymName = "JDGym", EquipmentName = "Treadmill", ImageUrl = "images/treadmill.png" },
                new GymEquipment { Id = 24, GymName = "JDGym", EquipmentName = "Cross Trainer", ImageUrl = "images/cross_trainer.png" },
                new GymEquipment { Id = 25, GymName = "JDGym", EquipmentName = "Stair Climber", ImageUrl = "images/stair_climber.png" },
                new GymEquipment { Id = 26, GymName = "JDGym", EquipmentName = "Stepper", ImageUrl = "images/stepper.png" },
                new GymEquipment { Id = 27, GymName = "JDGym", EquipmentName = "Exercise Bike", ImageUrl = "images/exercise_bike.png" },
                new GymEquipment { Id = 28, GymName = "JDGym", EquipmentName = "Rowing Machine", ImageUrl = "images/rowing_machine.png" },

                new GymEquipment { Id = 29, GymName = "JDGym", EquipmentName = "Dumbbells", ImageUrl = "images/dumbbells.png" },
                new GymEquipment { Id = 30, GymName = "JDGym", EquipmentName = "Weight Bench", ImageUrl = "images/weight_bench.png" },
                new GymEquipment { Id = 31, GymName = "JDGym", EquipmentName = "Squat Rack", ImageUrl = "images/squat_rack.png" },
                new GymEquipment { Id = 32, GymName = "JDGym", EquipmentName = "Plate-Loaded Machine", ImageUrl = "images/plate_loaded.png" },

                new GymEquipment { Id = 33, GymName = "JDGym", EquipmentName = "Chest Press", ImageUrl = "images/chest_press.png" },
                new GymEquipment { Id = 34, GymName = "JDGym", EquipmentName = "Shoulder Press", ImageUrl = "images/shoulder_press.png" },
                new GymEquipment { Id = 35, GymName = "JDGym", EquipmentName = "Bicep Curl Machine", ImageUrl = "images/bicep_curl.png" },
                new GymEquipment { Id = 36, GymName = "JDGym", EquipmentName = "Lateral Pulldown Machine", ImageUrl = "images/lat_pulldown.png" },
                new GymEquipment { Id = 37, GymName = "JDGym", EquipmentName = "Leg Press", ImageUrl = "images/leg_press.png" },
                new GymEquipment { Id = 38, GymName = "JDGym", EquipmentName = "Ab Machine", ImageUrl = "images/ab_machine.png" },
                new GymEquipment { Id = 39, GymName = "JDGym", EquipmentName = "Multi-Gym Station", ImageUrl = "images/multigym.png" },
                new GymEquipment { Id = 40, GymName = "JDGym", EquipmentName = "Hip Abductor", ImageUrl = "images/hip_abductor.png" },

                new GymEquipment { Id = 41, GymName = "JDGym", EquipmentName = "Kettlebell", ImageUrl = "images/kettlebell.png" },
                new GymEquipment { Id = 42, GymName = "JDGym", EquipmentName = "Medicine Ball", ImageUrl = "images/medicine_ball.png" },
                new GymEquipment { Id = 43, GymName = "JDGym", EquipmentName = "Battle Ropes", ImageUrl = "images/battle_ropes.png" },
                new GymEquipment { Id = 44, GymName = "JDGym", EquipmentName = "TRX", ImageUrl = "images/trx.png" }
            );
            modelBuilder.Entity<GymEquipment>().HasData(
                new GymEquipment { Id = 45, GymName = "AllamSportCentre", EquipmentName = "Treadmill", ImageUrl = "images/treadmill.png" },
                new GymEquipment { Id = 46, GymName = "AllamSportCentre", EquipmentName = "Cross Trainer", ImageUrl = "images/cross_trainer.png" },
                new GymEquipment { Id = 47, GymName = "AllamSportCentre", EquipmentName = "Stair Climber", ImageUrl = "images/stair_climber.png" },
                new GymEquipment { Id = 48, GymName = "AllamSportCentre", EquipmentName = "Stepper", ImageUrl = "images/stepper.png" },
                new GymEquipment { Id = 49, GymName = "AllamSportCentre", EquipmentName = "Exercise Bike", ImageUrl = "images/exercise_bike.png" },
                new GymEquipment { Id = 50, GymName = "AllamSportCentre", EquipmentName = "Rowing Machine", ImageUrl = "images/rowing_machine.png" },

                new GymEquipment { Id = 51, GymName = "AllamSportCentre", EquipmentName = "Dumbbells", ImageUrl = "images/dumbbells.png" },
                new GymEquipment { Id = 52, GymName = "AllamSportCentre", EquipmentName = "Weight Bench", ImageUrl = "images/weight_bench.png" },
                new GymEquipment { Id = 53, GymName = "AllamSportCentre", EquipmentName = "Squat Rack", ImageUrl = "images/squat_rack.png" },
                new GymEquipment { Id = 54, GymName = "AllamSportCentre", EquipmentName = "Plate-Loaded Machine", ImageUrl = "images/plate_loaded.png" },

                new GymEquipment { Id = 55, GymName = "AllamSportCentre", EquipmentName = "Chest Press", ImageUrl = "images/chest_press.png" },
                new GymEquipment { Id = 56, GymName = "AllamSportCentre", EquipmentName = "Shoulder Press", ImageUrl = "images/shoulder_press.png" },
                new GymEquipment { Id = 57, GymName = "AllamSportCentre", EquipmentName = "Bicep Curl Machine", ImageUrl = "images/bicep_curl.png" },
                new GymEquipment { Id = 58, GymName = "AllamSportCentre", EquipmentName = "Lateral Pulldown Machine", ImageUrl = "images/lat_pulldown.png" },
                new GymEquipment { Id = 59, GymName = "AllamSportCentre", EquipmentName = "Leg Press", ImageUrl = "images/leg_press.png" },
                new GymEquipment { Id = 60, GymName = "AllamSportCentre", EquipmentName = "Ab Machine", ImageUrl = "images/ab_machine.png" },
                new GymEquipment { Id = 61, GymName = "AllamSportCentre", EquipmentName = "Multi-Gym Station", ImageUrl = "images/multigym.png" },
                new GymEquipment { Id = 62, GymName = "AllamSportCentre", EquipmentName = "Hip Abductor", ImageUrl = "images/hip_abductor.png" },

                new GymEquipment { Id = 63, GymName = "AllamSportCentre", EquipmentName = "Kettlebell", ImageUrl = "images/kettlebell.png" },
                new GymEquipment { Id = 64, GymName = "AllamSportCentre", EquipmentName = "Medicine Ball", ImageUrl = "images/medicine_ball.png" },
                new GymEquipment { Id = 65, GymName = "AllamSportCentre", EquipmentName = "Battle Ropes", ImageUrl = "images/battle_ropes.png" },
                new GymEquipment { Id = 66, GymName = "AllamSportCentre", EquipmentName = "TRX", ImageUrl = "images/trx.png" }
            );

        }
        
    }
}